using DevExpress.DirectX.Common.DirectWrite;
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
    public class CacChiSoKhac : IChiSoKhac
    {
        // Cac chi so tac dong chung - Constant
        const double HE_SO_DIEN_NL = 3.6;
        //
        private IRepository<NhienLieuSanPham> _tableNL;
        private IRepository<ChiSoTacDong> _chiSoTacDong;
        private IRepository<TacDong> _infoTacDong;

        public CacChiSoKhac()
        {
            _tableNL = new ExRepository<NhienLieuSanPham>();
            _chiSoTacDong = new ExRepository<ChiSoTacDong>();
            _infoTacDong = new ExRepository<TacDong>();
        }

        public async Task KetQuaSDNuoc(List<NhienLieuSanPham> listNLSP, int spId, int lcaId)
        {
            double giaTri = 0;
            var tacDong = _infoTacDong.Table.FirstOrDefault(x => x.TenTacDong.ToLower() == "sử dụng nước");
            foreach (var item in listNLSP)
            {
                if (item.SanPhamId == spId && item.LCAId == lcaId
                    && item.NhienLieu.TenNhienLieu.ToLower() == "nước sạch"
                    && item.NhienLieu.TenHienThiTieuThu.ToLower() == "tổng lượng nước sạch tiêu thụ")
                {
                    giaTri += 1 * item.SoLuong;
                }
            }

            ChiSoTacDong chiSoTacDong = await _chiSoTacDong.DbSet().Include(x => x.TacDong)
                .FirstOrDefaultAsync(x => x.LCAId == lcaId && x.SanPhamId == spId && x.TacDong.Id == tacDong.Id);
            if (chiSoTacDong != null)
            {
                chiSoTacDong.GiaTri = giaTri;
                using (var dbContext = new AppDbContext())
                {
                    dbContext.Entry(chiSoTacDong).State = EntityState.Modified;
                    await dbContext.SaveChangesAsync();
                }
            }
            else
            {
                ChiSoTacDong cstd = new ChiSoTacDong()
                {
                    LCAId = lcaId,
                    SanPhamId = spId,
                    GiaTri = giaTri,
                    TacDongId = tacDong.Id
                };
                await _chiSoTacDong.AddAsync(cstd);
            }
        }

        public async Task KetQuaSuDungNLTaiTao(List<NhienLieuSanPham> listNLSP, int spId, int lcaId)
        {
            double giaTri = 0;
            var tacDong = _infoTacDong.Table.FirstOrDefault(x => x.TenTacDong.ToLower() == "sử dụng năng lượng tái tạo");
            foreach (var item in listNLSP)
            {
                if (item.SanPhamId == spId && item.LCAId == lcaId
                    && item.NhienLieu.TenNhienLieu.ToLower() == "sinh khối")
                {
                    giaTri += item.NhienLieu.NhietTriRieng * item.SoLuong;
                }
            }

            ChiSoTacDong chiSoTacDong = await _chiSoTacDong.DbSet().Include(x => x.TacDong)
                .FirstOrDefaultAsync(x => x.LCAId == lcaId && x.SanPhamId == spId
                && x.TacDong.Id == tacDong.Id);

            if (chiSoTacDong != null)
            {
                chiSoTacDong.GiaTri = giaTri;
                using (var dbContext = new AppDbContext())
                {
                    dbContext.Entry(chiSoTacDong).State = EntityState.Modified;
                    await dbContext.SaveChangesAsync();
                }
            }
            else
            {
                ChiSoTacDong cstd = new ChiSoTacDong()
                {
                    GiaTri = giaTri,
                    TacDongId = tacDong.Id,
                    SanPhamId = spId,
                    LCAId = lcaId
                };
                await _chiSoTacDong.AddAsync(cstd);
            }

        }

        public async Task KetQuaSuDungNLKoTaiTao(List<NhienLieuSanPham> listNLSP, int spId, int lcaId)
        {
            double giaTri = 0;
            var tacDong = _infoTacDong.Table.FirstOrDefault(x => x.TenTacDong.ToLower() == "sử dụng năng lượng không tái tạo");
            foreach (var item in listNLSP)
            {
                if (item.SanPhamId == spId && item.LCAId == lcaId)
                {
                    switch (item.NhienLieu.TenNhienLieu.ToLower())
                    {
                        case "than": giaTri += item.NhienLieu.NhietTriRieng * item.SoLuong; break;
                        case "dầu fo": giaTri += item.NhienLieu.NhietTriRieng * item.SoLuong; break;
                        case "dầu do": giaTri += item.NhienLieu.NhietTriRieng * item.SoLuong; break;
                        case "lpg": giaTri += item.NhienLieu.NhietTriRieng * item.SoLuong; break;
                        case "cng": giaTri += item.NhienLieu.NhietTriRieng * item.SoLuong; break;
                    }
                }
            }

            ChiSoTacDong chiSoTacDong = await _chiSoTacDong.DbSet().Include(x => x.TacDong)
               .FirstOrDefaultAsync(x => x.LCAId == lcaId && x.SanPhamId == spId && x.TacDong.Id == tacDong.Id);

            if (chiSoTacDong != null)
            {
                chiSoTacDong.GiaTri = giaTri;
                using (var dbContext = new AppDbContext())
                {
                    dbContext.Entry(chiSoTacDong).State = EntityState.Modified;
                    await dbContext.SaveChangesAsync();
                }
              
            }
            else
            {
                ChiSoTacDong cstd = new ChiSoTacDong()
                {
                    GiaTri = giaTri,
                    SanPhamId = spId,
                    LCAId = lcaId,
                    TacDongId = tacDong.Id,
                };
                await _chiSoTacDong.AddAsync(cstd);
            }
        }

        public async Task SuDungPTuNLThayThe(List<NhienLieuSanPham> listNLSP, int spId, int lcaId)
        {
            double giaTri = 0;
            var tacDong = _infoTacDong.Table.FirstOrDefault(x => x.TenTacDong.ToLower() == "sử dụng năng lượng từ nhiên liệu thay thế");
            foreach (var item in listNLSP)
            {
                if (item.SanPhamId == spId && item.LCAId == lcaId
                    && item.NhienLieu.TenNhienLieu.ToLower() == "chất thải công nghiệp")
                {
                    giaTri += item.NhienLieu.NhietTriRieng * item.SoLuong;
                }
            }

            ChiSoTacDong chiSoTacDong = await _chiSoTacDong.DbSet().Include(x => x.TacDong)
                .FirstOrDefaultAsync(x => x.LCAId == lcaId && x.SanPhamId == spId
                && x.TacDong.Id == tacDong.Id);


            if (chiSoTacDong != null)
            {
                chiSoTacDong.GiaTri = giaTri;
                using (var dbContext = new AppDbContext())
                {
                    dbContext.Entry(chiSoTacDong).State = EntityState.Modified;
                    await dbContext.SaveChangesAsync();
                }
            }
            else
            {
                ChiSoTacDong cstd = new ChiSoTacDong()
                {
                    SanPhamId = spId,
                    LCAId = lcaId,
                    TacDongId = tacDong.Id,
                    GiaTri = giaTri
                };
                await _chiSoTacDong.AddAsync(cstd);
            }
        }

        public async Task KetQuaTaoNL(List<NhienLieuSanPham> listNLSP, int spId, int lcaId)
        {
            double giaTri = 0;
            var tacDong = _infoTacDong.Table.FirstOrDefault(x => x.TenTacDong.ToLower() == "tạo ra năng lượng");
            foreach (var item in listNLSP)
            {
                if (item.SanPhamId == spId && item.LCAId == lcaId
                    && item.NhienLieu.TenNhienLieu.ToLower() == "điện"
                    && item.NhienLieu.TenHienThiTieuThu.ToLower() == "lượng điện tự sản xuất")
                {
                    giaTri += HE_SO_DIEN_NL * item.SoLuong;
                }
            }

            ChiSoTacDong chiSoTacDong = await _chiSoTacDong.DbSet().Include(x => x.TacDong)
               .FirstOrDefaultAsync(x => x.LCAId == lcaId && x.SanPhamId == spId && x.TacDong.Id == tacDong.Id);

            if (chiSoTacDong != null)
            {
                chiSoTacDong.GiaTri = giaTri;
                using (var dbContext = new AppDbContext())
                {
                    dbContext.Entry(chiSoTacDong).State = EntityState.Modified;
                    await dbContext.SaveChangesAsync();
                }
            }
            else
            {
                ChiSoTacDong cstd = new ChiSoTacDong()
                {
                    SanPhamId = spId,
                    GiaTri = giaTri,
                    LCAId = lcaId,
                    TacDongId = tacDong.Id
                };
                await _chiSoTacDong.AddAsync(cstd);
            }
        }

        #region KQNuocImport
        public async Task KetQuaSDNuoc_Import(List<NhienLieuSanPham> listNLSP)
        {

            var tacDong = _infoTacDong.Table.FirstOrDefault(x => x.TenTacDong.ToLower() == "sử dụng nước");
            foreach (var item in listNLSP)
            {
                double giaTri = 0;
                if (item.NhienLieu.TenNhienLieu.ToLower() == "nước sạch"
                    && item.NhienLieu.TenHienThiTieuThu.ToLower() == "tổng lượng nước sạch tiêu thụ")
                {
                    giaTri += 1 * item.SoLuong;
                }
                ChiSoTacDong chiSoTacDong = _chiSoTacDong.DbSet().Include(x => x.TacDong)
                       .FirstOrDefault(x => x.LCAId == item.LCAId && x.SanPhamId == item.SanPhamId
                       && x.TacDong.Id == tacDong.Id);
                if (chiSoTacDong != null)
                {
                    chiSoTacDong.GiaTri += giaTri;
                    using (var dbContext = new AppDbContext())
                    {
                        dbContext.Entry(chiSoTacDong).State = EntityState.Modified;
                        await dbContext.SaveChangesAsync();
                    }
                }
                else
                {
                    ChiSoTacDong cstd = new ChiSoTacDong()
                    {
                        LCAId = item.LCAId,
                        SanPhamId = item.SanPhamId,
                        GiaTri = giaTri,
                        TacDongId = tacDong.Id
                    };
                    _chiSoTacDong.Add(cstd);
                }
            }
        }
        #endregion

        #region KQNangLuongTaiTao
        public async Task KetQuaSuDungNLTaiTao_Import(List<NhienLieuSanPham> listNLSP)
        {
            var tacDong = _infoTacDong.Table.FirstOrDefault(x => x.TenTacDong.ToLower() == "sử dụng năng lượng tái tạo");
            foreach (var item in listNLSP)
            {
                double giaTri = 0;
                if (item.NhienLieu.TenNhienLieu.ToLower() == "sinh khối")
                {
                    giaTri += item.NhienLieu.NhietTriRieng * item.SoLuong;
                }
                ChiSoTacDong chiSoTacDong =  _chiSoTacDong.DbSet().Include(x => x.TacDong)
                            .FirstOrDefault(x => x.LCAId == item.LCAId && x.SanPhamId == item.SanPhamId
                                && x.TacDong.Id == tacDong.Id);

                if (chiSoTacDong != null)
                {
                    chiSoTacDong.GiaTri += giaTri;
                    using (var dbContext = new AppDbContext())
                    {
                        dbContext.Entry(chiSoTacDong).State = EntityState.Modified;
                        await dbContext.SaveChangesAsync();
                    }
                }
                else
                {
                    ChiSoTacDong cstd = new ChiSoTacDong()
                    {
                        GiaTri = giaTri,
                        TacDongId = tacDong.Id,
                        SanPhamId = item.SanPhamId,
                        LCAId = item.LCAId
                    };
                    _chiSoTacDong.Add(cstd);
                }
            }
        }
        #endregion

        #region KQNangLuongKoTaiTao
        public async Task KetQuaSuDungNLKoTaiTao_Import(List<NhienLieuSanPham> listNLSP)
        {
            var tacDong = _infoTacDong.Table.FirstOrDefault(x => x.TenTacDong.ToLower() == "sử dụng năng lượng không tái tạo");
            foreach (var item in listNLSP)
            {
                double giaTri = 0;
                switch (item.NhienLieu.TenNhienLieu.ToLower())
                {
                    case "than": giaTri += item.NhienLieu.NhietTriRieng * item.SoLuong; break;
                    case "dầu fo": giaTri += item.NhienLieu.NhietTriRieng * item.SoLuong; break;
                    case "dầu do": giaTri += item.NhienLieu.NhietTriRieng * item.SoLuong; break;
                    case "lpg": giaTri += item.NhienLieu.NhietTriRieng * item.SoLuong; break;
                    case "cng": giaTri += item.NhienLieu.NhietTriRieng * item.SoLuong; break;
                }
                ChiSoTacDong chiSoTacDong = _chiSoTacDong.DbSet().Include(x => x.TacDong)
                            .FirstOrDefault(x => x.LCAId == item.LCAId && x.SanPhamId == item.SanPhamId
                            && x.TacDong.Id == tacDong.Id);

                if (chiSoTacDong != null)
                {
                    chiSoTacDong.GiaTri += giaTri;
                    using (var dbContext = new AppDbContext())
                    {
                        dbContext.Entry(chiSoTacDong).State = EntityState.Modified;
                        await dbContext.SaveChangesAsync();
                    }
                }
                else
                {
                    ChiSoTacDong cstd = new ChiSoTacDong()
                    {
                        GiaTri = giaTri,
                        SanPhamId = item.SanPhamId,
                        LCAId = item.LCAId,
                        TacDongId = tacDong.Id,
                    };
                    _chiSoTacDong.Add(cstd);
                }
            }
        }
        #endregion

        #region KQNangLuongTuPTThayThe
        public async Task SuDungPTuNLThayThe_Import(List<NhienLieuSanPham> listNLSP)
        {
            var tacDong = _infoTacDong.Table.FirstOrDefault(x => x.TenTacDong.ToLower() == "sử dụng năng lượng từ nhiên liệu thay thế");
            foreach (var item in listNLSP)
            {
                double giaTri = 0;
                if (item.NhienLieu.TenNhienLieu.ToLower() == "chất thải công nghiệp")
                {
                    giaTri += item.NhienLieu.NhietTriRieng * item.SoLuong;
                }
                ChiSoTacDong chiSoTacDong = _chiSoTacDong.DbSet().Include(x => x.TacDong)
                            .FirstOrDefault(x => x.LCAId == item.LCAId && x.SanPhamId == item.SanPhamId
                            && x.TacDong.Id == tacDong.Id);
                if (chiSoTacDong != null)
                {
                    chiSoTacDong.GiaTri += giaTri;
                    using (var dbContext = new AppDbContext())
                    {
                        dbContext.Entry(chiSoTacDong).State = EntityState.Modified;
                        await dbContext.SaveChangesAsync();
                    }
                }
                else
                {
                    ChiSoTacDong cstd = new ChiSoTacDong()
                    {
                        SanPhamId = item.SanPhamId,
                        LCAId = item.LCAId,
                        TacDongId = tacDong.Id,
                        GiaTri = giaTri
                    };
                    _chiSoTacDong.Add(cstd);
                }
            }
        }
        #endregion

        #region KQTaoNL
        public async Task KetQuaTaoNL_Import(List<NhienLieuSanPham> listNLSP)
        {

            var tacDong = _infoTacDong.Table.FirstOrDefault(x => x.TenTacDong.ToLower() == "tạo ra năng lượng");
            foreach (var item in listNLSP)
            {
                double giaTri = 0;
                if (item.NhienLieu.TenNhienLieu.ToLower() == "điện"
                    && item.NhienLieu.TenHienThiTieuThu.ToLower() == "lượng điện tự sản xuất")
                {
                    giaTri += HE_SO_DIEN_NL * item.SoLuong;
                }
                ChiSoTacDong chiSoTacDong = _chiSoTacDong.DbSet().Include(x => x.TacDong)
                        .FirstOrDefault(x => x.LCAId == item.LCAId && x.SanPhamId == item.SanPhamId
                        && x.TacDong.Id == tacDong.Id);

                if (chiSoTacDong != null)
                {
                    chiSoTacDong.GiaTri += giaTri;
                    using (var dbContext = new AppDbContext())
                    {
                        dbContext.Entry(chiSoTacDong).State = EntityState.Modified;
                        await dbContext.SaveChangesAsync();
                    }
                }
                else
                {
                    ChiSoTacDong cstd = new ChiSoTacDong()
                    {
                        SanPhamId = item.SanPhamId,
                        GiaTri = giaTri,
                        LCAId = item.LCAId,
                        TacDongId = tacDong.Id
                    };
                    _chiSoTacDong.Add(cstd);
                }
            }
        }
        #endregion
    }
}