using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.Utils.MVVM;
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
using VienHoa.Common;

namespace VienHoa.View
{
    public partial class FormSanPhamView : DevExpress.XtraEditors.XtraForm
    {
        private readonly ISanPham _sanPhamService;
        private readonly IRepository<DuAn> duAnRepo;
        private readonly IRepository<NhaMay> nhaMayRepo;
        private readonly IRepository<LoaiLoNung> loaiLoNungRepo;
        private XtraForm parentForm;
        bool isCloseParentForm;
        private SanPham sanPhamUpdate;
        public FormSanPhamView()
        {
            duAnRepo = new ExRepository<DuAn>();
            nhaMayRepo = new ExRepository<NhaMay>();
            loaiLoNungRepo = new ExRepository<LoaiLoNung>();
            _sanPhamService = new SanPhamService();
            InitializeComponent();
            FillData();
        }

        public FormSanPhamView(XtraForm parentFormFluent, bool isCloseParentForm = false)
        {
            duAnRepo = new ExRepository<DuAn>();
            nhaMayRepo = new ExRepository<NhaMay>();
            loaiLoNungRepo = new ExRepository<LoaiLoNung>();
            _sanPhamService = new SanPhamService();
            parentForm = parentFormFluent;
            InitializeComponent();
            FillData();
        }

        public FormSanPhamView(SanPham sanPham)
        {
            _sanPhamService = new SanPhamService();
            duAnRepo = new ExRepository<DuAn>();
            nhaMayRepo = new ExRepository<NhaMay>();
            loaiLoNungRepo = new ExRepository<LoaiLoNung>();
            sanPhamUpdate = sanPham;
            InitializeComponent();
            FillData();
        }
        private void FillData()
        {
            lbErrLLN.Text = "";
            lbErrNM.Text = "";
            lbErrDA.Text = "";
            lbErrMC.Text = "";
            lbErrCSTK.Text = "";
            lbErrCN.Text = "";
            lbErrKH.Text = "";
            lbErrSP.Text = "";

            LoadCombobox();

            if (sanPhamUpdate != null)
            {
                this.Text = "Sửa dữ liệu";
                simpleButton1.Text = "Sửa";
                //simpleButton1.ImageOptions.Image = null;
                //simpleButton1.ImageOptions.ImageList = imageCollection1;
                //simpleButton1.ImageOptions.ImageIndex = 1;
                txSp.Text = sanPhamUpdate.TenSanPham;
                txKH.Text = sanPhamUpdate.KyHieu;
                txCN.Text = sanPhamUpdate.CongNghe;
                txCSTK.Text = sanPhamUpdate.CongSuatThietKe;
                txMC.Text = sanPhamUpdate.MaCode;
                foreach (CustomCombobox item in comboBoxDA.Properties.Items)
                {
                    if (item.Id == sanPhamUpdate.DuAnId)
                    {
                        comboBoxDA.EditValue = item;
                        break;
                    }
                }

                foreach (CustomCombobox item in comboBoxNM.Properties.Items)
                {
                    if (item.Id == sanPhamUpdate.NhaMayId)
                    {
                        comboBoxNM.EditValue = item;
                        break;
                    }
                }

                foreach (CustomCombobox item in comboBoxLLN.Properties.Items)
                {
                    if (item.Id == sanPhamUpdate.LoaiLoNungId)
                    {
                        comboBoxLLN.EditValue = item;
                        break;
                    }
                }
            }
            else
            {
                this.Text = "Thêm dữ liệu";
                //simpleButton1.ImageOptions.Image = null;
                //simpleButton1.ImageOptions.ImageList = imageCollection1;
                //simpleButton1.ImageOptions.ImageIndex = 0;
                simpleButton1.Text = "Thêm";
                txSp.Text = "";
                txKH.Text = "";
                txCN.Text = "";
                txCSTK.Text = "";
                comboBoxDA.SelectedIndex = -1;
                comboBoxNM.SelectedIndex = -1;
                comboBoxLLN.SelectedIndex = -1;
            }
        }

        private void LoadCombobox()
        {
            List<DuAn> duAns = duAnRepo.TableUntracked.ToList();
            List<NhaMay> nhaMays = nhaMayRepo.TableUntracked.ToList();
            List<LoaiLoNung> loaiLoNungs = loaiLoNungRepo.TableUntracked.ToList();

            foreach (DuAn duAn in duAns)
            {
                comboBoxDA.Properties.Items.Add(new CustomCombobox { Id = duAn.Id, Ten = duAn.TenDuAn });
            }

            foreach (NhaMay nhaMay in nhaMays)
            {
                comboBoxNM.Properties.Items.Add(new CustomCombobox { Id = nhaMay.Id, Ten = nhaMay.TenNhaMay });
            }

            foreach (LoaiLoNung loaiLoNung in loaiLoNungs)
            {
                comboBoxLLN.Properties.Items.Add(new CustomCombobox { Id = loaiLoNung.Id, Ten = loaiLoNung.TenLoaiLo });
            }

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (CheckError())
            {
                if (sanPhamUpdate != null)
                {
                    UpdateSP();
                }
                else
                {
                    Add();
                }
            }
        }

        private async void Add()
        {
            SanPham sanPham = new SanPham();
            SetDataSP(sanPham);

            var dlg = MessageBox.Show("Bạn có đồng ý thêm sản phẩm", "Xác nhận!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dlg == DialogResult.OK)
            {
                bool res = await _sanPhamService.AddSanPham(sanPham);
                if (res)
                {
                    MessageBox.Show("Thêm sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    parentForm.Close();
                }
                else
                {
                    MessageBox.Show("Thất bại", "Xác nhận ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private SanPham SetDataSP(SanPham sanPham)
        {
            sanPham.TenSanPham = txSp.Text;
            sanPham.KyHieu = txKH.Text;
            sanPham.CongNghe = txCN.Text;
            sanPham.CongSuatThietKe = txCSTK.Text;
            sanPham.MaCode = txMC.Text;
            sanPham.DuAnId = (CustomCombobox)comboBoxDA.SelectedItem != null ? ((CustomCombobox)comboBoxDA.SelectedItem).Id : 0;
            sanPham.NhaMayId = (CustomCombobox)comboBoxNM.SelectedItem != null ? ((CustomCombobox)comboBoxNM.SelectedItem).Id : 0;
            sanPham.LoaiLoNungId = (CustomCombobox)comboBoxLLN.SelectedItem != null ? ((CustomCombobox)comboBoxLLN.SelectedItem).Id : 0;
            return sanPham;
        }

        private bool CheckError()
        {
            bool check = true;
            if (string.IsNullOrEmpty(txSp.Text.Trim()))
            {
                check = false;
                lbErrSP.Text = "Vui lòng nhập tên sản phẩm";
            }
            else
            {
                lbErrSP.Text = "";
            }

            if (string.IsNullOrEmpty(txKH.Text.Trim()))
            {
                check = false;
                lbErrKH.Text = "Vui lòng nhập ký hiệu";
            }
            else
            {
                lbErrKH.Text = "";
            }

            if (string.IsNullOrEmpty(txCN.Text.Trim()))
            {
                check = false;
                lbErrCN.Text = "Vui lòng nhập công nghệ";
            }
            else
            {
                lbErrCN.Text = "";
            }

            if (string.IsNullOrEmpty(txCSTK.Text.Trim()))
            {
                check = false;
                lbErrCSTK.Text = "Vui lòng nhập công suất thiết kế";
            }
            else
            {
                lbErrCSTK.Text = "";
            }

            if (string.IsNullOrEmpty(txMC.Text.Trim()))
            {
                check = false;
                lbErrMC.Text = "Vui lòng nhập mã code";
            }
            else
            {
                lbErrMC.Text = "";
            }

            if ((CustomCombobox)comboBoxDA.SelectedItem == null)
            {
                check = false;
                lbErrDA.Text = "Vui lòng chọn dự án";
            }
            else
            {
                lbErrDA.Text = "";
            }

            if ((CustomCombobox)comboBoxNM.SelectedItem == null)
            {
                check = false;
                lbErrNM.Text = "Vui lòng chọn nhà máy";
            }
            else
            {
                lbErrNM.Text = "";
            }
            if ((CustomCombobox)comboBoxLLN.SelectedItem == null)
            {
                check = false;
                lbErrLLN.Text = "Vui lòng chọn loại lò nung";
            }
            else
            {
                lbErrLLN.Text = "";
            }
            return check;
        }
        private async void UpdateSP()
        {
            if (sanPhamUpdate != null)
            {
                var dlg = MessageBox.Show("Bạn có đồng ý sửa sản phẩm?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dlg == DialogResult.OK)
                {
                    sanPhamUpdate = SetDataSP(sanPhamUpdate);
                    bool res = await _sanPhamService.UpdateSanPham(sanPhamUpdate);
                    if (res)
                    {
                        MessageBox.Show("Sửa sản phẩm thành công!", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        sanPhamUpdate = null;
                    }
                    else
                    {
                        MessageBox.Show("Sửa sản phẩm thất bại!", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    sanPhamUpdate = null;
                }
            }
        }


        private void simpleButton2_Click(object sender, EventArgs e)
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