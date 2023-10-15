using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa_Core.Common;

namespace VienHoa_Core.Entity
{
    public class GayNongLenToanCau : BaseEntity
    {
        public int KhiPhatThaiId { get; set; }
        public virtual KhiPhatThai KhiPhatThai { get; set; }
        public double GiaTri { get; set; }
    }
}
