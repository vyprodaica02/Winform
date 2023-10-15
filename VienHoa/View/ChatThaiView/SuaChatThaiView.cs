using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
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
using VienHoa.IService;
using VienHoa.Service;

namespace VienHoa.View
{
    public partial class SuaChatThaiView : DevExpress.XtraEditors.XtraForm
    {
        private readonly IRepository<LoaiChatThai> _loaiChatThaiRepo;
        private readonly IChatThai chatThaiService;
        public SuaChatThaiView(ChatThai chatThai)
        {
            InitializeComponent();

            _loaiChatThaiRepo = new ExRepository<LoaiChatThai>();
            chatThaiService = new ChatThaiService();
            updateChatThai = chatThai;
        }

        private ChatThai updateChatThai;
        public ChatThai UpdateChatThai
        {
            get
            {
                return updateChatThai;
            }
        }

        private async void SuaChatThaiView_Load(object sender, EventArgs e)
        {

            try
            {
                var items = await chatThaiService.GetListLoaiChatThai();
                comboBoxEdit1.Properties.Items.Clear();
                foreach (LoaiChatThai loaiChatThai in items)
                {
                    comboBoxEdit1.Properties.Items.Add(new ComboBoxItem(loaiChatThai.Id, loaiChatThai.TenLoaiChatThai));

                }
                foreach (ComboBoxItem item in comboBoxEdit1.Properties.Items)
                {
                    if (item.ID == updateChatThai.LoaiChatThaiId)
                    {
                        comboBoxEdit1.EditValue = item;
                        break;
                    }
                }
                textEditTenChatThai.Text = updateChatThai.TenChatThai;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public class ComboBoxItem
        {
            public int ID { get; set; }
            public string Name { get; set; }

            public ComboBoxItem(int id, string name)
            {
                ID = id;
                Name = name;
            }

            public override string ToString()
            {
                return Name;
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
                DialogResult dialog = MessageBox.Show("Bạn có muốn sửa chất thải", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialog == DialogResult.OK)
                {
                    updateChatThai.LoaiChatThaiId = ((ComboBoxItem)comboBoxEdit1.SelectedItem).ID;
                    updateChatThai.TenChatThai = textEditTenChatThai.Text;
                    this.DialogResult = DialogResult.OK;

                }

            }
        }


        private bool ValidateInput()
        {
            bool check = true;
            if (string.IsNullOrWhiteSpace(textEditTenChatThai.Text))
            {
                labelChatThai.Text = "Vui lòng nhập tên chất thải";
                labelChatThai.Visible = true;
                labelChatThai.Focus();
                check = false;
            }
            else
            {
                labelChatThai.Visible = false;
            }

            return check;
        }
    }
}