using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa.Common;

namespace VienHoa.Entity
{
    public class ChatThai : BaseEntity
    {
        public int LoaiChatThaiId { get; set; }
        public virtual LoaiChatThai LoaiChatThai { get; set;}
        public string TenChatThai { get; set; }
        public virtual IEnumerable<ThaiDauRa> ThaiDauRas { get; set; }
    }
}
