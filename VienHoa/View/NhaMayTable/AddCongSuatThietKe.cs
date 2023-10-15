using DevExpress.Pdf.Native;
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
using VienHoa.Service;

namespace VienHoa.View.NhaMayTable
{
    public partial class AddCongSuatThietKe : DevExpress.XtraEditors.XtraForm
    {
        private XtraForm currForm;
        private bool closeForm;
        private CongSuatThietKeService CongSuatThietKe_;
        private double CongSuatInit;

        public AddCongSuatThietKe(XtraForm paForm, bool closeForm = true)
        {
            InitializeComponent();
            CongSuatThietKe_ = new CongSuatThietKeService();
            currForm = paForm;
            this.closeForm = closeForm;
        }
        private bool ValidateInput()
        {
            bool check = true;
            if (string.IsNullOrWhiteSpace(CongSuatTK.Text))
            {
                errCSTK.Text = "Trường này không được để trống";
                errCSTK.Visible = true;
                errCSTK.Focus();
                check = false;
            }
            else
            {
                errCSTK.Visible = false;
            }
            if (string.IsNullOrWhiteSpace(DonVi.Text))
            {
                errDVCS.Text = "Trường này không được để trống";
                errDVCS.Visible = true;
                errDVCS.Focus();
                check = false;
            }
            else
            {
                errDVCS.Visible = false;
            }
            return check;
        }
        private async void ConfirmOK_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                DialogResult res =
                        MessageBox.Show("Bạn có đồng ý thêm dữ liệu Công Suất Thiết Kế không?", "Xác nhận",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (res == DialogResult.OK)
                {
                    if (double.TryParse(CongSuatTK.Text, out CongSuatInit))
                    {
                        // Gathering data:
                        CongSuatThietKe congSuat = new CongSuatThietKe()
                        {
                            CongSuatDinhMuc = CongSuatInit,
                            DonViCongSuat = DonVi.Text
                        };
                        // Add data
                        await CongSuatThietKe_.AddAsync(congSuat);
                        if (closeForm)
                        {
                            currForm.Close();
                        }
                    }
                }
            }
        }

        private void ConfirmCancel_Click(object sender, EventArgs e)
        {
            currForm.Close();
        }
    }
}