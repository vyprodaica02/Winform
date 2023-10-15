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
using VienHoa.DataEx;
using VienHoa.Entity;
using VienHoa.IService;
using VienHoa.Service;

namespace VienHoa.View.NhienLieuView
{
    public partial class FormLoaiNhienLieu : DevExpress.XtraEditors.XtraForm
    {
        private ILoaiNhienLieu _loaiNhienLieu;
        private XtraForm parentFormFluent1;
        private bool isCloseParentForm1;

        public FormLoaiNhienLieu()
        {
            lb_lnl.Visible = false;
            InitializeComponent();
            _loaiNhienLieu = new LoaiNhienLieuService();
        }

        public FormLoaiNhienLieu(XtraForm parentFormFluent, bool isCloseParentForm = false)
        {
            InitializeComponent();
            lb_lnl.Visible = false;
            _loaiNhienLieu = new LoaiNhienLieuService();
            parentFormFluent1 = parentFormFluent;
            isCloseParentForm1 = isCloseParentForm;
        }
        private async void simpleButton1_Click(object sender, EventArgs e)
        {
            if (txt_lnl.Text == "")
            {
                lb_lnl.Visible = true;
                lb_lnl.Text = "Vui lòng nhập loại nhiên liệu";
            }
            else
            {
                LoaiNhienLieu loaiNhienLieu = new LoaiNhienLieu();
                loaiNhienLieu.TenLoai = txt_lnl.Text;
                lb_lnl.Visible = false;
                DialogResult dialog = MessageBox.Show("Bạn có chắc chắn muốn thêm loại nhiên liệu?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialog == DialogResult.OK)
                {
                    DialogResult dialog1 = MessageBox.Show("Bạn đã thêm dữ liệu thành công", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (dialog1 == DialogResult.OK)
                    {
                        await _loaiNhienLieu.ThemLoaiNhienLieu(loaiNhienLieu);
                        txt_lnl.Text = "";
                    }
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            isCloseParentForm1 = true;
            if (isCloseParentForm1 && parentFormFluent1 != null)
            {
                parentFormFluent1.Close();
            }
            this.Close();
        }
    }
}