using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa.Entity;

namespace VienHoa.IService
{
    public interface INhienLieuSanPhamChiSoTacDong
    {
        Task TinhToanChiSo(int nhienLieuSanPhamId);
        Task CapNhatChiSo(int nhienLieuSanPhamId);
        Task CapNhatChiSo(NhienLieuSanPham nhienLieuSanPham);
    }
}
