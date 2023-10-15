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
    public partial class FromSuaDoanhNghiep : DevExpress.XtraEditors.XtraForm
    {
        private bool isValid = true;
        private DoanhNghiep doanhNghiep;
        private readonly IQLDoanhNghiep qLDoanhNghiep;

        public FromSuaDoanhNghiep(DoanhNghiep doanhNghiep)
        {
            InitializeComponent();
            this.doanhNghiep = doanhNghiep;
            qLDoanhNghiep = new QLDoanhNghiepServices();
            this.Load += FromSuaDoanhNghiep_Load;
        }

        private async void simpleButton1_Click(object sender, EventArgs e)
        {
            if (doanhNghiep != null)
            {
                bool canUpdate = CheckFieldsNotEmpty();
                if (canUpdate)
                {
                    await UpdateDoanhNghiepAsync();
                    ShowSuccessMessageAndCloseForm();
                }

            }
            else
            {
                MessageBox.Show("Không thể cập nhật dữ liệu doanh nghiệp vì đối tượng doanh nghiệp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CheckFieldsNotEmpty()
        {
            bool fieldsAreValid = true;

            if (string.IsNullOrEmpty(textName.Text.Trim()) || string.IsNullOrEmpty(textDT.Text.Trim()) ||
                string.IsNullOrEmpty(textDC.Text.Trim()) || string.IsNullOrEmpty(textLH.Text.Trim()) || string.IsNullOrEmpty(textQuocGia.Text.Trim())) //tring.IsNullOrEmpty(textQuocGia.Text.Trim())
            {
                fieldsAreValid = false;
                CheckDoanhNghiepInfo();
            }
            CheckDoanhNghiepInfo();
            return fieldsAreValid;
        }
        private void CheckDoanhNghiepInfo()
        {
            isValid = true;

            if (string.IsNullOrEmpty(textName.Text.Trim()))
            {
                lbName.Text = "Nhập lại tên công ty";
                isValid = false;
            }
            else
            {
                lbName.Text = "";
                isValid = true;
            }

            if (string.IsNullOrEmpty(textDC.Text.Trim()))
            {
                lbDC.Text = "Nhập lại địa chỉ";
                isValid = false;
            }
            else
            {
                lbDC.Text = "";
                isValid = true;

            }

            if (string.IsNullOrEmpty(textDT.Text.Trim()))
            {
                lbDT.Text = "Nhập lại điện thoại";
                isValid = false;
            }
            else
            {
                lbDT.Text = "";
                isValid = true;

            }

            if (string.IsNullOrEmpty(textLH.Text.Trim()))
            {
                lbLH.Text = "Nhập lại liên hệ";
                isValid = false;
            }
            else
            {
                lbLH.Text = "";
                isValid = true;

            }

            if (string.IsNullOrEmpty(textQuocGia.Text.Trim()))
            {
                lbQuocGia.Text = "Nhập lại quốc gia";
                isValid = false;
            }
            else
            {
                lbQuocGia.Text = "";
                isValid = true;

            }

            if (!isValid)
            {
                return;
            }
        }
        private async Task UpdateDoanhNghiepAsync()
        {
            if (doanhNghiep != null)
            {
                if (isValid)
                {
                    doanhNghiep.TenCongTy = textName.Text.Trim();
                    doanhNghiep.DiaChi = textDC.Text.Trim();
                    doanhNghiep.DienThoai = textDT.Text.Trim();
                    doanhNghiep.NguoiLienHe = textLH.Text.Trim();
                    doanhNghiep.QuocGia = textQuocGia.Text.Trim();
                    await qLDoanhNghiep.UpdateDoanhNghiep(doanhNghiep);
                }
            }
        }

        private void ShowSuccessMessageAndCloseForm()
        {
            MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void FromSuaDoanhNghiep_Load(object sender, EventArgs e)
        {
            if (doanhNghiep != null)
            {
                textName.Text = doanhNghiep.TenCongTy;
                textDC.Text = doanhNghiep.DiaChi;
                textDT.Text = doanhNghiep.DienThoai;
                textLH.Text = doanhNghiep.NguoiLienHe;
                textQuocGia.Text = doanhNghiep.QuocGia;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
