using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VienHoa.Dtos
{
    public class ItemKhiPhatThai
    {
        public int Id { get; set; }
        public string TenKhi { get; set; }

        public override string ToString()
        {
            return TenKhi;
        }
    }
}
