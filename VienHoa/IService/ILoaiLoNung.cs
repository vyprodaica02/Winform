using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa.Entity;

namespace VienHoa.IService
{
    public interface ILoaiLoNung
    {
        public Task<IQueryable<LoaiLoNung>> GetAllData();
        public Task AddAsync(LoaiLoNung item);
    }
}
