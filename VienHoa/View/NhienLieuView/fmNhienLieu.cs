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
using VienHoa.Common;
using VienHoa.DataEx;
using VienHoa.Entity;
using VienHoa.IService;
using VienHoa.Service;
using DevExpress.Pdf.Native;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using DevExpress.XtraGrid.Views.Base;

namespace VienHoa.View
{
    public partial class fmNhienLieu : DevExpress.XtraEditors.XtraForm
    {
        private readonly IRepository<NhienLieu> nhienLieuRepo;
        private readonly INhienLieu _nhienLieu;
        public fmNhienLieu(DevExpress.XtraGrid.GridControl nhienLieutbl)
        {
            InitializeComponent();
            nhienLieuRepo = new ExRepository<NhienLieu>();
            _nhienLieu = new NhienLieuService();
            FillData(nhienLieutbl);
            LoadData(nhienLieutbl);
        }
        public fmNhienLieu()
        {
            InitializeComponent();
            nhienLieuRepo = new ExRepository<NhienLieu>();
            _nhienLieu = new NhienLieuService();
        }

        public async void FillData(DevExpress.XtraGrid.GridControl nhienLieutbl)
        {
            // Tạo một GridView và gán nó cho GridControl
            GridView gridView = gridView2;
            gridView.OptionsBehavior.AutoPopulateColumns = false;
            nhienLieutbl.MainView = gridView;
            // Tạo và thêm cột vào GridView
            GridColumn stt = gridView.Columns.AddVisible("stt");
            GridColumn tenNhienLieu = gridView.Columns.AddVisible("TenNhienLieu");
            GridColumn loaiNhienLieu = gridView.Columns.AddVisible("LoaiNhienLieu");
            GridColumn donViDoTheoNam = gridView.Columns.AddVisible("DonViDoTheoNam");
            GridColumn tenHienThi = gridView.Columns.AddVisible("TenHienThiTieuThu");
            GridColumn nhietTriRieng = gridView.Columns.AddVisible("NhietTriRieng");
            GridColumn suaCot = gridView.Columns.AddVisible("Sua");
            GridColumn xoaCot = gridView.Columns.AddVisible("Xoa");
            // Đặt tiêu đề cho cột (Caption)
            stt.Caption = "STT";
            tenNhienLieu.Caption = "Tên nhiên liệu";
            loaiNhienLieu.Caption = "Loai nhiên";
            donViDoTheoNam.Caption = "Đơn vị đo";
            tenHienThi.Caption = "Tên hiển thị tiêu thụ";
            nhietTriRieng.Caption = "Nhiệt trị riêng";
            suaCot.Caption = "Sửa";
            xoaCot.Caption = "Xóa";
            // Đặt kiểu kiểm soát của cột (Column Edit)
            gridView.OptionsBehavior.Editable = false;
            gridView.OptionsView.ShowIndicator = false;
           // gridView.OptionsView.ShowGroupPanel = false;
            // fiel name 
            loaiNhienLieu.FieldName = "LoaiNhienLieu.TenLoai";
            donViDoTheoNam.FieldName = "DonViDoTheoNam.TenDonVi";
            // Thiết lập căn giữa cho văn bản trong cột ThaoTac
            stt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            //tenNhienLieu.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            loaiNhienLieu.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            donViDoTheoNam.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            //tenHienThi.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            nhietTriRieng.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            suaCot.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            xoaCot.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            //Căn giữa header
            stt.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            tenNhienLieu.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            loaiNhienLieu.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            donViDoTheoNam.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            tenHienThi.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            nhietTriRieng.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            suaCot.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            xoaCot.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            //set width
            stt.Width = 50; // Ví dụ: độ rộng cho cột "stt" là 50 pixel
            stt.MinWidth = 50; 
            stt.MaxWidth = 50; 
            tenNhienLieu.Width = 230; // Ví dụ: độ rộng cho cột "Tên Công Ty" là 150 pixel
            tenNhienLieu.MinWidth = 100; 
            loaiNhienLieu.Width = 230; // Ví dụ: độ rộng cho cột "Địa Chỉ" là 200 pixel
            loaiNhienLieu.MinWidth = 100;
            donViDoTheoNam.Width = 150; // Ví dụ: độ rộng cho cột "Điện Thoại" là 100 pixel
            donViDoTheoNam.MinWidth = 100; 
            tenHienThi.Width = 190; // Ví dụ: độ rộng cho cột "Người Liên Hệ" là 150 pixel
            tenHienThi.MinWidth = 100;
            nhietTriRieng.Width = 100;
            nhietTriRieng.MinWidth = 50;

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

            tenNhienLieu.OptionsColumn.FixedWidth = false;
            tenNhienLieu.OptionsColumn.AllowSize = false; // Ngăn người dùng kéo rộng/thu hẹp cột
            tenNhienLieu.OptionsColumn.AllowMove = false; // Ngăn người dùng kéo cột

            loaiNhienLieu.OptionsColumn.FixedWidth = false;
            loaiNhienLieu.OptionsColumn.AllowSize = false;
            loaiNhienLieu.OptionsColumn.AllowMove = false;

            donViDoTheoNam.OptionsColumn.FixedWidth = false;
            donViDoTheoNam.OptionsColumn.AllowSize = false;
            donViDoTheoNam.OptionsColumn.AllowMove = false;

            tenHienThi.OptionsColumn.FixedWidth = false;
            tenHienThi.OptionsColumn.AllowSize = false;
            tenHienThi.OptionsColumn.AllowMove = false;

            nhietTriRieng.OptionsColumn.FixedWidth = false;
            nhietTriRieng.OptionsColumn.AllowSize = false;
            nhietTriRieng.OptionsColumn.AllowMove = false;

            suaCot.OptionsColumn.FixedWidth = false;
            suaCot.OptionsColumn.AllowSize = false;
            suaCot.OptionsColumn.AllowMove = false;

            xoaCot.OptionsColumn.FixedWidth = false;
            xoaCot.OptionsColumn.AllowSize = false;
            xoaCot.OptionsColumn.AllowMove = false;
            // font chữ 
            stt.AppearanceHeader.Font = new Font(stt.AppearanceHeader.Font.FontFamily, 8, FontStyle.Bold);
            tenNhienLieu.AppearanceHeader.Font = new Font(stt.AppearanceHeader.Font.FontFamily, 8, FontStyle.Bold);
            loaiNhienLieu.AppearanceHeader.Font = new Font(stt.AppearanceHeader.Font.FontFamily, 8, FontStyle.Bold);
            donViDoTheoNam.AppearanceHeader.Font = new Font(stt.AppearanceHeader.Font.FontFamily, 8, FontStyle.Bold);
            tenHienThi.AppearanceHeader.Font = new Font(stt.AppearanceHeader.Font.FontFamily, 8, FontStyle.Bold);
            nhietTriRieng.AppearanceHeader.Font = new Font(stt.AppearanceHeader.Font.FontFamily, 8, FontStyle.Bold);
            suaCot.AppearanceHeader.Font = new Font(stt.AppearanceHeader.Font.FontFamily, 8, FontStyle.Bold);
            xoaCot.AppearanceHeader.Font = new Font(stt.AppearanceHeader.Font.FontFamily, 8, FontStyle.Bold);

            stt.AppearanceCell.Font = new Font(stt.AppearanceHeader.Font.FontFamily, 8);
            tenNhienLieu.AppearanceCell.Font = new Font(stt.AppearanceHeader.Font.FontFamily, 8);
            loaiNhienLieu.AppearanceCell.Font = new Font(stt.AppearanceHeader.Font.FontFamily, 8);
            donViDoTheoNam.AppearanceCell.Font = new Font(stt.AppearanceHeader.Font.FontFamily, 8);
            tenHienThi.AppearanceCell.Font = new Font(stt.AppearanceHeader.Font.FontFamily, 8);
            nhietTriRieng.AppearanceCell.Font = new Font(stt.AppearanceHeader.Font.FontFamily, 8);
            // setup btn 
            nhienLieutbl.DataSource = nhienLieutbl;
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


        public async void LoadData(DevExpress.XtraGrid.GridControl nhienLieutbl)
        {
            List<NhienLieu> nguyenLieus = await _nhienLieu.GetAllNhienLieu();
            nhienLieutbl.DataSource = nguyenLieus;
        }
        private async void DeleteNL(DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            NhienLieu nhienLieu = gridView2.GetFocusedRow() as NhienLieu;
            var dlg = MessageBox.Show("Bạn chắc chắn muốn xóa nhiên liệu này", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dlg == DialogResult.OK)
            {
                
                DialogResult dialog1 = MessageBox.Show("Bạn đã xóa dữ liệu thành công", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dialog1 == DialogResult.OK)
                {
                    await _nhienLieu.XoaNhienLieu(nhienLieu.Id);
                    LoadData(nhienLieutbl);
                }
            }
            else
            {
                LoadData(nhienLieutbl);
            }
        }
        private void UpdateNL()
        {
            NhienLieu nhienLieu = gridView2.GetFocusedRow() as NhienLieu;
            FormNhienLieu formEdit = new FormNhienLieu(nhienLieu);
            var dlg = formEdit.ShowDialog();
            if (dlg == DialogResult.Cancel)
            {
                LoadData(nhienLieutbl);
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            FormNhienLieu formAdd = new FormNhienLieu();
            var dlg = formAdd.ShowDialog();
            LoadData(nhienLieutbl);
        }

        private void gridView2_RowCellClick_1(object sender, RowCellClickEventArgs e)
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
    }
}