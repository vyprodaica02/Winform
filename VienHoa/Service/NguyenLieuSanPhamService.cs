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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VienHoa.Service
{
    public class NguyenLieuSanPhamService : INguyenLieuSanPham
    {
        public readonly IRepository<NguyenLieuSanPham> _repository;
        private readonly INguyenLieuSanPhamChiSoTacDong _nguyenLieuChiSoTacDong;
        private readonly IChiSoKhac _cacChiSoKhac;
        private readonly AppDbContext dbContext;

        public NguyenLieuSanPhamService()
        {
            dbContext = new AppDbContext();
            _nguyenLieuChiSoTacDong = new NguyenLieuSanPhamChiSoTacDongService();
            _repository = new ExRepository<NguyenLieuSanPham>();
            _cacChiSoKhac = new CacChiSoKhac();
        }
        public async Task<List<NguyenLieuSanPham>> GetAllNguyenLieuSanPham()
        {
            var query = _repository.TableUntracked.Include(x => x.NguyenLieu).Include(x => x.DonVi);
            return query.ToList();
        }

        public async Task<List<NguyenLieuSanPham>> GetNguyenLieuSanPhamByLcaId(int lcaId)
        {
            var query = _repository.TableUntracked
                .Include(x => x.NguyenLieu)
                .Include(x => x.DonVi)
                .Where(x => x.LCAId == lcaId);
            return query.ToList();
        }

        public async Task<List<NguyenLieuSanPham>> GetNguyenLieuSanPhamBySPId(int sanPhamId)
        {
            var query = _repository.TableUntracked
                .Include(x => x.NguyenLieu)
                .Include(x => x.DonVi)
                .Where(x => x.SanPhamId == sanPhamId);
            return query.ToList();
        }

        public async Task<List<NguyenLieuSanPham>> GetNguyenLieuSanPhamByDonViSPId(int dvId)
        {
            var query = _repository.TableUntracked
               .Include(x => x.NguyenLieu)
               .Include(x => x.DonVi)
               .Where(x => x.DonViId == dvId);
            return query.ToList();
        }

        public async Task<NguyenLieuSanPham> GetNguyenLieuSanPhamByDVIdandNguyenLieuId(int nguyenLieuId,int dvId)
        {
            var query = _repository.TableUntracked
              .Include(x => x.NguyenLieu)
              .Include(x => x.DonVi)
              .FirstOrDefault(x => x.DonViId == dvId && x.NguyenLieuId == nguyenLieuId);
            return query;
        }

        public async Task<bool> AddRangeOrUpdateNguyenLieuSanPham(List<NguyenLieuSanPham> lstNguyenLieuSanPham)
        {
            using (var trans = dbContext.Database.BeginTransaction())
            {
                try
                {
                    bool check = false;
                    foreach (var item in lstNguyenLieuSanPham)
                    {
                        if (item.SoLuong == 0)
                        {
                            NguyenLieuSanPham nglSp = await GetNguyenLieuSanPhamByLCAIdandNguyenLieuIdandSPId(item.NguyenLieuId, item.LCAId, item.SanPhamId);

                            if (nglSp != null)
                            {
                                await _repository.DeleteAsync(nglSp);
                                //await _nguyenLieuChiSoTacDong.CapNhatChiSo(nglSp);
                            }
                        }
                        else
                        {
                            if (item.DonViId != 0)
                            {
                                NguyenLieuSanPham nguyenLieuSanPham = await GetNguyenLieuSanPhamByLCAIdandNguyenLieuIdandSPId(item.NguyenLieuId, item.LCAId, item.SanPhamId);
                                if (nguyenLieuSanPham != null)
                                {
                                    item.Id = nguyenLieuSanPham.Id;
                                    using (var dbContext = new AppDbContext())
                                    {
                                        dbContext.Entry(item).State = EntityState.Modified;
                                        await dbContext.SaveChangesAsync();
                                    }
                                    await _nguyenLieuChiSoTacDong.CapNhatChiSo(item.Id);
                                }
                                else
                                {
                                    await _repository.AddAsync(item);
                                    await _nguyenLieuChiSoTacDong.TinhToanChiSo(item.Id);
                                }
                            }
                            
                        }
                        check = true;
                    }


                    //if (check)
                    //{
                    //    List<NguyenLieuSanPham> lstNguyenLieuSPBySPId = new List<NguyenLieuSanPham>();
                    //    int spId = 0;
                    //    if (lstNguyenLieuSanPham.Count() > 0)
                    //    {
                    //        spId = lstNguyenLieuSanPham[0].SanPhamId;
                    //        lstNguyenLieuSPBySPId = await GetNguyenLieuSanPhamBySPId(spId);
                    //    }

                    //    List<int> lstLCAId = new List<int>();
                    //    foreach (var item in lstNguyenLieuSPBySPId)
                    //    {
                    //        if (!lstLCAId.Contains(item.LCAId))
                    //        {
                    //            lstLCAId.Add(item.LCAId);
                    //        }
                    //        NguyenLieuSanPham nguyenLieuSanPham = _repository.TableUntracked.Include(x => x.NguyenLieu).ThenInclude(y => y.HeSoPhatThaiTuNguyenLieus).SingleOrDefault(z => z.Id == item.Id);
                    //        await _nguyenLieuChiSoTacDong.HieuUngNhaKinhNguyenLieu(lstNguyenLieuSPBySPId, spId, nguyenLieuSanPham.LCAId);
                    //    }

                    //    if (spId != 0)
                    //    {
                    //        //foreach (var lcaId in lstLCAId)
                    //        //{
                    //        //    
                    //        //    
                    //        //}
                    //    }
                    //}
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

        public async Task<NguyenLieuSanPham> GetNguyenLieuSanPhamByLCAIdandNguyenLieuIdandSPId(int nguyenLieuId, int lcaId, int spId)
        {
            var query = _repository.TableUntracked
             .Include(x => x.NguyenLieu)
             .Include(x => x.DonVi)
             .SingleOrDefault(x => x.LCAId == lcaId && x.NguyenLieuId == nguyenLieuId && x.SanPhamId == spId);
            return query;
        }

        public async Task<List<NguyenLieuSanPham>> GetNguyenLieuSanPhamByNguyenLieuId(int nguyenLieuId)
        {
            var query = _repository.TableUntracked
            .Include(x => x.NguyenLieu)
            .Include(x => x.DonVi)
            .Where(x => x.NguyenLieuId == nguyenLieuId);
            return query.ToList();
        }

        public async Task<NguyenLieuSanPham> GetNguyenLieuSanPhamByDVIdandNguyenLieuIdandSPId(int nguyenLieuId, int dvId, int spId)
        {
            var query = _repository.TableUntracked
            .Include(x => x.NguyenLieu)
            .Include(x => x.DonVi)
            .FirstOrDefault(x => x.DonViId == dvId && x.NguyenLieuId == nguyenLieuId && x.SanPhamId == spId);
            return query;
        }
    }
}
