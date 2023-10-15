using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa.Common;

namespace VienHoa.Entity
{
    public class ThaiDauRaChiSoTacDong : BaseEntity
    {
        public int ThaiDauRaId { get; set; }
        public virtual ThaiDauRa ThaiDauRa { get; set; }
        public int ChiSoTacDongId { get; set; }
        public virtual ChiSoTacDong ChiSoTacDong { get; set; }
        public double GiaTri { get; set; }
    }
}
