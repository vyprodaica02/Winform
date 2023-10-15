using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraExport.Helpers;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using Microsoft.EntityFrameworkCore;
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
using VienHoa.Service;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace VienHoa.View
{
    public partial class NhaMayView_Modified : DevExpress.XtraEditors.XtraForm
    {
        private NhaMayService Service;
        private IRepository<NhaMay> Repository;


        public NhaMayView_Modified(GridControl tBlControl)
        {
            InitializeComponent();
            Service = new NhaMayService();
            Repository = new ExRepository<NhaMay>();
            nhaMayTbl = tBlControl;

            //gridView.OptionsBehavior.AutoPopulateColumns = false;
            factorView.OptionsBehavior.AutoPopulateColumns = false;
            tBlControl.MainView = factorView;
            CreateTable();
            FillData();
        }

        public NhaMayView_Modified()
        {
            Repository = new ExRepository<NhaMay>();
        }


        #region createTable
        private void CreateTable()
        {
            // Initialize columns:
            GridColumn STT = factorView.Columns.AddVisible("STT");
            GridColumn DoanhNghiepId = factorView.Columns.AddVisible("DoanhNghiep.TenCongTy");
            GridColumn TenNhaMay = factorView.Columns.AddVisible("TenNhaMay");
            GridColumn ViTri = factorView.Columns.AddVisible("ViTri");
            GridColumn TyleCoPhan = factorView.Columns.AddVisible("TiLeCoPhan");
            GridColumn LoaiLoNung = factorView.Columns.AddVisible("LoaiLoNung.TenLoaiLo");
            GridColumn LoaiNhaMay = factorView.Columns.AddVisible("LoaiNhaMay.TenLoai");
            GridColumn CongSuatThietKeId = factorView.Columns.AddVisible("CongSuatThietKe.CongSuatDinhMuc");
            GridColumn Update = factorView.Columns.AddVisible("Modified_UP");
            GridColumn Delete = factorView.Columns.AddVisible("Modifed_Del");

            // Set title column:
            STT.Caption = "STT"; STT.VisibleIndex = 0;
            DoanhNghiepId.Caption = "Tên công ty"; DoanhNghiepId.VisibleIndex = 1;
            TenNhaMay.Caption = "Tên Nhà máy"; TenNhaMay.VisibleIndex = 2;
            ViTri.Caption = "Vị trí"; ViTri.VisibleIndex = 3;
            TyleCoPhan.Caption = "Tỷ lệ cổ phần"; TyleCoPhan.VisibleIndex = 4;
            LoaiLoNung.Caption = "Loại lò nung"; LoaiLoNung.VisibleIndex = 5;
            LoaiNhaMay.Caption = "Loại Nhà máy"; LoaiNhaMay.VisibleIndex = 6;
            CongSuatThietKeId.Caption = "Công suất"; CongSuatThietKeId.VisibleIndex = 7;
            Update.Caption = "Sửa"; Update.VisibleIndex = 8;
            Delete.Caption = "Xóa"; Delete.VisibleIndex = 9;

            STT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            // Set align center for header
            STT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            STT.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8, FontStyle.Bold);
            STT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            DoanhNghiepId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            DoanhNghiepId.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8, FontStyle.Bold);
            TenNhaMay.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            TenNhaMay.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8, FontStyle.Bold);
            ViTri.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            ViTri.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8, FontStyle.Bold);
            TyleCoPhan.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            TyleCoPhan.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8, FontStyle.Bold);
            TyleCoPhan.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            LoaiLoNung.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            LoaiLoNung.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8, FontStyle.Bold);
            LoaiNhaMay.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            LoaiNhaMay.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8, FontStyle.Bold);
            CongSuatThietKeId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            CongSuatThietKeId.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8, FontStyle.Bold);
            CongSuatThietKeId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            Update.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            Update.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8, FontStyle.Bold);
            Delete.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            Delete.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8, FontStyle.Bold);

            // Set 2 function button ~ Update/Delete:
            RepositoryItemButtonEdit btnUpdate = new RepositoryItemButtonEdit();
            btnUpdate.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            btnUpdate.Buttons[0].ImageOptions.ImageList = imageCollection1;
            btnUpdate.Buttons[0].ImageOptions.ImageIndex = 0;
            btnUpdate.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            btnUpdate.Buttons[0].Click += btn_UpdateClick;
            Update.ColumnEdit = btnUpdate;

            RepositoryItemButtonEdit btnDelete = new RepositoryItemButtonEdit();
            btnDelete.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            btnDelete.Buttons[0].ImageOptions.ImageList = imageCollection1;
            btnDelete.Buttons[0].ImageOptions.ImageIndex = 1;
            btnDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            btnDelete.Buttons[0].Click += btn_DeleteClick;
            Delete.ColumnEdit = btnDelete;

            // Set align center for icon in two last column:
            Update.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            Delete.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            // Set width manually:
            STT.Width = 50; // -> STT Column have width =20px;
            STT.MinWidth = 50; 
            STT.MaxWidth = 50; 

            DoanhNghiepId.Width = 170;
            TenNhaMay.Width = 150;
            ViTri.Width = 130;
            TyleCoPhan.Width = 80;
            LoaiLoNung.Width = 90;
            LoaiNhaMay.Width = 90;
            CongSuatThietKeId.Width = 90;

            Update.Width = 50;
            Update.MinWidth = 50;
            Update.MaxWidth = 50;
            Delete.Width = 50;
            Delete.MinWidth = 50;
            Delete.MaxWidth = 50;

            // set allowedit
            STT.OptionsColumn.AllowEdit = false;
            DoanhNghiepId.OptionsColumn.AllowEdit = false;
            TenNhaMay.OptionsColumn.AllowEdit = false;
            ViTri.OptionsColumn.AllowEdit = false;
            TyleCoPhan.OptionsColumn.AllowEdit = false;
            LoaiLoNung.OptionsColumn.AllowEdit = false;
            LoaiNhaMay.OptionsColumn.AllowEdit = false;
            CongSuatThietKeId.OptionsColumn.AllowEdit = false;

            // Allow to dynamically display in cell but prevent change initial width
            STT.OptionsColumn.FixedWidth = false;
            STT.OptionsColumn.AllowSize = false; //Prevent user to drag/pull/chane the init width
            STT.OptionsColumn.AllowMove = false; // Same as above
            DoanhNghiepId.OptionsColumn.FixedWidth = false;
            DoanhNghiepId.OptionsColumn.AllowSize = false;
            DoanhNghiepId.OptionsColumn.AllowMove = false;
            TenNhaMay.OptionsColumn.FixedWidth = false;
            TenNhaMay.OptionsColumn.AllowSize = false;
            TenNhaMay.OptionsColumn.AllowMove = false;
            ViTri.OptionsColumn.FixedWidth = false;
            ViTri.OptionsColumn.AllowSize = false;
            ViTri.OptionsColumn.AllowMove = false;
            TyleCoPhan.OptionsColumn.FixedWidth = false;
            TyleCoPhan.OptionsColumn.AllowSize = false;
            TyleCoPhan.OptionsColumn.AllowMove = false;
            LoaiLoNung.OptionsColumn.FixedWidth = false;
            LoaiLoNung.OptionsColumn.AllowSize = false;
            LoaiLoNung.OptionsColumn.AllowMove = false;
            LoaiNhaMay.OptionsColumn.FixedWidth = false;
            LoaiNhaMay.OptionsColumn.AllowSize = false;
            LoaiNhaMay.OptionsColumn.AllowMove = false;
            CongSuatThietKeId.OptionsColumn.FixedWidth = false;
            CongSuatThietKeId.OptionsColumn.AllowSize = false;
            CongSuatThietKeId.OptionsColumn.AllowMove = false;
            Update.OptionsColumn.FixedWidth = false;
            Update.OptionsColumn.AllowSize = false;
            Update.OptionsColumn.AllowMove = false;
            Delete.OptionsColumn.FixedWidth = false;
            Delete.OptionsColumn.AllowSize = false;
            Delete.OptionsColumn.AllowMove = false;

            //Config the identity for STT Column
            STT.UnboundDataType = typeof(int);
            factorView.CustomUnboundColumnData += (sender, e) =>
            {
                if (e.Column == STT && e.IsGetData)
                {
                    e.Value = e.ListSourceRowIndex + 1;
                }
            };
            factorView.OptionsView.ShowIndicator = false;
        }
        #endregion

        #region initialize
        public void FillData()
        {
            // Process column expect Indexing
            var dataList = Repository.DbSet()
                .Include(x => x.LoaiLoNung)
                .Include(x => x.LoaiNhaMay)
                .Include(x => x.DoanhNghiep)
                .Include(x => x.CongSuatThietKe)
                .ToList();
            nhaMayTbl.DataSource = dataList;
        }

        public void Reload_data(GridControl tblControl)
        {
            // Process column expect Indexing
            var dataList = Repository.DbSet()
                .Include(x => x.LoaiLoNung)
                .Include(x => x.LoaiNhaMay)
                .Include(x => x.DoanhNghiep)
                .Include(x => x.CongSuatThietKe)
                .ToList();
            tblControl.DataSource = dataList;
        }

        #endregion

        // addFunction not neccessary

        #region rendering
        /*private void gridView_CustomDrawDeleteCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == factorView.Columns[9])
            {
                NhaMay Nm = factorView.GetRow(e.RowHandle) as NhaMay;

                if (Nm != null)
                {
                    // Determine if the cell is in the selected row
                    bool isSelectedRow = e.RowHandle == factorView.FocusedRowHandle;

                    // Set the AppearanceDisabled property based on whether the row is selected
                    e.Appearance.Options.UseBackColor = true;
                    e.Appearance.BackColor = isSelectedRow ? Color.Transparent : Color.Gray;

                    // Prevent default rendering if the row is not selected
                    if (!isSelectedRow)
                    {
                        e.Handled = true;
                    }
                }
            }
        }*/
        #endregion

        #region Update
        private async void btn_UpdateClick(object sender, EventArgs e)
        {
            await UpdateObjectClick(sender, e);
        }

        private async Task UpdateObjectClick(object sender, EventArgs e)
        {
            // retrive the current infor of object:
            NhaMay Nm = factorView.GetFocusedRow() as NhaMay;
            // Process form
            using UpdateInfor upInfor = new UpdateInfor(Nm.Id, Nm.DoanhNghiepId, Nm.LoaiNhaMayId, Nm.LoaiLoNungId,
                Nm.CongSuatThietKeId, Nm.TenNhaMay, Nm.ViTri, Nm.CongSuatThietKeId);
            {
                DialogResult res = upInfor.ShowDialog();
                if (res == DialogResult.OK)
                {
                    Nm.DoanhNghiepId = upInfor.DoanhNghiepId;
                    Nm.LoaiLoNungId = upInfor.LoaiLoNungId;
                    Nm.LoaiNhaMayId = upInfor.LoaiNhaMayId;
                    Nm.CongSuatThietKeId = upInfor.CongSuatThietKeId;
                    Nm.TenNhaMay = upInfor.TenNhaMay_;
                    Nm.ViTri = upInfor.ViTri;
                    Nm.TiLeCoPhan = upInfor.TyLeCoPhan_;

                    // ProcesS:
                    await Service.UpdateObj(Nm);
                    // Re-load data:
                    FillData();
                    MessageBox.Show(EnumNhaMay.ErrorInfo.ThaoTacThanhCong, "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        #endregion

        #region Delete
        private async void btn_DeleteClick(object sender, EventArgs e)
        {
            await DeleteObj(sender, e);
        }

        private async Task DeleteObj(object sender, EventArgs e)
        {
            // Ask user to sure of delete:
            DialogResult res = MessageBox.Show("Bản ghi này sẽ bị xóa, tiếp tục?",
                "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (res == DialogResult.OK)
            {
                // Retrive object:
                NhaMay nhaMay = factorView.GetFocusedRow() as NhaMay;
                if (nhaMay != null)
                {
                    int Id = nhaMay.Id;
                    await Service.DeleteObject(Id); FillData();
                    MessageBox.Show(EnumNhaMay.ErrorInfo.ThaoTacThanhCong,
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        #endregion

    }
}