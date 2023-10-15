using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa_Core.Common;

namespace VienHoa_Core.Entity
{
    public class LCA : BaseEntity
    {
        public string KyHieu { get; set; }
        public int ThuTu { get; set; }
        public string TenLCA { get; set; }
        public virtual IEnumerable<RanhGioiLCA> RanhGioiLCAs { get; set; }

    }
}
