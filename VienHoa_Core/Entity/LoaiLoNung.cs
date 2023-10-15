using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa_Core.Common;

namespace VienHoa_Core.Entity
{
    public class LoaiLoNung :BaseEntity
    {
        public string TenLoaiLo { get; set; }
        public virtual IEnumerable<LoNungTrongNhaMay> LoNungTrongNhaMays { get; set; }
        public virtual IEnumerable<NhaMay> NhaMays { get; set; }
    }
}
