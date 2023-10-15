using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa.Entity;

namespace VienHoa.IService
{
    public interface IChatThai
    {
        Task<IQueryable<ChatThai>> GetAllChatThai();
        Task<List<LoaiChatThai>> GetListLoaiChatThai();
        Task<ServiceResult2> Create(ChatThai chatThai);
        Task<ServiceResult2> Update(ChatThai chatThai);
        Task<ServiceResult2> Delete(int id);
        Task<List<ChatThai>> GetChatThaiByLoaiChatThaiId(int loaiChatThaiId);

    }
}
