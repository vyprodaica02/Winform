using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa.Common;

namespace VienHoa.Entity
{
    public class LoNungTrongNhaMay : BaseEntity
    {
        public int LoaiLoNungId { get; set; }
        public virtual LoaiLoNung LoaiLoNung { get; set; }
        public int NhaMayId { get; set; }
        public virtual NhaMay NhaMay { get; set; }
    }
}
