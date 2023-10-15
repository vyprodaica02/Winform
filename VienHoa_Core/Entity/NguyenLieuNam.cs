using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa_Core.Common;

namespace VienHoa_Core.Entity
{
    public class NguyenLieuNam : BaseEntity
    {
        public int SanXuatNamId { get; set; }
        public virtual SanXuatNam SanXuatNam { get; set; }
        public double SoLuong { get; set; }
    }
}
