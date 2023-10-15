using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa.Common;

namespace VienHoa.Entity
{
    public class NguyenLieuNam : BaseEntity
    {
        public int SanXuatNamId { get; set; }
        public virtual SanXuatNam SanXuatNam { get; set; }
        public double SoLuong { get; set; }
    }
}
