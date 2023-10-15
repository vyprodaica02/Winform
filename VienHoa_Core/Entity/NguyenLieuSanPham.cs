using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa_Core.Common;

namespace VienHoa_Core.Entity
{
    public class NguyenLieuSanPham : BaseEntity
    {
        public int SanPhamId { get; set; }
        public virtual SanPham SanPham { get; set; }
        public int NguyenLieuId { get; set; }
        public virtual NguyenLieu NguyenLieu { get; set; }
        public int DonViId { get; set; }
        // public virtual DonVi DonVi {get;set;}
        public double SoLuong { get; set; }
    }
}
