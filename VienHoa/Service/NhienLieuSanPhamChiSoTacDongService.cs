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
    public class NhienLieuSanPhamChiSoTacDongService : INhienLieuSanPhamChiSoTacDong
    {
        private readonly AppDbContext dbContext;
        private readonly IRepository<NhienLieuSanPham> nhienLieuSanPhamRepo;
        private readonly IRepository<NhienLieuSanPhamChiSoTacDong> nhienLieuSanPhamChiSoTacDongRepo;
        private readonly IRepository<NguyenLieuSanPhamChiSoTacDong> nguyenLieuSanPhamChiSoTacDongRepo;
        private readonly IRepository<ChiSoTacDong> chiSoTacDongRepo;
        private readonly IRepository<TacDong> tacDongRepo;

        public NhienLieuSanPhamChiSoTacDongService()
        {
            nguyenLieuSanPhamChiSoTacDongRepo = new ExRepository<NguyenLieuSanPhamChiSoTacDong>();
            nhienLieuSanPhamRepo = new ExRepository<NhienLieuSanPham>();
            nhienLieuSanPhamChiSoTacDongRepo = new ExRepository<NhienLieuSanPhamChiSoTacDong>();
            chiSoTacDongRepo = new ExRepository<ChiSoTacDong>();
            tacDongRepo = new ExRepository<TacDong>();
            dbContext = new AppDbContext();
        }

        public async Task CapNhatChiSo(int nhienLieuSanPhamId)
        {
            double tongheso = 0;

            NhienLieuSanPham nhienLieuSanPham = nhienLieuSanPhamRepo.TableUntracked.Include(x => x.NhienLieu).ThenInclude(y => y.HeSoPhatThaiTuNhienLieus).ThenInclude(z => z.KhiPhatThai).SingleOrDefault(x => x.Id == nhienLieuSanPhamId);
            foreach (var s in nhienLieuSanPham.NhienLieu.HeSoPhatThaiTuNhienLieus)
            {
                if (s.KhiPhatThai.TenKhi == "CO2")
                {
                    tongheso += s.GiaTri;
                }
                if (s.KhiPhatThai.TenKhi == "CH4")
                {
                    tongheso += s.GiaTri * 26;
                }
                if (s.KhiPhatThai.TenKhi == "N2O")
                {
                    tongheso += s.GiaTri * 265;
                }
            }
            double giatri = nhienLieuSanPham.SoLuong / 1000 / 1000 * nhienLieuSanPham.NhienLieu.NhietTriRieng * tongheso;
            ChiSoTacDong chiSoTacDong = dbContext.chiSoTacDongs.SingleOrDefault(x => x.SanPhamId == nhienLieuSanPham.SanPhamId && x.LCAId == nhienLieuSanPham.LCAId && x.TacDong.TenTacDong.ToLower() == "tiềm năng hiệu ứng nhà kính");
            NhienLieuSanPhamChiSoTacDong nhienLieuSanPhamChiSoTacDong = nhienLieuSanPhamChiSoTacDongRepo.TableUntracked.SingleOrDefault(x => x.NhienLieuSanPhamId == nhienLieuSanPham.Id && x.ChiSoTacDongId == chiSoTacDong.Id);
            nhienLieuSanPhamChiSoTacDong.GiaTri = giatri;
            using (var dbContext = new AppDbContext())
            {
                dbContext.Entry(nhienLieuSanPhamChiSoTacDong).State = EntityState.Modified;
                await dbContext.SaveChangesAsync();
                chiSoTacDong.GiaTri = nguyenLieuSanPhamChiSoTacDongRepo.TableUntracked.Where(x => x.ChiSoTacDongId == chiSoTacDong.Id).Sum(x => x.GiaTri) + nhienLieuSanPhamChiSoTacDongRepo.TableUntracked.Where(x => x.ChiSoTacDongId == chiSoTacDong.Id).Sum(x => x.GiaTri);
                dbContext.Entry(chiSoTacDong).State = EntityState.Modified;
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task TinhToanChiSo(int nhienLieuSanPhamId)
        {
            double tongheso = 0;

            NhienLieuSanPham nhienLieuSanPham = nhienLieuSanPhamRepo.TableUntracked.Include(x => x.NhienLieu).ThenInclude(y => y.HeSoPhatThaiTuNhienLieus).ThenInclude(z => z.KhiPhatThai).SingleOrDefault(x => x.Id == nhienLieuSanPhamId);
            foreach (var s in nhienLieuSanPham.NhienLieu.HeSoPhatThaiTuNhienLieus)
            {
                if (s.KhiPhatThai.TenKhi == "CO2")
                {
                    tongheso += s.GiaTri;
                }
                if (s.KhiPhatThai.TenKhi == "CH4")
                {
                    tongheso += s.GiaTri * 26;
                }
                if (s.KhiPhatThai.TenKhi == "N2O")
                {
                    tongheso += s.GiaTri * 265;
                }
            }
            double giatri = nhienLieuSanPham.SoLuong / 1000 / 1000 * nhienLieuSanPham.NhienLieu.NhietTriRieng * tongheso;
            ChiSoTacDong chiSoTacDong = chiSoTacDongRepo.TableUntracked.SingleOrDefault(x => x.LCAId == nhienLieuSanPham.LCAId && x.SanPhamId == nhienLieuSanPham.SanPhamId && x.TacDong.TenTacDong.ToLower() == "tiềm năng hiệu ứng nhà kính");
            if (chiSoTacDong == null)
            {
                chiSoTacDong = new ChiSoTacDong()
                {
                    SanPhamId = nhienLieuSanPham.SanPhamId,
                    LCAId = nhienLieuSanPham.LCAId,
                    TacDongId = (tacDongRepo.TableUntracked.Single(x => x.TenTacDong.ToLower() == "tiềm năng hiệu ứng nhà kính")).Id
                };
                chiSoTacDongRepo.Add(chiSoTacDong);
            }
            NhienLieuSanPhamChiSoTacDong res = new NhienLieuSanPhamChiSoTacDong
            {
                ChiSoTacDongId = chiSoTacDong.Id,
                GiaTri = giatri,
                NhienLieuSanPhamId = nhienLieuSanPham.Id
            };
            nhienLieuSanPhamChiSoTacDongRepo.Add(res);
            chiSoTacDong.GiaTri = nguyenLieuSanPhamChiSoTacDongRepo.TableUntracked.Where(x => x.ChiSoTacDongId == chiSoTacDong.Id).Sum(x => x.GiaTri) + nhienLieuSanPhamChiSoTacDongRepo.TableUntracked.Where(x => x.ChiSoTacDongId == chiSoTacDong.Id).Sum(x => x.GiaTri);
            using (var dbContext = new AppDbContext())
            {
                dbContext.Entry(chiSoTacDong).State = EntityState.Modified;
                await dbContext.SaveChangesAsync();
            }
        }
        public async Task CapNhatChiSo(NhienLieuSanPham nhienLieuSanPham)
        {
            NhienLieuSanPhamChiSoTacDong nhienLieuSanPhamChiSoTacDong = nhienLieuSanPhamChiSoTacDongRepo.TableUntracked.SingleOrDefault(x => x.NhienLieuSanPhamId == nhienLieuSanPham.Id && x.ChiSoTacDong.TacDong.TenTacDong.ToLower() == "tiềm năng hiệu ứng nhà kính");
            ChiSoTacDong chiSoTacDong = dbContext.chiSoTacDongs.SingleOrDefault(x => x.SanPhamId == nhienLieuSanPham.SanPhamId && x.LCAId == nhienLieuSanPham.LCAId && x.TacDong.TenTacDong.ToLower() == "tiềm năng hiệu ứng nhà kính");


            using (var dbContext = new AppDbContext())
            {
                dbContext.Remove(nhienLieuSanPhamChiSoTacDong);
                dbContext.Remove(nhienLieuSanPham);
                await dbContext.SaveChangesAsync();
                chiSoTacDong.GiaTri = nguyenLieuSanPhamChiSoTacDongRepo.TableUntracked.Where(x => x.ChiSoTacDongId == chiSoTacDong.Id).Sum(x => x.GiaTri) + nhienLieuSanPhamChiSoTacDongRepo.TableUntracked.Where(x => x.ChiSoTacDongId == chiSoTacDong.Id).Sum(x => x.GiaTri);
                dbContext.Entry(chiSoTacDong).State = EntityState.Modified;
                await dbContext.SaveChangesAsync();
            }
        }
    }
   
}