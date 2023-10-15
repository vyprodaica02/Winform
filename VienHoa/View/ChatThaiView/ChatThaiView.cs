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
    public partial class ChatThaiView : DevExpress.XtraEditors.XtraForm
    {
        private readonly IRepository<ChatThai> _chatThaiRepo;
        private readonly IChatThai chatThaiService;
        private readonly AppDbContext _db;
        public ChatThaiView(DevExpress.XtraGrid.GridControl gridControl)
        {
            _chatThaiRepo = new ExRepository<ChatThai>();
            InitializeComponent();

            chatThaiService = new ChatThaiService();
            _db = new AppDbContext();
            FillData(gridControl);

        }


        private async void FillData(DevExpress.XtraGrid.GridControl gridControl)
        {

            GridView gridView = gridView1;
            gridView.OptionsBehavior.AutoPopulateColumns = false;
            gridControl.MainView = gridView;
            GridColumn stt = gridView.Columns.AddVisible("stt");
            GridColumn tenloaiChatThai = gridView.Columns.AddVisible("LoaiChatThai.TenLoaiChatThai");
            GridColumn tenChatThai = gridView.Columns.AddVisible("TenChatThai");
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
            tenloaiChatThai.Width = 450;
            tenloaiChatThai.Visible = true;
            tenloaiChatThai.VisibleIndex = 1;
            tenloaiChatThai.OptionsColumn.AllowEdit = false;

            tenChatThai.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            tenChatThai.AppearanceCell.Options.UseFont = true;
            tenChatThai.AppearanceCell.Options.UseTextOptions = true;
            tenChatThai.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            tenChatThai.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            tenChatThai.AppearanceHeader.Options.UseFont = true;
            tenChatThai.AppearanceHeader.Options.UseTextOptions = true;
            tenChatThai.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            tenChatThai.Caption = "Tên chất thải";
            tenChatThai.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            tenChatThai.Width = 450;
            tenChatThai.Visible = true;
            tenChatThai.VisibleIndex = 2;
            tenChatThai.OptionsColumn.AllowEdit = false;

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
            Sua.VisibleIndex = 3;
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
            Xoa.VisibleIndex = 4;
            Xoa.Width = 40;

            gridView.OptionsView.ShowIndicator = false;

            gridView.CustomUnboundColumnData += (sender, e) =>
            {
                if (e.Column == stt && e.IsGetData)
                {
                    e.Value = e.ListSourceRowIndex + 1;
                }
            };



            ChatThaiTbl.DataSource = await _chatThaiRepo.TableUntracked.Include(x => x.LoaiChatThai).ToListAsync();

        }

        private void ChatThaiView_Load(object sender, EventArgs e)
        {
            //gridControl1.DataSource = _chatThaiRepo.TableUntracked.ToList();
        }

        //private async void btnThem_Click(object sender, EventArgs e)
        //{
        //    ThemChatThaiView themChatThaiView = new ThemChatThaiView();
        //    DialogResult result = themChatThaiView.ShowDialog();
        //    if (result == DialogResult.Cancel)
        //    {
        //        ChatThaiTbl.DataSource = await _chatThaiRepo.TableUntracked.Include(x => x.LoaiChatThai).ToListAsync().ConfigureAwait(false);
        //    }
        //}
        private async void btnSua_Click(object sender, EventArgs e)
        {
            var selectedChatThai = gridView1.GetFocusedRow() as ChatThai;
            SuaChatThaiView suaChatThaiView = new SuaChatThaiView(selectedChatThai);
            if (suaChatThaiView.ShowDialog() == DialogResult.OK)
            {
                DialogResult dialog = MessageBox.Show("Bạn có muốn sửa chất thải", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if(dialog == DialogResult.OK)
                {
                    try
                    {
                        var updatedChatThai = new ChatThai
                        {
                            Id = suaChatThaiView.UpdateChatThai.Id,
                            LoaiChatThaiId = suaChatThaiView.UpdateChatThai.LoaiChatThaiId,
                            TenChatThai = suaChatThaiView.UpdateChatThai.TenChatThai
                        };
                        var result = await chatThaiService.Update(updatedChatThai);
                        if (result.Error)
                        {
                            MessageBox.Show(result.ErrorMessage, "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ChatThaiTbl.DataSource = await _chatThaiRepo.TableUntracked.Include(x => x.LoaiChatThai).ToListAsync();
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Sửa thất bại: " + ex.Message, "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }
        private async void btnXoa_Click(object sender, EventArgs e)
        {
            var selectedChatThai = gridView1.GetFocusedRow() as ChatThai;
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn xóa dữ liệu này", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.OK)
            {
                var result = await chatThaiService.Delete(selectedChatThai.Id);
                if (result.Error)
                {
                    MessageBox.Show(result.ErrorMessage, "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show(result.ErrorMessage, "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                ChatThaiTbl.DataSource = _chatThaiRepo.TableUntracked.Include(x => x.LoaiChatThai).ToList();
            }
        }
    }
}