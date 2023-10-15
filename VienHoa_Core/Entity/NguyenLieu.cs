using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa_Core.Common;

namespace VienHoa_Core.Entity
{
    public class NguyenLieu : BaseEntity
    {
        public int LoaiNguyenLieuId { get; set; }
        public virtual LoaiNguyenLieu LoaiNguyenLieu { get; set; }
        public int DonViDoTheoNamId { get; set; }
        public virtual DonViDoTheoNam DonViDoTheoNam { get; set; }
        public string TenNguyenLieu { get; set; }
        public string TenHienThiTieuThu { get; set; }
        public virtual IEnumerable<NguyenLieuSanPham> NguyenLieuSanPhams { get; set; }
        public virtual IEnumerable<HeSoPhatThaiTuNguyenLieu> HeSoPhatThaiTuNguyenLieus { get; set; }

    }
}
