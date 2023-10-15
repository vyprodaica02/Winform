using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa.Common;

namespace VienHoa.Entity
{
    public class TacDong : BaseEntity
    {
        public string TenTacDong { get; set; }
        public virtual IEnumerable<ChiSoTacDong> ChiSoTacDongs { get; set; }
    }
}
