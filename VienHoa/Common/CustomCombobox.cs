using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VienHoa.Common
{
    public class CustomCombobox
    {
        public int Id { get; set; }
        public string Ten { get; set; }

        public override string ToString()
        {
            return Ten;
        }
    }
}
