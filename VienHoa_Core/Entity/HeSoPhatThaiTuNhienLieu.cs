using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa_Core.Common;

namespace VienHoa_Core.Entity
{
    public class HeSoPhatThaiTuNhienLieu : BaseEntity
    {
        public int KhiPhatThaiId { get; set; }
        public virtual KhiPhatThai KhiPhatThai { get; set; }
        public int NhienLieuId { get; set; }
        public virtual NhienLieu NhienLieu { get; set; }
        public int DonViTinhId { get; set; }
        public double GiaTri { get; set; }
    }
}
