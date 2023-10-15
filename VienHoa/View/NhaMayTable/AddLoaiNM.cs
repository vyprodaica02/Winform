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
using VienHoa.Entity;
using VienHoa.Service;

namespace VienHoa.View.NhaMayTable
{
    public partial class AddLoaiNM : DevExpress.XtraEditors.XtraForm
    {
        private LoaiNhaMayService LoaiNhaMayService;
        private XtraForm parentForm;
        private bool closeForm;
        public AddLoaiNM(XtraForm parentForm, bool closeForm = true)
        {
            InitializeComponent();
            LoaiNhaMayService = new LoaiNhaMayService();
            this.parentForm = parentForm;
            this.closeForm = closeForm;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(TenLoaiNm.Text))
            {
                errorType.Text = "Trường này không được để trống";
                errorType.Visible = true;
                errorType.Focus();
                return false;
            }
            else
            {
                errorType.Visible = false;
                return true;
            }
        }

        private async void ConfirmOK_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                DialogResult res =
                    MessageBox.Show("Bạn có đồng ý thêm dữ liệu Loại Nhà Máy?", "Xác nhận",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (res == DialogResult.OK)
                {
                    // Retrive data:
                    LoaiNhaMay Lmn = new LoaiNhaMay();
                    Lmn.TenLoai = TenLoaiNm.Text;
                    // ADD:
                    await LoaiNhaMayService.AddAsync(Lmn);
                    if (closeForm)
                    {
                        parentForm.Close();
                    }
                }
            }

        }
        private void ConfirmCancel_Click(object sender, EventArgs e)
        {
            parentForm.Close();
        }
    }
}