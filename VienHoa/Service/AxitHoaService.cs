using DevExpress.Utils.DirectXPaint;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraReports.Wizards.Templates;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VienHoa.Common;
using VienHoa.DataEx;
using VienHoa.Entity;
using VienHoa.IService;

namespace VienHoa.Service
{
    public class AxitHoaService : IAxitHoa
    {
        private readonly IRepository<ThaiDauRa> _thaiDauRaRepo;
        private readonly IRepository<ChiSoTacDong> _chiSoTacDongRepo;
        private readonly IRepository<ChatThai> _chatThaiRepo;
        private readonly IRepository<TacDong> _tacDongRepo;
        public AxitHoaService()
        {
            _thaiDauRaRepo = new ExRepository<ThaiDauRa>();
            _chiSoTacDongRepo = new ExRepository<ChiSoTacDong>();
            _chatThaiRepo = new ExRepository<ChatThai>();
            _tacDongRepo = new ExRepository<TacDong>();
        }
        public async Task AxitHoaTinhToan(List<ThaiDauRa> dssanphamtdr, int sanPhamId,int lcdId)
        {    
            double tinhToan = 0;
            //var dssanphamtdr = _thaiDauRaRepo.Table.Include(x => x.ChatThai).Where(x => x.SanPhamId == sanPhamId && x.LCAId == lcdId).ToList();
            foreach (var tdr in dssanphamtdr)
            {
                switch (tdr.ChatThai.TenChatThai.ToLower())
                {
                    case "so2": tinhToan += tdr.HeSoDieuChinh * tdr.SoLuong; break;
                    case "no": tinhToan += tdr.HeSoDieuChinh * tdr.SoLuong; break;
                    case "no2": tinhToan += tdr.HeSoDieuChinh * tdr.SoLuong; break;
                    case "nox": tinhToan += tdr.HeSoDieuChinh * tdr.SoLuong;  break;
                    case "nh3": tinhToan += tdr.HeSoDieuChinh * tdr.SoLuong; break;
                }
            }
            var tacDongCanTim = _tacDongRepo.Table.FirstOrDefault(x => x.TenTacDong.ToLower().Contains("Sự Axit Hóa"));
            var chiSoTacDongCanTim = _chiSoTacDongRepo.Table.FirstOrDefault(x => x.SanPhamId == sanPhamId && x.LCAId == lcdId && x.TacDongId ==tacDongCanTim.Id);
            if (chiSoTacDongCanTim != null)
            {
                chiSoTacDongCanTim.GiaTri = tinhToan;
                await _chiSoTacDongRepo.UpdateAsync(chiSoTacDongCanTim);
            }
            else
            {
                ChiSoTacDong chiSoTacDong = new ChiSoTacDong();
                chiSoTacDong.SanPhamId = sanPhamId;
                chiSoTacDong.LCAId = lcdId;
                chiSoTacDong.TacDongId = tacDongCanTim.Id;
                chiSoTacDong.GiaTri = tinhToan;
                await _chiSoTacDongRepo.AddAsync(chiSoTacDong);
            }
        }
        public async Task KetQuaAxitHoa(List<ThaiDauRa> dssanphamtdr)
        {
                
                //var dssanphamtdr = _thaiDauRaRepo.Table.Include(x => x.ChatThai).Where(x => x.SanPhamId == sanPhamId && x.LCAId == lcdId).ToList();
                foreach (var tdr in dssanphamtdr)
                {
                    double tinhToan = 0;
                    switch (tdr.ChatThai.TenChatThai.ToLower())
                    {
                        case "so2": tinhToan += tdr.HeSoDieuChinh * tdr.SoLuong; break;
                        case "no": tinhToan += tdr.HeSoDieuChinh * tdr.SoLuong; break;
                        case "no2": tinhToan += tdr.HeSoDieuChinh * tdr.SoLuong; break;
                        case "nox": tinhToan += tdr.HeSoDieuChinh * tdr.SoLuong; break;
                        case "nh3": tinhToan += tdr.HeSoDieuChinh * tdr.SoLuong; break;
                    }
                var tacDongCanTim = _tacDongRepo.Table.FirstOrDefault(x => x.TenTacDong.ToLower().Contains("Sự Axit Hóa"));
                var chiSoTacDongCanTim = _chiSoTacDongRepo.Table.FirstOrDefault(x => x.SanPhamId == tdr.SanPhamId && x.LCAId == tdr.LCAId && x.TacDongId == tacDongCanTim.Id);
                if (chiSoTacDongCanTim != null)
                {
                    chiSoTacDongCanTim.GiaTri += tinhToan;
                    using (var dbContext = new AppDbContext())
                    {
                        dbContext.Entry(chiSoTacDongCanTim).State = EntityState.Modified;
                        await dbContext.SaveChangesAsync();
                    }
                    // await _sumTable.UpdateAsync(chiTiet);
                }
                else
                {
                    ChiSoTacDong cstd = new ChiSoTacDong()
                    {
                        SanPhamId = tdr.SanPhamId,
                        GiaTri = tinhToan,
                        TacDongId = tacDongCanTim.Id,
                        LCAId = tdr.LCAId
                    };
                    await _chiSoTacDongRepo.AddAsync(cstd);
                }
            }
                // Check existance of record(s)
             

        }
    }
}
