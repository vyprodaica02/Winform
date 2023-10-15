using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa_Core.Entity;

namespace VienHoa_Core.IService
{
    public interface IDoanhNghiep
    {
        Task<IQueryable<DoanhNghiep>> GetAllDoanhNghiep();
    }
}
