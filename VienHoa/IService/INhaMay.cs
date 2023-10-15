using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa.Entity;
using VienHoa.Enums;

namespace VienHoa.IService
{
    public interface INhaMay
    {
        Task<IQueryable<NhaMay>> GetAllData();
        public Task<EnumType> AddObject(NhaMay obj);
        public Task<EnumType> DeleteObject(int Id);
        public Task<NhaMay> GetObjectById(int Id);
        public Task<EnumType> UpdateObj (NhaMay obj);
    }
}
