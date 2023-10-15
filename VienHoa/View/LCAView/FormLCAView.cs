using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraVerticalGrid;
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
using DevExpress.XtraRichEdit.Model;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraVerticalGrid.Native;
using Label = System.Windows.Forms.Label;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Reflection;
using DevExpress.XtraGrid.Scrolling;
using DevExpress.Xpo;
using System.Windows.Media;
using DevExpress.Office.Utils;
using DevExpress.CodeParser;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using VienHoa.Dtos;
using VienHoa.View.BangKetQuaTinhToanVIew;

namespace VienHoa.View
{
    public partial class FormLCAView : DevExpress.XtraEditors.XtraForm
    {
        private readonly ILCA _lcaService;
        private readonly ILoaiChatThai _loaiChatThaiService;
        private readonly INguyenLieuSanPham _nguyenLieuSanPhamService;
        private readonly INhienLieuSanPham _nhienLieuSanPhamService;
        private readonly IDonViSanPham _donViSanPhamService;
        private readonly IThaiDauRa _thaiDauRaService;
        private readonly IChatThai _chatThaiService;
        private readonly ILoaiNguyenLieu _loaiNguyenLieuService;
        private readonly ILoaiNhienLieu _loaiNhienLieuService;
        private readonly INguyenLieu _nguyenLieuService;
        private readonly INhienLieu _nhienLieuService;

        List<NguyenLieuSanPham> lstNguyenLieuSanPhamAdd = new List<NguyenLieuSanPham>();
        List<NhienLieuSanPham> lstNhienLieuSanPhamAdd = new List<NhienLieuSanPham>();
        List<ThaiDauRa> lstThaiDauRaAdd = new List<ThaiDauRa>();

        List<NguyenLieuSanPham> lstNguyenLieuSanPhamDT = new List<NguyenLieuSanPham>();
        List<NhienLieuSanPham> lstNhienLieuSanPhamDT = new List<NhienLieuSanPham>();
        List<ThaiDauRa> lstThaiDauRaDT = new List<ThaiDauRa>();

        private bool dvNLSanPham = true;
        private bool dvNgLSanPham = true;
        private bool dvThaiDauRaSanPham = true;
        private SanPham _sanPham;
        private List<string> lstKyHieuLCA = new List<string>();

        private Point locationGridControl = new Point(0, 70);
        private Point locationLabel = new Point(0, 40);

        public FormLCAView(SanPham sanPham)
        {
            _sanPham = sanPham;
            _loaiChatThaiService = new LoaiChatThaiServices();
            _nhienLieuSanPhamService = new NhienLieuSanPhamService();
            _nguyenLieuSanPhamService = new NguyenLieuSanPhamService();
            _lcaService = new LCAService();
            _donViSanPhamService = new DonViSanPhamService();
            _thaiDauRaService = new ThaiDauRaService();
            _chatThaiService = new ChatThaiService();
            _loaiNguyenLieuService = new LoaiNguyenLieuService();
            _loaiNhienLieuService = new LoaiNhienLieuService();
            _nguyenLieuService = new NguyenLieuService();
            _nhienLieuService = new NhienLieuService();

            InitializeComponent();
        }

        private async void FormLCAView_Load(object sender, EventArgs e)
        {
            lstKyHieuLCA.Clear();
            this.Text = "Giai đoạn sản phẩm " + _sanPham.TenSanPham;
            lstNguyenLieuSanPhamDT = await _nguyenLieuSanPhamService.GetNguyenLieuSanPhamBySPId(_sanPham.Id);
            lstNhienLieuSanPhamDT = await _nhienLieuSanPhamService.GetNhienLieuSanPhamBySPId(_sanPham.Id);
            lstThaiDauRaDT = await _thaiDauRaService.GetThaiDauRaBySPId(_sanPham.Id);
            await RenderTableNguyenLieu();
            await RenderTableNhienLieu();
            await RenderTableThaiDauRa();
        }

        private RepositoryItemLookUpEdit LoadLookupEdit(List<DonViSanPham> lstDonViSanPham)
        {
            List<CustomLookupEdit> lstDataDonViSP = new List<CustomLookupEdit>();
            RepositoryItemLookUpEdit lookupEdit = new RepositoryItemLookUpEdit();
            lookupEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            foreach (DonViSanPham item in lstDonViSanPham)
            {
                CustomLookupEdit lockupEditItem = new CustomLookupEdit() { Id = item.Id, Ten = item.TenDonVi };
                lstDataDonViSP.Add(lockupEditItem);
            }
            lookupEdit.NullText = "";
            lookupEdit.DataSource = lstDataDonViSP;
            lookupEdit.DisplayMember = "Ten";
            lookupEdit.ValueMember = "Id";
            return lookupEdit;
        }

        #region
        private async Task RenderTableNguyenLieu()
        {
            List<NguyenLieuSanPham> lstNguyenLieuSP = await _nguyenLieuSanPhamService.GetNguyenLieuSanPhamBySPId(_sanPham.Id);
            List<LoaiNguyenLieu> lstLoaiNguyenLieu = await _loaiNguyenLieuService.GetAllLoaiNguyenLieu();
            List<LCA> lcas = await _lcaService.GetAllLCA();
            List<DonViSanPham> lstDonViSanPham = await _donViSanPhamService.GetAllDonViSanPham();

            RepositoryItemLookUpEdit lookupEdit = LoadLookupEdit(lstDonViSanPham);

            Point locationLabelNLSP = new Point(0, 0);
            Label lbNguyenLieuSanPham = new Label();
            lbNguyenLieuSanPham.Text = "I. Nguyên liệu sản phẩm ";
            lbNguyenLieuSanPham.Width = 700;
            lbNguyenLieuSanPham.Height = 40;
            lbNguyenLieuSanPham.Location = locationLabelNLSP;
            lbNguyenLieuSanPham.Font = new Font(lbNguyenLieuSanPham.Font.FontFamily, 14, FontStyle.Bold);
            panelContainer.Controls.Add(lbNguyenLieuSanPham);

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("NguyenLieu", typeof(string));
            dataTable.Columns.Add("NguyenLieuId", typeof(int));
            dataTable.Columns.Add("DonVi", typeof(int));

            foreach (var giaidoan in lcas)
            {
                dataTable.Columns.Add(giaidoan.KyHieu);
            }

            List<NguyenLieu> lstNguyenLieu = await _nguyenLieuService.GetAllNguyenLieu();
            if (lstNguyenLieu.Count() > 0)
            {
                GridControl gridControl = new GridControl();
                gridControl.Width = panelContainer.Width - 40;
                panelContainer.Controls.Add(gridControl);

                gridControl.Name = "tblNguyenLieuSanPham";
                gridControl.Padding = new Padding(0, 20, 0, 20);
                gridControl.Location = locationGridControl;
                gridControl.RepositoryItems.Add(lookupEdit);

                GridView gridView = new GridView(gridControl);
                gridView.Name = "gridViewNguyenLieuSP";
                gridControl.MainView = gridView;

                gridView.Columns.Add(new GridColumn
                {
                    Caption = "Nguyên liệu",
                    FieldName = "NguyenLieu",
                    Visible = true,
                    //MaxWidth = 151,
                    //MinWidth = 151,
                    Width = 151,
                });
                gridView.Columns.Add(new GridColumn
                {
                    Caption = "NguyenLieuId",
                    FieldName = "NguyenLieuId",
                    Visible = false,
                });
                gridView.Columns.Add(new GridColumn
                {
                    Caption = "Đơn vị",
                    FieldName = "DonVi",
                    Visible = true,
                    ColumnEdit = lookupEdit,
                    Width = 151,
                    //MaxWidth = 151,
                    MinWidth = 70,

                });
                foreach (var giaidoan in lcas)
                {
                    lstKyHieuLCA.Add(giaidoan.KyHieu);
                    gridView.Columns.Add(new GridColumn
                    {
                        Caption = giaidoan.KyHieu,
                        FieldName = giaidoan.KyHieu,
                        Visible = true,
                        Width = 50,
                        MinWidth = 50,
                        MaxWidth = 50,
                    });
                    gridView.Columns[giaidoan.KyHieu].OptionsColumn.AllowMove = false;
                    gridView.Columns[giaidoan.KyHieu].AppearanceCell.Font = new Font(gridView.Columns[giaidoan.KyHieu].AppearanceHeader.Font.FontFamily, 8);
                    gridView.Columns[giaidoan.KyHieu].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                }

                gridView.CellValueChanged += GridViewNguyenLieuSP_CellValueChanged;
                gridView.ValidatingEditor += GridViewNguyenLieuSP_ValidatingEditor;

                gridView.Columns["DonVi"].AppearanceCell.Font = new Font(gridView.Columns["DonVi"].AppearanceHeader.Font.FontFamily, 8);
                gridView.Columns["DonVi"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gridView.Columns["NguyenLieu"].AppearanceCell.Font = new Font(gridView.Columns["NguyenLieu"].AppearanceHeader.Font.FontFamily, 8);
                gridView.Columns["NguyenLieu"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                gridView.Columns["NguyenLieu"].OptionsColumn.AllowEdit = false;
                gridView.Columns["DonVi"].OptionsColumn.AllowEdit = true;
                gridView.Columns["NguyenLieu"].OptionsColumn.AllowMove = false;
                gridView.Columns["DonVi"].OptionsColumn.AllowMove = false;

                gridView.OptionsView.ShowIndicator = false;
                gridView.OptionsView.ShowGroupPanel = false;
                gridView.ScrollStyle = DevExpress.XtraGrid.Views.Grid.ScrollStyleFlags.None;

                foreach (var nguyenLieu in lstNguyenLieu)
                {
                    DataRow newRow = dataTable.NewRow();
                    newRow["NguyenLieu"] = nguyenLieu.TenHienThiTieuThu;
                    newRow["NguyenLieuId"] = nguyenLieu.Id;
                    
                    if (lstNguyenLieuSP.Count() > 0)
                    {
                        foreach (var nguyenLieuSP in lstNguyenLieuSP)
                        {
                            LCA lca = await _lcaService.GetLCAById(nguyenLieuSP.LCAId);
                            if (lca != null && nguyenLieu.Id == nguyenLieuSP.NguyenLieuId)
                            {
                                newRow[lca.KyHieu] = nguyenLieuSP.SoLuong;
                            }
                            foreach (DonViSanPham donVi in lstDonViSanPham)
                            {
                                NguyenLieuSanPham dataNguyenLieuSP = lstNguyenLieuSP.FirstOrDefault(x => x.NguyenLieuId == nguyenLieu.Id && x.DonViId == donVi.Id && x.SanPhamId == _sanPham.Id);
                                //NguyenLieuSanPham dataNguyenLieuSP = await _nguyenLieuSanPhamService.GetNguyenLieuSanPhamByDVIdandNguyenLieuIdandSPId(nguyenLieu.Id, donVi.Id, _sanPham.Id);
                                if (dataNguyenLieuSP != null && donVi.Id == nguyenLieuSP.DonViId)
                                {
                                    newRow["DonVi"] = donVi.Id;
                                    break;
                                }
                            }
                        }
                    }
                    dataTable.Rows.Add(newRow);
                }


                gridControl.DataSource = dataTable;

                locationLabel = new Point(0, gridControl.Bottom + 80);
                locationGridControl = new Point(0, gridControl.Bottom + 110);

            }
        }
        private async Task RenderTableNhienLieu()
        {
            List<NhienLieuSanPham> lstNhienLieuSP = await _nhienLieuSanPhamService.GetNhienLieuSanPhamBySPId(_sanPham.Id);
            List<LoaiNhienLieu> lstLoaiNhienLieu = await _loaiNhienLieuService.GetAllLoaiNhienLieu();
            List<LCA> lcas = await _lcaService.GetAllLCA();
            List<DonViSanPham> lstDonViSanPham = await _donViSanPhamService.GetAllDonViSanPham();

            RepositoryItemLookUpEdit lookupEdit = LoadLookupEdit(lstDonViSanPham);

            Point locationLabelNhienLieuSP = new Point(0, locationGridControl.Y - 80);
            Label lbNhienLieuSanPham = new Label();
            lbNhienLieuSanPham.Text = "II. Nhiên liệu sản phẩm ";
            lbNhienLieuSanPham.Width = 700;
            lbNhienLieuSanPham.Height = 40;
            lbNhienLieuSanPham.Location = locationLabelNhienLieuSP;
            lbNhienLieuSanPham.Font = new Font(lbNhienLieuSanPham.Font.FontFamily, 14, FontStyle.Bold);
            panelContainer.Controls.Add(lbNhienLieuSanPham);

            int index = 1;
            foreach (var loaiNhienLieu in lstLoaiNhienLieu)
            {
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("NhienLieu", typeof(string));
                dataTable.Columns.Add("NhienLieuId", typeof(int));
                dataTable.Columns.Add("DonVi", typeof(int));

                foreach (var giaidoan in lcas)
                {
                    dataTable.Columns.Add(giaidoan.KyHieu, typeof(double));
                }

                List<NhienLieu> lstNhienLieu = await _nhienLieuService.GetNhienLieuByLoaiNhienLieuId(loaiNhienLieu.Id);
                if (lstNhienLieu.Count() > 0)
                {
                    Label label = new Label();
                    label.Text = index + ". " + loaiNhienLieu.TenLoai;
                    label.Location = locationLabel;
                    label.Font = new Font(lbNhienLieuSanPham.Font.FontFamily, 11, FontStyle.Bold);
                    panelContainer.Controls.Add(label);

                    GridControl gridControl = new GridControl();
                    gridControl.Width = panelContainer.Width - 40;
                    panelContainer.Controls.Add(gridControl);

                    gridControl.Name = "tblNhienLieuSanPham_" + loaiNhienLieu.Id;
                    gridControl.Padding = new Padding(0, 20, 0, 20);
                    gridControl.Location = locationGridControl;
                    gridControl.RepositoryItems.Add(lookupEdit);

                    GridView gridView = new GridView(gridControl);
                    gridView.Name = "gridViewNhienLieuSP_" + loaiNhienLieu.Id;
                    gridControl.MainView = gridView;

                    gridView.CellValueChanged += GridViewNhienLieuSP_CellValueChanged;
                    gridView.ValidatingEditor += GridViewNhienLieuSP_ValidatingEditor;

                    gridView.Columns.Add(new GridColumn
                    {
                        Caption = "Nhiên liệu",
                        FieldName = "NhienLieu",
                        Visible = true,
                        Width = 151,
                        //MaxWidth = 151,
                        //MinWidth = 151,

                    });
                    gridView.Columns.Add(new GridColumn
                    {
                        FieldName = "NhienLieuId",
                        Visible = false,
                    });
                    gridView.Columns.Add(new GridColumn
                    {
                        Caption = "Đơn vị",
                        FieldName = "DonVi",
                        Visible = true,
                        ColumnEdit = lookupEdit,
                        Width = 151,
                        //MaxWidth = 151,
                        MinWidth = 70,

                    });
                    foreach (var giaidoan in lcas)
                    {
                        gridView.Columns.Add(new GridColumn
                        {
                            Caption = giaidoan.KyHieu,
                            FieldName = giaidoan.KyHieu,
                            Visible = true,
                            Width = 50,
                            MinWidth = 50,
                            MaxWidth = 50,
                        });
                        gridView.Columns[giaidoan.KyHieu].OptionsColumn.AllowMove = false;
                        gridView.Columns[giaidoan.KyHieu].AppearanceCell.Font = new Font(gridView.Columns[giaidoan.KyHieu].AppearanceHeader.Font.FontFamily, 8);
                        gridView.Columns[giaidoan.KyHieu].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    }

                    gridView.Columns["DonVi"].AppearanceCell.Font = new Font(gridView.Columns["DonVi"].AppearanceHeader.Font.FontFamily, 8);
                    gridView.Columns["DonVi"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gridView.Columns["NhienLieu"].AppearanceCell.Font = new Font(gridView.Columns["NhienLieu"].AppearanceHeader.Font.FontFamily, 8);
                    gridView.Columns["NhienLieu"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                    gridView.Columns["NhienLieu"].OptionsColumn.AllowEdit = false;
                    gridView.Columns["DonVi"].OptionsColumn.AllowEdit = true;
                    gridView.Columns["NhienLieu"].OptionsColumn.AllowMove = false;
                    gridView.Columns["DonVi"].OptionsColumn.AllowMove = false;

                    gridView.OptionsView.ShowIndicator = false;
                    gridView.OptionsView.ShowGroupPanel = false;

                    foreach (var nhienLieu in lstNhienLieu)
                    {
                        DataRow newRow = dataTable.NewRow();
                        newRow["NhienLieu"] = nhienLieu.TenHienThiTieuThu;
                        newRow["NhienLieuId"] = nhienLieu.Id;

                        if (lstNhienLieuSP.Count() > 0)
                        {
                            foreach (var nhienLieuSP in lstNhienLieuSP)
                            {
                                LCA lca = await _lcaService.GetLCAById(nhienLieuSP.LCAId);
                                if (lca != null && nhienLieu.Id == nhienLieuSP.NhienLieuId)
                                {
                                    newRow[lca.KyHieu] = nhienLieuSP.SoLuong;
                                }
                                foreach (DonViSanPham donVi in lstDonViSanPham)
                                {
                                    NhienLieuSanPham dataNhienLieuSP = lstNhienLieuSP.FirstOrDefault(x => x.NhienLieuId == nhienLieu.Id && x.DonViId == donVi.Id && x.SanPhamId == _sanPham.Id);
                                    //NhienLieuSanPham dataNhienLieuSP = await _nhienLieuSanPhamService.GetNhienLieuSanPhamByDVIdandNhienLieuIdandSPId(nhienLieu.Id, donVi.Id, _sanPham.Id);
                                    if (dataNhienLieuSP != null && donVi.Id == nhienLieuSP.DonViId)
                                    {
                                        newRow["DonVi"] = donVi.Id;
                                        break;
                                    }
                                }
                            }
                        }
                        dataTable.Rows.Add(newRow);
                    }

                    gridControl.DataSource = dataTable;

                    if (index == lstLoaiNhienLieu.Count())
                    {
                        locationLabel = new Point(0, gridControl.Bottom + 80);
                        locationGridControl = new Point(0, gridControl.Bottom + 110);
                    }
                    else
                    {
                        locationLabel = new Point(0, gridControl.Bottom + 20);
                        locationGridControl = new Point(0, gridControl.Bottom + 50);
                    }
                    index++;
                }
            }
        }
        private async Task RenderTableThaiDauRa()
        {
            List<DonViSanPham> lstDonViSanPham = await _donViSanPhamService.GetAllDonViSanPham();
            List<LoaiChatThai> lstLoaiChatThai = await _loaiChatThaiService.GetAll();
            List<ThaiDauRa> lstThaiDauRa = await _thaiDauRaService.GetThaiDauRaBySPId(_sanPham.Id);
            List<LCA> lcas = await _lcaService.GetAllLCA();

            Point locationLabelThaiDauRa = new Point(0, locationGridControl.Y - 80);
            Label lbThaiDauRa = new Label();

            RepositoryItemLookUpEdit lookupEdit = LoadLookupEdit(lstDonViSanPham);

            lbThaiDauRa.Text = "III. Thải đầu ra ";
            lbThaiDauRa.Width = 700;
            lbThaiDauRa.Height = 40;
            lbThaiDauRa.Location = locationLabelThaiDauRa;
            lbThaiDauRa.Font = new Font(lbThaiDauRa.Font.FontFamily, 14, FontStyle.Bold);
            panelContainer.Controls.Add(lbThaiDauRa);

            int index = 1;
            foreach (var loaiChatThai in lstLoaiChatThai)
            {
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("ChatThai", typeof(string));
                dataTable.Columns.Add("ChatThaiId", typeof(int));
                dataTable.Columns.Add("HeSoDieuChinh", typeof(double));
                dataTable.Columns.Add("DonVi");

                foreach (var giaidoan in lcas)
                {
                    dataTable.Columns.Add(giaidoan.KyHieu, typeof(double));
                }

                List<ChatThai> lstChatThai = await _chatThaiService.GetChatThaiByLoaiChatThaiId(loaiChatThai.Id);
                if (lstChatThai.Count() > 0)
                {
                    Label label = new Label();
                    label.Text = index + ". " + loaiChatThai.TenLoaiChatThai;
                    label.Location = locationLabel;
                    label.Font = new Font(label.Font.FontFamily, 11, FontStyle.Bold);
                    panelContainer.Controls.Add(label);

                    GridControl gridControl = new GridControl();
                    gridControl.Name = "tblLoaiChatThai" + loaiChatThai.Id;
                    gridControl.Padding = new Padding(0, 20, 0, 20);
                    gridControl.Location = locationGridControl;
                    gridControl.Width = panelContainer.Width - 40;
                    panelContainer.Controls.Add(gridControl);

                    GridView gridView = new GridView(gridControl);
                    gridView.Name = "gridViewThaiDauRa" + loaiChatThai.Id;
                    gridControl.MainView = gridView;

                    gridView.CellValueChanged += GridViewThaiDauRa_CellValueChanged;
                    gridView.ValidatingEditor += GridViewThaiDauRa_ValidatingEditor;

                    gridView.Columns.Add(new GridColumn
                    {
                        Caption = "Chất thải",
                        FieldName = "ChatThai",
                        Visible = true,
                        Width = 110,
                        //MaxWidth = 110,
                        //MinWidth = 110,
                    });
                    gridView.Columns.Add(new GridColumn
                    {
                        FieldName = "ChatThaiId",
                        Visible = false,
                    });
                    gridView.Columns.Add(new GridColumn
                    {
                        Caption = "Đơn vị",
                        FieldName = "DonVi",
                        Visible = true,
                        ColumnEdit = lookupEdit,
                        //MaxWidth = 110,
                        MinWidth = 70,
                        Width = 110,
                    });
                    gridView.Columns.Add(new GridColumn
                    {
                        Caption = "Hệ số điều chỉnh",
                        FieldName = "HeSoDieuChinh",
                        Visible = true,
                        Width = 80,
                        //MaxWidth = 80,
                        MinWidth = 60,
                    });
                    foreach (var giaidoan in lcas)
                    {
                        gridView.Columns.Add(new GridColumn
                        {
                            Caption = giaidoan.KyHieu,
                            FieldName = giaidoan.KyHieu,
                            Visible = true,
                            Width = 50,
                            MinWidth = 50,
                            MaxWidth = 50,
                        });
                        gridView.Columns[giaidoan.KyHieu].OptionsColumn.AllowMove = false;
                        gridView.Columns[giaidoan.KyHieu].AppearanceCell.Font = new Font(gridView.Columns[giaidoan.KyHieu].AppearanceHeader.Font.FontFamily, 8);
                        gridView.Columns[giaidoan.KyHieu].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    }

                    gridView.Columns["DonVi"].AppearanceCell.Font = new Font(gridView.Columns["DonVi"].AppearanceHeader.Font.FontFamily, 8);
                    gridView.Columns["DonVi"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gridView.Columns["ChatThai"].AppearanceCell.Font = new Font(gridView.Columns["ChatThai"].AppearanceHeader.Font.FontFamily, 8);
                    gridView.Columns["ChatThai"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gridView.Columns["HeSoDieuChinh"].AppearanceCell.Font = new Font(gridView.Columns["HeSoDieuChinh"].AppearanceHeader.Font.FontFamily, 8);
                    gridView.Columns["HeSoDieuChinh"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                    gridView.Columns["ChatThai"].OptionsColumn.AllowEdit = false;
                    gridView.Columns["DonVi"].OptionsColumn.AllowEdit = true;
                    gridView.Columns["ChatThai"].OptionsColumn.AllowMove = false;
                    gridView.Columns["DonVi"].OptionsColumn.AllowMove = false;
                    gridView.Columns["HeSoDieuChinh"].OptionsColumn.AllowMove = false;

                    gridView.OptionsView.ShowIndicator = false;
                    gridView.OptionsView.ShowGroupPanel = false;
                    gridView.ScrollStyle = DevExpress.XtraGrid.Views.Grid.ScrollStyleFlags.None;

                    gridView.OptionsView.ShowIndicator = false;
                    gridView.OptionsView.ShowGroupPanel = false;

                    foreach (var chatThai in lstChatThai)
                    {
                        DataRow newRow = dataTable.NewRow();
                        newRow["ChatThai"] = chatThai.TenChatThai;
                        newRow["ChatThaiId"] = chatThai.Id;

                        if (lstThaiDauRa.Count() > 0)
                        {
                            foreach (var thaiDauRa in lstThaiDauRa)
                            {
                                LCA lca = await _lcaService.GetLCAById(thaiDauRa.LCAId);
                                if (lca != null && chatThai.Id == thaiDauRa.ChatThai.Id)
                                {
                                    newRow[lca.KyHieu] = thaiDauRa.SoLuong;
                                }
                                foreach (DonViSanPham donVi in lstDonViSanPham)
                                {
                                    ThaiDauRa dataThaiDauRa = lstThaiDauRa.FirstOrDefault(x => x.ChatThaiId == chatThai.Id && x.DonViId == donVi.Id && x.SanPhamId == _sanPham.Id);

                                    //ThaiDauRa dataThaiDauRa = await _thaiDauRaService.GetThaiDauRaByDVIdandChatThaiIdandSPId(chatThai.Id, donVi.Id, _sanPham.Id);
                                    if (dataThaiDauRa != null && donVi.Id == thaiDauRa.DonViId)
                                    {
                                        newRow["HeSoDieuChinh"] = dataThaiDauRa.HeSoDieuChinh;
                                        newRow["DonVi"] = donVi.Id;
                                        break;
                                    }
                                }
                            }
                        }
                        dataTable.Rows.Add(newRow);
                    }

                    gridControl.DataSource = dataTable;

                    if (index == lstLoaiChatThai.Count())
                    {
                        locationLabel = new Point(0, gridControl.Bottom + 80);
                        locationGridControl = new Point(0, gridControl.Bottom + 110);
                    }
                    else
                    {
                        locationLabel = new Point(0, gridControl.Bottom + 20);
                        locationGridControl = new Point(0, gridControl.Bottom + 50);
                    }
                    index++;
                }
            }
        }
        #endregion

        #region 
        private void ValidatingCellValue(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;

            if (e.Value == null || e.Value == "")
            {
                e.Valid = true;
                return;
            }

            GridColumn column = view.FocusedColumn;
            if (lstKyHieuLCA.Contains(column.FieldName))
            {
                if (e.Value != null && e.Value.ToString() != "" && e.Value.ToString() != "0")
                {
                    double value;
                    if (e.Value.ToString().Contains(",") || !double.TryParse(e.Value.ToString(), out value) || value < 0)
                    {
                        e.Valid = false;
                        e.ErrorText = "Giá trị không hợp lệ. Hãy nhập số thập phân không âm.";
                    }
                }
            }
            else if (column.FieldName == "HeSoDieuChinh")
            {
                if (e.Value != null)
                {
                    double hsdcValue;
                    if (e.Value.ToString().Contains(",") || !double.TryParse(e.Value.ToString(), out hsdcValue) || hsdcValue < 0)
                    {
                        e.Valid = false;
                        e.ErrorText = "Giá trị không hợp lệ. Hãy nhập số thập phân không âm.";
                    }
                }
            }
        }

        private void GridViewNguyenLieuSP_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            ValidatingCellValue(sender, e);
        }
        private void GridViewNhienLieuSP_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            ValidatingCellValue(sender, e);
        }

        private void GridViewThaiDauRa_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            ValidatingCellValue(sender, e);
        }

        int lcaId = 0;
        double soLuong = 0;
        private async void GridViewNguyenLieuSP_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            GridView gridView = sender as GridView;
            if (gridView != null)
            {
                int rowIndex = e.RowHandle;
                object row = gridView.GetRow(rowIndex);
                if (row != null)
                {
                    string col = e.Column.FieldName;

                    List<NguyenLieuSanPham> lstNguyenLieuSanPhamDV = new List<NguyenLieuSanPham>();
                    NguyenLieuSanPham nguyenLieuSP = new NguyenLieuSanPham();
                    int donViId = 0;
                    int nguyenLieuId = Convert.ToInt32(gridView.GetRowCellValue(rowIndex, "NguyenLieuId"));
                    object donViValue = gridView.GetRowCellValue(rowIndex, "DonVi");

                    if (donViValue != DBNull.Value)
                    {
                        dvNLSanPham = true;
                        donViId = Convert.ToInt32(donViValue);
                    }
                    else
                    {
                        dvNLSanPham = false;
                    }

                    if (col != "DonVi")
                    {
                        LCA lca = await _lcaService.GetLCAByKyHieu(col);
                        lcaId = lca.Id;
                        bool checkDouble = double.TryParse(e.Value.ToString(), out soLuong);
                        if (e.Value.ToString() == "" || e.Value.ToString() == "0")
                        {
                            soLuong = 0;
                            lstNguyenLieuSanPhamDT = await _nguyenLieuSanPhamService.GetNguyenLieuSanPhamBySPId(_sanPham.Id);

                            foreach (var item in lstNguyenLieuSanPhamDT)
                            {
                                if (item.NguyenLieuId == nguyenLieuId && item.LCAId == lcaId)
                                {
                                    item.SoLuong = soLuong;
                                    item.LCAId = lcaId;
                                    lstNguyenLieuSanPhamDV.Add(item);
                                }
                            }
                        }
                        if (soLuong != 0)
                        {
                            nguyenLieuSP.SoLuong = soLuong;
                            nguyenLieuSP.LCAId = lca.Id;
                            nguyenLieuSP.NguyenLieuId = nguyenLieuId;
                            nguyenLieuSP.SanPhamId = _sanPham.Id;
                            nguyenLieuSP.DonViId = donViId;
                            lstNguyenLieuSanPhamAdd.Add(nguyenLieuSP);
                        }

                    }
                    else
                    {
                        bool checkDonViId = int.TryParse(e.Value.ToString(), out donViId);
                        List<NguyenLieuSanPham> lstNguyenLieuSPup = lstNguyenLieuSanPhamAdd.Where(x => x.NguyenLieuId == nguyenLieuId).ToList();
                        if (lstNguyenLieuSPup.Count() > 0)
                        {
                            foreach (var nguyenLieuSPup in lstNguyenLieuSPup)
                            {
                                nguyenLieuSPup.DonViId = donViId;
                            }
                        }
                        foreach (var item in lstNguyenLieuSanPhamDT)
                        {
                            if (item.NguyenLieuId == nguyenLieuId)
                            {
                                item.DonViId = donViId;
                                lstNguyenLieuSanPhamDV.Add(item);
                            }
                        }
                    }

                    lstNguyenLieuSanPhamAdd.AddRange(lstNguyenLieuSanPhamDV);
                    var nguyenLieuSPupdate = lstNguyenLieuSanPhamAdd.FirstOrDefault(x => x.LCAId == lcaId && x.NguyenLieuId == nguyenLieuId && x.SanPhamId == _sanPham.Id);

                    if (nguyenLieuSPupdate != null)
                    {
                        nguyenLieuSPupdate.SoLuong = soLuong;
                        nguyenLieuSPupdate.DonViId = donViId != 0 ? donViId : 0;
                    }

                }

            }
        }

        private async void GridViewNhienLieuSP_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            GridView gridView = sender as GridView;
            if (gridView != null)
            {
                int rowIndex = e.RowHandle;
                object row = gridView.GetRow(rowIndex);

                if (row != null)
                {
                    string col = e.Column.FieldName;

                    List<NhienLieuSanPham> lstNhienLieuSanPhamDV = new List<NhienLieuSanPham>();
                    NhienLieuSanPham nhienLieuSP = new NhienLieuSanPham();
                    int donViId = 0;
                    LCA lca = new LCA();
                    int nhienLieuId = Convert.ToInt32(gridView.GetRowCellValue(rowIndex, "NhienLieuId"));
                    object donViValue = gridView.GetRowCellValue(rowIndex, "DonVi");

                    if (donViValue != DBNull.Value)
                    {
                        dvNLSanPham = true;
                        donViId = Convert.ToInt32(donViValue);
                    }
                    else
                    {
                        dvNLSanPham = false;
                    }

                    if (col != "DonVi")
                    {
                        lca = await _lcaService.GetLCAByKyHieu(col);

                        bool checkDouble = double.TryParse(e.Value.ToString(), out soLuong);
                        if (e.Value.ToString() == "" || e.Value.ToString() == "0")
                        {
                            soLuong = 0;
                            lstNhienLieuSanPhamDT = await _nhienLieuSanPhamService.GetNhienLieuSanPhamBySPId(_sanPham.Id);

                            foreach (var item in lstNhienLieuSanPhamDT)
                            {
                                if (item.NhienLieuId == nhienLieuId && item.LCAId == lca.Id)
                                {
                                    item.SoLuong = soLuong;
                                    item.LCAId = lca.Id;
                                    lstNhienLieuSanPhamDV.Add(item);
                                }
                            }
                        }

                        if (soLuong != 0)
                        {
                            nhienLieuSP.SoLuong = soLuong;
                            nhienLieuSP.LCAId = lca.Id;
                            nhienLieuSP.NhienLieuId = nhienLieuId;
                            nhienLieuSP.SanPhamId = _sanPham.Id;
                            nhienLieuSP.DonViId = donViId;
                            lstNhienLieuSanPhamAdd.Add(nhienLieuSP);
                        }
                    }
                    else
                    {
                        bool checkDonViId = int.TryParse(e.Value.ToString(), out donViId);
                        List<NhienLieuSanPham> lstNhienLieuSPup = lstNhienLieuSanPhamAdd.Where(x => x.NhienLieuId == nhienLieuId).ToList();
                        if (lstNhienLieuSPup.Count() > 0)
                        {
                            foreach (var nhienLieuup in lstNhienLieuSPup)
                            {
                                nhienLieuup.DonViId = donViId;
                            }
                        }
                        foreach (var item in lstNhienLieuSanPhamDT)
                        {
                            if (item.NhienLieuId == nhienLieuId)
                            {
                                item.DonViId = donViId;
                                lstNhienLieuSanPhamDV.Add(item);
                            }
                        }
                    }


                    lstNhienLieuSanPhamAdd.AddRange(lstNhienLieuSanPhamDV);
                    var nhienLieuSPUpdate = lstNhienLieuSanPhamAdd.FirstOrDefault(x => x.LCAId == lcaId && x.NhienLieuId == nhienLieuId && x.SanPhamId == _sanPham.Id);

                    if (nhienLieuSPUpdate != null)
                    {
                        nhienLieuSPUpdate.SoLuong = soLuong;
                        nhienLieuSPUpdate.DonViId = donViId != 0 ? donViId : 0;
                    }

                }

            }
        }

        //private double heSoDieuChinh = 0;
        private async void GridViewThaiDauRa_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            GridView gridView = sender as GridView;
            if (gridView != null)
            {
                int rowIndex = e.RowHandle;
                object row = gridView.GetRow(rowIndex);

                if (row != null)
                {
                    double soLuong = 0;
                    double heSoDieuChinh = 0;
                    int donViId = 0;

                    string col = e.Column.FieldName;

                    List<ThaiDauRa> lstThaiDauRaDV = new List<ThaiDauRa>();
                    ThaiDauRa thaiDauRa = new ThaiDauRa();
                    LCA lca = new LCA();
                    int chatThaiId = Convert.ToInt32(gridView.GetRowCellValue(rowIndex, "ChatThaiId"));
                    object heSoDieuChinhValue = gridView.GetRowCellValue(rowIndex, "HeSoDieuChinh");
                    object donViValue = gridView.GetRowCellValue(rowIndex, "DonVi");

                    if (donViValue != DBNull.Value)
                    {
                        dvThaiDauRaSanPham = true;
                        donViId = Convert.ToInt32(donViValue);
                    }
                    else
                    {
                        dvThaiDauRaSanPham = false;
                    }

                    if (heSoDieuChinhValue != DBNull.Value)
                    {
                        heSoDieuChinh = Convert.ToDouble(heSoDieuChinhValue);
                    }
                    else
                    {
                        heSoDieuChinh = 0;
                    }


                    if (col != "DonVi" && col != "HeSoDieuChinh")
                    {
                        lca = await _lcaService.GetLCAByKyHieu(col);
                        lcaId = lca.Id;
                        if (e.Value.ToString() == "" || e.Value.ToString() == "0")
                        {
                            soLuong = 0;
                            lstThaiDauRaDT = await _thaiDauRaService.GetThaiDauRaBySPId(_sanPham.Id);
                            foreach (var item in lstThaiDauRaDT)
                            {
                                if (item.ChatThaiId == chatThaiId && item.LCAId == lcaId)
                                {
                                    item.SoLuong = soLuong;
                                    item.LCAId = lcaId;
                                    lstThaiDauRaDV.Add(item);
                                }
                            }
                        }else
                        {
                            bool check = double.TryParse(e.Value.ToString(), out soLuong);
                        }

                        bool checkDouble = double.TryParse(e.Value.ToString(), out soLuong);
                        if (soLuong != 0)
                        {
                            thaiDauRa.SoLuong = soLuong;
                            thaiDauRa.LCAId = lca.Id;
                            thaiDauRa.ChatThaiId = chatThaiId;
                            thaiDauRa.HeSoDieuChinh = heSoDieuChinh;
                            thaiDauRa.SanPhamId = _sanPham.Id;
                            thaiDauRa.DonViId = donViId;
                            lstThaiDauRaAdd.Add(thaiDauRa);
                        }

                    }
                    else if (col == "HeSoDieuChinh")
                    {
                        bool checkHeSoDieuChinh = double.TryParse(e.Value.ToString(), out heSoDieuChinh);
                        if (e.Value.ToString() == "")
                        {
                            heSoDieuChinh = 0;
                        }
                        bool check = false;
                        List<ThaiDauRa> lstThaiDauRaup = lstThaiDauRaAdd.Where(x => x.ChatThaiId == chatThaiId).ToList();
                        if (!(lstThaiDauRaup.Count() > 0))
                        {
                            check = true;
                            lstThaiDauRaDT = await _thaiDauRaService.GetThaiDauRaBySPId(_sanPham.Id);
                            lstThaiDauRaup = lstThaiDauRaDT.Where(x => x.ChatThaiId == chatThaiId).ToList();
                        }

                        if (lstThaiDauRaup.Count() > 0)
                        {
                            foreach (var thaiDauRaup in lstThaiDauRaup)
                            {
                                thaiDauRaup.HeSoDieuChinh = heSoDieuChinh;
                                if (check && !lstThaiDauRaAdd.Any(x => x.LCAId == thaiDauRaup.LCAId && x.ChatThaiId == thaiDauRaup.ChatThaiId))
                                {
                                    lstThaiDauRaAdd.Add(thaiDauRaup);
                                }
                            }

                        }

                    }
                    else
                    {
                        bool checkDonViId = int.TryParse(e.Value.ToString(), out donViId);
                        List<ThaiDauRa> lstThaiDauRaUpDV = lstThaiDauRaAdd.Where(x => x.ChatThaiId == chatThaiId).ToList();
                        if (lstThaiDauRaUpDV.Count() > 0)
                        {
                            foreach (var thaiDauRaUpDV in lstThaiDauRaUpDV)
                            {
                                thaiDauRaUpDV.DonViId = donViId;
                            }
                        }
                        foreach (var item in lstThaiDauRaDT)
                        {
                            if (item.ChatThaiId == chatThaiId)
                            {
                                item.DonViId = donViId;
                                lstThaiDauRaDV.Add(item);
                            }
                        }
                    }

                    lstThaiDauRaAdd.AddRange(lstThaiDauRaDV);
                    var thaiDauRaUpdate = lstThaiDauRaAdd.FirstOrDefault(x => x.LCAId == lcaId && x.ChatThaiId == chatThaiId && x.SanPhamId == _sanPham.Id);

                    if (thaiDauRaUpdate != null)
                    {
                        thaiDauRaUpdate.SoLuong = soLuong != 0 ? soLuong : thaiDauRaUpdate.SoLuong;
                        thaiDauRaUpdate.HeSoDieuChinh = heSoDieuChinh;
                        thaiDauRaUpdate.DonViId = donViId != 0 ? donViId : 0;
                    }

                }

            }
        }
        #endregion

        private async void btnCalcResult_Click(object sender, EventArgs e)
        {
            //if (dvThaiDauRaSanPham && dvNgLSanPham && dvNLSanPham)
            //{
            bool check = await SaveDataLCA();
            if (check)
            {
                lstNguyenLieuSanPhamAdd.Clear();
                lstNhienLieuSanPhamAdd.Clear();
                lstThaiDauRaAdd.Clear();

                BangKetQuaTinhToanForm bkq = new BangKetQuaTinhToanForm(_sanPham);
                bkq.ShowDialog();
                //MessageBox.Show("Thành công", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lỗi", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //}
        }
        private async void btnSaveLCA_Click(object sender, EventArgs e)
        {
            if (dvThaiDauRaSanPham && dvNgLSanPham && dvNLSanPham)
            {
                bool check = await SaveDataLCA();
                if (check)
                {
                    lstNguyenLieuSanPhamAdd.Clear();
                    lstNhienLieuSanPhamAdd.Clear();
                    lstThaiDauRaAdd.Clear();
                    MessageBox.Show("Thành công", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Lỗi", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn đầy đủ đơn vị sản phẩm", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task<bool> SaveDataLCA()
        {
            bool checkNguyenLieuSP = await _nguyenLieuSanPhamService.AddRangeOrUpdateNguyenLieuSanPham(lstNguyenLieuSanPhamAdd);
            bool checkNhienLieuSP = await _nhienLieuSanPhamService.AddRangeOrUpdateNhienLieuSanPham(lstNhienLieuSanPhamAdd);
            bool checkThaiDauRa = await _thaiDauRaService.AddRangeOrUpdateThaiDauRa(lstThaiDauRaAdd);

            if (checkNguyenLieuSP && checkNhienLieuSP && checkThaiDauRa) return true;

            return false;
        }
    }
}