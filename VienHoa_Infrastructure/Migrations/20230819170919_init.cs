using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VienHoa_Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "doanhNghieps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenCongTy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DienThoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiLienHe = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doanhNghieps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "donViDoTheoNams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDonVi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_donViDoTheoNams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "khiPhatThais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKhi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_khiPhatThais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LCAs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KyHieu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThuTu = table.Column<int>(type: "int", nullable: false),
                    TenLCA = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LCAs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "loaiChatThais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoaiChatThai = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loaiChatThais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "loaiLoNungs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoaiLo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loaiLoNungs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "loaiNguyenLieus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoai = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loaiNguyenLieus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "loaiNhaMays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoai = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loaiNhaMays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "loaiNhienLieus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoai = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loaiNhienLieus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "duAns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoanhNghiepId = table.Column<int>(type: "int", nullable: false),
                    TenDuAn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_duAns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_duAns_doanhNghieps_DoanhNghiepId",
                        column: x => x.DoanhNghiepId,
                        principalTable: "doanhNghieps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "gayNongLenToanCaus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KhiPhatThaiId = table.Column<int>(type: "int", nullable: false),
                    GiaTri = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gayNongLenToanCaus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_gayNongLenToanCaus_khiPhatThais_KhiPhatThaiId",
                        column: x => x.KhiPhatThaiId,
                        principalTable: "khiPhatThais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "heSoPhatThaiDiens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KhiPhatThaiId = table.Column<int>(type: "int", nullable: false),
                    Nam = table.Column<int>(type: "int", nullable: false),
                    GiaTri = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_heSoPhatThaiDiens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_heSoPhatThaiDiens_khiPhatThais_KhiPhatThaiId",
                        column: x => x.KhiPhatThaiId,
                        principalTable: "khiPhatThais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "chatThais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoaiChatThaiId = table.Column<int>(type: "int", nullable: false),
                    TenChatThai = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chatThais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_chatThais_loaiChatThais_LoaiChatThaiId",
                        column: x => x.LoaiChatThaiId,
                        principalTable: "loaiChatThais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "nguyenLieus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoaiNguyenLieuId = table.Column<int>(type: "int", nullable: false),
                    DonViDoTheoNamId = table.Column<int>(type: "int", nullable: false),
                    TenNguyenLieu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenHienThiTieuThu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nguyenLieus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_nguyenLieus_donViDoTheoNams_DonViDoTheoNamId",
                        column: x => x.DonViDoTheoNamId,
                        principalTable: "donViDoTheoNams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_nguyenLieus_loaiNguyenLieus_LoaiNguyenLieuId",
                        column: x => x.LoaiNguyenLieuId,
                        principalTable: "loaiNguyenLieus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "nhaMays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoanhNghiepId = table.Column<int>(type: "int", nullable: false),
                    LoaiNhaMayId = table.Column<int>(type: "int", nullable: false),
                    LoaiLoNungId = table.Column<int>(type: "int", nullable: false),
                    CongSuatThietKeId = table.Column<int>(type: "int", nullable: false),
                    TenNhaMay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TiLeCoPhan = table.Column<double>(type: "float", nullable: false),
                    ViTri = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nhaMays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_nhaMays_doanhNghieps_DoanhNghiepId",
                        column: x => x.DoanhNghiepId,
                        principalTable: "doanhNghieps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_nhaMays_loaiLoNungs_LoaiLoNungId",
                        column: x => x.LoaiLoNungId,
                        principalTable: "loaiLoNungs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_nhaMays_loaiNhaMays_LoaiNhaMayId",
                        column: x => x.LoaiNhaMayId,
                        principalTable: "loaiNhaMays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "nhienLieus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoaiNhienLieuId = table.Column<int>(type: "int", nullable: false),
                    DonViDoTheoNamId = table.Column<int>(type: "int", nullable: false),
                    TenNhienLieu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenHienThiTieuThu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NhietTriRieng = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nhienLieus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_nhienLieus_donViDoTheoNams_DonViDoTheoNamId",
                        column: x => x.DonViDoTheoNamId,
                        principalTable: "donViDoTheoNams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_nhienLieus_loaiNhienLieus_LoaiNhienLieuId",
                        column: x => x.LoaiNhienLieuId,
                        principalTable: "loaiNhienLieus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "heSoPhatThaiTuNguyenLieus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KhiPhatThaiId = table.Column<int>(type: "int", nullable: false),
                    NguyenLieuId = table.Column<int>(type: "int", nullable: false),
                    DonViTinhId = table.Column<int>(type: "int", nullable: false),
                    GiaTri = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_heSoPhatThaiTuNguyenLieus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_heSoPhatThaiTuNguyenLieus_khiPhatThais_KhiPhatThaiId",
                        column: x => x.KhiPhatThaiId,
                        principalTable: "khiPhatThais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_heSoPhatThaiTuNguyenLieus_nguyenLieus_NguyenLieuId",
                        column: x => x.NguyenLieuId,
                        principalTable: "nguyenLieus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "loNungTrongNhaMays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoaiLoNungId = table.Column<int>(type: "int", nullable: false),
                    NhaMayId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loNungTrongNhaMays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_loNungTrongNhaMays_loaiLoNungs_LoaiLoNungId",
                        column: x => x.LoaiLoNungId,
                        principalTable: "loaiLoNungs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_loNungTrongNhaMays_nhaMays_NhaMayId",
                        column: x => x.NhaMayId,
                        principalTable: "nhaMays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sanPhams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenSanPham = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KyHieu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CongNghe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CongSuatThietKe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NhaMayId = table.Column<int>(type: "int", nullable: false),
                    DuAnId = table.Column<int>(type: "int", nullable: false),
                    LoaiLoNungId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sanPhams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sanPhams_duAns_DuAnId",
                        column: x => x.DuAnId,
                        principalTable: "duAns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sanPhams_loaiLoNungs_LoaiLoNungId",
                        column: x => x.LoaiLoNungId,
                        principalTable: "loaiLoNungs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sanPhams_nhaMays_NhaMayId",
                        column: x => x.NhaMayId,
                        principalTable: "nhaMays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tieuThuNhienLieuLoNams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NhaMayId = table.Column<int>(type: "int", nullable: false),
                    NamSanXuat = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tieuThuNhienLieuLoNams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tieuThuNhienLieuLoNams_nhaMays_NhaMayId",
                        column: x => x.NhaMayId,
                        principalTable: "nhaMays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "heSoPhatThaiTuNhienLieus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KhiPhatThaiId = table.Column<int>(type: "int", nullable: false),
                    NhienLieuId = table.Column<int>(type: "int", nullable: false),
                    DonViTinhId = table.Column<int>(type: "int", nullable: false),
                    GiaTri = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_heSoPhatThaiTuNhienLieus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_heSoPhatThaiTuNhienLieus_khiPhatThais_KhiPhatThaiId",
                        column: x => x.KhiPhatThaiId,
                        principalTable: "khiPhatThais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_heSoPhatThaiTuNhienLieus_nhienLieus_NhienLieuId",
                        column: x => x.NhienLieuId,
                        principalTable: "nhienLieus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "nguyenLieuSanPhams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SanPhamId = table.Column<int>(type: "int", nullable: false),
                    NguyenLieuId = table.Column<int>(type: "int", nullable: false),
                    DonViId = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nguyenLieuSanPhams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_nguyenLieuSanPhams_nguyenLieus_NguyenLieuId",
                        column: x => x.NguyenLieuId,
                        principalTable: "nguyenLieus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_nguyenLieuSanPhams_sanPhams_SanPhamId",
                        column: x => x.SanPhamId,
                        principalTable: "sanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "nhienLieuSanPhams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SanPhamId = table.Column<int>(type: "int", nullable: false),
                    NhienLieuId = table.Column<int>(type: "int", nullable: false),
                    DonViId = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nhienLieuSanPhams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_nhienLieuSanPhams_nhienLieus_NhienLieuId",
                        column: x => x.NhienLieuId,
                        principalTable: "nhienLieus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_nhienLieuSanPhams_sanPhams_SanPhamId",
                        column: x => x.SanPhamId,
                        principalTable: "sanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ranhGioiLCAs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SanPhamId = table.Column<int>(type: "int", nullable: false),
                    LCAId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ranhGioiLCAs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ranhGioiLCAs_LCAs_LCAId",
                        column: x => x.LCAId,
                        principalTable: "LCAs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ranhGioiLCAs_sanPhams_SanPhamId",
                        column: x => x.SanPhamId,
                        principalTable: "sanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sanXuatNams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SanPhamId = table.Column<int>(type: "int", nullable: false),
                    NhaMayId = table.Column<int>(type: "int", nullable: false),
                    NamSanXuat = table.Column<int>(type: "int", nullable: false),
                    DBKK_TieuThuNhienLieu = table.Column<double>(type: "float", nullable: false),
                    DBKK_TieuThuDienNang = table.Column<double>(type: "float", nullable: false),
                    DBKK_SanXuatDienNang = table.Column<double>(type: "float", nullable: false),
                    DBKK_TieuThuNguyenLieu = table.Column<double>(type: "float", nullable: false),
                    SLSP_SanLuongSanPham = table.Column<double>(type: "float", nullable: false),
                    SLSP_LuongMuaVao = table.Column<double>(type: "float", nullable: false),
                    SLSP_LuongBanRa = table.Column<double>(type: "float", nullable: false),
                    SLSP_LuongLuuKho = table.Column<double>(type: "float", nullable: false),
                    TTDN_TongLuongDien = table.Column<double>(type: "float", nullable: false),
                    TTDN_TongLuongSX = table.Column<double>(type: "float", nullable: false),
                    TTDN_TongLuongSH = table.Column<double>(type: "float", nullable: false),
                    TTDN_TongLuongTuSX = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sanXuatNams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sanXuatNams_nhaMays_NhaMayId",
                        column: x => x.NhaMayId,
                        principalTable: "nhaMays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sanXuatNams_sanPhams_SanPhamId",
                        column: x => x.SanPhamId,
                        principalTable: "sanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "thaiDauRas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SanPhamId = table.Column<int>(type: "int", nullable: false),
                    ChatThaiId = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_thaiDauRas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_thaiDauRas_chatThais_ChatThaiId",
                        column: x => x.ChatThaiId,
                        principalTable: "chatThais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_thaiDauRas_sanPhams_SanPhamId",
                        column: x => x.SanPhamId,
                        principalTable: "sanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "nguyenLieuNams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SanXuatNamId = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nguyenLieuNams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_nguyenLieuNams_sanXuatNams_SanXuatNamId",
                        column: x => x.SanXuatNamId,
                        principalTable: "sanXuatNams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_chatThais_LoaiChatThaiId",
                table: "chatThais",
                column: "LoaiChatThaiId");

            migrationBuilder.CreateIndex(
                name: "IX_duAns_DoanhNghiepId",
                table: "duAns",
                column: "DoanhNghiepId");

            migrationBuilder.CreateIndex(
                name: "IX_gayNongLenToanCaus_KhiPhatThaiId",
                table: "gayNongLenToanCaus",
                column: "KhiPhatThaiId");

            migrationBuilder.CreateIndex(
                name: "IX_heSoPhatThaiDiens_KhiPhatThaiId",
                table: "heSoPhatThaiDiens",
                column: "KhiPhatThaiId");

            migrationBuilder.CreateIndex(
                name: "IX_heSoPhatThaiTuNguyenLieus_KhiPhatThaiId",
                table: "heSoPhatThaiTuNguyenLieus",
                column: "KhiPhatThaiId");

            migrationBuilder.CreateIndex(
                name: "IX_heSoPhatThaiTuNguyenLieus_NguyenLieuId",
                table: "heSoPhatThaiTuNguyenLieus",
                column: "NguyenLieuId");

            migrationBuilder.CreateIndex(
                name: "IX_heSoPhatThaiTuNhienLieus_KhiPhatThaiId",
                table: "heSoPhatThaiTuNhienLieus",
                column: "KhiPhatThaiId");

            migrationBuilder.CreateIndex(
                name: "IX_heSoPhatThaiTuNhienLieus_NhienLieuId",
                table: "heSoPhatThaiTuNhienLieus",
                column: "NhienLieuId");

            migrationBuilder.CreateIndex(
                name: "IX_loNungTrongNhaMays_LoaiLoNungId",
                table: "loNungTrongNhaMays",
                column: "LoaiLoNungId");

            migrationBuilder.CreateIndex(
                name: "IX_loNungTrongNhaMays_NhaMayId",
                table: "loNungTrongNhaMays",
                column: "NhaMayId");

            migrationBuilder.CreateIndex(
                name: "IX_nguyenLieuNams_SanXuatNamId",
                table: "nguyenLieuNams",
                column: "SanXuatNamId");

            migrationBuilder.CreateIndex(
                name: "IX_nguyenLieus_DonViDoTheoNamId",
                table: "nguyenLieus",
                column: "DonViDoTheoNamId");

            migrationBuilder.CreateIndex(
                name: "IX_nguyenLieus_LoaiNguyenLieuId",
                table: "nguyenLieus",
                column: "LoaiNguyenLieuId");

            migrationBuilder.CreateIndex(
                name: "IX_nguyenLieuSanPhams_NguyenLieuId",
                table: "nguyenLieuSanPhams",
                column: "NguyenLieuId");

            migrationBuilder.CreateIndex(
                name: "IX_nguyenLieuSanPhams_SanPhamId",
                table: "nguyenLieuSanPhams",
                column: "SanPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_nhaMays_DoanhNghiepId",
                table: "nhaMays",
                column: "DoanhNghiepId");

            migrationBuilder.CreateIndex(
                name: "IX_nhaMays_LoaiLoNungId",
                table: "nhaMays",
                column: "LoaiLoNungId");

            migrationBuilder.CreateIndex(
                name: "IX_nhaMays_LoaiNhaMayId",
                table: "nhaMays",
                column: "LoaiNhaMayId");

            migrationBuilder.CreateIndex(
                name: "IX_nhienLieus_DonViDoTheoNamId",
                table: "nhienLieus",
                column: "DonViDoTheoNamId");

            migrationBuilder.CreateIndex(
                name: "IX_nhienLieus_LoaiNhienLieuId",
                table: "nhienLieus",
                column: "LoaiNhienLieuId");

            migrationBuilder.CreateIndex(
                name: "IX_nhienLieuSanPhams_NhienLieuId",
                table: "nhienLieuSanPhams",
                column: "NhienLieuId");

            migrationBuilder.CreateIndex(
                name: "IX_nhienLieuSanPhams_SanPhamId",
                table: "nhienLieuSanPhams",
                column: "SanPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_ranhGioiLCAs_LCAId",
                table: "ranhGioiLCAs",
                column: "LCAId");

            migrationBuilder.CreateIndex(
                name: "IX_ranhGioiLCAs_SanPhamId",
                table: "ranhGioiLCAs",
                column: "SanPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_sanPhams_DuAnId",
                table: "sanPhams",
                column: "DuAnId");

            migrationBuilder.CreateIndex(
                name: "IX_sanPhams_LoaiLoNungId",
                table: "sanPhams",
                column: "LoaiLoNungId");

            migrationBuilder.CreateIndex(
                name: "IX_sanPhams_NhaMayId",
                table: "sanPhams",
                column: "NhaMayId");

            migrationBuilder.CreateIndex(
                name: "IX_sanXuatNams_NhaMayId",
                table: "sanXuatNams",
                column: "NhaMayId");

            migrationBuilder.CreateIndex(
                name: "IX_sanXuatNams_SanPhamId",
                table: "sanXuatNams",
                column: "SanPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_thaiDauRas_ChatThaiId",
                table: "thaiDauRas",
                column: "ChatThaiId");

            migrationBuilder.CreateIndex(
                name: "IX_thaiDauRas_SanPhamId",
                table: "thaiDauRas",
                column: "SanPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_tieuThuNhienLieuLoNams_NhaMayId",
                table: "tieuThuNhienLieuLoNams",
                column: "NhaMayId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "gayNongLenToanCaus");

            migrationBuilder.DropTable(
                name: "heSoPhatThaiDiens");

            migrationBuilder.DropTable(
                name: "heSoPhatThaiTuNguyenLieus");

            migrationBuilder.DropTable(
                name: "heSoPhatThaiTuNhienLieus");

            migrationBuilder.DropTable(
                name: "loNungTrongNhaMays");

            migrationBuilder.DropTable(
                name: "nguyenLieuNams");

            migrationBuilder.DropTable(
                name: "nguyenLieuSanPhams");

            migrationBuilder.DropTable(
                name: "nhienLieuSanPhams");

            migrationBuilder.DropTable(
                name: "ranhGioiLCAs");

            migrationBuilder.DropTable(
                name: "thaiDauRas");

            migrationBuilder.DropTable(
                name: "tieuThuNhienLieuLoNams");

            migrationBuilder.DropTable(
                name: "khiPhatThais");

            migrationBuilder.DropTable(
                name: "sanXuatNams");

            migrationBuilder.DropTable(
                name: "nguyenLieus");

            migrationBuilder.DropTable(
                name: "nhienLieus");

            migrationBuilder.DropTable(
                name: "LCAs");

            migrationBuilder.DropTable(
                name: "chatThais");

            migrationBuilder.DropTable(
                name: "sanPhams");

            migrationBuilder.DropTable(
                name: "loaiNguyenLieus");

            migrationBuilder.DropTable(
                name: "donViDoTheoNams");

            migrationBuilder.DropTable(
                name: "loaiNhienLieus");

            migrationBuilder.DropTable(
                name: "loaiChatThais");

            migrationBuilder.DropTable(
                name: "duAns");

            migrationBuilder.DropTable(
                name: "nhaMays");

            migrationBuilder.DropTable(
                name: "doanhNghieps");

            migrationBuilder.DropTable(
                name: "loaiLoNungs");

            migrationBuilder.DropTable(
                name: "loaiNhaMays");
        }
    }
}
