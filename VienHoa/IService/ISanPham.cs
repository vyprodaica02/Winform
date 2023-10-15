using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VienHoa.Entity;
using System.Threading.Tasks;

namespace VienHoa.IService
{
    public interface ISanPham
    {
        Task<List<SanPham>> GetAllSanPham(string? keywords);
        Task<bool> AddSanPham(SanPham sanPham);
        Task<bool> UpdateSanPham(SanPham sanPham);
        Task<bool> DeleteSanPham(SanPham sanPham);
        Task<bool> DeleteRangeSanPham(List<SanPham> lstSanPham);
    }
}
