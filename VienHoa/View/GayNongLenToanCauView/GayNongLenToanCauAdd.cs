using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VienHoa.Dtos;
using VienHoa.Entity;
using VienHoa.IService;
using VienHoa.Service;

namespace VienHoa.View
{
    public partial class GayNongLenToanCauAdd : DevExpress.XtraEditors.XtraForm
    {
        private readonly IGayNongLenToanCau gayNongLenToanCauService;
        private GayNongLenToanCau addGayNongLenToanCau;
        private bool isValid;
        private bool closeForm;
        private XtraForm parentForm;
        public GayNongLenToanCauAdd(XtraForm ParentForm, bool CloseForm = true)
        {
            gayNongLenToanCauService = new GayNongLenToanCauService();
            InitializeComponent();
            parentForm = ParentForm;
            closeForm = CloseForm;
        }


        private bool ValidateInput()
        {
            isValid = true;
            if (string.IsNullOrWhiteSpace(cbbKhiPhatThai.Text))
            {
                errorKhiPhatThai.Text = "Khí phát thải chưa được chọn";
                errorKhiPhatThai.Visible = true;
                isValid = false;
            }
            else
            {
                errorKhiPhatThai.Visible = false;
            }
            if (!double.TryParse(txtGiaTri.Text, out double giatri) || giatri <= 0)
            {
                errorGiaTri.Text = "Giá trị không hợp lệ";
                errorGiaTri.Visible = true;
                isValid = false;
            }
            else
            {
                errorGiaTri.Visible = false;
            }
            return isValid;
        }

        private async void GayNongLenToanCauAdd_Load(object sender, EventArgs e)
        {
            var lstKhiPhatThai = await gayNongLenToanCauService.ListKhiPhatThai();
            foreach (KhiPhatThai khiPhatThai in lstKhiPhatThai)
            {
                cbbKhiPhatThai.Properties.Items.Add(new ItemKhiPhatThai { Id = khiPhatThai.Id, TenKhi = khiPhatThai.TenKhi });
            }
            addGayNongLenToanCau = new GayNongLenToanCau();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                if (MessageBox.Show("Bạn có đồng ý thêm dữ liệu gây nóng lên toàn cầu?", "Xác nhận!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    addGayNongLenToanCau.KhiPhatThaiId = ((ItemKhiPhatThai)cbbKhiPhatThai.SelectedItem).Id;
                    addGayNongLenToanCau.GiaTri = double.Parse(txtGiaTri.Text);
                    var res = await gayNongLenToanCauService.AddAsync(addGayNongLenToanCau);
                    if (!res.Error)
                    {
                        MessageBox.Show(res.Message, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (closeForm)
                        {
                            parentForm.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show(res.Message, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            parentForm.Close();
        }
    }
}