using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa_Core.Common;

namespace VienHoa_Core.Entity
{
    public class DoanhNghiep : BaseEntity
    {
        public string TenCongTy { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string NguoiLienHe { get; set; }
        public virtual IEnumerable<DuAn> DuAns { get; set; }
        public virtual IEnumerable<NhaMay> NhaMays { get; set; }
    }
}
