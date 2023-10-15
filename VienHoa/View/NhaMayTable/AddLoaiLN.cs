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
    public partial class AddLoaiLN : DevExpress.XtraEditors.XtraForm
    {
        private LoaiLoNungService loaiLoNungService;
        private bool closeform;
        private XtraForm parentForm;
        public AddLoaiLN(XtraForm ParentForm, bool CloseForm = true)
        {
            InitializeComponent();
            loaiLoNungService = new LoaiLoNungService();
            parentForm = ParentForm;
            closeform = CloseForm;
        }
        private bool ValidateInput()
        {
            bool check = true;
            if (string.IsNullOrWhiteSpace(TenLoaiLn.Text))
            {
                errLoaiLN.Text = "Trường này không được để trống";
                errLoaiLN.Visible = true;
                errLoaiLN.Focus();
                check = false;
            }
            else
            {
                errLoaiLN.Visible = false;
            }
            return check;
        }

        private async void ConfirmOK_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                DialogResult res =
                        MessageBox.Show("Bạn có đồng ý thêm dữ liệu Loại Lò Nung không?", "Xác nhận",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (res == DialogResult.OK)
                {
                    // Gathering data
                    LoaiLoNung Lnn = new LoaiLoNung();
                    Lnn.TenLoaiLo = TenLoaiLn.Text;
                    // Add data:
                    await loaiLoNungService.AddAsync(Lnn);

                    if (closeform)
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