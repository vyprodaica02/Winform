using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa.Entity;

namespace VienHoa.IService
{
    public interface IDuAn
    {
        Task<List<DuAn>> GetAllDuAn();
        Task<bool> AddDuAn(DuAn duAn);
        Task<bool> UpdateDuAn(DuAn duAn);
        Task<bool> DeleteDuAn(DuAn duAn);
    }
}
