using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa_Core.Common;

namespace VienHoa_Core.Entity
{
    public class LoaiNhienLieu : BaseEntity
    {
        public string TenLoai { get; set; }
        public virtual IEnumerable<NhienLieu> NhienLieus { get; set; }
    }
}
