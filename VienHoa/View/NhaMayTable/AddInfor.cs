using Microsoft.EntityFrameworkCore;
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
using VienHoa.EnumNhaMay;
using VienHoa.Service;
using VienHoa.Service.TransferService;
using VienHoa.Enums;

namespace VienHoa.View
{
    public partial class AddInfor : DevExpress.XtraEditors.XtraForm
    {

        private IRepository<DoanhNghiep> doanhNghiepRepository;
        private IRepository<LoaiNhaMay> loaiNMRepository;
        private IRepository<LoaiLoNung> loaiLNRepository;
        private IRepository<CongSuatThietKe> congSuatRepository;
        private NhaMayService NhaMayService_;
        private XtraForm parentForm;
        private bool closeForm;

        // Gathering data
        public int DoanhNghiepId { get; set; }
        public int LoaiNhaMayId { get; set; }
        public int LoaiLoNungId { get; set; }
        public int CongSuatThietKeId { get; set; }
        public string TenNhaMay_ { get; set; }
        public string ViTri { get; set; }
        public double TyLeCoPhan { get; set; }

        public AddInfor(XtraForm ParentForm, bool CloseForm = true)
        {
            InitializeComponent();
            doanhNghiepRepository = new ExRepository<DoanhNghiep>();
            loaiLNRepository = new ExRepository<LoaiLoNung>();
            loaiNMRepository = new ExRepository<LoaiNhaMay>();
            congSuatRepository = new ExRepository<CongSuatThietKe>();
            NhaMayService_ = new NhaMayService();
            RenderingData();
            parentForm = ParentForm;
            closeForm = CloseForm;
        }

        #region Initialize
        public async void RenderingData()
        {
            var dataList = await doanhNghiepRepository.TableUntracked.ToListAsync();
            // add item to checkBox Dn:
            foreach (var item in dataList)
            {
                comboBoxTenDN.Properties.Items.Add(new ItemComBoText { Id = item.Id, Name = item.TenCongTy });
            }
            // Render for checkBox LoaiNM
            var dataListNM = await loaiNMRepository.TableUntracked.ToListAsync();
            foreach (var item in dataListNM)
            {
                comboBoxLoaiNM.Properties.Items.Add(new ItemComBoText
                {
                    Id = item.Id,
                    Name = item.TenLoai
                });
            }
            // Render for checkbox LoaiLN
            var dataListLn = await loaiLNRepository.TableUntracked.ToListAsync();
            foreach (var item in dataListLn)
            {
                comboBoxLoaiLN.Properties.Items.Add(new ItemComBoText { Id = item.Id, Name = item.TenLoaiLo });
            }
            // Render for checkBox CongSuatTK
            var dataListCS = await congSuatRepository.TableUntracked.ToListAsync();
            foreach (var item in dataListCS)
            {
                comboBoxCongSuat.Properties.Items.Add(new ItemComboBox { Id = item.Id, CongSuatTK = item.CongSuatDinhMuc });
            }
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

        private async void ConfirmOK_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                DialogResult res =
                    MessageBox.Show("Bạn có đồng ý thêm dữ liệu Nhà Máy?", "Xác nhận",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (res == DialogResult.OK)
                {
                    // Gathering data:
                    DoanhNghiepId = ((ItemComBoText)comboBoxTenDN.SelectedItem).Id;
                    LoaiLoNungId = ((ItemComBoText)comboBoxLoaiLN.SelectedItem).Id;
                    LoaiNhaMayId = ((ItemComBoText)comboBoxLoaiNM.SelectedItem).Id;
                    CongSuatThietKeId = ((ItemComboBox)comboBoxCongSuat.SelectedItem).Id;
                    if (!NhaMayService_.ValidateDouble(TLCPr.Text))
                    { MessageBox.Show(ErrorInfo.TyLeCoPhanPhaiLaSoThuc, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                    TyLeCoPhan = NhaMayService_.TLCP;
                    ViTri = ViTriNhaMay.Text;
                    TenNhaMay_ = TenNhaMay.Text;

                    // Create object:
                    NhaMay Nm = new NhaMay()
                    {
                        TenNhaMay = TenNhaMay_,
                        DoanhNghiepId = DoanhNghiepId,
                        LoaiLoNungId = LoaiLoNungId,
                        LoaiNhaMayId = LoaiNhaMayId,
                        CongSuatThietKeId = CongSuatThietKeId,
                        ViTri = ViTri,
                        TiLeCoPhan = TyLeCoPhan
                    };

                    // Add object:
                    EnumType err = await NhaMayService_.AddObject(Nm);
                    if (err == EnumType.ThaoTacThanhCong)
                    {
                        MessageBox.Show("Thêm nhà máy thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (closeForm)
                        {
                            parentForm.Close();
                        }
                    }
                }
                if (closeForm)
                { // Neu muon hot exits
                    parentForm.Close();
                }
            }
        }
        private void ConfirmCancel_Click(object sender, EventArgs e)
        {
            parentForm.Close();
        }
    }
}