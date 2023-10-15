using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa_Core.Common;

namespace VienHoa_Core.Entity
{
    public class ThaiDauRa : BaseEntity
    {
        public int SanPhamId { get; set; }
        public virtual SanPham SanPham { get; set; }
        public int ChatThaiId { get; set; }
        public virtual ChatThai ChatThai { get; set; }
        public double SoLuong { get; set; }

    }
}
