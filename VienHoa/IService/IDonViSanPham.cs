using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa.Entity;

namespace VienHoa.IService
{
    public interface IDonViSanPham
    {
        Task<List<DonViSanPham>> GetAllDonViSanPham();
        Task<DonViSanPham> GetDonViSPById(int dvId);

    }
}
