using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit.Import.Doc;
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
using VienHoa.Entity;
using VienHoa.EnumNhaMay;
using VienHoa.Service;
using VienHoa.Service.TransferService;

namespace VienHoa.View
{
    public partial class UpdateInfor : DevExpress.XtraEditors.XtraForm
    {
        private IRepository<DoanhNghiep> DNRepository;
        private IRepository<LoaiNhaMay> LNMRepository;
        private IRepository<LoaiLoNung> LNNRepository;
        private IRepository<CongSuatThietKe> CSRepository;
        private NhaMayService NhaMayService;
        // Gathering data
        public int NMId { get; set; }
        public int DoanhNghiepId { get; set; }
        public int LoaiNhaMayId { get; set; }
        public int LoaiLoNungId { get; set; }
        public int CongSuatThietKeId { get; set; }
        public string TenNhaMay_ { get; set; }
        public string ViTri { get; set; }
        public double TyLeCoPhan_ { get; set; }

        public UpdateInfor(int Id, int DoanhNghiepId, int LoaiNhaMayId,
            int LoaiLoNungId, int CongSuatTKId, string TenNhaMay, string ViTri, double TyLeCoPhan)
        {
            InitializeComponent();
            DNRepository = new ExRepository<DoanhNghiep>();
            LNMRepository = new ExRepository<LoaiNhaMay>();
            LNNRepository = new ExRepository<LoaiLoNung>();
            CSRepository = new ExRepository<CongSuatThietKe>();
            NhaMayService = new NhaMayService();
            // Retrive the information:
            RenderingData();
            RenderPrevData(DoanhNghiepId, LoaiNhaMayId,
            LoaiLoNungId, CongSuatTKId, TenNhaMay, ViTri, TyLeCoPhan);
            NMId = Id;
        }

        #region Initialize
        private void RenderingData()
        {
            var dataList = DNRepository.TableUntracked.ToList();
            // add item to checkBox Dn:
            foreach (var item in dataList)
            {
                comboBoxTenDN.Properties.Items.Add(new ItemComBoText { Id = item.Id, Name = item.TenCongTy });
            }
            // Render for checkBox LoaiNM
            var dataListNM = LNMRepository.TableUntracked.ToList();
            foreach (var item in dataListNM)
            {
                comboBoxLoaiNM.Properties.Items.Add(new ItemComBoText { Id = item.Id, Name = item.TenLoai });
            }
            // Render for checkbox LoaiLN
            var dataListLn = LNNRepository.TableUntracked.ToList();
            foreach (var item in dataListLn)
            {
                comboBoxLoaiLN.Properties.Items.Add(new ItemComBoText { Id = item.Id, Name = item.TenLoaiLo });
            }
            // Render for checkBox CongSuatTK
            var dataListCS = CSRepository.TableUntracked.ToList();
            foreach (var item in dataListCS)
            {
                comboBoxCongSuat.Properties.Items.Add(new ItemComboBox { Id = item.Id, CongSuatTK = item.CongSuatDinhMuc });
            }
        }
        private void RenderPrevData(int DoanhNghiepId, int LoaiNhaMayId,
            int LoaiLoNungId, int CongSuatTKId, string TenNhaMay_, string ViTri, double TLCoPhan)
        {
            // Load context for checkBoxDn:
            foreach (ItemComBoText item in comboBoxTenDN.Properties.Items)
            {
                if (item.Id == DoanhNghiepId)
                {
                    // chon muc ung voi Id bang cach gan value:
                    comboBoxTenDN.EditValue = item;                    // Neu da tim thay => break
                    break;
                }
            }
            //Load context for checkBox LoaiLN
            foreach (ItemComBoText item in comboBoxLoaiLN.Properties.Items)
            {
                if (item.Id == LoaiLoNungId) { comboBoxLoaiLN.EditValue = item; break; }
            }
            // Load context for checkBox LoaiNM
            foreach (ItemComBoText item in comboBoxLoaiNM.Properties.Items)
            {
                if (item.Id == LoaiNhaMayId) { comboBoxLoaiNM.EditValue = item; break; }
            }
            // Load context for checkBox CongSuat
            foreach (ItemComboBox item in comboBoxCongSuat.Properties.Items)
            {
                if (item.Id == CongSuatTKId) { comboBoxCongSuat.EditValue = item; break; }
            }
            TenNhaMay.Text = TenNhaMay_; ViTriNhaMay.Text = ViTri; TLCPr.Text = TLCoPhan.ToString();
        }
        #endregion

        private bool ValidateInput()
        {
            bool check = true;
            if (string.IsNullOrWhiteSpace(ViTriNhaMay.Text))
            {
                errorViTri.Text = "Tên nhà máy không được để trống";
                errorViTri.Visible = true;
                errorViTri.Focus();
                check = false;
            }
            else { errorViTri.Visible = false; }
            if (string.IsNullOrWhiteSpace(TenNhaMay.Text))
            {
                errorTenNM.Text = "Vị trí nhà máy chưa nhập!";
                errorTenNM.Visible = true;
                errorTenNM.Focus();
                check = false;
            }
            else { errorTenNM.Visible = false; }
            if (string.IsNullOrWhiteSpace(TLCPr.Text))
            {
                errorTLCP.Text = "Tỷ lệ cổ phần chưa nhập!";
                errorTLCP.Visible = true;
                errorTLCP.Focus();
                check = false;
            }
            else { errorTLCP.Visible = false; }
            if (string.IsNullOrWhiteSpace(comboBoxTenDN.Text))
            {
                errTenDN.Text = "Chưa chọn tên DN!";
                errTenDN.Visible = true;
                errTenDN.Focus();
                check = false;
            }
            else { errTenDN.Visible = false; }
            if (string.IsNullOrWhiteSpace(comboBoxLoaiNM.Text))
            {
                errLoaiNM.Text = "Chưa chọn loại Nhà Máy!";
                errLoaiNM.Visible = true;
                errLoaiNM.Focus();
                check = false;
            }
            else { errLoaiNM.Visible = false; }
            if (string.IsNullOrWhiteSpace(comboBoxLoaiLN.Text))
            {
                errLoaiLoNung.Text = "Chưa chọn loại Lò Nung!";
                errLoaiLoNung.Visible = true;
                errLoaiLoNung.Focus();
                check = false;
            }
            else { errLoaiLoNung.Visible = false; }
            if (string.IsNullOrWhiteSpace(comboBoxCongSuat.Text))
            {
                errCongSuat.Text = "Chưa khai báo công suất định mức!";
                errCongSuat.Visible = true;
                errCongSuat.Focus();
                check = false;
            }
            else
            {
                errCongSuat.Visible = false;
            }
            return check;
        }

        #region Update
        private void ConfirmOK_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                DialogResult res = MessageBox.Show("Sửa bản ghi này trong mục lưu trữ\n Tiếp tục?", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Question);
                if (res == DialogResult.OK)
                {
                    // Gathering data:
                    DoanhNghiepId = ((ItemComBoText)comboBoxTenDN.SelectedItem).Id;
                    LoaiLoNungId = ((ItemComBoText)comboBoxLoaiLN.SelectedItem).Id;
                    LoaiNhaMayId = ((ItemComBoText)comboBoxLoaiNM.SelectedItem).Id;
                    CongSuatThietKeId = ((ItemComboBox)comboBoxCongSuat.SelectedItem).Id;
                    if (!NhaMayService.ValidateDouble(TLCPr.Text))
                    { MessageBox.Show(ErrorInfo.TyLeCoPhanPhaiLaSoThuc, "Thông báo", MessageBoxButtons.OK); return; }
                    TyLeCoPhan_ = NhaMayService.TLCP;
                    ViTri = ViTriNhaMay.Text;
                    TenNhaMay_ = TenNhaMay.Text;
                }
                DialogResult = DialogResult.OK;
                Close();
            }
        }
        private void ConfirmCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion
    }
}