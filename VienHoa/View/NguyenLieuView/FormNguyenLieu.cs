using DevExpress.Pdf.Native.BouncyCastle.Utilities.Collections;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DevExpress.XtraRichEdit.Layout.Engine;
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
using VienHoa.Enums;
using VienHoa.IService;
using VienHoa.Service;

namespace VienHoa.View
{
    public partial class FormNguyenLieu : DevExpress.XtraEditors.XtraForm
    {
        private NguyenLieu nguyenLieuView;
        private readonly IRepository<LoaiNguyenLieu> loaiNguyenLieuRepo;
        private readonly IRepository<DonViDoTheoNam> donViDoRepo;
        private readonly IRepository<NguyenLieu> nguyenLieuRepo;
        private readonly INguyenLieu _nguyenLieu;
        private readonly IAxitHoa _axitHoa;
        private XtraForm parentFormFluent1;
        private bool isCloseParentForm1;
        public FormNguyenLieu(XtraForm parentFormFluent, bool isCloseParentForm = false)
        {

            InitializeComponent();
            _axitHoa = new AxitHoaService();
            _nguyenLieu = new NguyenLieuService();
            nguyenLieuRepo = new ExRepository<NguyenLieu>();
            loaiNguyenLieuRepo = new ExRepository<LoaiNguyenLieu>();
            donViDoRepo = new ExRepository<DonViDoTheoNam>();
            ComBox();
            parentFormFluent1 = parentFormFluent;
            isCloseParentForm1 = isCloseParentForm;
        }
        public FormNguyenLieu()
        {
            InitializeComponent();
            _axitHoa = new AxitHoaService();
            _nguyenLieu = new NguyenLieuService();
            nguyenLieuRepo = new ExRepository<NguyenLieu>();
            loaiNguyenLieuRepo = new ExRepository<LoaiNguyenLieu>();
            donViDoRepo = new ExRepository<DonViDoTheoNam>();
            ComBox();
        }
        public FormNguyenLieu(NguyenLieu nguyenLieu)
        {
            InitializeComponent();
            _axitHoa = new AxitHoaService();
            _nguyenLieu = new NguyenLieuService();
            nguyenLieuRepo = new ExRepository<NguyenLieu>();
            loaiNguyenLieuRepo = new ExRepository<LoaiNguyenLieu>();
            donViDoRepo = new ExRepository<DonViDoTheoNam>();
            nguyenLieuView = nguyenLieu;
            ComBox();
        }

        public FormNguyenLieu(string nguyenLieu)
        {
            InitializeComponent();
            _axitHoa = new AxitHoaService();
            _nguyenLieu = new NguyenLieuService();
            nguyenLieuRepo = new ExRepository<NguyenLieu>();
            loaiNguyenLieuRepo = new ExRepository<LoaiNguyenLieu>();
            donViDoRepo = new ExRepository<DonViDoTheoNam>();
            txt_tnl.Text = nguyenLieu;
            ComBox();
        }

        private void ValidateEnum(List<EnumNguyenLieu> list)
        {
            if (list.Contains(EnumNguyenLieu.TrongTenNL))
            {
                lb_tnl.Text = "Vui lòng nhập tên nguyên liệu";
            }
            else
            {
                lb_tnl.Text = "";
            }
            if (list.Contains(EnumNguyenLieu.TrongTenHT))
            {
                lb_thttt.Text = " Vui lòng nhập hiện thị tiêu thụ";
            }
            else
            {
                lb_thttt.Text = "";
            }
            if (list.Contains(EnumNguyenLieu.TrongHTTN))
            {
                lb_tdv.Text = "Vui lòng nhập đơn vị theo năm";
            }
            else
            {
                lb_tdv.Text = "";
            }
            if (list.Contains(EnumNguyenLieu.TrongLoaiNL))
            {
                lb_lnl.Text = "Vui lòng nhập loai nguyên liệu";
            }
            else
            {
                lb_lnl.Text = "";
            }
        }

        private void ComBox()
        {  //Đơn vị đo theo năm 
           //  _axitHoa.AxitHoaTinhToan();
            List<DonViDoTheoNam> donViDoTheoNams = donViDoRepo.TableUntracked.ToList();
            foreach (DonViDoTheoNam donViDoTheoNam in donViDoTheoNams)
            {
                cb_tdv.Properties.Items.Add(new CustomCombobox { Id = donViDoTheoNam.Id, Ten = donViDoTheoNam.TenDonVi });
            }
            cb_tdv.SelectedIndex = -1;
            //Loại nguyên liệu 
            List<LoaiNguyenLieu> loaiNguyenLieus = loaiNguyenLieuRepo.TableUntracked.ToList();
            foreach (LoaiNguyenLieu loaiNguyenLieu in loaiNguyenLieus)
            {
                cb_lnl.Properties.Items.Add(new CustomCombobox { Id = loaiNguyenLieu.Id, Ten = loaiNguyenLieu.TenLoai });
            }
            cb_lnl.SelectedIndex = -1;

            if (nguyenLieuView != null)
            {
                this.Text = "Sửa dữ liệu";
                //simpleButton1.ImageOptions.Image = null;
                //simpleButton1.ImageOptions.ImageList = imageCollection1;
                //simpleButton1.ImageOptions.ImageIndex = 1;
                simpleButton1.Text = "Sửa";
                txt_tnl.Text = nguyenLieuView.TenNguyenLieu;
                txt_thttt.Text = nguyenLieuView.TenHienThiTieuThu;
                foreach (CustomCombobox item in cb_lnl.Properties.Items)
                {
                    if (item.Id == nguyenLieuView.LoaiNguyenLieuId)
                    {
                        cb_lnl.EditValue = item;
                        break;
                    }
                }
                foreach (CustomCombobox item in cb_tdv.Properties.Items)
                {
                    if (item.Id == nguyenLieuView.DonViDoTheoNamId)
                    {
                        cb_tdv.EditValue = item;
                        break;
                    }
                }

                lb_lnl.Text = "";
                lb_tdv.Text = "";
                lb_thttt.Text = "";
                lb_tnl.Text = "";
            }
            else
            {
                this.Text = "Thêm dữ liệu";
                //simpleButton1.ImageOptions.Image = null;
                //simpleButton1.ImageOptions.ImageList = imageCollection1;
                //simpleButton1.ImageOptions.ImageIndex = 0;
                simpleButton1.Text = "Thêm";
                cb_lnl.SelectedIndex = -1;
                cb_tdv.SelectedItem = -1;
                //txt_tnl.Text = "";
                txt_thttt.Text = "";
                lb_lnl.Text = "";
                lb_tdv.Text = "";
                lb_thttt.Text = "";
                lb_tnl.Text = "";
            }


        }

        public async void ThemNguyenLieu()
        {

            NguyenLieu nguyenLieu = new NguyenLieu();
            nguyenLieu.TenNguyenLieu = txt_tnl.Text;
            nguyenLieu.TenHienThiTieuThu = txt_thttt.Text;
            nguyenLieu.LoaiNguyenLieuId = (CustomCombobox)cb_lnl.SelectedItem != null ? ((CustomCombobox)cb_lnl.SelectedItem).Id : 0;
            nguyenLieu.DonViDoTheoNamId = (CustomCombobox)cb_tdv.SelectedItem != null ? ((CustomCombobox)cb_tdv.SelectedItem).Id : 0;
            List<EnumNguyenLieu> listNL = await _nguyenLieu.ThemNguyenLieu(nguyenLieu);

            if (listNL.Count() == 0)
            {
                DialogResult dialog = MessageBox.Show("Bạn có chắc chắn muốn thêm nguyên liệu?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialog == DialogResult.OK)
                {
                    DialogResult dialog1 = MessageBox.Show("Bạn đã thêm dữ liệu thành công", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (dialog1 == DialogResult.OK)
                    {
                        await nguyenLieuRepo.AddAsync(nguyenLieu);
                        isCloseParentForm1 = true;
                        if (isCloseParentForm1)
                        {
                            parentFormFluent1.Close();
                        }
                        this.Close();

                    }
                }
            }
            else
            {
                ValidateEnum(listNL);
            }


        }
        public async void SuaNguyenLieu()
        {
            nguyenLieuView.TenNguyenLieu = txt_tnl.Text;
            nguyenLieuView.TenHienThiTieuThu = txt_thttt.Text;
            nguyenLieuView.LoaiNguyenLieuId = (CustomCombobox)cb_lnl.SelectedItem != null ? ((CustomCombobox)cb_lnl.SelectedItem).Id : 0;
            nguyenLieuView.DonViDoTheoNamId = (CustomCombobox)cb_tdv.SelectedItem != null ? ((CustomCombobox)cb_tdv.SelectedItem).Id : 0;
            List<EnumNguyenLieu> listNLS = await _nguyenLieu.SuaNguyenLieu(nguyenLieuView.Id, nguyenLieuView);

            if (listNLS.Count() == 0)
            {
                DialogResult dialog = MessageBox.Show("Bạn có chắc chắn muốn sửa nguyên liệu?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialog == DialogResult.OK)
                {
                    DialogResult dialog1 = MessageBox.Show("Bạn đã sửa dữ liệu thành công", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (dialog1 == DialogResult.OK)
                    {
                        await nguyenLieuRepo.UpdateAsync(nguyenLieuView);
                        this.Close();
                    }
                }
            }
            else
            {
                ValidateEnum(listNLS);
            }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (nguyenLieuView != null)
            {
                SuaNguyenLieu();
            }
            else
            {
                ThemNguyenLieu();
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

            isCloseParentForm1 = true;
            if (isCloseParentForm1 && parentFormFluent1 != null)
            {
                parentFormFluent1.Close();
            }
            this.Close();
        }
    }
}