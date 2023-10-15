using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa.Common;

namespace VienHoa.Entity
{
    public class TieuThuNhienLieuLoNam : BaseEntity
    {
        public int NhaMayId { get; set; }
        public virtual NhaMay NhaMay { get; set; }
        public int DonViDoNamId { get; set; }
        public virtual DonViDoTheoNam DonViDoNam { get; set; }
        public int NamSanXuat { get; set; }
        public double SoLuong { get; set; }
        public string TenNhienLieu { get; set; }
    }
}
