using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa.Entity;

namespace VienHoa.IService
{
    public interface INguyenLieuSanPhamChiSoTacDong
    {
        Task TinhToanChiSo( int nguyenLieuSanPhamId);
        Task CapNhatChiSo(int nguyenLieuSanPhamId);
        Task CapNhatChiSo(NguyenLieuSanPham nglSP);

        Task HieuUngNhaKinhNguyenLieu(List<NguyenLieuSanPham> dsnguyenLieu, int sanPhamId, int lcdId);
    }
}