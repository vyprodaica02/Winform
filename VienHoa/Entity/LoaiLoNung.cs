using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa.Common;

namespace VienHoa.Entity
{
    public class LoaiLoNung :BaseEntity
    {
        public string TenLoaiLo { get; set; }
        public virtual IEnumerable<LoNungTrongNhaMay> LoNungTrongNhaMays { get; set; }
        public virtual IEnumerable<NhaMay> NhaMays { get; set; }
    }
}
