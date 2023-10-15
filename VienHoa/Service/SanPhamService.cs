using DevExpress.Office.Utils;
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
    public class SanPhamService : ISanPham
    {
        public readonly IRepository<SanPham> _repository;

        public SanPhamService()
        {
            _repository = new ExRepository<SanPham>();
        }
        public async Task<bool> AddSanPham(SanPham sanPham)
        {
            bool check = ValidateSP(sanPham);

            if (check)
            {
                await _repository.AddAsync(sanPham);
                return true;
            }
            return false;
        }
        public async Task<bool> DeleteRangeSanPham(List<SanPham> lstSanPham)
        {
            if(lstSanPham.Count() > 0)
            {
                await _repository.DeleteRangeAsync(lstSanPham);
                return true;
            }
            return false;
        }
        public async Task<bool> DeleteSanPham(SanPham sanPham)
        {
            await _repository.DeleteAsync(sanPham);
            return true;
        }
        public async Task<List<SanPham>> GetAllSanPham(string? keywords)
        {
            var query = _repository.TableUntracked;

            if (!string.IsNullOrEmpty(keywords))
            {
                query = query.Where(x => x.TenSanPham.Contains(keywords));
            }

            return query.Include(x => x.NhaMay)
                        .Include(x => x.DuAn)
                        .Include(x => x.LoaiLoNung)
                        .ToList();
        }

        public async Task<bool> UpdateSanPham(SanPham sanPham)
        {
            bool check = ValidateSP(sanPham);
            if(check)
            {
                await _repository.UpdateAsync(sanPham);
                return true;
            }
            return false;
        }

        private bool ValidateSP(SanPham sanPham)
        {
            
            if (string.IsNullOrEmpty(sanPham.TenSanPham))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(sanPham.KyHieu))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(sanPham.MaCode))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(sanPham.CongNghe))
            {
                return false;
            }

            else if (string.IsNullOrEmpty(sanPham.CongSuatThietKe))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(sanPham.MaCode))
            {
                return false;
            }
            else if (sanPham.DuAnId == 0)
            {
                return false;
            }
            else if (sanPham.NhaMayId == 0)
            {
                return false;
            }
            else if (sanPham.LoaiLoNungId == 0)
            {
                return false;
            }

            return true;
        }

    }
}
