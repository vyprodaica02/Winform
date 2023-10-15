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

namespace VienHoa.View.NguyenLieuView
{
    public partial class FormDonViDo : DevExpress.XtraEditors.XtraForm
    {
        private IDonViDo _donViDo;
        private XtraForm parentFormFluent1;
        private bool isCloseParentForm1;
        public FormDonViDo()
        {
            InitializeComponent();
            lb_tdv.Visible = false;
            _donViDo = new DonViDoService();
        }
        public FormDonViDo(XtraForm parentFormFluent, bool isCloseParentForm = false)
        {
            InitializeComponent();
            lb_tdv.Visible = false;
            _donViDo = new DonViDoService();
            parentFormFluent1 = parentFormFluent;
            isCloseParentForm1 = isCloseParentForm;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            isCloseParentForm1 = true;
            if (isCloseParentForm1 && parentFormFluent1 != null)
            {
                parentFormFluent1.Close();
            }
        }

        private async void simpleButton1_Click(object sender, EventArgs e)
        {
            if (txt_tdv.Text == "")
            {
                lb_tdv.Visible = true;
                lb_tdv.Text = "Vui lòng nhập tên đơn vị";
            }
            else
            {
                DonViDoTheoNam donViDo = new DonViDoTheoNam();
                donViDo.TenDonVi = txt_tdv.Text;
                lb_tdv.Visible = false;
                DialogResult dialog = MessageBox.Show("Bạn có chắc chắn muốn thêm tên đơn vị?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialog == DialogResult.OK)
                {
                    DialogResult dialog1 = MessageBox.Show("Bạn đã thêm dữ liệu thành công", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (dialog1 == DialogResult.OK)
                    {
                        await _donViDo.ThemDonViDo(donViDo);
                        lb_tdv.Visible = false;
                        txt_tdv.Text = "";
                    }
                }
            }
        }
    }
}