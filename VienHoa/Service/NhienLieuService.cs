using DevExpress.XtraScheduler.VCalendar;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa.Common;
using VienHoa.DataEx;
using VienHoa.Entity;
using VienHoa.Enums;
using VienHoa.IService;
using VienHoa.View;

namespace VienHoa.Service
{
    public class NhienLieuService : INhienLieu
    {
        private readonly IRepository<NhienLieu> _repository;
        public NhienLieuService()
        {
            _repository = new ExRepository<NhienLieu>();
        }

        public async Task<List<NhienLieu>> GetAllNhienLieu()
        {
            return _repository.TableUntracked.Include(x => x.LoaiNhienLieu).Include(x=>x.DonViDoTheoNam).ToList();
        }
        public async Task<List<EnumNhienLieu>> SuaNhienLieu(int nhienLieuId, NhienLieu nhienLieu)
        {
            List<EnumNhienLieu> listError = new List<EnumNhienLieu>();
            var nhienlieucantim = await _repository.GetByIdAsync(nhienLieuId);
            if (nhienlieucantim != null)
            {
                nhienlieucantim.TenNhienLieu = nhienLieu.TenNhienLieu;
                nhienlieucantim.TenHienThiTieuThu = nhienLieu.TenHienThiTieuThu;
                nhienlieucantim.LoaiNhienLieuId = nhienLieu.LoaiNhienLieuId;
                nhienlieucantim.DonViDoTheoNamId = nhienLieu.DonViDoTheoNamId;
                nhienlieucantim.NhietTriRieng = nhienLieu.NhietTriRieng;
                var listNL = ValidateNL(nhienlieucantim);
                if (listNL.Count() == 0 )
                {
                    return listNL;
                }
                listError = listNL;
            }
            return listError;

        }
        private List<EnumNhienLieu> ValidateNL(NhienLieu nhienLieu)
        {
            List<EnumNhienLieu> listError = new List<EnumNhienLieu>();
            if (string.IsNullOrEmpty(nhienLieu.TenNhienLieu))
            {
                listError.Add(EnumNhienLieu.TrongTenNL);
            }
            if (string.IsNullOrEmpty(nhienLieu.TenHienThiTieuThu))
            {
                listError.Add(EnumNhienLieu.TrongTenHT);
            }
            if (nhienLieu.LoaiNhienLieuId == 0)
            {
                listError.Add(EnumNhienLieu.TrongLoaiNL);
            }
            if (nhienLieu.DonViDoTheoNamId == 0)
            {
                listError.Add(EnumNhienLieu.TrongHTTN);
            }
            if (nhienLieu.NhietTriRieng == -1)
            {
                listError.Add(EnumNhienLieu.TrongNTR);
            }
            return listError;
        }
        public async Task<List<EnumNhienLieu>> ThemNhienLieu(NhienLieu nhienLieu)
        {
            var listNL = ValidateNL(nhienLieu);
            if (listNL.Count() == 0)
            {
                return listNL;
            }
            else
            {
                return listNL;
            }
        }
        public async Task<List<NhienLieu>> TimTenNhienLieu(string tenNL)
        {
           return _repository.Table.Where(x=>x.TenNhienLieu.ToLower().Contains(tenNL.ToLower())).ToList();
        }
        public async Task XoaNhienLieu(int nhienLieuId)
        {
           var nhienlieucantim = await _repository.GetByIdAsync(nhienLieuId);
            await _repository.DeleteAsync(nhienlieucantim);
        }

        public async Task<List<NhienLieu>> GetNhienLieuByLoaiNhienLieuId(int loaiNhienLieuId)
        {
            return _repository.TableUntracked.Where(x => x.LoaiNhienLieuId == loaiNhienLieuId).ToList();
        }
    }
}
