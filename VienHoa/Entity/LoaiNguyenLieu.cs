using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa.Common;

namespace VienHoa.Entity
{
    public class LoaiNguyenLieu : BaseEntity
    {
        public string TenLoai { get; set; }
        public virtual IEnumerable<NguyenLieu> NguyenLieus { get; set; }
    }
}
