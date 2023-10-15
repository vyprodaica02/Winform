using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa.Entity;

namespace VienHoa.DataEx
{
    public class AppDbContext : DbContext
    {
        //public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        //{
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = localhost;Integrated Security=true;Initial Catalog=dbVienHoa;MultipleActiveResultSets=True;encrypt=true;trustservercertificate=true");
        }
        public DbSet<ChatThai> chatThais { get; set; }
        public DbSet<DoanhNghiep> doanhNghieps { get; set; }
        public DbSet<DonViDoTheoNam> donViDoTheoNams { get; set; }
        public DbSet<DonViSanPham> donViSanPhams { get; set; }
        public DbSet<DuAn> duAns { get; set; }
        public DbSet<GayNongLenToanCau> gayNongLenToanCaus { get; set; }
        public DbSet<HeSoPhatThaiDien> heSoPhatThaiDiens { get; set; }
        public DbSet<HeSoPhatThaiTuNguyenLieu> heSoPhatThaiTuNguyenLieus { get; set; }
        public DbSet<HeSoPhatThaiTuNhienLieu> heSoPhatThaiTuNhienLieus { get; set; }
        public DbSet<KhiPhatThai> khiPhatThais { get; set; }
        public DbSet<LCA> LCAs { get; set; }
        public DbSet<LoaiChatThai> loaiChatThais { get; set; }
        public DbSet<LoaiLoNung> loaiLoNungs { get; set; }
        public DbSet<LoaiNguyenLieu> loaiNguyenLieus { get; set; }
        public DbSet<LoaiNhaMay> loaiNhaMays { get; set; }
        public DbSet<LoaiNhienLieu> loaiNhienLieus { get; set; }
        public DbSet<LoNungTrongNhaMay> loNungTrongNhaMays { get; set; }
        public DbSet<NguyenLieu> nguyenLieus { get; set; }
        public DbSet<NguyenLieuNam> nguyenLieuNams { get; set; }
        public DbSet<NhaMay> nhaMays { get; set; }
        public DbSet<NhienLieu> nhienLieus { get; set; }
        public DbSet<NguyenLieuSanPham> nguyenLieuSanPhams { get; set; }
        public DbSet<NhienLieuSanPham> nhienLieuSanPhams { get; set; }
        public DbSet<CongSuatThietKe> congSuatThietKes { get; set; }
        public DbSet<SanPham> sanPhams { get; set; }
        public DbSet<SanXuatNam> sanXuatNams { get; set; }
        public DbSet<ThaiDauRa> thaiDauRas { get; set; }
        public DbSet<TieuThuNhienLieuLoNam> tieuThuNhienLieuLoNams { get; set; }
        public DbSet<TacDong> tacDongs { get; set; }
        public DbSet<ChiSoTacDong> chiSoTacDongs { get; set; }
        public DbSet<ThaiDauRaChiSoTacDong> thaiDauRaChiSoTacDongs { get; set; }
        public DbSet<NguyenLieuSanPhamChiSoTacDong> nguyenLieuSanPhamChiSoTacDongs { get; set; }
        public DbSet<NhienLieuSanPhamChiSoTacDong> nhienLieuSanPhamChiSoTacDongs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SanPham>().HasOne(x => x.NhaMay).WithMany(x => x.SanPhams).HasForeignKey(x => x.NhaMayId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<SanXuatNam>().HasOne(x => x.SanPham).WithMany(x => x.SanXuatNams).HasForeignKey(x => x.SanPhamId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<LoNungTrongNhaMay>().HasOne(x => x.NhaMay).WithMany(x => x.LoNungTrongNhaMays).HasForeignKey(x => x.NhaMayId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<NguyenLieuSanPham>().HasOne(x => x.SanPham).WithMany(x => x.NguyenLieuSanPhams).HasForeignKey(x => x.SanPhamId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<NhienLieuSanPham>().HasOne(x => x.SanPham).WithMany(x => x.NhienLieuSanPhams).HasForeignKey(x => x.SanPhamId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ThaiDauRa>().HasOne(x => x.SanPham).WithMany(x => x.ThaiDauRas).HasForeignKey(x => x.SanPhamId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<NguyenLieuSanPhamChiSoTacDong>().HasOne(x => x.NguyenLieuSanPham).WithMany(x => x.NguyenLieuSanPhamChiSoTacDongs).HasForeignKey(x => x.NguyenLieuSanPhamId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<NhienLieuSanPhamChiSoTacDong>().HasOne(x => x.NhienLieuSanPham).WithMany(x => x.NhienLieuSanPhamChiSoTacDongs).HasForeignKey(x => x.NhienLieuSanPhamId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ThaiDauRaChiSoTacDong>().HasOne(x => x.ThaiDauRa).WithMany(x => x.ThaiDauRaChiSoTacDongs).HasForeignKey(x => x.ThaiDauRaId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
