using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VienHoa.Common;
using VienHoa.DataEx;
using VienHoa.Dtos;
using VienHoa.Entity;
using VienHoa.IService;
using VienHoa.Service;

namespace VienHoa.View
{
    public partial class GayNongLenToanCauUpdate : DevExpress.XtraEditors.XtraForm
    {
        //private readonly IGayNongLenToanCauService gayNongLenToanCauService;
        private readonly IRepository<KhiPhatThai> khiPhatThaiRepos;
        private bool isValid;
        private GayNongLenToanCau updateGayNongLenToanCau;
        public GayNongLenToanCau UpdateGayNongLenToanCau
        {
            get
            {
                return updateGayNongLenToanCau;
            }
        }
        public GayNongLenToanCauUpdate(GayNongLenToanCau selectGayNongLenToanCau)
        {
            //gayNongLenToanCauService = new GayNongLenToanCauService();
            khiPhatThaiRepos = new ExRepository<KhiPhatThai>();
            updateGayNongLenToanCau = selectGayNongLenToanCau;
            InitializeComponent();
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn sửa gây nòng lên toàn cầu?", "Xác nhận!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    updateGayNongLenToanCau.KhiPhatThaiId = ((ItemKhiPhatThai)cbbKhiPhatThai.SelectedItem).Id;
                    updateGayNongLenToanCau.GiaTri = double.Parse(txtGiaTri.Text);
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void GayNongLenToanCauUpdate_Load(object sender, EventArgs e)
        {
            var lstKhiPhatThai = khiPhatThaiRepos.TableUntracked.ToList();
            foreach (KhiPhatThai khiPhatThai in lstKhiPhatThai)
            {
                cbbKhiPhatThai.Properties.Items.Add(new ItemKhiPhatThai { Id = khiPhatThai.Id, TenKhi = khiPhatThai.TenKhi });
            }
            txtGiaTri.Text = updateGayNongLenToanCau.GiaTri.ToString();
            foreach (ItemKhiPhatThai item in cbbKhiPhatThai.Properties.Items)
            {
                if (item.Id == updateGayNongLenToanCau.KhiPhatThaiId)
                {
                    // Chọn mục có giá trị Id phù hợp bằng cách gán EditValue
                    cbbKhiPhatThai.EditValue = item;
                    break; // Dừng vòng lặp sau khi tìm thấy và chọn mục
                }
            }
            this.ActiveControl = null;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}