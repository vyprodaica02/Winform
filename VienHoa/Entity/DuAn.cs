using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa.Common;

namespace VienHoa.Entity
{
    public class DuAn : BaseEntity
    {
        public int DoanhNghiepId { get; set; }
        public virtual DoanhNghiep DoanhNghiep { get; set; }
        public string TenDuAn { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
    }
}
