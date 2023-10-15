using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa_Core.Common;

namespace VienHoa_Core.Entity
{
    public class NhienLieuSanPham : BaseEntity
    {
        public int SanPhamId { get; set; }
        public virtual SanPham SanPham { get; set; }
        public int NhienLieuId { get; set; }
        public virtual NhienLieu NhienLieu { get; set; }
        public int DonViId { get; set; }
        // public virtual DonVi DonVi {get;set;}
        public double SoLuong { get; set; }

    }
}
