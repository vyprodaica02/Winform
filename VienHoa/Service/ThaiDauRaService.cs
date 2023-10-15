using DevExpress.Utils.DirectXPaint;
using DevExpress.XtraGantt.Scheduling;
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
    public class ThaiDauRaService : IThaiDauRa
    {
        private readonly IRepository<ThaiDauRa> _thaiDauRaRepo;
        private readonly IRepository<TacDong> _tacDongRepo;
        private readonly IRepository<SanPham> _SanPhamRepo;
        private readonly IRepository<ChiSoTacDong> _chiSoTacDong;
        private readonly TinhThaiDauRa _tinhThaiDauRa;
        private readonly AppDbContext dbContext;
        private readonly IAxitHoa _axitHoaService;
        public ThaiDauRaService()
        {
            dbContext = new AppDbContext();
            _chiSoTacDong = new ExRepository<ChiSoTacDong>();
            _thaiDauRaRepo = new ExRepository<ThaiDauRa>();
            _tacDongRepo = new ExRepository<TacDong>();
            _axitHoaService = new AxitHoaService();
            _tinhThaiDauRa = new TinhThaiDauRa();
        }

        public async Task<ServiceResult2> Create(ThaiDauRa thaiDauRa)
        {
            try
            {
                await _thaiDauRaRepo.AddAsync(thaiDauRa);
                return ServiceResult2.Success("Thêm thành công!");
            }
            catch
            {
                return ServiceResult2.Failed("Thêm thất bại!");
            }

        }

        public async Task<ServiceResult2> Delete(int id)
        {
            ThaiDauRa thaiDauRa = await _thaiDauRaRepo.GetByIdAsync(id);
            if (thaiDauRa != null)
            {
                await _thaiDauRaRepo.DeleteAsync(thaiDauRa);
                return ServiceResult2.Success("Xóa thành công!");
            }
            return ServiceResult2.Failed("Xóa thất bại!");
        }

        public Task<IQueryable<ThaiDauRa>> GetAllThaiDauRa()
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult2> Update(ThaiDauRa thaiDauRa)
        {
            try
            {

                using (var dbContext = new AppDbContext())
                {
                    dbContext.Entry(thaiDauRa).State = EntityState.Modified;
                    await dbContext.SaveChangesAsync();
                    return ServiceResult2.Success("Sửa dữ liệu thành công!");
                }
            }
            catch (Exception ex)
            {
                return ServiceResult2.Failed(ex.Message);
            }
        }


        public async Task<List<ThaiDauRa>> GetAll()
        {
            var query = _thaiDauRaRepo.TableUntracked.Include(x => x.ChatThai).Include(x => x.DonVi);
            return query.ToList();
        }

        public async Task<List<ThaiDauRa>> GetThaiDauRaByDonViSPId(int dvId)
        {
            var query = _thaiDauRaRepo.TableUntracked
               .Include(x => x.ChatThai)
               .Include(x => x.DonVi)
               .Where(x => x.DonViId == dvId);
            return query.ToList();
        }

        public async Task<ThaiDauRa> GetThaiDauRaByDVIdandChatThaiId(int chatThaiId, int dvId)
        {
            var query = _thaiDauRaRepo.TableUntracked
              .Include(x => x.ChatThai)
              .Include(x => x.DonVi)
              .FirstOrDefault(x => x.DonViId == dvId && x.ChatThaiId == chatThaiId);
            return query;
        }

        public async Task<List<ThaiDauRa>> GetThaiDauRaByLcaId(int lcaId)
        {
            var query = _thaiDauRaRepo.TableUntracked
               .Include(x => x.ChatThai)
               .Include(x => x.DonVi)
               .Where(x => x.LCAId == lcaId);
            return query.ToList();
        }
        public async Task<ThaiDauRa> GetThaiDauRaByChatThaiId(int chatThaiId)
        {
            var query = _thaiDauRaRepo.TableUntracked
               .Include(x => x.ChatThai)
               .Include(x => x.DonVi)
               .SingleOrDefault(x => x.ChatThaiId == chatThaiId);
            return query;
        }

        public async Task<List<ThaiDauRa>> GetThaiDauRaBySPId(int sanPhamId)
        {
            var query = _thaiDauRaRepo.TableUntracked
                 .Include(x => x.ChatThai)
                 .Include(x => x.DonVi)
                 .Where(x => x.SanPhamId == sanPhamId);
            return query.ToList();
        }

        public async Task<bool> AddRangeOrUpdateThaiDauRa(List<ThaiDauRa> lstThaiDauRa)
        {
            using (var trans = dbContext.Database.BeginTransaction())
            {
                try
                {
                    bool check = false;
                    foreach (var item in lstThaiDauRa)
                    {
                        if (item.SoLuong == 0)
                        {
                            await _thaiDauRaRepo.DeleteAsync(item);
                        }
                        else
                        {
                            if(item.DonViId != 0)
                            {
                                ThaiDauRa thaiDauRa = await GetThaiDauRaByLCAIdandChatThaiIdandSPId(item.ChatThaiId, item.LCAId, item.SanPhamId);
                                if (thaiDauRa != null)
                                {
                                    item.Id = thaiDauRa.Id;
                                    using (var dbContext = new AppDbContext())
                                    {
                                        dbContext.Entry(item).State = EntityState.Modified;
                                        await dbContext.SaveChangesAsync();
                                    }
                                }
                                else
                                {
                                    await _thaiDauRaRepo.AddAsync(item);
                                }
                            }
                            //_axitHoaService.AxitHoaTinhToan(item.SanPhamId, item.LCAId);
                        }
                        check = true;
                    }

                    if (check)
                    {
                        List<ThaiDauRa> lstThaiDauRaBySPId = new List<ThaiDauRa>();
                        int spId = 0;
                        if (lstThaiDauRa.Count() > 0)
                        {
                            spId = lstThaiDauRa[0].SanPhamId;
                            lstThaiDauRaBySPId = _thaiDauRaRepo.TableUntracked.Where(x => x.SanPhamId == lstThaiDauRa[0].SanPhamId).ToList();
                        }
                        List<int> lstLCAId = new List<int>();
                        foreach (var item in lstThaiDauRaBySPId)
                        {
                            if(!lstLCAId.Contains(item.LCAId))
                            {
                                lstLCAId.Add(item.LCAId);
                            }
                        }

                        if(spId != 0)
                        {
                            foreach (var lcaId in lstLCAId)
                            {
                                List<ThaiDauRa> lstTDR = _thaiDauRaRepo.TableUntracked.Include(x => x.ChatThai).Where(x => x.SanPhamId == lstThaiDauRa[0].SanPhamId && x.LCAId == lcaId).ToList();

                                await _axitHoaService.AxitHoaTinhToan(lstTDR, lstThaiDauRa[0].SanPhamId, lcaId );

                                await _tinhThaiDauRa.KetQuaPhuDuong(lstTDR, spId, lcaId);
                                await _tinhThaiDauRa.KetQuaPhaHuyOzon(lstTDR, spId, lcaId);
                                await _tinhThaiDauRa.KetQuaPhatSinhBui(lstTDR, spId, lcaId);
                                await _tinhThaiDauRa.GetChatThai(lstTDR, spId, lcaId);
                                await _tinhThaiDauRa.GetChatThaiNguyHai(lstTDR, spId, lcaId);
                                await _tinhThaiDauRa.KetQuaOzonHoa(lstTDR, spId, lcaId);
                            }
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
    
        public async Task<ThaiDauRa> GetThaiDauRaByLCAIdandChatThaiIdandSPId(int chatThaiId, int lcaId, int spId)
        {
            var query = _thaiDauRaRepo.TableUntracked
            .Include(x => x.ChatThai)
            .Include(x => x.DonVi)
            .FirstOrDefault(x => x.LCAId == lcaId && x.ChatThaiId == chatThaiId && x.SanPhamId == spId);
            return query;
        }

        public async Task<ThaiDauRa> GetThaiDauRaByDVIdandChatThaiIdandSPId(int chatThaiId, int dvId, int spId)
        {
            var query = _thaiDauRaRepo.TableUntracked
                .Include(x => x.ChatThai)
                .Include(x => x.DonVi)
                .FirstOrDefault(x => x.DonViId == dvId && x.ChatThaiId == chatThaiId && x.SanPhamId == spId);
            return query;
        }
    }
}
