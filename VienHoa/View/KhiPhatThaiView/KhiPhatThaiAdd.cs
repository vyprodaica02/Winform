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
using VienHoa.Entity;
using VienHoa.IService;
using VienHoa.Service;

namespace VienHoa.View
{
    public partial class KhiPhatThaiAdd : DevExpress.XtraEditors.XtraForm
    {
        private readonly IKhiPhatThai khiPhatThaiService;
        private KhiPhatThai addKhiPhatThai;
        private bool closeForm;
        private XtraForm parentForm;
        public KhiPhatThaiAdd(XtraForm ParentForm, bool CloseForm = true)
        {
            khiPhatThaiService = new KhiPhatThaiService();
            InitializeComponent();
            addKhiPhatThai = new KhiPhatThai();
            parentForm = ParentForm;
            closeForm = CloseForm;
        }
        bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTenKhi.Text))
            {
                errorTenKhi.Text = "Tên không hợp lệ";
                errorTenKhi.Visible = true;
                errorTenKhi.Focus();
                return false;
            }
            else
            {
                errorTenKhi.Visible = false;
            }
            return true;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                if (MessageBox.Show("Bạn có đồng ý thêm dữ liệu khí phát thải?", "Xác nhận!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    addKhiPhatThai.TenKhi = txtTenKhi.Text.Trim();
                    var res = await khiPhatThaiService.AddAsync(addKhiPhatThai);
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