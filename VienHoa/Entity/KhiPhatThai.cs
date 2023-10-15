using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa.Common;

namespace VienHoa.Entity
{
    public class KhiPhatThai : BaseEntity
    {
        public string TenKhi { get; set; }
        public virtual IEnumerable<HeSoPhatThaiTuNguyenLieu> HeSoPhatThaiTuNguyenLieus { get; set; }
        public virtual IEnumerable<HeSoPhatThaiTuNhienLieu> HeSoPhatThaiTuNhienLieus { get; set; }
        public virtual IEnumerable<GayNongLenToanCau> GayNongLenToanCaus { get; set; }
        public virtual IEnumerable<HeSoPhatThaiDien> HeSoPhatThaiDiens { get; set; }



    }
}
