using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa_Core.Common;
using VienHoa_Core.DataEx;
using VienHoa_Core.Entity;
using VienHoa_Core.IService;

namespace VienHoa_Core.Service
{
    public class DoanhNghiepService : IDoanhNghiep
    {
        public readonly IRepository<DoanhNghiep> _repository;

        public DoanhNghiepService()
        {
            _repository = new ExRepository<DoanhNghiep>();
        }

        public async Task<IQueryable<DoanhNghiep>> GetAllDoanhNghiep()
        {
            return _repository.TableUntracked;
        }
    }
}
