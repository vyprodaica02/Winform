using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa_Core.Common;

namespace VienHoa_Core.Entity
{
    public class LoaiNguyenLieu : BaseEntity
    {
        public string TenLoai { get; set; }
        public virtual IEnumerable<NguyenLieu> NguyenLieus { get; set; }
    }
}
