using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa_Core.Common;

namespace VienHoa_Core.Entity
{
    public class LoaiChatThai : BaseEntity
    {
        public string TenLoaiChatThai { get; set; }
        public virtual IEnumerable<ChatThai> ChatThais { get; set; }
    }
}
