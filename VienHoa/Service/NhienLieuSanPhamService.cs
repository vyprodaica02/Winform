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
    public class NhienLieuSanPhamService : INhienLieuSanPham
    {

        public readonly IRepository<NhienLieuSanPham> _repository;
        private readonly IRepository<NhienLieuSanPham> nhienLieuSanPhamRepo;
        private readonly IRepository<ChiSoTacDong> chiSoTacDongRepo;
        private readonly IRepository<NhienLieuSanPhamChiSoTacDong> nhienLieuSanPhamChiSoTacDongRepo;
        private readonly INhienLieuSanPhamChiSoTacDong _nhienLieuChiSoTacDong;
        private readonly AppDbContext dbContext;
        private readonly IChiSoKhac _cacChiSoKhac;
        public NhienLieuSanPhamService()
        {
            dbContext = new AppDbContext();

            _nhienLieuChiSoTacDong = new NhienLieuSanPhamChiSoTacDongService();
            _repository = new ExRepository<NhienLieuSanPham>();
            chiSoTacDongRepo = new ExRepository<ChiSoTacDong>();
            nhienLieuSanPhamRepo = new ExRepository<NhienLieuSanPham>();
            nhienLieuSanPhamChiSoTacDongRepo = new ExRepository<NhienLieuSanPhamChiSoTacDong>();
            _cacChiSoKhac = new CacChiSoKhac();
        }
        public async Task<List<NhienLieuSanPham>> GetAllNhienLieuSanPham()
        {
            var query = _repository.TableUntracked.Include(x => x.NhienLieu).Include(x => x.DonVi);
            return query.ToList();
        }
        public async Task<List<NhienLieuSanPham>> GetNhienLieuSanPhamByLcaId(int lcaId)
        {
            var query = _repository.TableUntracked
                .Include(x => x.NhienLieu)
                .Include(x => x.DonVi)
                .Where(x => x.LCAId == lcaId);
            return query.ToList();
        }

        public async Task<List<NhienLieuSanPham>> GetNhienLieuSanPhamBySPId(int sanPhamId)
        {
            var query = _repository.TableUntracked
                .Include(x => x.NhienLieu)
                .Include(x => x.DonVi)
                .Where(x => x.SanPhamId == sanPhamId);
            return query.ToList();
        }
        public async Task<NhienLieuSanPham> GetNhienLieuSanPhamByDVIdandNhienLieuId(int nhienLieuId, int dvId)
        {
            var query = _repository.TableUntracked
              .Include(x => x.NhienLieu)
              .Include(x => x.DonVi)
              .FirstOrDefault(x => x.DonViId == dvId && x.NhienLieuId == nhienLieuId);
            return query;
        }

        public async Task<bool> AddRangeOrUpdateNhienLieuSanPham(List<NhienLieuSanPham> lstNhienLieuSanPham)
        {
            using (var trans = dbContext.Database.BeginTransaction())
            {
                try
                {
                    bool check = false;
                    foreach (var item in lstNhienLieuSanPham)
                    {
                        if (item.SoLuong == 0)
                        {
                            NhienLieuSanPham nlSp = await GetNhienLieuSanPhamByLCAIdandNhienLieuIdandSPId(item.NhienLieuId, item.LCAId, item.SanPhamId);
                            if (nlSp != null)
                            {
                                //await _nhienLieuChiSoTacDong.CapNhatChiSo(nlSp);

                                await _repository.DeleteAsync(nlSp);
                            }
                        }
                        else
                        {
                            if (item.DonViId != 0)
                            {
                                NhienLieuSanPham nhienLieuSanPham = await GetNhienLieuSanPhamByLCAIdandNhienLieuIdandSPId(item.NhienLieuId, item.LCAId, item.SanPhamId);
                                if (nhienLieuSanPham != null)
                                {
                                    item.Id = nhienLieuSanPham.Id;
                                    //await _repository.UpdateAsync(item);
                                    using (var dbContext = new AppDbContext())
                                    {
                                        dbContext.Entry(item).State = EntityState.Modified;
                                        await dbContext.SaveChangesAsync();
                                    }
                                    await _nhienLieuChiSoTacDong.CapNhatChiSo(item.Id);
                                }

                                else
                                {
                                    await _repository.AddAsync(item);
                                    await _nhienLieuChiSoTacDong.TinhToanChiSo(item.Id);
                                }

                            }    
                        }
                        check = true;
                    }


                    if (check)
                    {
                        List<NhienLieuSanPham> lstNhienLieuSPBySPId = new List<NhienLieuSanPham>();
                        int spId = 0;
                        if (lstNhienLieuSanPham.Count() > 0)
                        {
                            spId = lstNhienLieuSanPham[0].SanPhamId;
                            lstNhienLieuSPBySPId = await GetNhienLieuSanPhamBySPId(spId);
                        }

                        List<int> lstLCAId = new List<int>();
                        foreach (var item in lstNhienLieuSPBySPId)
                        {
                            await _cacChiSoKhac.KetQuaSDNuoc(lstNhienLieuSPBySPId, spId, item.LCAId);
                            await _cacChiSoKhac.KetQuaSuDungNLTaiTao(lstNhienLieuSPBySPId, spId, item.LCAId);
                            await _cacChiSoKhac.KetQuaSuDungNLKoTaiTao(lstNhienLieuSPBySPId, spId, item.LCAId);
                            await _cacChiSoKhac.SuDungPTuNLThayThe(lstNhienLieuSPBySPId, spId, item.LCAId);
                            await _cacChiSoKhac.KetQuaTaoNL(lstNhienLieuSPBySPId, spId, item.LCAId);

                        }

                    }
                    trans.Commit();
                    return true;
                }
                catch (Exception)
                {
                    trans.Rollback();
                    return false;
                }
            }
        }

        public async Task<NhienLieuSanPham> GetNhienLieuSanPhamByLCAIdandNhienLieuIdandSPId(int nhienLieuId, int lcaId, int spId)
        {
            var query = _repository.TableUntracked
             .Include(x => x.NhienLieu)
             .Include(x => x.DonVi)
             .SingleOrDefault(x => x.LCAId == lcaId && x.NhienLieuId == nhienLieuId && x.SanPhamId == spId);
            return query;
        }

        public async Task<List<NhienLieuSanPham>> GetNhienLieuSanPhamByNhienLieuId(int nhienLieuId)
        {
            var query = _repository.TableUntracked
            .Include(x => x.NhienLieu)
            .Include(x => x.DonVi)
            .Where(x => x.NhienLieuId == nhienLieuId);
            return query.ToList();
        }

        public async Task<NhienLieuSanPham> GetNhienLieuSanPhamByDVIdandNhienLieuIdandSPId(int nhienLieuId, int dvId, int spId)
        {
            var query = _repository.TableUntracked
                 .Include(x => x.NhienLieu)
                 .Include(x => x.DonVi)
                 .FirstOrDefault(x => x.DonViId == dvId && x.NhienLieuId == nhienLieuId && x.SanPhamId == spId);
            return query;
        }
    }
}
