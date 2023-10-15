using DevExpress.XtraBars.Docking2010.DragEngine;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraExport.Helpers;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting.Native;
using DevExpress.XtraReports.Design.DragDrop;
using DevExpress.XtraSplashScreen;
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
using Word = Microsoft.Office.Interop.Word;
using GridView = DevExpress.XtraGrid.Views.Grid.GridView;
namespace VienHoa.View.BangKetQuaTinhToanVIew
{

    public partial class BangKetQuaTinhToanForm : DevExpress.XtraEditors.XtraForm
    {
        private readonly IRepository<ChiSoTacDong> _chiSoTacDongRepo;
        private readonly AppDbContext _db;
        private int desiredId;

        public BangKetQuaTinhToanForm(SanPham sanPham)
        {
            InitializeComponent();
            _chiSoTacDongRepo = new ExRepository<ChiSoTacDong>();
            _db = new AppDbContext();
            desiredId = sanPham.Id;
            FillData(sanPham);
        }
        private void dataChiSoTacDong(List<ChiSoTacDong> chiSoTacDongs, TypeData typeData)
        {
            foreach (ChiSoTacDong chiSoTacDong in chiSoTacDongs)
            {
                switch (chiSoTacDong.LCA.KyHieu)
                {
                    case "A1":
                        typeData.A1 = chiSoTacDong.GiaTri;
                        break;
                    case "A2":
                        typeData.A2 = chiSoTacDong.GiaTri;
                        break;
                    case "A3":
                        typeData.A3 = chiSoTacDong.GiaTri;
                        break;
                    case "A4":
                        typeData.A4 = chiSoTacDong.GiaTri;
                        break;
                    case "A5":
                        typeData.A5 = chiSoTacDong.GiaTri;
                        break;
                    case "B1":
                        typeData.B1 = chiSoTacDong.GiaTri;
                        break;
                    case "B2":
                        typeData.B2 = chiSoTacDong.GiaTri;
                        break;
                    case "B3":
                        typeData.B3 = chiSoTacDong.GiaTri;
                        break;
                    case "B4":
                        typeData.B4 = chiSoTacDong.GiaTri;
                        break;
                    case "B5":
                        typeData.B5 = chiSoTacDong.GiaTri;
                        break;
                    case "B6":
                        typeData.B6 = chiSoTacDong.GiaTri;
                        break;
                    case "B7":
                        typeData.B7 = chiSoTacDong.GiaTri;
                        break;
                    case "C1":
                        typeData.C1 = chiSoTacDong.GiaTri;
                        break;
                    case "C2":
                        typeData.C2 = chiSoTacDong.GiaTri;
                        break;
                    case "C3":
                        typeData.C3 = chiSoTacDong.GiaTri;
                        break;
                    case "C4":
                        typeData.D = chiSoTacDong.GiaTri;
                        break;
                    case "D":
                        typeData.D = chiSoTacDong.GiaTri;
                        break;
                }
            }
        }

        private async void FillData(SanPham sanPham)
        {

            DevExpress.XtraGrid.Views.Grid.GridView HieuUngNhaKinhView = gridViewHieuUngNhaKinh;
            HieuUngNhaKinhView.OptionsBehavior.AutoPopulateColumns = false;
            HieuUngNhaKinhTbl.MainView = HieuUngNhaKinhView;
            GridViewData(HieuUngNhaKinhView);
            List<ChiSoTacDong> hieuUngNhaKinh = _chiSoTacDongRepo.TableUntracked.Include(x => x.LCA).Where(x => x.SanPhamId == sanPham.Id && x.TacDong.TenTacDong.Contains("Tiềm Năng Hiệu Ứng Nhà Kính")).ToList();
            TypeData typeDataHieuUngNhaKinh = new TypeData();
            typeDataHieuUngNhaKinh.tacDong = "Hiệu ứng nhà kính";
            typeDataHieuUngNhaKinh.donVi = "kg CO2-e";
            dataChiSoTacDong(hieuUngNhaKinh, typeDataHieuUngNhaKinh);
            List<TypeData> lstHieuUngNhaKinh = new List<TypeData>() { typeDataHieuUngNhaKinh };
            HieuUngNhaKinhTbl.DataSource = lstHieuUngNhaKinh;

            DevExpress.XtraGrid.Views.Grid.GridView PhuDuongView = gridViewPhuDuong;
            PhuDuongView.OptionsBehavior.AutoPopulateColumns = false;
            GridViewData(PhuDuongView);
            List<ChiSoTacDong> phuDuong = _chiSoTacDongRepo.TableUntracked.Include(x => x.LCA).Where(x => x.SanPhamId == sanPham.Id && x.TacDong.TenTacDong.Contains("Phú Dưỡng")).ToList();
            TypeData typeDataPhuDuong = new TypeData();
            typeDataPhuDuong.tacDong = "Phú dưỡng";
            typeDataPhuDuong.donVi = " kg PO4-e";
            dataChiSoTacDong(phuDuong, typeDataPhuDuong);
            List<TypeData> lstPhuDuong = new List<TypeData>() { typeDataPhuDuong };
            PhuDuongTbl.DataSource = lstPhuDuong;

            DevExpress.XtraGrid.Views.Grid.GridView AxitHoaView = gridViewAxitHoa;
            AxitHoaView.OptionsBehavior.AutoPopulateColumns = false;
            GridViewData(AxitHoaView);
            List<ChiSoTacDong> axitHoa = _chiSoTacDongRepo.TableUntracked.Include(x => x.LCA).Where(x => x.SanPhamId == sanPham.Id && x.TacDong.TenTacDong.Contains("Sự Axit Hóa")).ToList();
            TypeData typeDataAxitHoa = new TypeData();
            typeDataAxitHoa.tacDong = "Sự Axit hóa";
            typeDataAxitHoa.donVi = "kg SO2-e";
            dataChiSoTacDong(axitHoa, typeDataAxitHoa);
            List<TypeData> lstAxitHoa = new List<TypeData>() { typeDataAxitHoa };
            AxitHoaTbl.DataSource = lstAxitHoa;

            DevExpress.XtraGrid.Views.Grid.GridView OzonQuangHoaView = gridViewOzonQuangHoa;
            OzonQuangHoaView.OptionsBehavior.AutoPopulateColumns = false;
            GridViewData(OzonQuangHoaView);
            List<ChiSoTacDong> ozonQuangHoa = _chiSoTacDongRepo.TableUntracked.Include(x => x.LCA).Where(x => x.SanPhamId == sanPham.Id && x.TacDong.TenTacDong.Contains("Tiềm Năng Tạo Ozzon Quang Hóa")).ToList();
            TypeData typeDataOzonQuangHoa = new TypeData();
            typeDataOzonQuangHoa.tacDong = "Tiềm năng Ozon quang hóa";
            typeDataOzonQuangHoa.donVi = "kg C2H4-e";
            dataChiSoTacDong(ozonQuangHoa, typeDataOzonQuangHoa);
            List<TypeData> lstOzonQuangHoa = new List<TypeData>() { typeDataOzonQuangHoa };
            OzonQuangHoaTbl.DataSource = lstOzonQuangHoa;

            DevExpress.XtraGrid.Views.Grid.GridView PhaHuyTangOzonView = gridViewPhaHuyTangOzon;
            PhaHuyTangOzonView.OptionsBehavior.AutoPopulateColumns = false;
            GridViewData(PhaHuyTangOzonView);
            List<ChiSoTacDong> phaHuyTangOzon = _chiSoTacDongRepo.TableUntracked.Include(x => x.LCA).Where(x => x.SanPhamId == sanPham.Id && x.TacDong.TenTacDong.Contains("Phá Hủy Tầng Ozon")).ToList();
            TypeData typeDataPhaHuyTangOzon = new TypeData();
            typeDataPhaHuyTangOzon.tacDong = "Phá hủy tầng Ozon";
            typeDataPhaHuyTangOzon.donVi = "kg CFC-11 ";
            dataChiSoTacDong(phaHuyTangOzon, typeDataPhaHuyTangOzon);
            List<TypeData> lstPhaHuyTangOzon = new List<TypeData>() { typeDataPhaHuyTangOzon };
            PhaHuyTangOzonTbl.DataSource = lstPhaHuyTangOzon;

            DevExpress.XtraGrid.Views.Grid.GridView BuiView = gridViewBui;
            BuiView.OptionsBehavior.AutoPopulateColumns = false;
            GridViewData(BuiView);
            List<ChiSoTacDong> Bui = _chiSoTacDongRepo.TableUntracked.Include(x => x.LCA).Where(x => x.SanPhamId == sanPham.Id && x.TacDong.TenTacDong.Contains("Phát sinh bụi")).ToList();
            TypeData typeDataBui = new TypeData();
            typeDataBui.tacDong = "Phát sinh bụi";
            typeDataBui.donVi = "kg CFC-11 ";
            dataChiSoTacDong(Bui, typeDataBui);
            List<TypeData> lstBui = new List<TypeData>() { typeDataBui };
            BuiTbl.DataSource = lstBui;

            DevExpress.XtraGrid.Views.Grid.GridView SuDungCacNguonTaiNguyenView = gridViewSuDungCacNguonTaiNguyen;
            SuDungCacNguonTaiNguyenView.OptionsBehavior.AutoPopulateColumns = false;
            GridViewData(SuDungCacNguonTaiNguyenView);
            List<ChiSoTacDong> nangLuongTaiTao = _chiSoTacDongRepo.TableUntracked.Include(x => x.LCA).Where(x => x.SanPhamId == sanPham.Id && x.TacDong.TenTacDong.Contains("Sử Dụng Năng Lượng Tái Tạo")).ToList();
            TypeData typeDataNangLuongTaiTao = new TypeData();
            typeDataNangLuongTaiTao.tacDong = "Sử dụng năng lượng tái tạo";
            typeDataNangLuongTaiTao.donVi = "MJ";
            dataChiSoTacDong(nangLuongTaiTao, typeDataNangLuongTaiTao);
            List<TypeData> lstNangLuongTaiTao = new List<TypeData>() { typeDataNangLuongTaiTao };

            List<ChiSoTacDong> nangLuongKhongTaiTao = _chiSoTacDongRepo.TableUntracked.Include(x => x.LCA).Where(x => x.SanPhamId == sanPham.Id && x.TacDong.TenTacDong.Contains("Sử Dụng Năng Lượng Không Tái Tạo")).ToList();
            TypeData typeDataNangLuongKhongTaiTao = new TypeData();
            typeDataNangLuongKhongTaiTao.tacDong = "Sử dụng năng lượng không tái tạo";
            typeDataNangLuongKhongTaiTao.donVi = "MJ";
            dataChiSoTacDong(nangLuongKhongTaiTao, typeDataNangLuongKhongTaiTao);
            List<TypeData> lstNangLuongKhongTaiTao = new List<TypeData>() { typeDataNangLuongKhongTaiTao };

            List<ChiSoTacDong> nangLuongTuNangLuongThayThe = _chiSoTacDongRepo.TableUntracked.Include(x => x.LCA).Where(x => x.SanPhamId == sanPham.Id && x.TacDong.TenTacDong.Contains("Sử Dụng Năng Lượng Từ Nhiên Liệu Thay Thế")).ToList();
            TypeData typeDataNangLuongTuNangLuongThayThe = new TypeData();
            typeDataNangLuongTuNangLuongThayThe.tacDong = "Sử dụng năng lượng từ nhiên liệu thay thế";
            typeDataNangLuongTuNangLuongThayThe.donVi = "MJ";
            dataChiSoTacDong(nangLuongTuNangLuongThayThe, typeDataNangLuongTuNangLuongThayThe);
            List<TypeData> lstNangLuongTuNangLuongThayThe = new List<TypeData>() { typeDataNangLuongTuNangLuongThayThe };

            List<ChiSoTacDong> suDungNuoc = _chiSoTacDongRepo.TableUntracked.Include(x => x.LCA).Where(x => x.SanPhamId == sanPham.Id && x.TacDong.TenTacDong.Contains("Sử dụng nước")).ToList();
            TypeData typeDataSuDungNuoc = new TypeData();
            typeDataSuDungNuoc.tacDong = "Sử dụng nước";
            typeDataSuDungNuoc.donVi = "M3";
            dataChiSoTacDong(suDungNuoc, typeDataSuDungNuoc);
            List<TypeData> lstSuDungNuoc = new List<TypeData>() { typeDataSuDungNuoc };

            List<TypeData> lstSuDungCacNguonTaiNguyen = new List<TypeData>();
            lstSuDungCacNguonTaiNguyen.AddRange(lstNangLuongTaiTao);
            lstSuDungCacNguonTaiNguyen.AddRange(lstNangLuongKhongTaiTao);
            lstSuDungCacNguonTaiNguyen.AddRange(lstNangLuongTuNangLuongThayThe);
            lstSuDungCacNguonTaiNguyen.AddRange(lstSuDungNuoc);
            SuDungCacNguonTaiNguyenTbl.DataSource = lstSuDungCacNguonTaiNguyen;

            DevExpress.XtraGrid.Views.Grid.GridView ChatThaiPhatSinhView = gridViewChatThaiPhatSinh;
            ChatThaiPhatSinhView.OptionsBehavior.AutoPopulateColumns = false;
            GridViewData(ChatThaiPhatSinhView);

            List<ChiSoTacDong> chatThaiNguyHai = _chiSoTacDongRepo.TableUntracked.Include(x => x.LCA).Where(x => x.SanPhamId == sanPham.Id && x.TacDong.TenTacDong.Contains("Chất thải nguy hại")).ToList();
            TypeData typeDataChatThaiNguyHai = new TypeData();
            typeDataChatThaiNguyHai.tacDong = "Chất thải nguy hại";
            typeDataChatThaiNguyHai.donVi = "Kg";
            dataChiSoTacDong(chatThaiNguyHai, typeDataChatThaiNguyHai);
            List<TypeData> lstChatThaiNguyHai = new List<TypeData>() { typeDataChatThaiNguyHai };

            List<ChiSoTacDong> chatThaiKhongNguyHai = _chiSoTacDongRepo.TableUntracked.Include(x => x.LCA).Where(x => x.SanPhamId == sanPham.Id && x.TacDong.TenTacDong.Contains("Chất thải không nguy hại")).ToList();
            TypeData typeDataChatThaiKhongNguyHai = new TypeData();
            typeDataChatThaiKhongNguyHai.tacDong = "Chất thải không nguy hại";
            typeDataChatThaiKhongNguyHai.donVi = "Kg";
            dataChiSoTacDong(chatThaiKhongNguyHai, typeDataChatThaiKhongNguyHai);
            List<TypeData> lstChatThaiKhongNguyHai = new List<TypeData>() { typeDataChatThaiKhongNguyHai };

            List<TypeData> lstChatThaiPhatSinh = new List<TypeData>();
            lstChatThaiPhatSinh.AddRange(lstChatThaiNguyHai);
            lstChatThaiPhatSinh.AddRange(lstChatThaiKhongNguyHai);
            ChatThaiPhatSinhTbl.DataSource = lstChatThaiPhatSinh;

            DevExpress.XtraGrid.Views.Grid.GridView DongVatLieuDauRaView = gridViewDongVatLieuDauRa;
            DongVatLieuDauRaView.OptionsBehavior.AutoPopulateColumns = false;
            GridViewData(DongVatLieuDauRaView);
            List<ChiSoTacDong> taoRaNangLuong = _chiSoTacDongRepo.TableUntracked.Include(x => x.LCA).Where(x => x.SanPhamId == sanPham.Id && x.TacDong.TenTacDong.Contains("Tạo ra năng lượng")).ToList();
            TypeData typeDataTaoRaNangLuong = new TypeData();
            typeDataTaoRaNangLuong.tacDong = "Tạo ra năng lượng ";
            typeDataTaoRaNangLuong.donVi = "kg CFC-11 ";
            dataChiSoTacDong(taoRaNangLuong, typeDataTaoRaNangLuong);
            List<TypeData> lstTaoRaNangLuong = new List<TypeData>() { typeDataTaoRaNangLuong };
            DongVatLieuDauRaTbl.DataSource = lstTaoRaNangLuong;

        }

        private void GridViewData(DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            gridView.OptionsBehavior.AutoPopulateColumns = false;

            GridColumn tacdong = gridView.Columns.AddVisible("tacDong");
            GridColumn donvi = gridView.Columns.AddVisible("donVi");
            GridColumn A1 = gridView.Columns.AddVisible("A1");
            GridColumn A2 = gridView.Columns.AddVisible("A2");
            GridColumn A3 = gridView.Columns.AddVisible("A3");
            GridColumn A4 = gridView.Columns.AddVisible("A4");
            GridColumn A5 = gridView.Columns.AddVisible("A5");
            GridColumn B1 = gridView.Columns.AddVisible("B1");
            GridColumn B2 = gridView.Columns.AddVisible("B2");
            GridColumn B3 = gridView.Columns.AddVisible("B3");
            GridColumn B4 = gridView.Columns.AddVisible("B4");
            GridColumn B5 = gridView.Columns.AddVisible("B5");
            GridColumn B6 = gridView.Columns.AddVisible("B6");
            GridColumn B7 = gridView.Columns.AddVisible("B7");
            GridColumn C1 = gridView.Columns.AddVisible("C1");
            GridColumn C2 = gridView.Columns.AddVisible("C2");
            GridColumn C3 = gridView.Columns.AddVisible("C3");
            GridColumn C4 = gridView.Columns.AddVisible("C4");
            GridColumn D = gridView.Columns.AddVisible("D");

            tacdong.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            tacdong.AppearanceCell.Options.UseFont = true;
            tacdong.AppearanceCell.Options.UseTextOptions = true;
            tacdong.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            tacdong.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            tacdong.AppearanceHeader.Options.UseFont = true;
            tacdong.AppearanceHeader.Options.UseTextOptions = true;
            tacdong.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            tacdong.Caption = "Tác động";
            tacdong.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            tacdong.MinWidth = 100;
            tacdong.OptionsColumn.AllowEdit = false;
            tacdong.Visible = true;
            tacdong.VisibleIndex = 0;
            tacdong.Width = 128;

            donvi.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            donvi.AppearanceCell.Options.UseFont = true;
            donvi.AppearanceCell.Options.UseTextOptions = true;
            donvi.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            donvi.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            donvi.AppearanceHeader.Options.UseFont = true;
            donvi.AppearanceHeader.Options.UseTextOptions = true;
            donvi.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            donvi.Caption = "Đơn vị";
            donvi.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            donvi.MinWidth = 25;
            donvi.OptionsColumn.AllowEdit = false;
            donvi.Visible = true;
            donvi.VisibleIndex = 1;
            donvi.Width = 80;

            A1.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            A1.AppearanceCell.Options.UseFont = true;
            A1.AppearanceCell.Options.UseTextOptions = true;
            A1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            A1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            A1.AppearanceHeader.Options.UseFont = true;
            A1.AppearanceHeader.Options.UseTextOptions = true;
            A1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            A1.Caption = "A1";
            A1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            A1.MinWidth = 30;
            A1.OptionsColumn.AllowEdit = false;
            A1.Visible = true;
            A1.VisibleIndex = 2;
            A1.Width = 52;

            A2.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            A2.AppearanceCell.Options.UseFont = true;
            A2.AppearanceCell.Options.UseTextOptions = true;
            A2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            A2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            A2.AppearanceHeader.Options.UseFont = true;
            A2.AppearanceHeader.Options.UseTextOptions = true;
            A2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            A2.Caption = "A2";
            A2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            A2.MinWidth = 30;
            A2.OptionsColumn.AllowEdit = false;
            A2.Visible = true;
            A2.VisibleIndex = 3;
            A2.Width = 52;

            A3.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            A3.AppearanceCell.Options.UseFont = true;
            A3.AppearanceCell.Options.UseTextOptions = true;
            A3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            A3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            A3.AppearanceHeader.Options.UseFont = true;
            A3.AppearanceHeader.Options.UseTextOptions = true;
            A3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            A3.Caption = "A3";
            A3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            A3.MinWidth = 30;
            A3.OptionsColumn.AllowEdit = false;
            A3.Visible = true;
            A3.VisibleIndex = 4;
            A3.Width = 52;

            A4.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            A4.AppearanceCell.Options.UseFont = true;
            A4.AppearanceCell.Options.UseTextOptions = true;
            A4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            A4.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            A4.AppearanceHeader.Options.UseFont = true;
            A4.AppearanceHeader.Options.UseTextOptions = true;
            A4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            A4.Caption = "A4";
            A4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            A4.MinWidth = 30;
            A4.OptionsColumn.AllowEdit = false;
            A4.Visible = true;
            A4.VisibleIndex = 5;
            A4.Width = 52;

            A5.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            A5.AppearanceCell.Options.UseFont = true;
            A5.AppearanceCell.Options.UseTextOptions = true;
            A5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            A5.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            A5.AppearanceHeader.Options.UseFont = true;
            A5.AppearanceHeader.Options.UseTextOptions = true;
            A5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            A5.Caption = "A5";
            A5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            A5.MinWidth = 30;
            A5.OptionsColumn.AllowEdit = false;
            A5.Visible = true;
            A5.VisibleIndex = 6;
            A5.Width = 52;

            B1.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            B1.AppearanceCell.Options.UseFont = true;
            B1.AppearanceCell.Options.UseTextOptions = true;
            B1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            B1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            B1.AppearanceHeader.Options.UseFont = true;
            B1.AppearanceHeader.Options.UseTextOptions = true;
            B1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            B1.Caption = "B1";
            B1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            B1.MinWidth = 30;
            B1.OptionsColumn.AllowEdit = false;
            B1.Visible = true;
            B1.VisibleIndex = 7;
            B1.Width = 52;

            B2.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            B2.AppearanceCell.Options.UseFont = true;
            B2.AppearanceCell.Options.UseTextOptions = true;
            B2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            B2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            B2.AppearanceHeader.Options.UseFont = true;
            B2.AppearanceHeader.Options.UseTextOptions = true;
            B2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            B2.Caption = "B2";
            B2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            B2.MinWidth = 30;
            B2.OptionsColumn.AllowEdit = false;
            B2.Visible = true;
            B2.VisibleIndex = 8;
            B2.Width = 52;

            B3.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            B3.AppearanceCell.Options.UseFont = true;
            B3.AppearanceCell.Options.UseTextOptions = true;
            B3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            B3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            B3.AppearanceHeader.Options.UseFont = true;
            B3.AppearanceHeader.Options.UseTextOptions = true;
            B3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            B3.Caption = "B3";
            B3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            B3.MinWidth = 30;
            B3.OptionsColumn.AllowEdit = false;
            B3.Visible = true;
            B3.VisibleIndex = 9;
            B3.Width = 52;

            B4.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            B4.AppearanceCell.Options.UseFont = true;
            B4.AppearanceCell.Options.UseTextOptions = true;
            B4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            B4.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            B4.AppearanceHeader.Options.UseFont = true;
            B4.AppearanceHeader.Options.UseTextOptions = true;
            B4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            B4.Caption = "B4";
            B4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            B4.MinWidth = 30;
            B4.OptionsColumn.AllowEdit = false;
            B4.Visible = true;
            B4.VisibleIndex = 10;
            B4.Width = 52;

            B5.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            B5.AppearanceCell.Options.UseFont = true;
            B5.AppearanceCell.Options.UseTextOptions = true;
            B5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            B5.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            B5.AppearanceHeader.Options.UseFont = true;
            B5.AppearanceHeader.Options.UseTextOptions = true;
            B5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            B5.Caption = "B5";
            B5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            B5.MinWidth = 30;
            B5.OptionsColumn.AllowEdit = false;
            B5.Visible = true;
            B5.VisibleIndex = 11;
            B5.Width = 52;

            B6.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            B6.AppearanceCell.Options.UseFont = true;
            B6.AppearanceCell.Options.UseTextOptions = true;
            B6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            B6.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            B6.AppearanceHeader.Options.UseFont = true;
            B6.AppearanceHeader.Options.UseTextOptions = true;
            B6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            B6.Caption = "B6";
            B6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            B6.MinWidth = 30;
            B6.OptionsColumn.AllowEdit = false;
            B6.Visible = true;
            B6.VisibleIndex = 12;
            B6.Width = 52;

            B7.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            B7.AppearanceCell.Options.UseFont = true;
            B7.AppearanceCell.Options.UseTextOptions = true;
            B7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            B7.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            B7.AppearanceHeader.Options.UseFont = true;
            B7.AppearanceHeader.Options.UseTextOptions = true;
            B7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            B7.Caption = "B7";
            B7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            B7.MinWidth = 30;
            B7.OptionsColumn.AllowEdit = false;
            B7.Visible = true;
            B7.VisibleIndex = 13;
            B7.Width = 52;

            C1.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            C1.AppearanceCell.Options.UseFont = true;
            C1.AppearanceCell.Options.UseTextOptions = true;
            C1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            C1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            C1.AppearanceHeader.Options.UseFont = true;
            C1.AppearanceHeader.Options.UseTextOptions = true;
            C1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            C1.Caption = "C1";
            C1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            C1.MinWidth = 30;
            C1.OptionsColumn.AllowEdit = false;
            C1.Visible = true;
            C1.VisibleIndex = 14;
            C1.Width = 52;

            C2.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            C2.AppearanceCell.Options.UseFont = true;
            C2.AppearanceCell.Options.UseTextOptions = true;
            C2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            C2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            C2.AppearanceHeader.Options.UseFont = true;
            C2.AppearanceHeader.Options.UseTextOptions = true;
            C2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            C2.Caption = "C2";
            C2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            C2.MinWidth = 30;
            C2.OptionsColumn.AllowEdit = false;
            C2.Visible = true;
            C2.VisibleIndex = 15;
            C2.Width = 52;

            C3.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            C3.AppearanceCell.Options.UseFont = true;
            C3.AppearanceCell.Options.UseTextOptions = true;
            C3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            C3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            C3.AppearanceHeader.Options.UseFont = true;
            C3.AppearanceHeader.Options.UseTextOptions = true;
            C3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            C3.Caption = "C3";
            C3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            C3.MinWidth = 30;
            C3.OptionsColumn.AllowEdit = false;
            C3.Visible = true;
            C3.VisibleIndex = 16;
            C3.Width = 52;

            C4.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            C4.AppearanceCell.Options.UseFont = true;
            C4.AppearanceCell.Options.UseTextOptions = true;
            C4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            C4.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            C4.AppearanceHeader.Options.UseFont = true;
            C4.AppearanceHeader.Options.UseTextOptions = true;
            C4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            C4.Caption = "C4";
            C4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            C4.MinWidth = 30;
            C4.OptionsColumn.AllowEdit = false;
            C4.Visible = true;
            C4.VisibleIndex = 17;
            C4.Width = 52;

            D.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            D.AppearanceCell.Options.UseFont = true;
            D.AppearanceCell.Options.UseTextOptions = true;
            D.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            D.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            D.AppearanceHeader.Options.UseFont = true;
            D.AppearanceHeader.Options.UseTextOptions = true;
            D.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            D.Caption = "D";
            D.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            D.MinWidth = 10;
            D.OptionsColumn.AllowEdit = false;
            D.Visible = true;
            D.VisibleIndex = 18;
            D.Width = 52;
        }

        public class TypeData
        {
            public string tacDong { get; set; }
            public string donVi { get; set; }
            public double A1 { get; set; }
            public double A2 { get; set; }
            public double A3 { get; set; }
            public double A4 { get; set; }
            public double A5 { get; set; }
            public double B1 { get; set; }
            public double B2 { get; set; }
            public double B3 { get; set; }
            public double B4 { get; set; }
            public double B5 { get; set; }
            public double B6 { get; set; }
            public double B7 { get; set; }
            public double C1 { get; set; }
            public double C2 { get; set; }
            public double C3 { get; set; }
            public double C4 { get; set; }
            public double D { get; set; }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void UpdateWordField(Microsoft.Office.Interop.Word.Document doc, string fieldName, string newValue)
        {
            object findtext = fieldName;
            Microsoft.Office.Interop.Word.Range wordRange = doc.Content;
            wordRange.Find.Execute(ref findtext);

            if (wordRange.Find.Found)
            {
                wordRange.Text = newValue;
            }
        }

        private void UpdateTableWord(Microsoft.Office.Interop.Word.Document doc, string fieldName, DevExpress.XtraGrid.GridControl gridControl)
        {
            object findText = fieldName;
            Microsoft.Office.Interop.Word.Range wordRange = doc.Content;
            wordRange.Find.Execute(ref findText);
            wordRange.Delete();

            GridView myGridView = gridControl.MainView as GridView;

            // Thêm 1 hàng để chứa tiêu đề cột
            Microsoft.Office.Interop.Word.Table table = doc.Tables.Add(wordRange, myGridView.RowCount + 1, myGridView.Columns.Count);
            table.Borders.Enable = 1;

            // Thêm tiêu đề cột vào hàng đầu tiên của bảng
            for (int j = 0; j < myGridView.Columns.Count; j++)
            {
                string caption = myGridView.Columns[j].Caption;
                table.Cell(1, j + 1).Range.Text = caption;
            }

            // Thêm dữ liệu vào các ô còn lại của bảng
            for (int i = 0; i < myGridView.RowCount; i++)
            {
                for (int j = 0; j < myGridView.Columns.Count; j++)
                {
                    object cellValue = myGridView.GetRowCellValue(i, myGridView.Columns[j]);
                    table.Cell(i + 2, j + 1).Range.Text = cellValue?.ToString() ?? "";
                }
            }
        }

        private void btnXuatFileWord_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowDefaultWaitForm("Đang xử lý", "Vui lòng chờ...");

            try
            {
                // Kiểm tra xem Microsoft Word đã được cài đặt hay chưa
                Type type = Type.GetTypeFromProgID("Word.Application");
                if (type == null)
                {
                    MessageBox.Show("Microsoft Word chưa được cài đặt trên máy tính này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    SplashScreenManager.CloseDefaultWaitForm();
                    return;
                }

                Word.Application wordApp = new Word.Application();
                wordApp.Visible = false;

                string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string rootDirectory = System.IO.Directory.GetParent(appDirectory).Parent.Parent.Parent.FullName;
                string filePath = System.IO.Path.Combine(rootDirectory, "Word", "FormWord.docx");
                Word.Document docTemplate = wordApp.Documents.Open(filePath);
                Word.Document docNew = wordApp.Documents.Add();
                docTemplate.Content.Copy();
                docNew.Content.Paste();

                // tiêu đề 
                var sanPham = _db.sanPhams.Include(x => x.DuAn).ThenInclude(x => x.DoanhNghiep).FirstOrDefault(sp => sp.Id == desiredId);
                Dictionary<string, string> fieldMap = new Dictionary<string, string>
                {
                    { "TenCongTy", sanPham.DuAn.DoanhNghiep.TenCongTy },
                    { "TenDuAn", sanPham.DuAn.TenDuAn },
                    { "DiaChi", sanPham.DuAn.DoanhNghiep.DiaChi },
                    { "LienHe", sanPham.DuAn.DoanhNghiep.DienThoai },
                    { "TenSanPham", sanPham.TenSanPham },
                    { "KyHieuSanPham", sanPham.KyHieu },
                    { "NoiSanXuat", sanPham.DuAn.DoanhNghiep.DiaChi },
                    { "Codes", sanPham.MaCode }
                };
                foreach (var item in fieldMap)
                {
                    UpdateWordField(docNew, item.Key, item.Value);
                }
                //
                UpdateTableWord(docNew, "HUNK", HieuUngNhaKinhTbl);
                //
                UpdateTableWord(docNew, "PHTOZ", PhaHuyTangOzonTbl);
                //
                UpdateTableWord(docNew, "AXHOA", AxitHoaTbl);
                //
                UpdateTableWord(docNew, "PD", PhuDuongTbl);
                //
                UpdateTableWord(docNew, "BKQTN", SuDungCacNguonTaiNguyenTbl);
                //
                UpdateTableWord(docNew, "BKQCTPS", ChatThaiPhatSinhTbl);
                //
                UpdateTableWord(docNew, "CDDR", DongVatLieuDauRaTbl);

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Word Document|*.docx";
                saveFileDialog.Title = "Save Word File";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    SplashScreenManager.ShowDefaultWaitForm("Đang lưu...", "Vui lòng chờ...");

                    try
                    {
                        docNew.SaveAs2(saveFileDialog.FileName);
                        docNew.Close();
                        wordApp.Quit();
                    }
                    catch (Exception exSave)
                    {
                        // Xử lý lỗi khi không thể lưu
                    }
                    finally
                    {
                        // Tắt splash screen khi quá trình lưu hoàn tất hoặc có lỗi
                        SplashScreenManager.CloseDefaultWaitForm();
                    }
                }
                else
                {
                    docNew.Close(false);
                    wordApp.Quit();
                }

                docTemplate.Close();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("đã tồn tại"))
                {
                    MessageBox.Show("Tên file bị trùng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}