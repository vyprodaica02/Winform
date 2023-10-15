using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa.Common;

namespace VienHoa.Entity
{
    public class NhienLieuSanPhamChiSoTacDong : BaseEntity
    {
        public int NhienLieuSanPhamId { get; set; }
        public virtual NhienLieuSanPham NhienLieuSanPham { get; set; }
        public int ChiSoTacDongId { get; set; }
        public virtual ChiSoTacDong ChiSoTacDong { get; set; }
        public double GiaTri { get; set; }
    }
}
