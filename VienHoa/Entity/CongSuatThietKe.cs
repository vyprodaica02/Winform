using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa.Common;

namespace VienHoa.Entity
{
    public class CongSuatThietKe : BaseEntity
    {
        public double CongSuatDinhMuc { get; set; }
        public string DonViCongSuat { get; set; }
        public virtual IEnumerable<NhaMay> NhaMays { get; set; }
    }
}
