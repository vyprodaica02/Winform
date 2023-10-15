using DevExpress.Mvvm.Native;
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

namespace VienHoa.View
{
    public partial class ThemThaiDauRaView : DevExpress.XtraEditors.XtraForm
    {
        private readonly AppDbContext _db;
        private readonly IThaiDauRa _thaiDauRaService;
        private XtraForm xtraForm;
        private bool close;
        public ThemThaiDauRaView(XtraForm XtraForm, bool Close = false)
        {
            InitializeComponent();

            _db = new AppDbContext();
            _thaiDauRaService = new ThaiDauRaService();
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
                DialogResult dialog = MessageBox.Show("Bạn có chắc chắn muốn thêm thải đầu ra?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialog == DialogResult.OK)
                {
                    ThaiDauRa thaiDauRaNew = new ThaiDauRa();
                    if (comboBoxChatThai.SelectedItem is ComboBoxItem selectedItemChatThai)
                    {
                        thaiDauRaNew.ChatThaiId = selectedItemChatThai.ID;
                    }

                    if (comboBoxSanPham.SelectedItem is ComboBoxItem selectedItemSanPham)
                    {
                        thaiDauRaNew.SanPhamId = selectedItemSanPham.ID;
                    }

                    if (comboBoxDonVi.SelectedItem is ComboBoxItem selectedItemDonVi)
                    {
                        thaiDauRaNew.DonViId = selectedItemDonVi.ID;
                    }
                    thaiDauRaNew.SoLuong = double.Parse(textEditSoLuong.Text);
                    thaiDauRaNew.HeSoDieuChinh = double.Parse(textEditHeSoDieuChinh.Text);
                    var result = await _thaiDauRaService.Create(thaiDauRaNew);
                    if (result.Error)
                    {
                        MessageBox.Show(result.ErrorMessage, "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        xtraForm.Close();
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
            if (!double.TryParse(textEditSoLuong.Text, out double giatri) || giatri < 0)
            {
                labelSoLuong.Text = "Số lượng không hợp lệ";
                labelSoLuong.Visible = true;
                textEditSoLuong.Focus();
                check = false;
            }
            else
            {
                labelSoLuong.Visible = false;
            }
            if (string.IsNullOrEmpty(comboBoxSanPham.Text))
            {
                labelSanPham.Text = "Vui lòng chọn sản phẩm";
                labelSanPham.Visible = true;
                comboBoxSanPham.Focus();
                check = false;
            }
            else
            {
                labelSanPham.Visible = false;
            }
            if (string.IsNullOrEmpty(comboBoxDonVi.Text))
            {
                labelDonVi.Text = "Vui lòng chọn đơn vị";
                labelDonVi.Visible = true;
                comboBoxDonVi.Focus();
                check = false;
            }
            else
            {
                labelDonVi.Visible = false;
            }
            if (string.IsNullOrWhiteSpace(comboBoxChatThai.Text))
            {
                labelChatthai.Text = "Vui lòng chọn chất thải";
                labelChatthai.Visible = true;
                comboBoxChatThai.Focus();
                check = false;
            }
            else
            {
                labelChatthai.Visible = true;
            }
            if (!double.TryParse(textEditHeSoDieuChinh.Text, out double giatri1) || giatri1 < 0)
            {
                labelHeSoDieuChinh.Text = "Hệ số điều chỉnh không hợp lệ";
                labelHeSoDieuChinh.Visible = true;
                textEditHeSoDieuChinh.Focus();
                check = false;
            }
            else
            {
                labelHeSoDieuChinh.Visible = false;
            }
            return check;
        }
        private void ThemThaiDauRaView_Load(object sender, EventArgs e)
        {
            try
            {
                var sanPhamItems = _db.sanPhams.ToList();
                comboBoxSanPham.Properties.Items.Clear();
                foreach (var item in sanPhamItems)
                {
                    comboBoxSanPham.Properties.Items.Add(new ComboBoxItem(item.Id, item.TenSanPham));
                }

                var chatThaiItems = _db.chatThais.ToList();
                comboBoxChatThai.Properties.Items.Clear();
                foreach (var item in chatThaiItems)
                {
                    comboBoxChatThai.Properties.Items.Add(new ComboBoxItem(item.Id, item.TenChatThai));
                }

                var donViItems = _db.donViSanPhams.ToList();
                comboBoxDonVi.Properties.Items.Clear();
                foreach (var item in donViItems)
                {
                    comboBoxDonVi.Properties.Items.Add(new ComboBoxItem(item.Id, item.TenDonVi));
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
    }
}