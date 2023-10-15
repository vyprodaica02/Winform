using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa.Entity;
using VienHoa.Enums;

namespace VienHoa.IService
{
    public interface INguyenLieu
    {
        Task<List<NguyenLieu>> GetAllNguyenLieu();
        Task<List<EnumNguyenLieu>> ThemNguyenLieu(NguyenLieu nguyenLieu);
        Task<List<EnumNguyenLieu>> SuaNguyenLieu(int nguyenLieuId,NguyenLieu nguyenLieu);
        Task XoaNguyenLieu(int nguyenLieuId);
        Task<List<NguyenLieu>> TimTenNguyenLieu(string tenNL);
        Task<List<NguyenLieu>> GetNguyenLieuByLoaiNguyenLieuId(int loaiNguyenLieuId);
    }
}
