using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa.Common;

namespace VienHoa.Entity
{
    public class ThaiDauRa : BaseEntity
    {
        public int SanPhamId { get; set; }
        public virtual SanPham SanPham { get; set; }
        public int ChatThaiId { get; set; }
        public virtual ChatThai ChatThai { get; set; }
        public int DonViId { get; set; }
        public virtual DonViSanPham DonVi { get; set; }
        public int LCAId { get; set; }
        public virtual LCA LCA { get; set; }
        public double SoLuong { get; set; }
        public double HeSoDieuChinh { get; set; }
        public virtual IEnumerable<ThaiDauRaChiSoTacDong> ThaiDauRaChiSoTacDongs { get; set; }
    }
}
