using DevExpress.XtraEditors;
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
using VienHoa.Common;
using VienHoa.DataEx;
using VienHoa.Entity;
using VienHoa.IService;
using VienHoa.Service;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
using DevExpress.Pdf.Native;
using DevExpress.XtraReports.UI;
using DevExpress.XtraGrid.Views.Base;

namespace VienHoa.View
{
    public partial class fmNguyenLieu : DevExpress.XtraEditors.XtraForm
    {
        private readonly IRepository<NguyenLieu> nguyenLieuRepo;
        private readonly INguyenLieu _nguyenLieu;

        public fmNguyenLieu()
        {
            InitializeComponent();
            nguyenLieuRepo = new ExRepository<NguyenLieu>();
            _nguyenLieu = new NguyenLieuService();
        }
        public fmNguyenLieu(DevExpress.XtraGrid.GridControl nguyenLieutbl)
        {
            InitializeComponent();
            nguyenLieuRepo = new ExRepository<NguyenLieu>();
            _nguyenLieu = new NguyenLieuService();
            FillData(nguyenLieutbl);
            LoadData(nguyenLieutbl);
        }

        public async void FillData(DevExpress.XtraGrid.GridControl nguyenLieutbl)
        {
            // Tạo một GridView và gán nó cho GridControl
            GridView gridView = gridView1;
            gridView.OptionsBehavior.AutoPopulateColumns = false;
            nguyenLieutbl.MainView = gridView;
            // Tạo và thêm cột vào GridView
            GridColumn stt = gridView.Columns.AddVisible("stt");
            GridColumn tenNguyenLieu = gridView.Columns.AddVisible("TenNguyenLieu");
            GridColumn loaiNguyenLieu = gridView.Columns.AddVisible("LoaiNguyenLieu");
            GridColumn donViDoTheoNam = gridView.Columns.AddVisible("DonViDoTheoNam");
            GridColumn tenHienThi = gridView.Columns.AddVisible("TenHienThiTieuThu");
            GridColumn suaCot = gridView.Columns.AddVisible("Sua");
            GridColumn xoaCot = gridView.Columns.AddVisible("Xoa");
            // Đặt tiêu đề cho cột (Caption)
            stt.Caption = "STT";
            tenNguyenLieu.Caption = "Tên nguyên liệu";
            loaiNguyenLieu.Caption = "Loai nguyên liệu";
            donViDoTheoNam.Caption = "Đơn vị đo";
            tenHienThi.Caption = "Tên hiển thị tiêu thụ";
            suaCot.Caption = "Sửa";
            xoaCot.Caption = "Xóa";
            // Đặt kiểu kiểm soát của cột (Column Edit)
            gridView.OptionsBehavior.Editable = false;
            gridView.OptionsView.ShowIndicator = false;
            //gridView.OptionsView.ShowGroupPanel = false;
            // fiel name 
            loaiNguyenLieu.FieldName = "LoaiNguyenLieu.TenLoai";
            donViDoTheoNam.FieldName = "DonViDoTheoNam.TenDonVi";
            // Thiết lập căn giữa cho văn bản trong cột ThaoTac
            stt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            //tenNguyenLieu.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            loaiNguyenLieu.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            donViDoTheoNam.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            //tenHienThi.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            suaCot.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            xoaCot.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            //Căn giữa header
            stt.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            tenNguyenLieu.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            loaiNguyenLieu.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            donViDoTheoNam.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            tenHienThi.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            suaCot.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            xoaCot.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            //set width
            stt.Width = 50; // Ví dụ: độ rộng cho cột "stt" là 50 pixel
            stt.MinWidth = 50;
            stt.MaxWidth = 50;
            tenNguyenLieu.Width = 230; // Ví dụ: độ rộng cho cột "Tên Công Ty" là 150 pixel
            tenNguyenLieu.MinWidth = 100;
            loaiNguyenLieu.Width = 230; // Ví dụ: độ rộng cho cột "Địa Chỉ" là 200 pixel
            loaiNguyenLieu.MinWidth = 100; // Ví dụ: độ rộng cho cột "Địa Chỉ" là 200 pixel
            donViDoTheoNam.Width = 250; // Ví dụ: độ rộng cho cột "Điện Thoại" là 100 pixel
            donViDoTheoNam.MinWidth = 100;
            tenHienThi.Width = 190; // Ví dụ: độ rộng cho cột "Người Liên Hệ" là 150 pixel
            tenHienThi.MinWidth = 100;
            suaCot.Width = 50;
            suaCot.MinWidth = 50;
            suaCot.MaxWidth = 50;
            xoaCot.Width = 50;
            xoaCot.MinWidth = 50;
            xoaCot.MaxWidth = 50;
            //bỏ auto size
            stt.OptionsColumn.FixedWidth = false;
            stt.OptionsColumn.AllowSize = false;
            stt.OptionsColumn.AllowMove = false;

            tenNguyenLieu.OptionsColumn.FixedWidth = false;
            tenNguyenLieu.OptionsColumn.AllowSize = false; // Ngăn người dùng kéo rộng/thu hẹp cột
            tenNguyenLieu.OptionsColumn.AllowMove = false; // Ngăn người dùng kéo cột

            loaiNguyenLieu.OptionsColumn.FixedWidth = false;
            loaiNguyenLieu.OptionsColumn.AllowSize = false;
            loaiNguyenLieu.OptionsColumn.AllowMove = false;

            donViDoTheoNam.OptionsColumn.FixedWidth = false;
            donViDoTheoNam.OptionsColumn.AllowSize = false;
            donViDoTheoNam.OptionsColumn.AllowMove = false;

            tenHienThi.OptionsColumn.FixedWidth = false;
            tenHienThi.OptionsColumn.AllowSize = false;
            tenHienThi.OptionsColumn.AllowMove = false;

            suaCot.OptionsColumn.FixedWidth = false;
            suaCot.OptionsColumn.AllowSize = false;
            suaCot.OptionsColumn.AllowMove = false;

            xoaCot.OptionsColumn.FixedWidth = false;
            xoaCot.OptionsColumn.AllowSize = false;
            xoaCot.OptionsColumn.AllowMove = false;
            // font chữ 
            stt.AppearanceHeader.Font = new Font(stt.AppearanceHeader.Font.FontFamily, 8, FontStyle.Bold);
            tenNguyenLieu.AppearanceHeader.Font = new Font(stt.AppearanceHeader.Font.FontFamily, 8, FontStyle.Bold);
            loaiNguyenLieu.AppearanceHeader.Font = new Font(stt.AppearanceHeader.Font.FontFamily, 8, FontStyle.Bold);
            donViDoTheoNam.AppearanceHeader.Font = new Font(stt.AppearanceHeader.Font.FontFamily, 8, FontStyle.Bold);
            tenHienThi.AppearanceHeader.Font = new Font(stt.AppearanceHeader.Font.FontFamily, 8, FontStyle.Bold);
            suaCot.AppearanceHeader.Font = new Font(stt.AppearanceHeader.Font.FontFamily, 8, FontStyle.Bold);
            xoaCot.AppearanceHeader.Font = new Font(stt.AppearanceHeader.Font.FontFamily, 8, FontStyle.Bold);

            stt.AppearanceCell.Font = new Font(stt.AppearanceHeader.Font.FontFamily, 8);
            tenNguyenLieu.AppearanceCell.Font = new Font(stt.AppearanceHeader.Font.FontFamily, 8);
            loaiNguyenLieu.AppearanceCell.Font = new Font(stt.AppearanceHeader.Font.FontFamily, 8);
            donViDoTheoNam.AppearanceCell.Font = new Font(stt.AppearanceHeader.Font.FontFamily, 8);
            tenHienThi.AppearanceCell.Font = new Font(stt.AppearanceHeader.Font.FontFamily, 8);
            //khong cho phep sua du lieu
            stt.OptionsColumn.AllowEdit = false;
            tenNguyenLieu.OptionsColumn.AllowEdit = false;
            loaiNguyenLieu.OptionsColumn.AllowEdit = false;
            donViDoTheoNam.OptionsColumn.AllowEdit = false;
            tenHienThi.OptionsColumn.AllowEdit = false;
            // setup btn 
            nguyenLieutbl.DataSource = nguyenLieutbl;
            // sua btn 
            RepositoryItemButtonEdit buttonEdit = new RepositoryItemButtonEdit();
            buttonEdit.Buttons[0].ImageOptions.ImageList = imageCollection1;
            buttonEdit.Buttons[0].ImageOptions.ImageIndex = 1;
            buttonEdit.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            buttonEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            suaCot.ColumnEdit = buttonEdit;
            // xoa btn 
            RepositoryItemButtonEdit buttonDelete = new RepositoryItemButtonEdit();
            buttonDelete.Buttons[0].ImageOptions.ImageList = imageCollection1;
            buttonDelete.Buttons[0].ImageOptions.ImageIndex = 0;
            buttonDelete.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            buttonDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            xoaCot.ColumnEdit = buttonDelete;
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
        }


        public async void LoadData(DevExpress.XtraGrid.GridControl nguyenLieutbl)
        {
            if (isSearch)
            {
                List<NguyenLieu> nguyenLieus = await _nguyenLieu.TimTenNguyenLieu(txt_search.Text);
                nguyenLieutbl.DataSource = nguyenLieus;
            }
            else
            {
                List<NguyenLieu> nguyenLieus = await _nguyenLieu.GetAllNguyenLieu();
                nguyenLieutbl.DataSource = nguyenLieus;
            }
        }
        private async void DeleteNL(DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            NguyenLieu nguyenLieu = gridView1.GetFocusedRow() as NguyenLieu;
            var dlg = MessageBox.Show("Bạn chắc chắn muốn xóa nguyên liệu này", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dlg == DialogResult.OK)
            {

                DialogResult dialog1 = MessageBox.Show("Bạn đã xóa dữ liệu thành công", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dialog1 == DialogResult.OK)
                {
                    await _nguyenLieu.XoaNguyenLieu(nguyenLieu.Id);
                    LoadData(nguyenLieutbl);
                }

            }
            else
            {
                LoadData(nguyenLieutbl);
            }
        }
        private void UpdateNL()
        {
            NguyenLieu nguyenLieu = gridView1.GetFocusedRow() as NguyenLieu;
            FormNguyenLieu formEdit = new FormNguyenLieu(nguyenLieu);
            var dlg = formEdit.ShowDialog();
            if (dlg == DialogResult.Cancel)
            {
                LoadData(nguyenLieutbl);
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            FormNguyenLieu formAdd = new FormNguyenLieu();
            var dlg = formAdd.ShowDialog();
            LoadData(nguyenLieutbl);
        }

        private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {

            if (e.Column.FieldName == "Xoa" && e.Button == System.Windows.Forms.MouseButtons.Left)
            {

                DeleteNL(e);
            }
            else if (e.Column.FieldName == "Sua" && e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                UpdateNL();
            }
        }

        private void nguyenLieutbl_Load(object sender, EventArgs e)
        {
            LoadData(nguyenLieutbl);
        }
        private bool isSearch = false;
        private async void button1_Click(object sender, EventArgs e)
        {
            if (txt_search.Text == "")
            {
                List<NguyenLieu> nguyenLieus = await _nguyenLieu.GetAllNguyenLieu();
                nguyenLieutbl.DataSource = nguyenLieus;
            }
            else
            {
                List<NguyenLieu> nguyenLieus = await _nguyenLieu.TimTenNguyenLieu(txt_search.Text);
                nguyenLieutbl.DataSource = nguyenLieus;
                isSearch = true;
            }
            LoadData(nguyenLieutbl);
        }
    }
}