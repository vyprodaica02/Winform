using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace VienHoa.View
{
    public partial class ThemChatThaiView : DevExpress.XtraEditors.XtraForm
    {
        private readonly IRepository<LoaiChatThai> _loaiChatThaiRepo;
        private readonly IChatThai _chatThaiService;
        private XtraForm xtraForm;
        private bool close;
        public ThemChatThaiView(XtraForm XtraForm, bool Close = false)
        {
            InitializeComponent();

            _loaiChatThaiRepo = new ExRepository<LoaiChatThai>();
            _chatThaiService = new ChatThaiService();
            xtraForm = XtraForm;
            close = Close;
        }

        public ThemChatThaiView( string tenChatThai)
        {
            InitializeComponent();

            _loaiChatThaiRepo = new ExRepository<LoaiChatThai>();
            _chatThaiService = new ChatThaiService();
            comboBoxEdit1.Text = tenChatThai;
           
        }


        private void ThemChatThaiView_Load(object sender, EventArgs e)
        {
            try
            {
                var items = _loaiChatThaiRepo.TableUntracked.ToList();
                comboBoxEdit1.Properties.Items.Clear();
                foreach (var item in items)
                {
                    comboBoxEdit1.Properties.Items.Add(new ComboBoxItem(item.Id, item.TenLoaiChatThai));

                }
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

        private void comboBoxEdit1_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private bool ValidateInput()
        {
            bool check = true;
            if (string.IsNullOrWhiteSpace(comboBoxEdit1.Text))
            {
                labelLoaiChatThai.Text = "Vui lòng nhập loại chất thải";
                labelLoaiChatThai.Visible = true;
                labelLoaiChatThai.Focus();
                check = false;
            }
            else
            {
                labelLoaiChatThai.Visible = false;
            }
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

        private void btnHuy_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            //xtraForm.Close();
            this.Close();
        }

        private async void btnThem_Click_1(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                DialogResult dialog = MessageBox.Show("Bạn có chắc chắn muốn thêm chất thải?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialog == DialogResult.OK)
                {
                    ChatThai chatThaiNew = new ChatThai();
                    if (comboBoxEdit1.SelectedItem is ComboBoxItem selectedComboBoxItem)
                    {
                        chatThaiNew.LoaiChatThaiId = selectedComboBoxItem.ID;
                    }
                    chatThaiNew.TenChatThai = textEditTenChatThai.Text;
                    var result = await _chatThaiService.Create(chatThaiNew);
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

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}