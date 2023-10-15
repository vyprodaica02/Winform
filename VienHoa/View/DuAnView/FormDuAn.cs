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
using VienHoa.IService;
using VienHoa.Service;

namespace VienHoa.View.DuAnView
{
    public partial class FormDuAn : DevExpress.XtraEditors.XtraForm
    {
        private DuAn duAnUpdate;
        private Form parentForm;
        private IDuAn _duAnService;
        private IQLDoanhNghiep _doanhNghiepService;
        private readonly IRepository<DoanhNghiep> doanhNghiepRepos;

        public FormDuAn()
        {
            _doanhNghiepService = new QLDoanhNghiepServices();
            _duAnService = new DuAnService();
            doanhNghiepRepos = new ExRepository<DoanhNghiep>();
            InitializeComponent();
            FillData();
        }
        bool isCloseParentForm = true;
        public FormDuAn(XtraForm parentFormFluent, bool isClose = true)
        {
            _duAnService = new DuAnService();
            doanhNghiepRepos = new ExRepository<DoanhNghiep>();
            _doanhNghiepService = new QLDoanhNghiepServices();
            parentForm = parentFormFluent;
            isCloseParentForm = isClose;
            InitializeComponent();
            FillData();
        }

        public FormDuAn(DuAn duAn)
        {
            doanhNghiepRepos = new ExRepository<DoanhNghiep>();
            _duAnService = new DuAnService();
            duAnUpdate = duAn;
            doanhNghiepRepos = new ExRepository<DoanhNghiep>();

            InitializeComponent();
            FillData();
        }
        private void FillData()
        {
            lbErrTenDA.Text = "";
            lbErrDateStart.Text = "";
            lbErrDateEnd.Text = "";
            lbErrDN.Text = "";
            LoadCombobox();

            if (duAnUpdate != null)
            {
                this.Text = "Sửa dữ liệu";
                //btnSaveDuAn.ImageOptions.Image = null;
                //btnSaveDuAn.ImageOptions.ImageList = imageCollection1;
                //btnSaveDuAn.ImageOptions.ImageIndex = 1;
                btnSaveDuAn.Text = "Sửa";
                txTenDA.Text = duAnUpdate.TenDuAn;
                dateStart.EditValue = duAnUpdate.NgayBatDau;
                dateEnd.EditValue = duAnUpdate.NgayKetThuc;
                foreach (CustomCombobox item in comboboxDN.Properties.Items)
                {
                    if (item.Id == duAnUpdate.DoanhNghiepId)
                    {
                        comboboxDN.EditValue = item;
                        break;
                    }
                }
            }
            else
            {
                this.Text = "Thêm dữ liệu";
                //btnSaveDuAn.ImageOptions.Image = null;
                //btnSaveDuAn.ImageOptions.ImageList = imageCollection1;
                //btnSaveDuAn.ImageOptions.ImageIndex = 0;
                btnSaveDuAn.Text = "Thêm";
                txTenDA.Text = "";
                dateStart.EditValue = null;
                dateEnd.EditValue = null;
                comboboxDN.SelectedIndex = -1;
            }
        }

        private void LoadCombobox()
        {
            List<DoanhNghiep> doanhNghieps = doanhNghiepRepos.TableUntracked.ToList();

            foreach (DoanhNghiep doanhNghiep in doanhNghieps)
            {
                comboboxDN.Properties.Items.Add(new CustomCombobox { Id = doanhNghiep.Id, Ten = doanhNghiep.TenCongTy });
            }
        }

        private async void Add()
        {
            DuAn duAn = new DuAn();
            SetDataDA(duAn);

            var dlg = MessageBox.Show("Bạn có đồng ý thêm dự án", "Xác nhận!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dlg == DialogResult.OK)
            {
                bool res = await _duAnService.AddDuAn(duAn);
                if (res)
                {
                    MessageBox.Show("Thêm sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (isCloseParentForm)
                    {
                        parentForm.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Thất bại", "Xác nhận ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private DuAn SetDataDA(DuAn duAn)
        {
            duAn.TenDuAn = txTenDA.Text;
            duAn.NgayBatDau = Convert.ToDateTime(dateStart.EditValue);
            duAn.NgayKetThuc = Convert.ToDateTime(dateEnd.EditValue);
            duAn.DoanhNghiepId = (CustomCombobox)comboboxDN.SelectedItem != null ? ((CustomCombobox)comboboxDN.SelectedItem).Id : 0;

            return duAn;
        }

        private bool CheckError()
        {
            bool check = true;

            if (string.IsNullOrEmpty(txTenDA.Text.Trim()))
            {
                check = false;
                lbErrTenDA.Text = "Vui lòng nhập tên dự án";
            }
            else
            {
                lbErrTenDA.Text = "";
            }
            if (dateStart.EditValue == null)
            {
                check = false;
                lbErrDateStart.Text = "Vui chọn ngày bắt đầu";
            }
            else
            {
                lbErrDateStart.Text = "";
            }

            if (dateEnd.EditValue == null)
            {
                check = false;
                lbErrDateEnd.Text = "Vui chọn ngày kết thúc";
            }
            else
            {
                lbErrDateEnd.Text = "";
            }
            if ((CustomCombobox)comboboxDN.SelectedItem == null)
            {
                check = false;
                lbErrDN.Text = "Vui lòng chọn doanh nghiệp";
            }
            else
            {
                lbErrDN.Text = "";
            }

            if (dateEnd.EditValue != null && dateStart != null)
            {
                DateTime ngayBatDau = Convert.ToDateTime(dateStart.EditValue);
                DateTime ngayKetThuc = Convert.ToDateTime(dateEnd.EditValue); ;
                if (ngayBatDau > ngayKetThuc)
                {
                    check = false;
                    lbErrDateEnd.Text = "Ngày kết thúc phải lớn hơn ngày bắt đầu";
                }
            }

            return check;
        }

        private async void UpdateDA()
        {
            if (duAnUpdate != null)
            {
                var dlg = MessageBox.Show("Bạn có đồng ý sửa dự án?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dlg == DialogResult.OK)
                {
                    duAnUpdate = SetDataDA(duAnUpdate);
                    bool res = await _duAnService.UpdateDuAn(duAnUpdate);
                    if (res)
                    {
                        MessageBox.Show("Sửa dự án thành công!", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        duAnUpdate = null;
                    }
                    else
                    {
                        MessageBox.Show("Sửa dự án thất bại!", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    duAnUpdate = null;
                }
            }
        }


        private void btnSaveDuAn_Click(object sender, EventArgs e)
        {
            if (CheckError())
            {
                if (duAnUpdate != null)
                {
                    UpdateDA();
                }
                else
                {
                    Add();
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (parentForm != null)
            {
                parentForm.Close();
            }
            else
            {
                this.Close();
            }
        }
    }
}