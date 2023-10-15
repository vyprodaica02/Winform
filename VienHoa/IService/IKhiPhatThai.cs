using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa.Entity;
using VienHoa.Service;

namespace VienHoa.IService
{
    public interface IKhiPhatThai
    {
        Task<List<KhiPhatThai>> GetAllAsync();
        Task<ServiceResult> AddAsync(KhiPhatThai khiPhatThai);
        Task<ServiceResult> UpdateAsync(KhiPhatThai khiPhatThai);
        Task<bool> DeleteAsync(KhiPhatThai khiPhatThai);
    }
}
