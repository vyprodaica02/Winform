using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa.Common;
using VienHoa.DataEx;
using VienHoa.Entity;
using VienHoa.IService;

namespace VienHoa.Service
{
    public class LCAService : ILCA
    {

        public readonly IRepository<LCA> _repository;

        public LCAService()
        {
            _repository = new ExRepository<LCA>();
        }
        public async Task<List<LCA>> GetAllLCA()
        {
            var query = _repository.TableUntracked.OrderBy(x => x.ThuTu);
            return query.ToList();
        }
        public async Task<LCA> GetLCAByKyHieu(string KH)
        {
            var query = await _repository.TableUntracked.SingleOrDefaultAsync(x => x.KyHieu == KH);
            return query;
        }

        public async Task<LCA> GetLCAById(int lcaId)
        {
            var query = await _repository.TableUntracked.SingleOrDefaultAsync(x => x.Id == lcaId);
            return query;
        }
    }
}
