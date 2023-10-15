using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa_Core.Common;

namespace VienHoa_Core.Entity
{
    public class ChatThai : BaseEntity
    {
        public int LoaiChatThaiId { get; set; }
        public virtual LoaiChatThai LoaiChatThai { get; set;}
        public string TenChatThai { get; set; }
        public virtual IEnumerable<ThaiDauRa> ThaiDauRas { get; set; }
    }
}
