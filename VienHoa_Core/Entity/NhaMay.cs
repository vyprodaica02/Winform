using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa_Core.Common;

namespace VienHoa_Core.Entity
{
    public class NhaMay : BaseEntity
    {
        public int DoanhNghiepId { get; set; }
        public virtual DoanhNghiep DoanhNghiep { get; set; }
        public  int LoaiNhaMayId { get; set; }
        public virtual LoaiNhaMay LoaiNhaMay { get; set; }
        public int LoaiLoNungId { get; set; }
        public virtual LoaiLoNung LoaiLoNung  { get; set; }
        public int CongSuatThietKeId { get; set; }
        // public virtual CongSuatThietKe {get;set;}
        public string TenNhaMay { get; set; }
        public double TiLeCoPhan { get; set; }
        public string ViTri  { get; set; }
        public virtual IEnumerable<SanPham> SanPhams { get; set; }
        public virtual IEnumerable<LoNungTrongNhaMay> LoNungTrongNhaMays { get; set; }
        public virtual IEnumerable<TieuThuNhienLieuLoNam> TieuThuNhienLieuLoNams { get; set; }

    }
}
