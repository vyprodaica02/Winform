using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa_Core.Common;

namespace VienHoa_Core.Entity
{
    public class SanPham : BaseEntity
    {
        public string TenSanPham { get; set; }
        public string KyHieu { get; set; }
        public string MaCode { get; set; }
        public string CongNghe { get; set; }
        public string CongSuatThietKe { get; set; }
        public int NhaMayId { get; set; }
        public virtual NhaMay NhaMay { get; set; }
        public int DuAnId { get; set; }
        public virtual DuAn DuAn { get; set; }
        public int LoaiLoNungId { get; set; }
        public virtual LoaiLoNung LoaiLoNung { get; set; }
        public virtual IEnumerable<SanXuatNam> SanXuatNams { get; set; }
        public virtual IEnumerable<ThaiDauRa> ThaiDauRas { get; set; }
        public virtual IEnumerable<NguyenLieuSanPham> NguyenLieuSanPhams { get; set; }
        public virtual IEnumerable<NhienLieuSanPham> NhienLieuSanPhams { get; set; }
        public virtual IEnumerable<RanhGioiLCA> RanhGioiLCAs { get; set; }
    }
}
