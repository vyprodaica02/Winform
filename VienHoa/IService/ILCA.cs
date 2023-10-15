using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa.Entity;

namespace VienHoa.IService
{
    public interface ILCA
    {
        Task<List<LCA>> GetAllLCA();
        Task<LCA> GetLCAByKyHieu(string KH);
        Task<LCA> GetLCAById(int lcaId);
    }
}
