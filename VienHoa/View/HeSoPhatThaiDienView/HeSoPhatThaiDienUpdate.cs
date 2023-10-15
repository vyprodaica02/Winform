using DevExpress.XtraCharts;
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
using VienHoa.Dtos;
using VienHoa.Entity;
using VienHoa.IService;
using VienHoa.Service;

namespace VienHoa.View
{
    public partial class HeSoPhatThaiDienUpdate : DevExpress.XtraEditors.XtraForm
    {
        private readonly IHeSoPhatThaiDien heSoPhatThaiDienService;
        private bool isValid;
        private readonly IRepository<KhiPhatThai> khiPhatThaiRepo;
        private HeSoPhatThaiDien updateHeSoPhatThaiDien;
        public HeSoPhatThaiDien UpdateHeSoPhatThaiDien
        {
            get
            {
                return updateHeSoPhatThaiDien;
            }
        }
        public HeSoPhatThaiDienUpdate(HeSoPhatThaiDien selectSoPhatThaiDien)
        {
            heSoPhatThaiDienService = new HeSoPhatThaiDienService();
            khiPhatThaiRepo = new ExRepository<KhiPhatThai>();
            InitializeComponent();
            updateHeSoPhatThaiDien = selectSoPhatThaiDien;
        }
        private bool ValidateInput()
        {
            isValid = true;
            if (string.IsNullOrWhiteSpace(cbbKhiPhatThai.Text))
            {
                errorKhiPhatThai.Text = "Khí phát thải chưa được chọn";
                errorKhiPhatThai.Visible = true;
                isValid = false;
            }
            else
            {
                errorKhiPhatThai.Visible = false;
            }
            if (!int.TryParse(txtNam.Text, out int nam) || nam <= 0)
            {
                errorNam.Text = "Năm không hợp lệ";
                errorNam.Visible = true;
                isValid = false;
            }
            else
            {
                errorNam.Visible = false;
            }
            if (!double.TryParse(txtGiaTri.Text, out double giatri) || giatri <= 0)
            {
                errorGiaTri.Text = "Giá trị không hợp lệ";
                errorGiaTri.Visible = true;
                isValid = false;
            }
            else
            {
                errorGiaTri.Visible = false;
            }
            return isValid;
        }

        private void HeSoPhatThaiDienAdd_Load(object sender, EventArgs e)
        {
            var lstKhiPhatThai = khiPhatThaiRepo.TableUntracked.ToList();
            foreach (KhiPhatThai khiPhatThai in lstKhiPhatThai)
            {
                cbbKhiPhatThai.Properties.Items.Add(new ItemKhiPhatThai { Id = khiPhatThai.Id, TenKhi = khiPhatThai.TenKhi });
            }
            foreach (ItemKhiPhatThai item in cbbKhiPhatThai.Properties.Items)
            {
                if (item.Id == updateHeSoPhatThaiDien.KhiPhatThaiId)
                {
                    // Chọn mục có giá trị Id phù hợp bằng cách gán EditValue
                    cbbKhiPhatThai.EditValue = item;
                    break; // Dừng vòng lặp sau khi tìm thấy và chọn mục
                }
            }
            txtNam.Text = updateHeSoPhatThaiDien.Nam.ToString();
            txtGiaTri.Text = updateHeSoPhatThaiDien.GiaTri.ToString();
            this.ActiveControl = null;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn sửa hệ số phát thải điện?", "Xác nhận!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    updateHeSoPhatThaiDien.KhiPhatThaiId = ((ItemKhiPhatThai)cbbKhiPhatThai.SelectedItem).Id;
                    updateHeSoPhatThaiDien.Nam = int.Parse(txtNam.Text);
                    updateHeSoPhatThaiDien.GiaTri = double.Parse(txtGiaTri.Text);
                    this.DialogResult = DialogResult.OK;
                }
            }
        }
    }
}