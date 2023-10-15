using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa.Entity;

namespace VienHoa.IService
{
    public interface INhienLieuSanPham
    {
        Task<List<NhienLieuSanPham>> GetAllNhienLieuSanPham();
        Task<List<NhienLieuSanPham>> GetNhienLieuSanPhamByLcaId(int lcaId);
        Task<List<NhienLieuSanPham>> GetNhienLieuSanPhamBySPId(int spId);
        Task<List<NhienLieuSanPham>> GetNhienLieuSanPhamByNhienLieuId(int nhienLieuId);

        Task<NhienLieuSanPham> GetNhienLieuSanPhamByDVIdandNhienLieuId(int nhienLieuId, int dvId);
        Task<NhienLieuSanPham> GetNhienLieuSanPhamByDVIdandNhienLieuIdandSPId(int nhienLieuId, int dvId, int spId);
        Task<bool> AddRangeOrUpdateNhienLieuSanPham(List<NhienLieuSanPham> lstNhienLieuSanPham);
        Task<NhienLieuSanPham> GetNhienLieuSanPhamByLCAIdandNhienLieuIdandSPId(int nhienLieuId, int lcaId, int spId);

    }
}
