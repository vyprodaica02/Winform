using DevExpress.Mvvm.Native;
using DevExpress.Mvvm.POCO;
using DevExpress.Utils.DirectXPaint;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using VienHoa.Common;
using VienHoa.DataEx;
using VienHoa.Entity;
using VienHoa.IService;

namespace VienHoa.Service
{
    // Class nay chi dung de tinh toan ket qua
    public class TinhThaiDauRa : ITinhThaiDauRa
    {
        private IRepository<ThaiDauRa> _repoThaiDauRa;
        private IRepository<TacDong> _inforTacDong;
        private IRepository<ChiSoTacDong> _sumTable;

        public TinhThaiDauRa()
        {
            _repoThaiDauRa = new ExRepository<ThaiDauRa>();
            _inforTacDong = new ExRepository<TacDong>();
            _sumTable = new ExRepository<ChiSoTacDong>();
        }

        public async Task KetQuaOzonHoa(List<ThaiDauRa> dssanphamtdr, int spId, int lcaId)
        {
            double giaTriFinal = 0;

            foreach (var item in dssanphamtdr)
            {
                if (item.SanPhamId == spId && item.LCAId == lcaId
                    && item.ChatThai.TenChatThai.ToLower() == "ch4") { giaTriFinal += item.SoLuong * item.HeSoDieuChinh; }
            }
            // Check existance of record(s)
            var tacDongCanTim = _inforTacDong.TableUntracked
                .FirstOrDefault(x => x.TenTacDong.ToLower().Contains("tiềm năng tạo ozzon quang hóa"));
            var chiTiet = _sumTable.TableUntracked.FirstOrDefault(x => x.SanPhamId == spId &&
            x.LCAId == lcaId && x.TacDong.TenTacDong == tacDongCanTim.TenTacDong);
            if (chiTiet != null)
            {
                chiTiet.GiaTri = giaTriFinal;
                using (var dbContext = new AppDbContext())
                {
                    dbContext.Entry(chiTiet).State = EntityState.Modified;
                    await dbContext.SaveChangesAsync();
                }
                //await _sumTable.UpdateAsync(chiTiet);
            }
            else
            {
                ChiSoTacDong cstd = new ChiSoTacDong()
                {
                    SanPhamId = spId,
                    GiaTri = giaTriFinal,
                    TacDongId = tacDongCanTim.Id,
                    LCAId = lcaId
                };
                await _sumTable.AddAsync(cstd);
            }
        }

        public async Task KetQuaPhaHuyOzon(List<ThaiDauRa> dssanphamtdr, int spId, int lcaId)
        {
            double giaTriFinal = 0;

            foreach (var item in dssanphamtdr)
            {
                if (item.SanPhamId == spId && item.LCAId == lcaId
                    && (item.ChatThai.TenChatThai.ToLower() == "cf2cl2" || item.ChatThai.TenChatThai.ToLower() == "c2f3cl3"
                    || item.ChatThai.TenChatThai.ToLower() == "c2f4cl2" || item.ChatThai.TenChatThai.ToLower() == "cfcl3"
                    || item.ChatThai.TenChatThai.ToLower() == "c2f5cl" || item.ChatThai.TenChatThai.ToLower() == "ccl4"))
                { giaTriFinal += item.SoLuong * item.HeSoDieuChinh; }
            }
            // Check existance of record(s)
            var tacDongCanTim = _inforTacDong.Table.FirstOrDefault(x => x.TenTacDong.ToLower().Contains("phá hủy tầng ozon"));
            var chiTiet = _sumTable.Table.FirstOrDefault(x => x.SanPhamId == spId &&
            x.LCAId == lcaId && x.TacDong.TenTacDong == tacDongCanTim.TenTacDong);
            if (chiTiet != null)
            {
                chiTiet.GiaTri = giaTriFinal;
                using (var dbContext = new AppDbContext())
                {
                    dbContext.Entry(chiTiet).State = EntityState.Modified;
                    await dbContext.SaveChangesAsync();
                }
                //await _sumTable.UpdateAsync(chiTiet);
            }
            else
            {
                ChiSoTacDong cstd = new ChiSoTacDong()
                {
                    SanPhamId = spId,
                    GiaTri = giaTriFinal,
                    TacDongId = tacDongCanTim.Id,
                    LCAId = lcaId
                };
                await _sumTable.AddAsync(cstd);
            }
        }

        public async Task KetQuaPhuDuong(List<ThaiDauRa> dssanphamtdr, int spId, int lcaId)
        {
            double giaTriFinal = 0;

            foreach (var item in dssanphamtdr)
            {
                switch (item.ChatThai.TenChatThai.ToLower())
                {
                    case "cod": giaTriFinal += item.SoLuong * item.HeSoDieuChinh; break;
                    case "n": giaTriFinal += item.SoLuong * item.HeSoDieuChinh; break;
                    case "p": giaTriFinal += item.SoLuong * item.HeSoDieuChinh; break;
                    case "po4": giaTriFinal += item.SoLuong * item.HeSoDieuChinh; break;
                    case "nh4": giaTriFinal += item.SoLuong * item.HeSoDieuChinh; break;
                    case "no": giaTriFinal += item.SoLuong * item.HeSoDieuChinh; break;
                    case "no2": giaTriFinal += item.SoLuong * item.HeSoDieuChinh; break;
                    case "nox": giaTriFinal += item.SoLuong * item.HeSoDieuChinh; break;
                }
            }
            // Check existance of record(s)
            var tacDongCanTim = _inforTacDong.Table.FirstOrDefault(x => x.TenTacDong.ToLower().Contains("phú dưỡng"));
            var chiTiet = _sumTable.Table.FirstOrDefault(x => x.SanPhamId == spId &&
            x.LCAId == lcaId && x.TacDong.TenTacDong == tacDongCanTim.TenTacDong);
            if (chiTiet != null)
            {
                chiTiet.GiaTri = giaTriFinal;
                using (var dbContext = new AppDbContext())
                {
                    dbContext.Entry(chiTiet).State = EntityState.Modified;
                    await dbContext.SaveChangesAsync();
                }
                // await _sumTable.UpdateAsync(chiTiet);
            }
            else
            {
                ChiSoTacDong cstd = new ChiSoTacDong()
                {
                    SanPhamId = spId,
                    GiaTri = giaTriFinal,
                    TacDongId = tacDongCanTim.Id,
                    LCAId = lcaId
                };
                await _sumTable.AddAsync(cstd);
            }
        }

        public async Task GetChatThaiNguyHai(List<ThaiDauRa> dssanphamtdr, int spId, int lcaId)
        {
            double giaTriFinal = 0;

            foreach (var item in dssanphamtdr)
            {
                if (item.SanPhamId == spId && item.LCAId == lcaId
                    && item.ChatThai.TenChatThai.ToLower() == "chất thải rắn nguy hại")
                { giaTriFinal += item.SoLuong * item.HeSoDieuChinh; }
            }
            // Check existance of record(s)
            var tacDongCanTim = _inforTacDong.TableUntracked.FirstOrDefault(x => x.TenTacDong.ToLower().Contains("chất thải nguy hại"));
            var chiTiet = _sumTable.TableUntracked.FirstOrDefault(x => x.SanPhamId == spId &&
            x.LCAId == lcaId && x.TacDong.TenTacDong == tacDongCanTim.TenTacDong);
            if (chiTiet != null)
            {
                chiTiet.GiaTri = giaTriFinal;
                using (var dbContext = new AppDbContext())
                {
                    dbContext.Entry(chiTiet).State = EntityState.Modified;
                    await dbContext.SaveChangesAsync();
                }
                //await _sumTable.UpdateAsync(chiTiet);
            }
            else
            {
                ChiSoTacDong cstd = new ChiSoTacDong()
                {
                    SanPhamId = spId,
                    GiaTri = giaTriFinal,
                    TacDongId = tacDongCanTim.Id,
                    LCAId = lcaId
                };
                await _sumTable.AddAsync(cstd);
            }
        }

        public async Task GetChatThai(List<ThaiDauRa> dssanphamtdr, int spId, int lcaId)
        {
            double giaTriFinal = 0;

            foreach (var item in dssanphamtdr)
            {
                if (item.SanPhamId == spId && item.LCAId == lcaId
                    && item.ChatThai.TenChatThai.ToLower() == "chất thải rắn thông thường")
                { giaTriFinal += item.SoLuong * item.HeSoDieuChinh; }
            }
            // Check existance of record(s)
            var tacDongCanTim = _inforTacDong.TableUntracked
                .FirstOrDefault(x => x.TenTacDong.ToLower().Contains("chất thải không nguy hại"));
            var chiTiet = _sumTable.TableUntracked.FirstOrDefault(x => x.SanPhamId == spId &&
            x.LCAId == lcaId && x.TacDong.TenTacDong == tacDongCanTim.TenTacDong);
            if (chiTiet != null)
            {
                chiTiet.GiaTri = giaTriFinal;
                using (var dbContext = new AppDbContext())
                {
                    dbContext.Entry(chiTiet).State = EntityState.Modified;
                    await dbContext.SaveChangesAsync();
                }
                //await _sumTable.UpdateAsync(chiTiet);
            }
            else
            {
                ChiSoTacDong cstd = new ChiSoTacDong()
                {
                    SanPhamId = spId,
                    GiaTri = giaTriFinal,
                    TacDongId = tacDongCanTim.Id,
                    LCAId = lcaId
                };
                await _sumTable.AddAsync(cstd);
            }
        }

        public async Task KetQuaPhatSinhBui(List<ThaiDauRa> dssanphamtdr, int spId, int lcaId)
        {
            double giaTriFinal = 0;

            foreach (var item in dssanphamtdr)
            {
                if (item.SanPhamId == spId && item.LCAId == lcaId
                    && item.ChatThai.TenChatThai.ToLower() == "bụi") { giaTriFinal += item.SoLuong * item.HeSoDieuChinh; }
            }
            // Check existance of record(s)
            var tacDongCanTim = _inforTacDong.TableUntracked.FirstOrDefault(x => x.TenTacDong.ToLower().Contains("phát sinh bụi"));
            var chiTiet = _sumTable.TableUntracked.FirstOrDefault(x => x.SanPhamId == spId &&
            x.LCAId == lcaId && x.TacDong.TenTacDong == tacDongCanTim.TenTacDong);
            if (chiTiet != null)
            {
                chiTiet.GiaTri = giaTriFinal;
                using (var dbContext = new AppDbContext())
                {
                    dbContext.Entry(chiTiet).State = EntityState.Modified;
                    await dbContext.SaveChangesAsync();
                }
                //await _sumTable.UpdateAsync(chiTiet);
            }
            else
            {
                ChiSoTacDong cstd = new ChiSoTacDong()
                {
                    SanPhamId = spId,
                    GiaTri = giaTriFinal,
                    TacDongId = tacDongCanTim.Id,
                    LCAId = lcaId
                };
                await _sumTable.AddAsync(cstd);
            }
        }
        #region TinhOzonImport
        public async Task KetQuaOzonHoa_Import(List<ThaiDauRa> dssanphamtdr)
        {
            foreach (var item in dssanphamtdr)
            {
                double giaTriFinal = 0;
                if (item.ChatThai.TenChatThai.ToLower() == "ch4")
                { giaTriFinal += item.SoLuong * item.HeSoDieuChinh; }
                // Check existance of record(s)
                var tacDongCanTim = _inforTacDong.TableUntracked
                    .FirstOrDefault(x => x.TenTacDong.ToLower().Contains("tiềm năng tạo ozzon quang hóa"));
                var chiTiet = _sumTable.TableUntracked.FirstOrDefault(x => x.SanPhamId == item.SanPhamId &&
                x.LCAId == item.LCAId && x.TacDong.TenTacDong == tacDongCanTim.TenTacDong);
                if (chiTiet != null)
                {
                    chiTiet.GiaTri += giaTriFinal;
                    using (var dbContext = new AppDbContext())
                    {
                        dbContext.Entry(chiTiet).State = EntityState.Modified;
                        await dbContext.SaveChangesAsync();
                    }
                    //await _sumTable.UpdateAsync(chiTiet);
                }
                else
                {
                    ChiSoTacDong cstd = new ChiSoTacDong()
                    {
                        SanPhamId = item.SanPhamId,
                        GiaTri = giaTriFinal,
                        TacDongId = tacDongCanTim.Id,
                        LCAId = item.LCAId
                    };
                    _sumTable.Add(cstd);
                }
            }
        }
        #endregion

        #region TinhPhaHUyOzonImport
        public async Task KetQuaPhaHuyOzon_Import(List<ThaiDauRa> dssanphamtdr)
        {
            foreach (var item in dssanphamtdr)
            {
                double giaTriFinal = 0;
                if (item.ChatThai.TenChatThai.ToLower() == "cf2cl2" || item.ChatThai.TenChatThai.ToLower() == "c2f3cl3"
                    || item.ChatThai.TenChatThai.ToLower() == "c2f4cl2" || item.ChatThai.TenChatThai.ToLower() == "cfcl3"
                    || item.ChatThai.TenChatThai.ToLower() == "c2f5cl" || item.ChatThai.TenChatThai.ToLower() == "ccl4")
                { giaTriFinal += item.SoLuong * item.HeSoDieuChinh; }
                // Check existance of record(s)
                var tacDongCanTim = _inforTacDong.Table.FirstOrDefault(x => x.TenTacDong.ToLower().Contains("phá hủy tầng ozon"));
                var chiTiet = _sumTable.Table.FirstOrDefault(x => x.SanPhamId == item.SanPhamId &&
                x.LCAId == item.LCAId && x.TacDong.TenTacDong == tacDongCanTim.TenTacDong);
                if (chiTiet != null)
                {
                    chiTiet.GiaTri += giaTriFinal;
                    using (var dbContext = new AppDbContext())
                    {
                        dbContext.Entry(chiTiet).State = EntityState.Modified;
                        await dbContext.SaveChangesAsync();
                    }
                    //await _sumTable.UpdateAsync(chiTiet);
                }
                else
                {
                    ChiSoTacDong cstd = new ChiSoTacDong()
                    {
                        SanPhamId = item.SanPhamId,
                        GiaTri = giaTriFinal,
                        TacDongId = tacDongCanTim.Id,
                        LCAId = item.LCAId
                    };
                    _sumTable.Add(cstd);
                }
            }
        }
        #endregion

        #region TinhPhuDuongImport
        public async Task KetQuaPhuDuong_Import(List<ThaiDauRa> dssanphamtdr)
        {
            foreach (var item in dssanphamtdr)
            {
                double giaTriFinal = 0;
                switch (item.ChatThai.TenChatThai.ToLower())
                {
                    case "cod": giaTriFinal += item.SoLuong * item.HeSoDieuChinh; break;
                    case "n": giaTriFinal += item.SoLuong * item.HeSoDieuChinh; break;
                    case "p": giaTriFinal += item.SoLuong * item.HeSoDieuChinh; break;
                    case "po4": giaTriFinal += item.SoLuong * item.HeSoDieuChinh; break;
                    case "nh4": giaTriFinal += item.SoLuong * item.HeSoDieuChinh; break;
                    case "no": giaTriFinal += item.SoLuong * item.HeSoDieuChinh; break;
                    case "no2": giaTriFinal += item.SoLuong * item.HeSoDieuChinh; break;
                    case "nox": giaTriFinal += item.SoLuong * item.HeSoDieuChinh; break;
                }
                // Check existance of record(s)
                var tacDongCanTim = _inforTacDong.Table.FirstOrDefault(x => x.TenTacDong.ToLower().Contains("phú dưỡng"));
                var chiTiet = _sumTable.Table.FirstOrDefault(x => x.SanPhamId == item.SanPhamId &&
                x.LCAId == item.LCAId && x.TacDong.TenTacDong == tacDongCanTim.TenTacDong);
                if (chiTiet != null)
                {
                    chiTiet.GiaTri += giaTriFinal;
                    using (var dbContext = new AppDbContext())
                    {
                        dbContext.Entry(chiTiet).State = EntityState.Modified;
                        await dbContext.SaveChangesAsync();
                    }
                    // await _sumTable.UpdateAsync(chiTiet);
                }
                else
                {
                    ChiSoTacDong cstd = new ChiSoTacDong()
                    {
                        SanPhamId = item.SanPhamId,
                        GiaTri = giaTriFinal,
                        TacDongId = tacDongCanTim.Id,
                        LCAId = item.LCAId
                    };
                    _sumTable.Add(cstd);
                }
            }
        }
        #endregion

        #region TinhChatThaiNguyHai
        public async Task GetChatThaiNguyHai_Import(List<ThaiDauRa> dssanphamtdr)
        {
            foreach (var item in dssanphamtdr)
            {
                double giaTriFinal = 0;
                if (item.ChatThai.TenChatThai.ToLower() == "chất thải rắn nguy hại")
                { giaTriFinal += item.SoLuong * item.HeSoDieuChinh; }
                // Check existance of record(s)
                var tacDongCanTim = _inforTacDong.TableUntracked.FirstOrDefault(x => x.TenTacDong.ToLower().Contains("chất thải nguy hại"));
                var chiTiet = _sumTable.TableUntracked.FirstOrDefault(x => x.SanPhamId == item.SanPhamId &&
                x.LCAId == item.LCAId && x.TacDong.TenTacDong == tacDongCanTim.TenTacDong);
                if (chiTiet != null)
                {
                    chiTiet.GiaTri += giaTriFinal;
                    using (var dbContext = new AppDbContext())
                    {
                        dbContext.Entry(chiTiet).State = EntityState.Modified;
                        await dbContext.SaveChangesAsync();
                    }
                    //await _sumTable.UpdateAsync(chiTiet);
                }
                else
                {
                    ChiSoTacDong cstd = new ChiSoTacDong()
                    {
                        SanPhamId = item.SanPhamId,
                        GiaTri = giaTriFinal,
                        TacDongId = tacDongCanTim.Id,
                        LCAId = item.LCAId
                    };
                    _sumTable.Add(cstd);
                }
            }

        }
        #endregion

        #region TinhCHatThaiBt
        public async Task GetChatThai_Import(List<ThaiDauRa> dssanphamtdr)
        {
            foreach (var item in dssanphamtdr)
            {
                double giaTriFinal = 0;
                if (item.ChatThai.TenChatThai.ToLower() == "chất thải rắn thông thường")
                { giaTriFinal += item.SoLuong * 1; }
                // Check existance of record(s)
                var tacDongCanTim = _inforTacDong.TableUntracked
                    .FirstOrDefault(x => x.TenTacDong.ToLower().Contains("chất thải không nguy hại"));
                var chiTiet = _sumTable.TableUntracked.FirstOrDefault(x => x.SanPhamId == item.SanPhamId &&
                x.LCAId == item.LCAId && x.TacDong.TenTacDong == tacDongCanTim.TenTacDong);
                if (chiTiet != null)
                {
                    chiTiet.GiaTri += giaTriFinal;
                    using (var dbContext = new AppDbContext())
                    {
                        dbContext.Entry(chiTiet).State = EntityState.Modified;
                        await dbContext.SaveChangesAsync();
                    }
                }
                else
                {
                    ChiSoTacDong cstd = new ChiSoTacDong()
                    {
                        SanPhamId = item.SanPhamId,
                        GiaTri = giaTriFinal,
                        TacDongId = tacDongCanTim.Id,
                        LCAId = item.LCAId
                    };
                    _sumTable.Add(cstd);
                }
            }
        }
        #endregion

        #region TinhKqPhatSinhBui
        public async Task KetQuaPhatSinhBui_Import(List<ThaiDauRa> dssanphamtdr)
        {
            foreach (var item in dssanphamtdr)
            {
                double giaTriFinal = 0;
                if (item.ChatThai.TenChatThai.ToLower() == "bụi") { giaTriFinal += item.SoLuong * item.HeSoDieuChinh; }
                // Check existance of record(s)
                var tacDongCanTim = _inforTacDong.TableUntracked.FirstOrDefault(x => x.TenTacDong.ToLower().Contains("phát sinh bụi"));
                var chiTiet = _sumTable.TableUntracked.FirstOrDefault(x => x.SanPhamId == item.SanPhamId &&
                x.LCAId == item.LCAId && x.TacDong.TenTacDong == tacDongCanTim.TenTacDong);
                if (chiTiet != null)
                {
                    chiTiet.GiaTri += giaTriFinal;
                    using (var dbContext = new AppDbContext())
                    {
                        dbContext.Entry(chiTiet).State = EntityState.Modified;
                        await dbContext.SaveChangesAsync();
                    }
                    //await _sumTable.UpdateAsync(chiTiet);
                }
                else
                {
                    ChiSoTacDong cstd = new ChiSoTacDong()
                    {
                        SanPhamId = item.SanPhamId,
                        GiaTri = giaTriFinal,
                        TacDongId = tacDongCanTim.Id,
                        LCAId = item.LCAId,
                    };
                     _sumTable.Add(cstd);
                }
            }

        }
        #endregion
    }
}