using DevExpress.CodeParser;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa.Common;
using VienHoa.DataEx;
using VienHoa.Entity;
using VienHoa.IService;

namespace VienHoa.Service
{
    public class NguyenLieuSanPhamChiSoTacDongService : INguyenLieuSanPhamChiSoTacDong
    {
        private readonly AppDbContext dbContext;
        private readonly IRepository<NguyenLieuSanPham> nguyenLieuSanPhamRepo;
        private readonly IRepository<NhienLieuSanPhamChiSoTacDong> nhienLieuSanPhamChiSoTacDongRepo;
        private readonly IRepository<NguyenLieuSanPhamChiSoTacDong> nguyenLieuSanPhamChiSoTacDongRepo;
        private readonly IRepository<ChiSoTacDong> chiSoTacDongRepo;
        private readonly IRepository<TacDong> tacDongRepo;
        private readonly IRepository<HeSoPhatThaiTuNguyenLieu> _hsptnguyenLieuRepo;
        public NguyenLieuSanPhamChiSoTacDongService()
        {
            nguyenLieuSanPhamRepo = new ExRepository<NguyenLieuSanPham>();
            nhienLieuSanPhamChiSoTacDongRepo = new ExRepository<NhienLieuSanPhamChiSoTacDong>();
            nguyenLieuSanPhamChiSoTacDongRepo = new ExRepository<NguyenLieuSanPhamChiSoTacDong>();
            chiSoTacDongRepo = new ExRepository<ChiSoTacDong>();
            tacDongRepo = new ExRepository<TacDong>();
            _hsptnguyenLieuRepo = new ExRepository<HeSoPhatThaiTuNguyenLieu>();
            dbContext = new AppDbContext();
        }
        public async Task CapNhatChiSo(int nguyenLieuSanPhamId)
        {
            NguyenLieuSanPham nguyenLieuSanPham = nguyenLieuSanPhamRepo.TableUntracked.Include(x => x.NguyenLieu).ThenInclude(y => y.HeSoPhatThaiTuNguyenLieus).SingleOrDefault(z => z.Id == nguyenLieuSanPhamId);
            double hesophatthainguyenlieu = nguyenLieuSanPham.NguyenLieu.HeSoPhatThaiTuNguyenLieus.Single().GiaTri;
            double giatri = nguyenLieuSanPham.SoLuong * hesophatthainguyenlieu;
            ChiSoTacDong chiSoTacDong = dbContext.chiSoTacDongs.SingleOrDefault(x => x.SanPhamId == nguyenLieuSanPham.SanPhamId && x.LCAId == nguyenLieuSanPham.LCAId && x.TacDong.TenTacDong.ToLower() == "tiềm năng hiệu ứng nhà kính");
            NguyenLieuSanPhamChiSoTacDong nguyenLieuSanPhamChiSoTacDong = nguyenLieuSanPhamChiSoTacDongRepo.TableUntracked.SingleOrDefault(x => x.NguyenLieuSanPhamId == nguyenLieuSanPham.Id && x.ChiSoTacDongId == chiSoTacDong.Id);
            nguyenLieuSanPhamChiSoTacDong.GiaTri = giatri;
            using (var dbContext = new AppDbContext())
            {
                dbContext.Entry(nguyenLieuSanPhamChiSoTacDong).State = EntityState.Modified;
                await dbContext.SaveChangesAsync();
                chiSoTacDong.GiaTri = nguyenLieuSanPhamChiSoTacDongRepo.TableUntracked.Where(x => x.ChiSoTacDongId == chiSoTacDong.Id).Sum(x => x.GiaTri) + nhienLieuSanPhamChiSoTacDongRepo.TableUntracked.Where(x => x.ChiSoTacDongId == chiSoTacDong.Id).Sum(x => x.GiaTri);
                dbContext.Entry(chiSoTacDong).State = EntityState.Modified;
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task TinhToanChiSo(int nguyenLieuSanPhamId)
        {
            NguyenLieuSanPham nguyenLieuSanPham = nguyenLieuSanPhamRepo.TableUntracked.Include(x => x.NguyenLieu).ThenInclude(y => y.HeSoPhatThaiTuNguyenLieus).SingleOrDefault(z => z.Id == nguyenLieuSanPhamId);
            double hesophatthainguyenlieu = nguyenLieuSanPham.NguyenLieu.HeSoPhatThaiTuNguyenLieus.Sum(x => x.GiaTri);
            double giatri = nguyenLieuSanPham.SoLuong * hesophatthainguyenlieu;


            ChiSoTacDong chiSoTacDong = dbContext.chiSoTacDongs.SingleOrDefault(x => x.SanPhamId == nguyenLieuSanPham.SanPhamId && x.LCAId == nguyenLieuSanPham.LCAId && x.TacDong.TenTacDong.ToLower() == "tiềm năng hiệu ứng nhà kính");
            if (chiSoTacDong == null)
            {
                chiSoTacDong = new ChiSoTacDong()
                {
                    SanPhamId = nguyenLieuSanPham.SanPhamId,
                    LCAId = nguyenLieuSanPham.LCAId,
                    TacDongId = (tacDongRepo.TableUntracked.Single(x => x.TenTacDong.ToLower() == "tiềm năng hiệu ứng nhà kính")).Id
                };
                chiSoTacDongRepo.Add(chiSoTacDong);
            }
            NguyenLieuSanPhamChiSoTacDong res = new NguyenLieuSanPhamChiSoTacDong()
            {
                ChiSoTacDongId = chiSoTacDong.Id,
                NguyenLieuSanPhamId = nguyenLieuSanPham.Id,
                GiaTri = giatri,
            };
            nguyenLieuSanPhamChiSoTacDongRepo.Add(res);
            chiSoTacDong.GiaTri = nguyenLieuSanPhamChiSoTacDongRepo.TableUntracked.Where(x => x.ChiSoTacDongId == chiSoTacDong.Id).Sum(x => x.GiaTri) + nhienLieuSanPhamChiSoTacDongRepo.TableUntracked.Where(x => x.ChiSoTacDongId == chiSoTacDong.Id).Sum(x => x.GiaTri);

            using (var dbContext = new AppDbContext())
            {
                dbContext.Entry(chiSoTacDong).State = EntityState.Modified;
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task HieuUngNhaKinhNguyenLieu(List<NguyenLieuSanPham> dsnguyenLieu, int sanPhamId, int lcdId)
        {
            double tinhToan = 0;
            //var dssanphamtdr = _thaiDauRaRepo.Table.Include(x => x.ChatThai).Where(x => x.SanPhamId == sanPhamId && x.LCAId == lcdId).ToList();
            foreach (var nl in dsnguyenLieu)
            {
                var nguyenlieucantim = _hsptnguyenLieuRepo.Table.FirstOrDefault(x => x.NguyenLieuId == nl.NguyenLieuId);
                tinhToan += nl.SoLuong * nguyenlieucantim.GiaTri;
            }
            var chiSoTacDongCanTim = chiSoTacDongRepo.Table.FirstOrDefault(x => x.SanPhamId == sanPhamId && x.LCAId == lcdId && x.TacDongId == 1);
            if (chiSoTacDongCanTim != null)
            {
                chiSoTacDongCanTim.GiaTri = tinhToan;
                using (var dbContext = new AppDbContext())
                {
                    dbContext.Entry(chiSoTacDongCanTim).State = EntityState.Modified;
                    await dbContext.SaveChangesAsync();
                }
                //await chiSoTacDongRepo.UpdateAsync(chiSoTacDongCanTim);
            }
            else
            {
                ChiSoTacDong chiSoTacDong = new ChiSoTacDong();
                chiSoTacDong.SanPhamId = sanPhamId;
                chiSoTacDong.LCAId = lcdId;
                chiSoTacDong.TacDongId = 1;
                chiSoTacDong.GiaTri = tinhToan;
                await chiSoTacDongRepo.AddAsync(chiSoTacDong);
            }
        }

        public async Task CapNhatChiSo(NguyenLieuSanPham nguyenLieuSanPham)
        {
            NguyenLieuSanPhamChiSoTacDong nguyenLieuSanPhamChiSoTacDong = nguyenLieuSanPhamChiSoTacDongRepo.TableUntracked.SingleOrDefault(x => x.NguyenLieuSanPhamId == nguyenLieuSanPham.Id && x.ChiSoTacDong.TacDong.TenTacDong.ToLower() == "tiềm năng hiệu ứng nhà kính");
            ChiSoTacDong chiSoTacDong = dbContext.chiSoTacDongs.SingleOrDefault(x => x.SanPhamId == nguyenLieuSanPham.SanPhamId && x.LCAId == nguyenLieuSanPham.LCAId && x.TacDong.TenTacDong.ToLower() == "tiềm năng hiệu ứng nhà kính");

            using (var dbContext = new AppDbContext())
            {
                dbContext.Remove(nguyenLieuSanPhamChiSoTacDong);
                dbContext.Remove(nguyenLieuSanPham);
                await dbContext.SaveChangesAsync();
                chiSoTacDong.GiaTri = nguyenLieuSanPhamChiSoTacDongRepo.TableUntracked.Where(x => x.ChiSoTacDongId == chiSoTacDong.Id).Sum(x => x.GiaTri) + nhienLieuSanPhamChiSoTacDongRepo.TableUntracked.Where(x => x.ChiSoTacDongId == chiSoTacDong.Id).Sum(x => x.GiaTri);
                dbContext.Entry(chiSoTacDong).State = EntityState.Modified;
                await dbContext.SaveChangesAsync();
            }
        }
    }
}