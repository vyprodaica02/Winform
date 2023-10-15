using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa.Common;

namespace VienHoa.Entity
{
    public class LCA : BaseEntity
    {
        public string KyHieu { get; set; }
        public int ThuTu { get; set; }
        public string TenLCA { get; set; }
        public virtual IEnumerable<ChiSoTacDong> ChiSoTacDongs { get; set; }
        public virtual IEnumerable<ThaiDauRa> ThaiDauRas { get; set; }
        public virtual IEnumerable<NguyenLieuSanPham> NguyenLieuSanPhams { get; set; }
        public virtual IEnumerable<NhienLieuSanPham> NhienLieuSanPhams { get; set; }
    }
}
