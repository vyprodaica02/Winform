using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
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
using System.Windows.Forms;
using VienHoa.Common;
using VienHoa.DataEx;
using VienHoa.Entity;
using VienHoa.IService;
using VienHoa.Service;

namespace VienHoa.View
{
    public partial class ThaiDauRaView : DevExpress.XtraEditors.XtraForm
    {
        private readonly IRepository<ThaiDauRa> _thaiDauRaRepo;
        private readonly IThaiDauRa thaiDauRaService;
        public ThaiDauRaView(DevExpress.XtraGrid.GridControl gridControl)
        {
            _thaiDauRaRepo = new ExRepository<ThaiDauRa>();
            InitializeComponent();

            FillData(gridControl);
            thaiDauRaService = new ThaiDauRaService();
        }

        private void FillData(DevExpress.XtraGrid.GridControl gridControl)
        {
            List<ThaiDauRa> thaiDauRas = _thaiDauRaRepo.TableUntracked.Include(x => x.ChatThai).Include(x => x.DonVi).Include(x => x.SanPham).ToList();

            GridView gridView = gridView1;
            gridControl.MainView = gridView;

            GridColumn stt = gridView.Columns.AddVisible("stt");
            GridColumn tenSanPham = gridView.Columns.AddVisible("SanPham.TenSanPham");
            GridColumn chatThai = gridView.Columns.AddVisible("ChatThai.TenChatThai");
            GridColumn donVi = gridView.Columns.AddVisible("DonVi.TenDonVi");
            GridColumn soLuong = gridView.Columns.AddVisible("SoLuong");
            GridColumn heSoDieuChinh = gridView.Columns.AddVisible("HeSoDieuChinh");
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
            stt.MaxWidth = 50;
            stt.MinWidth = 50;
            stt.UnboundDataType = typeof(int);
            stt.Visible = true;
            stt.VisibleIndex = 0;
            stt.Width = 50;

            tenSanPham.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            tenSanPham.AppearanceCell.Options.UseFont = true;
            tenSanPham.AppearanceCell.Options.UseTextOptions = true;
            tenSanPham.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            tenSanPham.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            tenSanPham.AppearanceHeader.Options.UseFont = true;
            tenSanPham.AppearanceHeader.Options.UseTextOptions = true;
            tenSanPham.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            tenSanPham.Caption = "Sản phẩm";
            tenSanPham.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //tenSanPham.MaxWidth = 200;
            tenSanPham.MinWidth = 50;
            tenSanPham.Visible = true;
            tenSanPham.VisibleIndex = 1;
            tenSanPham.Width = 200;

            chatThai.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            chatThai.AppearanceCell.Options.UseFont = true;
            chatThai.AppearanceCell.Options.UseTextOptions = true;
            chatThai.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            chatThai.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            chatThai.AppearanceHeader.Options.UseFont = true;
            chatThai.AppearanceHeader.Options.UseTextOptions = true;
            chatThai.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            chatThai.Caption = "Chất thải";
            chatThai.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //chatThai.MaxWidth = 180;
            chatThai.MinWidth = 50;
            chatThai.Visible = true;
            chatThai.VisibleIndex = 2;
            chatThai.Width = 180;

            donVi.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            donVi.AppearanceCell.Options.UseFont = true;
            donVi.AppearanceCell.Options.UseTextOptions = true;
            donVi.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            donVi.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            donVi.AppearanceHeader.Options.UseFont = true;
            donVi.AppearanceHeader.Options.UseTextOptions = true;
            donVi.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            donVi.Caption = "Đơn vị";
            donVi.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //donVi.MaxWidth = 160;
            donVi.MinWidth = 50;
            donVi.Visible = true;
            donVi.VisibleIndex = 3;
            donVi.Width = 160;

            soLuong.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            soLuong.AppearanceCell.Options.UseFont = true;
            soLuong.AppearanceCell.Options.UseTextOptions = true;
            soLuong.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            soLuong.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            soLuong.AppearanceHeader.Options.UseFont = true;
            soLuong.AppearanceHeader.Options.UseTextOptions = true;
            soLuong.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            soLuong.Caption = "Số lượng";
            soLuong.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //soLuong.MaxWidth = 180;
            soLuong.MinWidth = 50;
            soLuong.Visible = true;
            soLuong.VisibleIndex = 4;
            soLuong.Width = 180;

            heSoDieuChinh.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            heSoDieuChinh.AppearanceCell.Options.UseFont = true;
            heSoDieuChinh.AppearanceCell.Options.UseTextOptions = true;
            heSoDieuChinh.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            heSoDieuChinh.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            heSoDieuChinh.AppearanceHeader.Options.UseFont = true;
            heSoDieuChinh.AppearanceHeader.Options.UseTextOptions = true;
            heSoDieuChinh.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            heSoDieuChinh.Caption = "Hệ số điều chỉnh";
            heSoDieuChinh.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //heSoDieuChinh.MaxWidth = 180;
            heSoDieuChinh.MinWidth = 50;
            heSoDieuChinh.Visible = true;
            heSoDieuChinh.VisibleIndex = 5;
            heSoDieuChinh.Width = 180;

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
            Sua.MaxWidth = 50;
            Sua.MinWidth = 50;
            Sua.Visible = true;
            Sua.VisibleIndex = 6;
            Sua.Width = 50;

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
            Xoa.MaxWidth = 50;
            Xoa.MinWidth = 50;
            Xoa.Visible = true;
            Xoa.VisibleIndex = 7;
            Xoa.Width = 50;

            gridView.OptionsView.ShowIndicator = false;

            gridView.CustomUnboundColumnData += (sender, e) =>
            {
                if (e.Column == stt && e.IsGetData)
                {
                    e.Value = e.ListSourceRowIndex + 1;
                }
            };



            tblThaiDauRa.DataSource = thaiDauRas;

        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            var selectedThaiDauRa = gridView1.GetFocusedRow() as ThaiDauRa;
            SuaThaiDauRaView suaThaiDauRaView = new SuaThaiDauRaView(selectedThaiDauRa);
            if (suaThaiDauRaView.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    var result = await thaiDauRaService.Update(suaThaiDauRaView.UpdateThaiDauRa);
                    if (result.Error)
                    {
                        MessageBox.Show(result.ErrorMessage, "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tblThaiDauRa.DataSource = _thaiDauRaRepo.TableUntracked.Include(x => x.ChatThai).Include(x => x.DonVi).Include(x => x.SanPham).ToList();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Sửa thất bại: " + ex.Message, "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private async void btnXoa_Click(object sender, EventArgs e)
        {
            var selectedThaiDauRa = gridView1.GetFocusedRow() as ThaiDauRa;
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn xóa dữ liệu này", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.OK)
            {
                var result = await thaiDauRaService.Delete(selectedThaiDauRa.Id);
                if (result.Error)
                {
                    MessageBox.Show(result.ErrorMessage, "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tblThaiDauRa.DataSource = _thaiDauRaRepo.TableUntracked.Include(x => x.ChatThai).Include(x => x.DonVi).Include(x => x.SanPham).ToList();
                }
                else
                {
                    MessageBox.Show(result.ErrorMessage, "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ThaiDauRaView_Load(object sender, EventArgs e)
        {
            tblThaiDauRa.DataSource = _thaiDauRaRepo.TableUntracked.ToList();
        }
    }
}