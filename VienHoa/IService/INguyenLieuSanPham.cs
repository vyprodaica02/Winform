using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa.Entity;

namespace VienHoa.IService
{
    public interface INguyenLieuSanPham
    {
        Task<List<NguyenLieuSanPham>> GetAllNguyenLieuSanPham();
        Task<List<NguyenLieuSanPham>> GetNguyenLieuSanPhamByLcaId(int lcaId);
        Task<List<NguyenLieuSanPham>> GetNguyenLieuSanPhamByDonViSPId(int dvId);
        Task<NguyenLieuSanPham> GetNguyenLieuSanPhamByDVIdandNguyenLieuId(int nguyenLieuId,int dvId);
        Task<NguyenLieuSanPham> GetNguyenLieuSanPhamByDVIdandNguyenLieuIdandSPId(int nguyenLieuId,int dvId, int spId);
        Task<NguyenLieuSanPham> GetNguyenLieuSanPhamByLCAIdandNguyenLieuIdandSPId(int nguyenLieuId,int lcaId, int spId);
        Task<List<NguyenLieuSanPham>> GetNguyenLieuSanPhamBySPId(int sanPhamId);
        Task<List<NguyenLieuSanPham>> GetNguyenLieuSanPhamByNguyenLieuId(int nguyenLieuId);
        Task<bool> AddRangeOrUpdateNguyenLieuSanPham(List<NguyenLieuSanPham> lstNguyenLieuSanPham);

    }
}
