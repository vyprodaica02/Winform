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

namespace VienHoa.View
{
    public partial class SuaLoaiChatThaiView : DevExpress.XtraEditors.XtraForm
    {
        public readonly IRepository<LoaiChatThai> _repository;
        public SuaLoaiChatThaiView(LoaiChatThai loaiChatThai)
        {
            InitializeComponent();

            updateLoaiChatThai = loaiChatThai;
            _repository = new ExRepository<LoaiChatThai>();
            textEditTenLoaiChatThai.Text = updateLoaiChatThai.TenLoaiChatThai;

        }

        private LoaiChatThai updateLoaiChatThai;
        public LoaiChatThai UpdateLoaiChatThai
        {
            get
            {
                return updateLoaiChatThai;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                DialogResult dialog = MessageBox.Show("Bạn có muốn sửa loại chất thải", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialog == DialogResult.OK)
                {
                    updateLoaiChatThai.TenLoaiChatThai = textEditTenLoaiChatThai.Text;
                    this.DialogResult = DialogResult.OK;
                }
            }

        }
        private bool ValidateInput()
        {
            bool check = true;
            if (string.IsNullOrWhiteSpace(textEditTenLoaiChatThai.Text))
            {
                label1.Text = "Vui lòng nhập loại chất thải";
                label1.Visible = true;
                label1.Focus();
                check = false;
            }
            else
            {
                label1.Visible = false;
                LoaiChatThai loaiChatThai = _repository.TableUntracked.FirstOrDefault(x => x.TenLoaiChatThai == textEditTenLoaiChatThai.Text);
                if (loaiChatThai != null)
                {
                    label1.Text = "Tên loại chất thải đã tồn tại";
                    label1.Visible = true;
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