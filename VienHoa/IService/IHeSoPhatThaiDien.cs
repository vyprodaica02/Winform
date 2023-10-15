using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa.Entity;
using VienHoa.Service;

namespace VienHoa.IService
{
    public interface IHeSoPhatThaiDien
    {
        Task<List<HeSoPhatThaiDien>> GetAllAsync();
        Task<ServiceResult> AddAsync(HeSoPhatThaiDien heSoPhatThaiDien);
        Task<ServiceResult> UpdateAsync(HeSoPhatThaiDien heSoPhatThaiDien);
        Task<bool> DeleteAsync(HeSoPhatThaiDien heSoPhatThaiDien);
    }
}
