using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.Map.Kml.Model;
using DevExpress.Map.Native;
using DevExpress.Utils;
using DevExpress.Utils.Svg;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
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
    public partial class LoaiChatThaiView : DevExpress.XtraEditors.XtraForm
    {
        private readonly AppDbContext _db;
        private readonly IRepository<LoaiChatThai> loaiChatThaiRepo;
        private readonly ILoaiChatThai loaiChatThaiServices;
        public LoaiChatThaiView()
        {
            loaiChatThaiRepo = new ExRepository<LoaiChatThai>();
            InitializeComponent();


            _db = new AppDbContext();
            loaiChatThaiServices = new LoaiChatThaiServices();


        }
        public LoaiChatThaiView(DevExpress.XtraGrid.GridControl gridControl)
        {
            loaiChatThaiRepo = new ExRepository<LoaiChatThai>();
            InitializeComponent();

            FillData(gridControl);
            _db = new AppDbContext();
            loaiChatThaiServices = new LoaiChatThaiServices();


        }

        private void FillData(DevExpress.XtraGrid.GridControl gridControl)
        {
            List<LoaiChatThai> loaiChatThais = loaiChatThaiRepo.TableUntracked.ToList();

            GridView gridView = gridView1;

            gridView.OptionsBehavior.AutoPopulateColumns = false;
            gridControl.MainView = gridView;

            GridColumn stt = gridView.Columns.AddVisible("stt");
            GridColumn tenloaiChatThai = gridView.Columns.AddVisible("TenLoaiChatThai");
            GridColumn Sua = gridView.Columns.AddVisible("Sua");
            GridColumn Xoa = gridView.Columns.AddVisible("Xoa");

            RepositoryItemButtonEdit btnSua = new RepositoryItemButtonEdit();
            btnSua.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            btnSua.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            btnSua.Buttons[0].ImageOptions.ImageList = imageCollection1;
            btnSua.Buttons[0].ImageOptions.ImageIndex = 1;
            btnSua.Buttons[0].Click += btnSua_Click;

            RepositoryItemButtonEdit btnXoa = new RepositoryItemButtonEdit();
            btnXoa.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            btnXoa.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            btnXoa.Buttons[0].ImageOptions.ImageList = imageCollection1;
            btnXoa.Buttons[0].ImageOptions.ImageIndex = 0;
            btnXoa.Buttons[0].Click += btnXoa_Click;


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

            tenloaiChatThai.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            tenloaiChatThai.AppearanceCell.Options.UseFont = true;
            tenloaiChatThai.AppearanceCell.Options.UseTextOptions = true;
            tenloaiChatThai.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            tenloaiChatThai.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            tenloaiChatThai.AppearanceHeader.Options.UseFont = true;
            tenloaiChatThai.AppearanceHeader.Options.UseTextOptions = true;
            tenloaiChatThai.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            tenloaiChatThai.Caption = "Tên loại chất thải";
            tenloaiChatThai.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            tenloaiChatThai.Width = 900;
            tenloaiChatThai.Visible = true;
            tenloaiChatThai.VisibleIndex = 1;
            tenloaiChatThai.OptionsColumn.AllowEdit = false;

            Sua.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Sua.AppearanceCell.Options.UseFont = true;
            Sua.AppearanceCell.Options.UseTextOptions = true;
            Sua.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            Sua.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            Sua.AppearanceHeader.Options.UseFont = true;
            Sua.AppearanceHeader.Options.UseTextOptions = true;
            Sua.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            Sua.Caption = "Sửa";
            Sua.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            Sua.ColumnEdit = btnSua;
            Sua.MaxWidth = 40;
            Sua.MinWidth = 40;
            Sua.Visible = true;
            Sua .VisibleIndex = 2;
            Sua.Width = 40;

            Xoa.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Xoa.AppearanceCell.Options.UseFont = true;
            Xoa.AppearanceCell.Options.UseTextOptions = true;
            Xoa.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            Xoa.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            Xoa.AppearanceHeader.Options.UseFont = true;
            Xoa.AppearanceHeader.Options.UseTextOptions = true;
            Xoa.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            Xoa.Caption = "Xóa";
            Xoa.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            Xoa.ColumnEdit = btnXoa;
            Xoa.MaxWidth = 40;
            Xoa.MinWidth = 40;
            Xoa.Visible = true;
            Xoa.VisibleIndex = 3;
            Xoa.Width = 40;


            gridView.OptionsView.ShowIndicator = false;

            gridView.CustomUnboundColumnData += (sender, e) =>
            {
                if (e.Column == stt && e.IsGetData)
                {
                    e.Value = e.ListSourceRowIndex + 1;
                }
            };



            LoaiChatThaiTbl.DataSource = loaiChatThais;

        }

        private void LoaiChatThaiView_Load(object sender, EventArgs e)
        {
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            var selectedLoaiChatThai = gridView1.GetFocusedRow() as LoaiChatThai;
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn xóa dữ liệu này", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.OK)
            {
                var result = await loaiChatThaiServices.Delete(selectedLoaiChatThai.Id);
                if (result.Error)
                {
                    MessageBox.Show(result.ErrorMessage, "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(result.ErrorMessage, "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                LoaiChatThaiTbl.DataSource = loaiChatThaiRepo.TableUntracked.ToList();
            }
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            var selectedLoaiChatThai = gridView1.GetFocusedRow() as LoaiChatThai;
            SuaLoaiChatThaiView suaLoaiChatThaiView = new SuaLoaiChatThaiView(selectedLoaiChatThai);
            DialogResult result = suaLoaiChatThaiView.ShowDialog();
            if (result == DialogResult.OK)
            {
                DialogResult dialog = MessageBox.Show("Bạn có muốn sửa loại chất thải", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if(dialog == DialogResult.OK)
                {
                    var updateLoaiChatThai = await loaiChatThaiServices.Update(suaLoaiChatThaiView.UpdateLoaiChatThai);
                    if (updateLoaiChatThai.Error)
                    {
                        MessageBox.Show(updateLoaiChatThai.ErrorMessage, "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show(updateLoaiChatThai.ErrorMessage, "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoaiChatThaiTbl.DataSource = loaiChatThaiRepo.TableUntracked.ToList();
                }
                
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}