using DevExpress.XtraEditors;
using Microsoft.EntityFrameworkCore;
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
using VienHoa.Service;

namespace VienHoa.View
{
    public partial class SuaThaiDauRaView : DevExpress.XtraEditors.XtraForm
    {
        private readonly AppDbContext _db;
        public SuaThaiDauRaView(ThaiDauRa thaiDauRa)
        {
            InitializeComponent();

            updateThaiDauRa = thaiDauRa;
            _db = new AppDbContext();
        }
        private ThaiDauRa updateThaiDauRa;
        public ThaiDauRa UpdateThaiDauRa
        {
            get
            {
                return updateThaiDauRa;
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
                updateThaiDauRa.SanPhamId = ((ComboBoxItem)comboBoxSanPham.SelectedItem).ID;
                updateThaiDauRa.ChatThaiId = ((ComboBoxItem)comboBoxChatThai.SelectedItem).ID;
                updateThaiDauRa.DonViId = ((ComboBoxItem)comboBoxDonVi.SelectedItem).ID;
                updateThaiDauRa.HeSoDieuChinh = double.Parse(textEditHeSoDieuChinh.Text);
                updateThaiDauRa.SoLuong = double.Parse(textEditSoLuong.Text);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool ValidateInput()
        {
            if (!double.TryParse(textEditSoLuong.Text, out double giatri) || giatri < 0)
            {
                labelSoLuong.Text = "Số lượng không hợp lệ";
                labelSoLuong.Visible = true;
                textEditSoLuong.Focus();
                return false;
            }
            else
            {
                labelSoLuong.Visible = false;
            }

            if (!double.TryParse(textEditHeSoDieuChinh.Text, out double giatri1) || giatri1 < 0)
            {
                labelHeSoDieuChinh.Text = "Hệ số điều chỉnh không hợp lệ";
                labelHeSoDieuChinh.Visible = true;
                textEditHeSoDieuChinh.Focus();
                return false;
            }
            else
            {
                labelHeSoDieuChinh.Visible = false;
            }
            return true;
        }

        private async void SuaThaiDauRaView_Load(object sender, EventArgs e)
        {
            try
            {
                var itemChatThai = await _db.chatThais.ToListAsync();
                comboBoxChatThai.Properties.Items.Clear();
                foreach (ChatThai chatThai in itemChatThai)
                {
                    comboBoxChatThai.Properties.Items.Add(new ComboBoxItem(chatThai.Id, chatThai.TenChatThai));

                }
                foreach (ComboBoxItem item in comboBoxChatThai.Properties.Items)
                {
                    if (item.ID == updateThaiDauRa.ChatThaiId)
                    {
                        comboBoxChatThai.EditValue = item;
                        break;
                    }
                }

                var itemSanPham = await _db.sanPhams.ToListAsync();
                comboBoxSanPham.Properties.Items.Clear();
                foreach (SanPham sanPham in itemSanPham)
                {
                    comboBoxSanPham.Properties.Items.Add(new ComboBoxItem(sanPham.Id, sanPham.TenSanPham));

                }
                foreach (ComboBoxItem item in comboBoxSanPham.Properties.Items)
                {
                    if (item.ID == updateThaiDauRa.SanPhamId)
                    {
                        comboBoxSanPham.EditValue = item;
                        break;
                    }
                }

                var itemDonVi = await _db.donViSanPhams.ToListAsync();
                comboBoxDonVi.Properties.Items.Clear();
                foreach (DonViSanPham donViSanPham in itemDonVi)
                {
                    comboBoxDonVi.Properties.Items.Add(new ComboBoxItem(donViSanPham.Id, donViSanPham.TenDonVi));

                }
                foreach (ComboBoxItem item in comboBoxDonVi.Properties.Items)
                {
                    if (item.ID == updateThaiDauRa.DonViId)
                    {
                        comboBoxDonVi.EditValue = item;
                        break;
                    }
                }
                textEditSoLuong.Text = updateThaiDauRa.SoLuong.ToString();
                textEditHeSoDieuChinh.Text = updateThaiDauRa.HeSoDieuChinh.ToString();
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