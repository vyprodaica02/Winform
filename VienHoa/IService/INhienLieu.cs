using DevExpress.CodeParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa.Entity;
using VienHoa.Enums;

namespace VienHoa.IService
{
    public interface INhienLieu
    {   
        Task<List<NhienLieu>> GetAllNhienLieu();
        Task<List<EnumNhienLieu>> ThemNhienLieu(NhienLieu nhienLieu);
        Task<List<EnumNhienLieu>> SuaNhienLieu(int nhienLieuId, NhienLieu nhienLieu);
        Task XoaNhienLieu(int nhienLieuId);
        Task<List<NhienLieu>> TimTenNhienLieu(string tenNL);
        Task<List<NhienLieu>> GetNhienLieuByLoaiNhienLieuId(int loaiNhienLieuId);

    }
}
