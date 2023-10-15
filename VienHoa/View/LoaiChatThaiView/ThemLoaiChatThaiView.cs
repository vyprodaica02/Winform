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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace VienHoa.View
{
    public partial class ThemLoaiChatThaiView : DevExpress.XtraEditors.XtraForm
    {
        private readonly ILoaiChatThai _loaiChatThaiServices;
        private readonly AppDbContext _db;
        private XtraForm xtraForm;
        private bool close;
        public ThemLoaiChatThaiView(XtraForm XtraForm, bool Close = false)
        {
            InitializeComponent();

            _loaiChatThaiServices = new LoaiChatThaiServices();
            _db = new AppDbContext();
            xtraForm = XtraForm;
            close = Close;
        }


        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            xtraForm.Close();
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                DialogResult dialog = MessageBox.Show("Bạn có chắc chắn muốn thêm loại chất thải?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialog == DialogResult.OK)
                {
                    LoaiChatThai loaiChatThaiNew = new LoaiChatThai();
                    loaiChatThaiNew.TenLoaiChatThai = textEditTenLoaiChatThai.Text;
                    var result = await _loaiChatThaiServices.Create(loaiChatThaiNew);
                    if (result.Error)
                    {
                        MessageBox.Show(result.ErrorMessage, "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.Cancel;
                        if (close == false)
                        {
                            xtraForm.Close();
                        }

                    }
                    else
                    {
                        MessageBox.Show(result.ErrorMessage, "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }
        private bool ValidateInput()
        {
            bool check = true;
            if (string.IsNullOrWhiteSpace(textEditTenLoaiChatThai.Text))
            {
                labelLoaiChatThai.Text = "Vui lòng nhập loại chất thải";
                labelLoaiChatThai.Visible = true;
                labelLoaiChatThai.Focus();
                check = false;
            }
            else
            {
                labelLoaiChatThai.Visible = false;
                LoaiChatThai loaiChatThai = _db.loaiChatThais.FirstOrDefault(x => x.TenLoaiChatThai == textEditTenLoaiChatThai.Text);
                if (loaiChatThai != null)
                {
                    labelLoaiChatThai.Text = "Tên loại chất thải đã tồn tại";
                    labelLoaiChatThai.Visible = true;
                    textEditTenLoaiChatThai.Focus();
                    check = false;
                }
                else
                {
                    labelLoaiChatThai.Visible = false;
                }
            }

            return check;
        }
    }
}