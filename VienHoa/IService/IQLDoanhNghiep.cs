using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa.Entity;
using VienHoa.Enums;

namespace VienHoa.IService
{
    public interface IQLDoanhNghiep
    {
        Task<IQueryable<DoanhNghiep>> GetAllDoanhNghiep();
        public Task<InputHellperDoanhNghiep> AddDoanhNgiep(DoanhNghiep doanhNghiep);
        public Task<InputHellperDoanhNghiep> UpdateDoanhNghiep(DoanhNghiep doanhNghiep);
        public Task<DoanhNghiep> GetId(int id);
        Task<InputHellperDoanhNghiep> DeleteDoanhNghiep(DoanhNghiep doanhNghiep);
        Task<InputHellperDoanhNghiep> ListDeleteDoanhNghiep(IEnumerable<DoanhNghiep> list);
    }
}
