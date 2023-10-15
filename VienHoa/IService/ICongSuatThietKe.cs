using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa.Entity;

namespace VienHoa.IService
{
    public interface ICongSuatThietKe
    {
        public Task<IQueryable> GetAllData();

        public Task AddAsync(CongSuatThietKe item);
    }
}
