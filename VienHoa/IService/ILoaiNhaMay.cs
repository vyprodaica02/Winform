using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa.Entity;

namespace VienHoa.IService
{
    public interface ILoaiNhaMay
    {
        public Task<IQueryable<LoaiNhaMay>> GetAll();
        public Task AddAsync(LoaiNhaMay entity);
    }
}
