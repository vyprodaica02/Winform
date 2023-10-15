using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa_Core.Common;

namespace VienHoa_Core.Entity
{
    public class TieuThuNhienLieuLoNam : BaseEntity
    {
        public int NhaMayId { get; set; }
        public virtual NhaMay NhaMay { get; set; }
        public int NamSanXuat { get; set; }
        public double SoLuong { get; set; }
    }
}
