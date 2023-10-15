using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSpreadsheet.Import.Xls;
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

namespace VienHoa.View
{
    public partial class GayNongLenToanCauView : DevExpress.XtraEditors.XtraForm
    {
        private readonly IGayNongLenToanCau gayNongLenToanCauService;
        public GayNongLenToanCauView(GridControl gridControl)
        {
            gayNongLenToanCauService = new GayNongLenToanCauService();
            InitializeComponent();
            FillData(gridControl);
        }

        async Task LoadData()
        {
            GayNongLenToanCauTbl.DataSource = await gayNongLenToanCauService.GetAllAsync();
        }

        private async void FillData(GridControl gridControl)
        {
            // Thêm cột cho gridView
            GridColumn stt = gridView.Columns.AddVisible("stt");
            GridColumn khiPhatThai = gridView.Columns.AddVisible("KhiPhatThai.TenKhi");
            GridColumn giaTri = gridView.Columns.AddVisible("GiaTri");
            GridColumn edit = gridView.Columns.AddVisible("edit");
            GridColumn delete = gridView.Columns.AddVisible("delete");
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
            // colKhiPhatThaiId
            // 
            khiPhatThai.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            khiPhatThai.AppearanceCell.Options.UseFont = true;
            khiPhatThai.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            khiPhatThai.AppearanceHeader.Options.UseFont = true;
            khiPhatThai.Caption = "Khí phát thải";
            khiPhatThai.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            khiPhatThai.Width = 440;
            khiPhatThai.Visible = true;
            khiPhatThai.VisibleIndex = 1;
            khiPhatThai.OptionsColumn.AllowEdit =false;
            // 
            // colGiaTri
            // 
            giaTri.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            giaTri.AppearanceCell.Options.UseFont = true;
            giaTri.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            giaTri.AppearanceHeader.Options.UseFont = true;
            giaTri.Caption = "Giá trị";
            giaTri.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            giaTri.Width = 440;
            giaTri.Visible = true;
            giaTri.VisibleIndex = 2;
            giaTri.OptionsColumn.AllowEdit = false;
            // 
            // Tạo nút sửa
            //
            RepositoryItemButtonEdit btnEdit = new RepositoryItemButtonEdit();
            btnEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            btnEdit.Buttons[0].Click += btnEdit_Click;
            btnEdit.Buttons[0].Caption = "Sửa";
            btnEdit.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            btnEdit.Buttons[0].ImageOptions.ImageList = buttonicon;
            btnEdit.Buttons[0].ImageOptions.ImageIndex = 0;
            //
            //Tạo nút xóa
            //
            RepositoryItemButtonEdit btnDelete = new RepositoryItemButtonEdit();
            btnDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            btnDelete.Buttons[0].Click += btnDelete_Click;
            btnDelete.Buttons[0].Caption = "Xóa";
            btnDelete.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            btnDelete.Buttons[0].ImageOptions.ImageList = buttonicon;
            btnDelete.Buttons[0].ImageOptions.ImageIndex = 1;
            //
            // Custom cột Sửa
            // 
            edit.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            edit.AppearanceCell.Options.UseFont = true;
            edit.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            edit.AppearanceHeader.Options.UseFont = true;
            edit.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            edit.ColumnEdit = btnEdit;
            edit.Caption = "Sửa";
            edit.MaxWidth = 40;
            edit.MinWidth = 40;
            edit.Visible = true;
            edit.VisibleIndex = 3;
            // 
            // Custom cột Xóa
            // 
            delete.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            delete.AppearanceCell.Options.UseFont = true;
            delete.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            delete.AppearanceHeader.Options.UseFont = true;
            delete.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            delete.ColumnEdit = btnDelete;
            delete.Caption = "Xóa";
            delete.MaxWidth = 40;
            delete.MinWidth = 40;
            delete.Visible = true;
            delete.VisibleIndex = 4;

            gridControl.MainView = gridView;
            await LoadData();
        }

        private async void GayNongLenToanCauView_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        private void gridView_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "stt" && e.IsGetData)
            {
                e.Value = e.ListSourceRowIndex + 1; // Tính toán số thứ tự (bắt đầu từ 1)
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            GayNongLenToanCau gayNongLenToanCau = gridView.GetFocusedRow() as GayNongLenToanCau;
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa gây nóng lên toàn cầu này?", "Xác nhận!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (await gayNongLenToanCauService.DeleteAsync(gayNongLenToanCau))
                {
                    MessageBox.Show("Xóa gây nóng lên toàn cầu thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadData();
                    this.ActiveControl = null;
                }
                else
                {
                    MessageBox.Show("Xóa gây nóng lên toàn cầu thất bại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            GayNongLenToanCau gayNongLenToanCau = gridView.GetFocusedRow() as GayNongLenToanCau;
            GayNongLenToanCauUpdate frm = new GayNongLenToanCauUpdate(gayNongLenToanCau);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var res = await gayNongLenToanCauService.UpdateAsync(frm.UpdateGayNongLenToanCau);
                if (!res.Error)
                {
                    MessageBox.Show(res.Message, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadData();
                }
                else
                {
                    MessageBox.Show(res.Message, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}