using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VienHoa.Entity;
using VienHoa.IService;
using VienHoa.Service;

namespace VienHoa.View.NguyenLieuView
{
    public partial class FormLoaiNguyenLieu : DevExpress.XtraEditors.XtraForm
    {
        private ILoaiNguyenLieu _loaiNguyenLieu;
        private XtraForm parentFormFluent1;
        private bool isCloseParentForm1;
        public FormLoaiNguyenLieu()
        {
            InitializeComponent();
            lb_lnl.Visible = false;

        }
        public FormLoaiNguyenLieu(XtraForm parentFormFluent, bool isCloseParentForm = false)
        {
            InitializeComponent();
            lb_lnl.Visible = false;
            _loaiNguyenLieu = new LoaiNguyenLieuService();
            parentFormFluent1 = parentFormFluent;
            isCloseParentForm1 = isCloseParentForm;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            isCloseParentForm1 = true;
            if (isCloseParentForm1 && parentFormFluent1 != null)
            {
                parentFormFluent1.Close();
            }
            this.Close();
        }

        private async void simpleButton2_Click(object sender, EventArgs e)
        {
            if (txt_lnl.Text == "")
            {
                lb_lnl.Visible = true;
                lb_lnl.Text = "Vui lòng nhập loại nguyên liệu";
            }
            else
            {
                LoaiNguyenLieu loaiNguyenLieu = new LoaiNguyenLieu();
                loaiNguyenLieu.TenLoai = txt_lnl.Text;
                lb_lnl.Visible = false;
                DialogResult dialog = MessageBox.Show("Bạn có chắc chắn muốn thêm loại nguyên liệu?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialog == DialogResult.OK)
                {
                    DialogResult dialog1 = MessageBox.Show("Bạn đã thêm dữ liệu thành công", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (dialog1 == DialogResult.OK)
                    {
                        await _loaiNguyenLieu.ThemLoaiNguyenLieu(loaiNguyenLieu);
                        txt_lnl.Text = "";
                    }
                }
            }
        }
    }
}