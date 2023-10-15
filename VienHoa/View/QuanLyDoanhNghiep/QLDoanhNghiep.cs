using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.XtraDialogs.FileExplorerExtensions;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraExport.Helpers;
using DevExpress.XtraGrid;
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
using System.Windows.Controls;
using System.Windows.Forms;
using VienHoa.Common;
using VienHoa.DataEx;
using VienHoa.Entity;
using VienHoa.Enums;
using VienHoa.IService;
using VienHoa.Service;
using GridView = DevExpress.XtraGrid.Views.Grid.GridView;

namespace VienHoa.View
{
    public partial class QLDoanhNghiep : DevExpress.XtraEditors.XtraForm
    {
        private readonly IQLDoanhNghiep qLDoanhNghiep;
        private readonly IRepository<DoanhNghiep> doanhNghiepRepos;
        public QLDoanhNghiep()
        {
            InitializeComponent();
            doanhNghiepRepos = new ExRepository<DoanhNghiep>();
            qLDoanhNghiep = new QLDoanhNghiepServices();
            ReLoaddata();
        }
        public QLDoanhNghiep(DevExpress.XtraGrid.GridControl gridControlDataDoanhNghiep)
        {
            InitializeComponent();
            doanhNghiepRepos = new ExRepository<DoanhNghiep>();
            qLDoanhNghiep = new QLDoanhNghiepServices();
            FillData(gridControlDataDoanhNghiep);
        }
        public DoanhNghiep SelectedDoanhNghiep { get; private set; }

        //search 

        //
        private void Loaddata(DevExpress.XtraGrid.GridControl gridControlDataDoanhNghiep)
        {
            List<DoanhNghiep> doanhNghieps = doanhNghiepRepos.TableUntracked.ToList();
            GridView gridView = gridView1;
            SetupGridViewColumns(gridView);
            gridView.OptionsBehavior.AutoPopulateColumns = false;
            gridControlDataDoanhNghiep.MainView = gridView;
            gridView.GridControl.DataSource = doanhNghieps;
        }


        private void ReLoaddata()
        {
            List<DoanhNghiep> doanhNghieps = doanhNghiepRepos.TableUntracked.ToList();
            GridView gridView = gridView1;
            gridView.GridControl.DataSource = doanhNghieps;
        }
        //tạo gridview
        private void SetupGridViewColumns(GridView gridView)
        {

            GridColumn stt = gridView.Columns.AddVisible("stt");
            stt.Caption = "STT";
            stt.VisibleIndex = 1;
            stt.UnboundDataType = typeof(int);

            GridColumn tenDoanhNghiep = gridView.Columns.AddVisible("TenCongTy");
            tenDoanhNghiep.Caption = "Tên Công ty";
            tenDoanhNghiep.VisibleIndex = 0;

            GridColumn diaChi = gridView.Columns.AddVisible("DiaChi");
            diaChi.Caption = "Địa Chỉ";
            diaChi.VisibleIndex = 2;

            GridColumn sdt = gridView.Columns.AddVisible("DienThoai");
            sdt.Caption = "Số điện thoại";
            sdt.VisibleIndex = 3;

            GridColumn nguoiLienHe = gridView.Columns.AddVisible("NguoiLienHe");
            nguoiLienHe.Caption = "Người Liên Hệ";
            nguoiLienHe.VisibleIndex = 4;

            GridColumn quocgia = gridView.Columns.AddVisible("QuocGia");
            quocgia.Caption = "Quốc Gia";
            quocgia.VisibleIndex = 5;

            GridColumn Sua = gridView.Columns.AddVisible("Sua");
            Sua.Caption = "Sửa";
            Sua.VisibleIndex = 6;

            GridColumn Xoa = gridView.Columns.AddVisible("Xoa");
            Xoa.Caption = "Xóa";
            Xoa.VisibleIndex = 7;

            RepositoryItemButtonEdit buttonEdit = new RepositoryItemButtonEdit();
            buttonEdit.Buttons[0].Caption = "Nút 1";
            buttonEdit.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            buttonEdit.Buttons[0].ImageOptions.ImageList = imageCollection1;
            buttonEdit.Buttons[0].ImageOptions.ImageIndex = 0;
            buttonEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            Sua.ColumnEdit = buttonEdit;

            buttonEdit.Buttons[0].Click += (s, args) =>
            {
                int rowIndex = gridView.FocusedRowHandle;
                if (rowIndex >= 0)
                {
                    DoanhNghiep selectedDoanhNghiep = gridView.GetRow(rowIndex) as DoanhNghiep;

                    if (selectedDoanhNghiep != null)
                    {
                        FromSuaDoanhNghiep form = new FromSuaDoanhNghiep(selectedDoanhNghiep);
                        form.ShowDialog();
                        ReLoaddata();
                    }
                }
            };

            RepositoryItemButtonEdit buttonDelete = new RepositoryItemButtonEdit();
            buttonDelete.Buttons[0].Caption = "Nút 2";
            buttonDelete.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            buttonDelete.Buttons[0].ImageOptions.ImageList = imageCollection1;
            buttonDelete.Buttons[0].ImageOptions.ImageIndex = 1;
            buttonDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            Xoa.ColumnEdit = buttonDelete;
            buttonDelete.Buttons[0].Click += async (s, args) =>
            {
                int rowIndex = gridView.FocusedRowHandle;
                if (rowIndex >= 0)
                {
                    DoanhNghiep selectedDoanhNghiep = gridView.GetRow(rowIndex) as DoanhNghiep;

                    if (selectedDoanhNghiep != null)
                    {
                        List<DoanhNghiep> selectedRows = new List<DoanhNghiep> { selectedDoanhNghiep };
                        await DeleteSelectedDoanhNghiep(selectedRows);
                    }
                }
            };
            //size text
            
            stt.Width = 40;
            stt.MinWidth = 40;
            stt.MaxWidth = 40;
            tenDoanhNghiep.Width = 400;
            tenDoanhNghiep.MinWidth = 100;
            diaChi.Width = 200;
            diaChi.MinWidth = 100;
            sdt.Width = 180;
            stt.MinWidth = 100;
            nguoiLienHe.Width = 200;
            nguoiLienHe.MinWidth = 100;
            quocgia.Width = 200;
            quocgia.MinWidth = 100;
            Sua.Width = 40;
            Sua.MinWidth = 40;
            Sua.MaxWidth = 40;
            Xoa.Width = 40;
            Xoa.MaxWidth = 40;
            Xoa.MinWidth = 40;

            // set allowedit
            stt.OptionsColumn.AllowEdit = false;
            tenDoanhNghiep.OptionsColumn.AllowEdit = false;
            diaChi.OptionsColumn.AllowEdit = false;
            sdt.OptionsColumn.AllowEdit = false;
            nguoiLienHe.OptionsColumn.AllowEdit = false;
            quocgia.OptionsColumn.AllowEdit = false;

            //FontStyle
            stt.AppearanceHeader.Font = new Font(stt.AppearanceHeader.Font.FontFamily, 8, FontStyle.Bold);
            tenDoanhNghiep.AppearanceHeader.Font = new Font(stt.AppearanceHeader.Font.FontFamily, 8, FontStyle.Bold);
            diaChi.AppearanceHeader.Font = new Font(stt.AppearanceHeader.Font.FontFamily, 8, FontStyle.Bold);
            sdt.AppearanceHeader.Font = new Font(stt.AppearanceHeader.Font.FontFamily, 8, FontStyle.Bold);
            nguoiLienHe.AppearanceHeader.Font = new Font(stt.AppearanceHeader.Font.FontFamily, 8, FontStyle.Bold);
            Sua.AppearanceHeader.Font = new Font(stt.AppearanceHeader.Font.FontFamily, 8, FontStyle.Bold);
            Xoa.AppearanceHeader.Font = new Font(stt.AppearanceHeader.Font.FontFamily, 8, FontStyle.Bold);
            quocgia.AppearanceHeader.Font = new Font(stt.AppearanceHeader.Font.FontFamily, 8, FontStyle.Bold);


            stt.AppearanceCell.Font = new Font(stt.AppearanceHeader.Font.FontFamily, 8);
            tenDoanhNghiep.AppearanceCell.Font = new Font(stt.AppearanceHeader.Font.FontFamily, 8);
            diaChi.AppearanceCell.Font = new Font(stt.AppearanceHeader.Font.FontFamily, 8);
            sdt.AppearanceCell.Font = new Font(stt.AppearanceHeader.Font.FontFamily, 8);
            nguoiLienHe.AppearanceCell.Font = new Font(stt.AppearanceHeader.Font.FontFamily, 8);
            Sua.AppearanceCell.Font = new Font(stt.AppearanceHeader.Font.FontFamily, 8);
            Xoa.AppearanceCell.Font = new Font(stt.AppearanceHeader.Font.FontFamily, 8);
            quocgia.AppearanceCell.Font = new Font(stt.AppearanceHeader.Font.FontFamily, 8);

            Sua.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            Sua.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            stt.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            stt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            Xoa.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            Xoa.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

        }

        private  void FillData(GridControl gridControl)
        {
            // Thêm cột cho gridView
            GridColumn stt = gridView1.Columns.AddVisible("stt");
            GridColumn tenDoanhNghiep = gridView1.Columns.AddVisible("TenCongTy");
            GridColumn diaChi = gridView1.Columns.AddVisible("DiaChi");
            GridColumn sdt = gridView1.Columns.AddVisible("DienThoai");
            GridColumn nguoiLienHe = gridView1.Columns.AddVisible("NguoiLienHe");
            GridColumn quocgia = gridView1.Columns.AddVisible("QuocGia");
            GridColumn edit = gridView1.Columns.AddVisible("edit");
            GridColumn delete = gridView1.Columns.AddVisible("delete");
            //
            // Custom cột stt
            // 
            stt.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            stt.AppearanceCell.Options.UseFont = true;
            stt.AppearanceCell.Options.UseTextOptions = true;
            stt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            stt.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            stt.AppearanceHeader.Options.UseFont = true;
            stt.AppearanceHeader.Options.UseTextOptions = true;
            stt.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            stt.Caption = "STT";
            stt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            stt.MaxWidth = 40;
            stt.MinWidth = 40;
            stt.UnboundDataType = typeof(int);
            stt.Visible = true;
            stt.VisibleIndex = 0;
            stt.Width = 40;
            stt.OptionsColumn.AllowEdit = false;
            // 
            // tên doanh nghiệp
            // 
            tenDoanhNghiep.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            tenDoanhNghiep.AppearanceCell.Options.UseFont = true;
            tenDoanhNghiep.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            tenDoanhNghiep.AppearanceHeader.Options.UseFont = true;
            tenDoanhNghiep.Caption = "Tên doanh nghiệp";
            tenDoanhNghiep.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            tenDoanhNghiep.Width = 220;
            tenDoanhNghiep.Visible = true;
            tenDoanhNghiep.VisibleIndex = 1;
            tenDoanhNghiep.OptionsColumn.AllowEdit = false;
            // 
            // cột địa chỉ
            // 
            diaChi.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            diaChi.AppearanceCell.Options.UseFont = true;
            diaChi.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            diaChi.AppearanceHeader.Options.UseFont = true;
            diaChi.Caption = "Địa chỉ";
            diaChi.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            diaChi.Width = 180;
            diaChi.Visible = true;
            diaChi.VisibleIndex = 2;
            diaChi.OptionsColumn.AllowEdit = false;
            // 
            // cột sdt
            // 
            sdt.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            sdt.AppearanceCell.Options.UseFont = true;
            sdt.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            sdt.AppearanceHeader.Options.UseFont = true;
            sdt.Caption = "Số điện thoại";
            sdt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            sdt.Width = 120;
            sdt.Visible = true;
            sdt.VisibleIndex = 3;
            sdt.OptionsColumn.AllowEdit = false;
            // 
            // cột ng liên hệ
            // 
            nguoiLienHe.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            nguoiLienHe.AppearanceCell.Options.UseFont = true;
            nguoiLienHe.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            nguoiLienHe.AppearanceHeader.Options.UseFont = true;
            nguoiLienHe.Caption = "Người liên hệ";
            nguoiLienHe.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            nguoiLienHe.Width = 180;
            nguoiLienHe.Visible = true;
            nguoiLienHe.VisibleIndex = 4;
            nguoiLienHe.OptionsColumn.AllowEdit = false;
            // 
            // cột quốc gia
            // 
            quocgia.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            quocgia.AppearanceCell.Options.UseFont = true;
            quocgia.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            quocgia.AppearanceHeader.Options.UseFont = true;
            quocgia.Caption = "Quốc gia";
            quocgia.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            quocgia.Width = 180;
            quocgia.Visible = true;
            quocgia.VisibleIndex = 5;
            quocgia.OptionsColumn.AllowEdit = false;
            // 
            // Tạo nút sửa
            //
            RepositoryItemButtonEdit buttonEdit = new RepositoryItemButtonEdit();
            buttonEdit.Buttons[0].Caption = "Nút 1";
            buttonEdit.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            buttonEdit.Buttons[0].ImageOptions.ImageList = imageCollection1;
            buttonEdit.Buttons[0].ImageOptions.ImageIndex = 0;
            buttonEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            edit.ColumnEdit = buttonEdit;

            buttonEdit.Buttons[0].Click += (s, args) =>
            {
                int rowIndex = gridView1.FocusedRowHandle;
                if (rowIndex >= 0)
                {
                    DoanhNghiep selectedDoanhNghiep = gridView1.GetRow(rowIndex) as DoanhNghiep;

                    if (selectedDoanhNghiep != null)
                    {
                        FromSuaDoanhNghiep form = new FromSuaDoanhNghiep(selectedDoanhNghiep);
                        form.ShowDialog();
                        ReLoaddata();
                    }
                }
            };

            RepositoryItemButtonEdit buttonDelete = new RepositoryItemButtonEdit();
            buttonDelete.Buttons[0].Caption = "Nút 2";
            buttonDelete.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            buttonDelete.Buttons[0].ImageOptions.ImageList = imageCollection1;
            buttonDelete.Buttons[0].ImageOptions.ImageIndex = 1;
            buttonDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            delete.ColumnEdit = buttonDelete;
            buttonDelete.Buttons[0].Click += async (s, args) =>
            {
                int rowIndex = gridView1.FocusedRowHandle;
                if (rowIndex >= 0)
                {
                    DoanhNghiep selectedDoanhNghiep = gridView1.GetRow(rowIndex) as DoanhNghiep;

                    if (selectedDoanhNghiep != null)
                    {
                        List<DoanhNghiep> selectedRows = new List<DoanhNghiep> { selectedDoanhNghiep };
                        await DeleteSelectedDoanhNghiep(selectedRows);
                    }
                }
            };
            //
            // Custom cột Sửa
            // 
            edit.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            edit.AppearanceCell.Options.UseFont = true;
            edit.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            edit.AppearanceHeader.Options.UseFont = true;
            edit.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            edit.Caption = "Sửa";
            edit.MaxWidth = 40;
            edit.MinWidth = 40;
            edit.Visible = true;
            edit.VisibleIndex = 6;
            // 
            // Custom cột Xóa
            // 
            delete.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            delete.AppearanceCell.Options.UseFont = true;
            delete.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            delete.AppearanceHeader.Options.UseFont = true;
            delete.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            delete.Caption = "Xóa";
            delete.MaxWidth = 40;
            delete.MinWidth = 40;
            delete.Visible = true;
            delete.VisibleIndex = 7;

            gridControl.MainView = gridView1;
            ReLoaddata();
        }
        //thuộc tính col


        //showDialog Thêm
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //new FromThemDoanhNghiep().ShowDialog();
            //gridView.RefreshData();
        }

        #region Xóa 
        // Xóa
        private async Task DeleteSelectedDoanhNghiep(List<DoanhNghiep> selectedRows)
        {
            string mes = "Bạn chắc chắn muốn xóa " + (selectedRows.Count > 1 ? selectedRows.Count.ToString() : "doanh nghiệp?");

            if (MessageBox.Show(mes, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                foreach (DoanhNghiep dn in selectedRows)
                {
                    var result = await qLDoanhNghiep.DeleteDoanhNghiep(dn);

                    if (result == InputHellperDoanhNghiep.thanhCong)
                    {
                        ReLoaddata();
                    }
                    else if (result == InputHellperDoanhNghiep.thatBai)
                    {
                        MessageBox.Show("Xóa doanh nghiệp thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        #endregion


        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "stt" && e.IsGetData)
            {
                e.Value = e.ListSourceRowIndex + 1; // Tính toán số thứ tự (bắt đầu từ 1)
            }
        }
    }
}