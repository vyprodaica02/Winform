using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa.Entity;

namespace VienHoa.IService
{
    public interface ILoaiChatThai
    {
        Task<IQueryable<LoaiChatThai>> GetAllLoaiChatThai();
        Task<ServiceResult2> Create(LoaiChatThai loaiChatThai);
        Task<ServiceResult2> Update(LoaiChatThai loaiChatThai);
        Task<ServiceResult2> Delete(int id);
        Task<List<LoaiChatThai>> GetAll();
    }
}
