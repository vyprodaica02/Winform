using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa_Core.Common;

namespace VienHoa_Core.Entity
{
    public class NhienLieu : BaseEntity
    {
        public int LoaiNhienLieuId { get; set; }
        public virtual LoaiNhienLieu LoaiNhienLieu { get; set; }
        public int DonViDoTheoNamId { get; set; }
        public virtual DonViDoTheoNam DonViDoTheoNam { get; set; }
        public string TenNhienLieu { get; set; }
        public string TenHienThiTieuThu { get; set; }
        public double NhietTriRieng { get; set; }
        public virtual IEnumerable<NhienLieuSanPham> NhienLieuSanPhams { get; set; }
        public virtual IEnumerable<HeSoPhatThaiTuNhienLieu> HeSoPhatThaiTuNhienLieus { get; set; }
    }
}
