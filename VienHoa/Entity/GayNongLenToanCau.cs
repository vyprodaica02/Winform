using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa.Common;

namespace VienHoa.Entity
{
    public class GayNongLenToanCau : BaseEntity
    {
        public int KhiPhatThaiId { get; set; }
        public virtual KhiPhatThai KhiPhatThai { get; set; }
        public double GiaTri { get; set; }
    }
}
