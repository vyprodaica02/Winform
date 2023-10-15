using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa.Common;

namespace VienHoa.Entity
{
    public class NguyenLieuSanPham : BaseEntity
    {
        public int SanPhamId { get; set; }
        public virtual SanPham SanPham { get; set; }
        public int NguyenLieuId { get; set; }
        public virtual NguyenLieu NguyenLieu { get; set; }
        public int DonViId { get; set; }
        public virtual DonViSanPham DonVi { get; set; }
        public int LCAId { get; set; }
        public virtual LCA LCA { get; set; }
        public double SoLuong { get; set; }
        public virtual IEnumerable<NguyenLieuSanPhamChiSoTacDong> NguyenLieuSanPhamChiSoTacDongs { get; set; }
    }
}
