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
using VienHoa.Common;
using VienHoa.DataEx;
using VienHoa.Dtos;
using VienHoa.Entity;
using VienHoa.IService;
using VienHoa.Service;

namespace VienHoa.View
{
    public partial class HeSoPhatThaiDienAdd : DevExpress.XtraEditors.XtraForm
    {
        private readonly IHeSoPhatThaiDien heSoPhatThaiDienService;
        private readonly IRepository<KhiPhatThai> khiPhatThaiRepo;
        private HeSoPhatThaiDien addHeSoPhatThaiDien;
        private bool isValid;
        private bool closeForm;
        private XtraForm parentForm;
        public HeSoPhatThaiDienAdd(XtraForm ParentForm, bool CloseForm = true)
        {
            heSoPhatThaiDienService = new HeSoPhatThaiDienService();
            khiPhatThaiRepo = new ExRepository<KhiPhatThai>();
            InitializeComponent();
            parentForm = ParentForm;
            closeForm = CloseForm;
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
            if (!int.TryParse(txtGiaTri.Text, out int nam) || nam <= 0)
            {
                errorGiaTri.Text = "Giá trị không hợp lệ";
                errorGiaTri.Visible = true;
                isValid = false;
            }
            else
            {
                errorGiaTri.Visible = false;
            }
            if (!double.TryParse(txtNam.Text, out double giatri) || giatri <= 0)
            {
                errorNam.Text = "Năm không hợp lệ";
                errorNam.Visible = true;
                isValid = false;
            }
            else
            {
                errorNam.Visible = false;
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
            addHeSoPhatThaiDien = new HeSoPhatThaiDien();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                if (MessageBox.Show("Bạn có đồng ý thêm dữ liệu hệ số phát thải điện?", "Xác nhận!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    addHeSoPhatThaiDien.KhiPhatThaiId = ((ItemKhiPhatThai)cbbKhiPhatThai.SelectedItem).Id;
                    addHeSoPhatThaiDien.Nam = int.Parse(txtNam.Text);
                    addHeSoPhatThaiDien.GiaTri = double.Parse(txtGiaTri.Text);
                    var res = await heSoPhatThaiDienService.AddAsync(addHeSoPhatThaiDien);
                    if (!res.Error)
                    {
                        MessageBox.Show(res.Message, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (closeForm)
                        {
                            parentForm.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show(res.Message, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            parentForm.Close();
        }
    }
}