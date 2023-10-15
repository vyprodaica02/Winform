using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VienHoa.Entity;
using VienHoa.IService;
using VienHoa.Service;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using static DevExpress.Utils.Filtering.ExcelFilterOptions;

namespace VienHoa.View
{
    public partial class SanPhamView : DevExpress.XtraEditors.XtraForm
    {

        private readonly ISanPham _sanPhamService;
        private string _tabType;
        public SanPhamView()
        {
            _sanPhamService = new SanPhamService();
            InitializeComponent();
        }
        DevExpress.XtraGrid.GridControl tblSanPham;
        public SanPhamView(DevExpress.XtraGrid.GridControl gridControlDataSP, string tabType = null)
        {
            _tabType = tabType;
            _sanPhamService = new SanPhamService();
            InitializeComponent();
            FillData(gridControlDataSP);
            tblSanPham = gridControlDataSP;
            LoadData();
        }
        private async void FillData(DevExpress.XtraGrid.GridControl gridControlDataSP)
        {
            GridView gridView = gridView1;
            gridView1.OptionsBehavior.Editable = false;

            gridView.OptionsView.ShowIndicator = false;
            gridView.OptionsView.ShowGroupPanel = true;

            GridColumn stt = gridView.Columns.AddVisible("stt");
            GridColumn tenSanPham = gridView.Columns.AddVisible("TenSanPham");
            GridColumn kyHieu = gridView.Columns.AddVisible("KyHieu");
            GridColumn maCode = gridView.Columns.AddVisible("MaCode");
            GridColumn congNghe = gridView.Columns.AddVisible("CongNghe");
            GridColumn congSuat = gridView.Columns.AddVisible("CongSuat");
            GridColumn nhaMay = gridView.Columns.AddVisible("NhaMay");
            GridColumn duAn = gridView.Columns.AddVisible("DuAn");
            GridColumn loaiLoNung = gridView.Columns.AddVisible("LoaiLoNung");
            GridColumn loaiLoNungId = gridView.Columns.AddVisible("LoaiLoNungId");
            GridColumn duAnId = gridView.Columns.AddVisible("DuAnId");
            GridColumn nhaMayId = gridView.Columns.AddVisible("NhaMayId");
            GridColumn LCA = gridView.Columns.AddVisible("LCA");
            GridColumn colEdit = gridView.Columns.AddVisible("Sua");
            GridColumn colDelete = gridView.Columns.AddVisible("Xoa");
            // Đặt tiêu đề cho cột (Caption)
            stt.Caption = "STT";
            tenSanPham.Caption = "Tên sản phẩm";
            kyHieu.Caption = "Ký hiệu";
            maCode.Caption = "Mã code";
            congNghe.Caption = "Công nghệ";
            congSuat.Caption = "Công suất dữ liệu";
            nhaMay.Caption = "Nhà Máy";
            duAn.Caption = "Dự án";
            loaiLoNung.Caption = "Loại lò nung";
            colEdit.Caption = "Sửa";
            colDelete.Caption = "Xóa";
            LCA.Caption = "LCA";
            //
            congSuat.FieldName = "CongSuatThietKe";
            duAnId.FieldName = "DuAnId";
            nhaMayId.FieldName = "nhaMayId";
            loaiLoNungId.FieldName = "LoaiLoNungId";
            loaiLoNung.FieldName = "LoaiLoNung.TenLoaiLo";
            duAn.FieldName = "DuAn.TenDuAn";
            nhaMay.FieldName = "NhaMay.TenNhaMay";
            //

            duAnId.Visible = false;
            nhaMayId.Visible = false;
            loaiLoNungId.Visible = false;

            if (_tabType != null)
            {
                LCA.Visible = true;
                colEdit.Visible = false;
                colDelete.Visible = false;
            }
            else
            {
                LCA.Visible = false;
                colEdit.Visible = true;
                colDelete.Visible = true;
            }

            // Font style
            stt.AppearanceHeader.Font = new Font(stt.AppearanceHeader.Font.FontFamily, 8, FontStyle.Bold);
            tenSanPham.AppearanceHeader.Font = new Font(tenSanPham.AppearanceHeader.Font.FontFamily, 8, FontStyle.Bold);
            kyHieu.AppearanceHeader.Font = new Font(kyHieu.AppearanceHeader.Font.FontFamily, 8, FontStyle.Bold);
            maCode.AppearanceHeader.Font = new Font(maCode.AppearanceHeader.Font.FontFamily, 8, FontStyle.Bold);
            congNghe.AppearanceHeader.Font = new Font(congNghe.AppearanceHeader.Font.FontFamily, 8, FontStyle.Bold);
            congSuat.AppearanceHeader.Font = new Font(congSuat.AppearanceHeader.Font.FontFamily, 8, FontStyle.Bold);
            nhaMay.AppearanceHeader.Font = new Font(nhaMay.AppearanceHeader.Font.FontFamily, 8, FontStyle.Bold);
            duAn.AppearanceHeader.Font = new Font(duAn.AppearanceHeader.Font.FontFamily, 8, FontStyle.Bold);
            loaiLoNung.AppearanceHeader.Font = new Font(loaiLoNung.AppearanceHeader.Font.FontFamily, 8, FontStyle.Bold);
            colEdit.AppearanceHeader.Font = new Font(colEdit.AppearanceHeader.Font.FontFamily, 8, FontStyle.Bold);
            colDelete.AppearanceHeader.Font = new Font(colDelete.AppearanceHeader.Font.FontFamily, 8, FontStyle.Bold);
            LCA.AppearanceHeader.Font = new Font(LCA.AppearanceHeader.Font.FontFamily, 8, FontStyle.Bold);

            stt.AppearanceCell.Font = new Font(stt.AppearanceHeader.Font.FontFamily, 8);
            tenSanPham.AppearanceCell.Font = new Font(tenSanPham.AppearanceHeader.Font.FontFamily, 8);
            kyHieu.AppearanceCell.Font = new Font(kyHieu.AppearanceHeader.Font.FontFamily, 8);
            maCode.AppearanceCell.Font = new Font(maCode.AppearanceHeader.Font.FontFamily, 8);
            congNghe.AppearanceCell.Font = new Font(congNghe.AppearanceHeader.Font.FontFamily, 8);
            congSuat.AppearanceCell.Font = new Font(congSuat.AppearanceHeader.Font.FontFamily, 8);
            nhaMay.AppearanceCell.Font = new Font(nhaMay.AppearanceHeader.Font.FontFamily, 8);
            duAn.AppearanceCell.Font = new Font(duAn.AppearanceHeader.Font.FontFamily, 8);
            loaiLoNung.AppearanceCell.Font = new Font(loaiLoNung.AppearanceHeader.Font.FontFamily, 8);

            // Đặt kiểu kiểm soát của cột (Column Edit)
            gridControlDataSP.DataSource = gridControlDataSP;
            // Thiết lập căn giữa cho văn bản trong cột ThaoTac

            stt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            //tenSanPham.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            kyHieu.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            maCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            congNghe.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            congSuat.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            nhaMay.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            duAn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            loaiLoNung.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colEdit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colDelete.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            LCA.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            //Căn giữa header
            stt.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            tenSanPham.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            kyHieu.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            maCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            congNghe.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            congSuat.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            nhaMay.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            duAn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            loaiLoNung.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colEdit.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colDelete.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            LCA.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            //set width
            stt.Width = 50;
            stt.MinWidth = 50;
            stt.MaxWidth = 50;

            tenSanPham.Width = 129;
            kyHieu.Width = 100;
            maCode.Width = 100;
            congNghe.Width = 105;
            congSuat.Width = 100;
            nhaMay.Width = 110;
            duAn.Width = 110;
            loaiLoNung.Width = 110;

            LCA.Width = 50;
            LCA.MinWidth = 50;
            LCA.MaxWidth = 50;

            colEdit.Width = 50;
            colEdit.MinWidth = 50;
            colEdit.MaxWidth = 50;

            colDelete.Width = 50;
            colDelete.MinWidth = 50;
            colDelete.MaxWidth = 50;

            //bỏ auto size
            stt.OptionsColumn.FixedWidth = false;
            stt.OptionsColumn.AllowSize = false;
            stt.OptionsColumn.AllowMove = false;

            tenSanPham.OptionsColumn.FixedWidth = false;
            tenSanPham.OptionsColumn.AllowSize = false; // Ngăn người dùng kéo rộng/thu hẹp cột
            tenSanPham.OptionsColumn.AllowMove = false; // Ngăn người dùng kéo cột

            kyHieu.OptionsColumn.FixedWidth = false;
            kyHieu.OptionsColumn.AllowSize = false;
            kyHieu.OptionsColumn.AllowMove = false;

            maCode.OptionsColumn.FixedWidth = false;
            maCode.OptionsColumn.AllowSize = false;
            maCode.OptionsColumn.AllowMove = false;

            congNghe.OptionsColumn.FixedWidth = false;
            congNghe.OptionsColumn.AllowSize = false;
            congNghe.OptionsColumn.AllowMove = false;

            congSuat.OptionsColumn.FixedWidth = false;
            congSuat.OptionsColumn.AllowSize = false;
            congSuat.OptionsColumn.AllowMove = false;

            nhaMay.OptionsColumn.FixedWidth = false;
            nhaMay.OptionsColumn.AllowSize = false;
            nhaMay.OptionsColumn.AllowMove = false;

            duAn.OptionsColumn.FixedWidth = false;
            duAn.OptionsColumn.AllowSize = false;
            duAn.OptionsColumn.AllowMove = false;

            loaiLoNung.OptionsColumn.FixedWidth = false;
            loaiLoNung.OptionsColumn.AllowSize = false;
            loaiLoNung.OptionsColumn.AllowMove = false;

            LCA.OptionsColumn.FixedWidth = false;
            LCA.OptionsColumn.AllowSize = false;
            LCA.OptionsColumn.AllowMove = false;
            LCA.OptionsColumn.AllowEdit = false;

            colEdit.OptionsColumn.FixedWidth = false;
            colEdit.OptionsColumn.AllowSize = false;
            colEdit.OptionsColumn.AllowMove = false;
            colEdit.OptionsColumn.AllowEdit = false;

            colDelete.OptionsColumn.FixedWidth = false;
            colDelete.OptionsColumn.AllowSize = false;
            colDelete.OptionsColumn.AllowMove = false;
            colDelete.OptionsColumn.AllowEdit = false;

            // setup btn 
            // btn edit 
            RepositoryItemButtonEdit buttonEdit = new RepositoryItemButtonEdit();
            buttonEdit.Buttons[0].ImageOptions.ImageList = imageCollection1;
            buttonEdit.Buttons[0].ImageOptions.ImageIndex = 1;
            buttonEdit.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            buttonEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            colEdit.ColumnEdit = buttonEdit;

            // btn delete 
            RepositoryItemButtonEdit buttonDelete = new RepositoryItemButtonEdit();
            buttonDelete.Buttons[0].ImageOptions.ImageList = imageCollection1;
            buttonDelete.Buttons[0].ImageOptions.ImageIndex = 0;
            buttonDelete.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            buttonDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            colDelete.ColumnEdit = buttonDelete;

            RepositoryItemButtonEdit buttonAddLCA = new RepositoryItemButtonEdit();
            buttonAddLCA.Buttons[0].ImageOptions.ImageList = imageCollection1;
            buttonAddLCA.Buttons[0].ImageOptions.ImageIndex = 2;
            buttonAddLCA.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            buttonAddLCA.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            LCA.ColumnEdit = buttonAddLCA;

            // Cấu hình cột "stt" tương tự như trước
            stt.Caption = "STT";
            stt.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            stt.VisibleIndex = 0;
            gridView.CustomUnboundColumnData += (sender, e) =>
            {
                if (e.Column == stt && e.IsGetData)
                {
                    e.Value = e.ListSourceRowIndex + 1;
                }
            };


            gridControlDataSP.MainView = gridView;

        }
        private async void LoadData(string keywords = null)
        {
            List<SanPham> sanPhams = await _sanPhamService.GetAllSanPham(keywords);
            tblSanPham.DataSource = sanPhams;
        }
        private void SanPhamView_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            FormSanPhamView formAdd = new FormSanPhamView();
            var dlg = formAdd.ShowDialog();
            LoadData();
        }

        private async void Delete(DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            SanPham sanPhamDelete = gridView1.GetFocusedRow() as SanPham;
            var dlg = XtraMessageBox.Show("Bạn có chắc muốn xóa sản phẩm này?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dlg == DialogResult.OK)
            {
                bool res = await _sanPhamService.DeleteSanPham(sanPhamDelete);
                if (res)
                {
                    gridView1.DeleteSelectedRows();
                    XtraMessageBox.Show("Xóa thành công !", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("Xóa thất bại !", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void UpdateSP()
        {
            SanPham sanPhamUpdate = gridView1.GetFocusedRow() as SanPham;
            FormSanPhamView formAdd = new FormSanPhamView(sanPhamUpdate);
            var dlg = formAdd.ShowDialog();
            if (dlg == DialogResult.Cancel)
            {
                LoadData();
            }
        }
        private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (e.Column.Name == "colXoa")
            {
                Delete(e);
            }
            else if (e.Column.Name == "colSua")
            {
                UpdateSP();
            }
            else if (e.Column.Name == "colLCA")
            {
                SanPham sanPham = gridView1.GetFocusedRow() as SanPham;
                FormLCAView frmLCA = new FormLCAView(sanPham);
                frmLCA.ShowDialog();
            }
        }

        private async void txSearch_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //string keywords = txSearch.Text;
            //LoadData(keywords);
        }
    }
}