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
using VienHoa.Common;
using VienHoa.DataEx;
using VienHoa.Entity;
using VienHoa.Enums;
using VienHoa.IService;
using VienHoa.Service;

namespace VienHoa.View
{
    public partial class FormThemDoanhNghiep : DevExpress.XtraEditors.XtraForm
    {
        private readonly IQLDoanhNghiep qLDoanhNghiep;
        private FormFluentThemDoanhNghiep parentForm;
        private XtraForm parentForm2;
        private bool closeForm;

        public FormThemDoanhNghiep(FormFluentThemDoanhNghiep parent)
        {
            InitializeComponent();
            qLDoanhNghiep = new QLDoanhNghiepServices();
            parentForm = parent;
        }
        public FormThemDoanhNghiep(XtraForm parent, bool CloseForm = true)
        {
            InitializeComponent();
            qLDoanhNghiep = new QLDoanhNghiepServices();
            parentForm2 = parent;
        }
        #region Thêm
        //thêm
        //gọi thằng function add
        private async void simpleButton1_Click(object sender, EventArgs e)
        {
            string name = textName.Text.Trim();
            string addRess = textAddress.Text.Trim();
            string phoneNumber = textPhone.Text.Trim();
            string conTact = textLH.Text.Trim();
            string quocGia = textQuocGia.Text.Trim();
            await ThemDoanhNghiep(name, addRess, phoneNumber, conTact, quocGia);

        }
        //khởi tạo function add
        private async Task ThemDoanhNghiep(string name, string addRess, string phoneNumber, string conTact, string quocGia)
        {
            // Đặt lại nội dung và ẩn label lỗi ban đầu

            bool isValid = true;

            if (string.IsNullOrEmpty(name))
            {
                lbTCT.Text = "Nhập lại tên công ty";
                isValid = false;
            }
            else
            {
                lbTCT.Text = "";
                isValid = true;

            }

            if (string.IsNullOrEmpty(addRess))
            {
                lbDC.Text = "Nhập lại địa chỉ";
                isValid = false;
            }
            else
            {
                lbDC.Text = "";
                isValid = true;

            }

            if (string.IsNullOrEmpty(phoneNumber))
            {
                lbDT.Text = "Nhập lại điện thoại";
                isValid = false;
            }
            else
            {
                lbDT.Text = "";
                isValid = true;

            }

            if (string.IsNullOrEmpty(conTact))
            {
                lbNLH.Text = "Nhập lại liên hệ";
                isValid = false;
            }
            else
            {
                lbNLH.Text = "";
                isValid = true;

            }
            if (string.IsNullOrEmpty(quocGia))
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

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thêm doanh nghiệp?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                DoanhNghiep doanhNghiep = new DoanhNghiep();
                doanhNghiep.TenCongTy = name;
                doanhNghiep.DiaChi = addRess;
                doanhNghiep.DienThoai = phoneNumber;
                doanhNghiep.NguoiLienHe = conTact;
                doanhNghiep.QuocGia = quocGia;
                var addResult = await qLDoanhNghiep.AddDoanhNgiep(doanhNghiep);

                if (addResult == InputHellperDoanhNghiep.thieuThongTin)
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (addResult == InputHellperDoanhNghiep.thanhCong)
                {
                    MessageBox.Show("Thêm doanh nghiệp thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Xóa nội dung các trường văn bản sau khi thêm thành công
                    textName.Text = "";
                    textAddress.Text = "";
                    textLH.Text = "";
                    textPhone.Text = "";
                    textQuocGia.Text = "";
                    // Ẩn các label lỗi
                    lbTCT.Text = "";
                    lbDC.Text = "";
                    lbDT.Text = "";
                    lbNLH.Text = "";
                    lbQuocGia.Text = "";
                    if (parentForm2 == null && !closeForm)
                    {
                        this.Close();
                        parentForm.Close();
                    }
                    //doanhNghiep1.Loaddata();
                }
                else if (addResult == InputHellperDoanhNghiep.thatBai)
                {
                    MessageBox.Show("Thêm doanh nghiệp thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (parentForm2 == null && !closeForm)
            {
                this.Close();
                parentForm.Close();
            }
        }
    }
}