using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
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

namespace VienHoa.View
{
    public partial class FormDuAnView : DevExpress.XtraEditors.XtraForm
    {

        private IDuAn _duAnService;
        DevExpress.XtraGrid.GridControl _tblSanPham;
        public FormDuAnView()
        {
            _duAnService = new DuAnService();
            InitializeComponent();
        }
        public FormDuAnView(DevExpress.XtraGrid.GridControl tblDuAn)
        {
            _duAnService = new DuAnService();
            _tblSanPham = tblDuAn;
            InitializeComponent();
            FillData(tblDuAn);
            LoadData();
        }
        private void FillData(DevExpress.XtraGrid.GridControl tblDuAn)
        {
            GridView gridView = gridView1;
            gridView1.OptionsBehavior.Editable = false;

            gridView.OptionsView.ShowIndicator = false;
            gridView.OptionsView.ShowGroupPanel = true;

            GridColumn stt = gridView.Columns.AddVisible("stt");
            GridColumn doanhNghiep = gridView.Columns.AddVisible("DoanhNgiep");
            GridColumn doanhNghiepId = gridView.Columns.AddVisible("DoanhNgiepId");
            GridColumn tenDuAn = gridView.Columns.AddVisible("TenDuAn");
            GridColumn ngayBatDau = gridView.Columns.AddVisible("NgayBatDau");
            GridColumn ngayKetThuc = gridView.Columns.AddVisible("NgayKetThuc");

            GridColumn colEdit = gridView.Columns.AddVisible("Sua");
            GridColumn colDelete = gridView.Columns.AddVisible("Xoa");
            // Đặt tiêu đề cho cột (Caption)
            stt.Caption = "STT";
            doanhNghiep.Caption = "Tên doanh nghiệp";
            tenDuAn.Caption = "Tên dự án";
            ngayBatDau.Caption = "Ngày bắt đầu";
            ngayKetThuc.Caption = "Ngày kết thúc";

            colEdit.Caption = "Sửa";
            colDelete.Caption = "Xóa";
            //
            doanhNghiep.FieldName = "DoanhNghiep.TenCongTy";
            doanhNghiepId.FieldName = "DoanhNghiep.Id";
            tenDuAn.FieldName = "TenDuAn";
            ngayBatDau.FieldName = "NgayBatDau";
            ngayKetThuc.FieldName = "NgayKetThuc";

            // Font style
            stt.AppearanceHeader.Font = new Font(stt.AppearanceHeader.Font.FontFamily, 8, FontStyle.Bold);
            tenDuAn.AppearanceHeader.Font = new Font(tenDuAn.AppearanceHeader.Font.FontFamily, 8, FontStyle.Bold);
            ngayBatDau.AppearanceHeader.Font = new Font(ngayBatDau.AppearanceHeader.Font.FontFamily, 8, FontStyle.Bold);
            ngayKetThuc.AppearanceHeader.Font = new Font(ngayKetThuc.AppearanceHeader.Font.FontFamily, 8, FontStyle.Bold);
            doanhNghiep.AppearanceHeader.Font = new Font(ngayKetThuc.AppearanceHeader.Font.FontFamily, 8, FontStyle.Bold);

            colEdit.AppearanceHeader.Font = new Font(colEdit.AppearanceHeader.Font.FontFamily, 8, FontStyle.Bold);
            colDelete.AppearanceHeader.Font = new Font(colDelete.AppearanceHeader.Font.FontFamily, 8, FontStyle.Bold);

            stt.AppearanceCell.Font = new Font(stt.AppearanceHeader.Font.FontFamily, 8);
            ngayBatDau.AppearanceCell.Font = new Font(ngayBatDau.AppearanceHeader.Font.FontFamily, 8);
            ngayKetThuc.AppearanceCell.Font = new Font(ngayKetThuc.AppearanceHeader.Font.FontFamily, 8);
            tenDuAn.AppearanceCell.Font = new Font(tenDuAn.AppearanceHeader.Font.FontFamily, 8);
            doanhNghiep.AppearanceCell.Font = new Font(tenDuAn.AppearanceHeader.Font.FontFamily, 8);

            // Đặt kiểu kiểm soát của cột (Column Edit)
            tblDuAn.DataSource = tblDuAn;
            // Thiết lập căn giữa cho văn bản trong cột ThaoTac
            stt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            //tenSanPham.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            ngayBatDau.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            ngayKetThuc.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            colEdit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colDelete.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            //Căn giữa header
            stt.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            tenDuAn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            ngayBatDau.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            ngayKetThuc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            doanhNghiep.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colEdit.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colDelete.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            //set width
            stt.Width = 50;
            stt.MinWidth = 50;
            stt.MaxWidth = 50;

            doanhNghiep.Width = 200;
            tenDuAn.Width = 200;
            ngayBatDau.Width = 200;
            ngayKetThuc.Width = 200;

            colEdit.Width = 50;
            colEdit.MinWidth = 50;
            colEdit.MaxWidth = 50;
            colDelete.Width = 50;
            colDelete.MinWidth = 50;
            colDelete.MaxWidth = 50;

            ngayBatDau.DisplayFormat.FormatType = FormatType.DateTime;
            ngayBatDau.DisplayFormat.FormatString = "dd/MM/yyyy";

            ngayKetThuc.DisplayFormat.FormatType = FormatType.DateTime;
            ngayKetThuc.DisplayFormat.FormatString = "dd/MM/yyyy";

            //bỏ auto size
            stt.OptionsColumn.FixedWidth = false;
            stt.OptionsColumn.AllowSize = false;
            stt.OptionsColumn.AllowMove = false;

            tenDuAn.OptionsColumn.FixedWidth = false;
            tenDuAn.OptionsColumn.AllowSize = false; // Ngăn người dùng kéo rộng/thu hẹp cột
            tenDuAn.OptionsColumn.AllowMove = false; // Ngăn người dùng kéo cột

            ngayBatDau.OptionsColumn.FixedWidth = false;
            ngayBatDau.OptionsColumn.AllowSize = false;
            ngayBatDau.OptionsColumn.AllowMove = false;

            doanhNghiep.OptionsColumn.FixedWidth = false;
            doanhNghiep.OptionsColumn.AllowSize = false;
            doanhNghiep.OptionsColumn.AllowMove = false;

            ngayKetThuc.OptionsColumn.FixedWidth = false;
            ngayKetThuc.OptionsColumn.AllowSize = false;
            ngayKetThuc.OptionsColumn.AllowMove = false;

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
            buttonEdit.Buttons[0].ImageOptions.ImageIndex = 0;
            buttonEdit.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            buttonEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            colEdit.ColumnEdit = buttonEdit;

            // btn delete 
            RepositoryItemButtonEdit buttonDelete = new RepositoryItemButtonEdit();
            buttonDelete.Buttons[0].ImageOptions.ImageList = imageCollection1;
            buttonDelete.Buttons[0].ImageOptions.ImageIndex = 1;
            buttonDelete.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            buttonDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            colDelete.ColumnEdit = buttonDelete;

            doanhNghiepId.Visible = false;

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

            tblDuAn.MainView = gridView;

        }
        private async void LoadData()
        {
            List<DuAn> duAns = await _duAnService.GetAllDuAn();
            _tblSanPham.DataSource = duAns;
        }

        private async void Delete(DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            DuAn duAnDelete = gridView1.GetFocusedRow() as DuAn;
            var dlg = XtraMessageBox.Show("Bạn có chắc muốn xóa dự án này?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dlg == DialogResult.OK)
            {
                bool res = await _duAnService.DeleteDuAn(duAnDelete);
                if (res)
                {
                    gridView1.DeleteSelectedRows();
                    MessageBox.Show("Xóa thành công !", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa thất bại !", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void UpdateDA()
        {
            DuAn duAnUpdate = gridView1.GetFocusedRow() as DuAn;
            View.DuAnView.FormDuAn formAdd = new View.DuAnView.FormDuAn(duAnUpdate);
            var dlg = formAdd.ShowDialog();
            if (dlg == DialogResult.Cancel)
            {
                LoadData();
            }
        }


        private void FormDuAnView_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (e.Column.Name == "colXoa")
            {
                Delete(e);
            }
            else if (e.Column.Name == "colSua")
            {
                UpdateDA();
            }
        }
    }
}