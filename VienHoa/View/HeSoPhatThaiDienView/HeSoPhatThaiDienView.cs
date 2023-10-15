using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid;
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
    public partial class HeSoPhatThaiDienView : DevExpress.XtraEditors.XtraForm
    {
        private readonly IRepository<KhiPhatThai> khiPhatThaiRepo;
        private readonly IHeSoPhatThaiDien heSoPhatThaiDienService;
        public HeSoPhatThaiDienView(GridControl gridControl)
        {
            khiPhatThaiRepo = new ExRepository<KhiPhatThai>();
            heSoPhatThaiDienService = new HeSoPhatThaiDienService();
            InitializeComponent();
            FillData(gridControl);
        }
        async Task LoadData()
        {
            GayNongLenToanCauTbl.DataSource = await heSoPhatThaiDienService.GetAllAsync();
        }

        private async void FillData(GridControl gridControl)
        {
            // Thêm cột cho gridView
            GridColumn stt = gridView.Columns.AddVisible("stt");
            GridColumn khiPhatThai = gridView.Columns.AddVisible("KhiPhatThai.TenKhi");
            GridColumn nam = gridView.Columns.AddVisible("Nam");
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
            // Custom cột stt khiPhatThai
            // 
            khiPhatThai.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            khiPhatThai.AppearanceCell.Options.UseFont = true;
            khiPhatThai.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            khiPhatThai.AppearanceHeader.Options.UseFont = true;
            khiPhatThai.Caption = "Khí phát thải";
            khiPhatThai.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            khiPhatThai.Width = 400;
            khiPhatThai.Visible = true;
            khiPhatThai.VisibleIndex = 1;
            khiPhatThai.OptionsColumn.AllowEdit = false;
            // 
            // Custom cột nam
            // 
            nam.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            nam.AppearanceCell.Options.UseFont = true;
            nam.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            nam.AppearanceHeader.Options.UseFont = true;
            nam.Caption = "Năm";
            nam.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            nam.Width = 240;
            nam.MinWidth = 240;
            nam.Visible = true;
            nam.VisibleIndex = 2;
            nam.OptionsColumn.AllowEdit = false;
            // 
            // Custom cột giaTri
            // 
            giaTri.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            giaTri.AppearanceCell.Options.UseFont = true;
            giaTri.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            giaTri.AppearanceHeader.Options.UseFont = true;
            giaTri.Caption = "Giá trị";
            giaTri.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            giaTri.Width = 240;
            giaTri.MinWidth = 240;
            giaTri.Visible = true;
            giaTri.VisibleIndex = 3;
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
            edit.VisibleIndex = 4;
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
            delete.VisibleIndex = 5;

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
            HeSoPhatThaiDien heSoPhatThaiDien = gridView.GetFocusedRow() as HeSoPhatThaiDien;
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa hệ số phát thải điện này?", "Xác nhận!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (await heSoPhatThaiDienService.DeleteAsync(heSoPhatThaiDien))
                {
                    MessageBox.Show("Xóa hệ số phát thải điện thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadData();
                    this.ActiveControl = null;
                }
                else
                {
                    MessageBox.Show("Xóa hệ số phát thải điện thất bại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            HeSoPhatThaiDien heSoPhatThaiDien = gridView.GetFocusedRow() as HeSoPhatThaiDien;
            HeSoPhatThaiDienUpdate frm =  new HeSoPhatThaiDienUpdate(heSoPhatThaiDien);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var res = await heSoPhatThaiDienService.UpdateAsync(frm.UpdateHeSoPhatThaiDien);
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