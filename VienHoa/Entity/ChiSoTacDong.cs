using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa.Common;

namespace VienHoa.Entity
{
    public class ChiSoTacDong : BaseEntity
    {
        public int SanPhamId { get; set; }
        public virtual SanPham SanPham { get; set; }
        public int LCAId { get; set; }
        public virtual LCA LCA { get; set; }
        public int TacDongId { get; set; }
        public virtual TacDong TacDong { get; set; }
        public double GiaTri { get; set; }
        public virtual IEnumerable<ThaiDauRaChiSoTacDong> ThaiDauRaChiSoTacDongs { get; set; }
        public virtual IEnumerable<NguyenLieuSanPhamChiSoTacDong> NguyenLieuSanPhamChiSoTacDongs { get; set; }
        public virtual IEnumerable<NhienLieuSanPhamChiSoTacDong> NhienLieuSanPhamChiSoTacDongs { get; set; }
    }
}
