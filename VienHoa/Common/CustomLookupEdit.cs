using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VienHoa.Common
{
    public class CustomLookupEdit
    {
        [Browsable(false)]
        public int Id { get; set; }
        [DisplayName("Đơn vị sản phẩm")]
        public string Ten { get; set; }
    }
}
