using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VienHoa.Entity;
using VienHoa.Service;

namespace VienHoa.IService
{
    public interface IGayNongLenToanCau
    {
        Task<List<KhiPhatThai>> ListKhiPhatThai();
        Task<List<GayNongLenToanCau>> GetAllAsync();
        Task<ServiceResult> AddAsync(GayNongLenToanCau gayNongLenToanCau);
        Task<ServiceResult> UpdateAsync(GayNongLenToanCau gayNongLenToanCau);
        Task<bool> DeleteAsync(GayNongLenToanCau gayNongLenToanCau);
    }
}
