using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa.Common;

namespace VienHoa.Entity
{
    public class DonViDoTheoNam : BaseEntity
    {
        public string TenDonVi { get; set; }
        public virtual IEnumerable<TieuThuNhienLieuLoNam> TieuThuNhienLieuLoNams { get; set; }

    }
}
