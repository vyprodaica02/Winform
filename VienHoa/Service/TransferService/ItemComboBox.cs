using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VienHoa.Service.TransferService
{
    public class ItemComboBox
    {
        public int Id { get; set; }
        public double CongSuatTK { get; set; }
        public override string ToString()
        {
            return CongSuatTK.ToString();
        }
    }
}
