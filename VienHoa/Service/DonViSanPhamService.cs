using DevExpress.Xpo;
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
    public class DonViSanPhamService : IDonViSanPham
    {

        public readonly IRepository<DonViSanPham> _repository;

        public DonViSanPhamService()
        {
            _repository = new ExRepository<DonViSanPham>();
        }
        public async Task<List<DonViSanPham>> GetAllDonViSanPham()
        {
            var query = _repository.TableUntracked;
            return query.ToList();
        }

        public async Task<DonViSanPham> GetDonViSPById(int dvId)
        {
            var query = await _repository.TableUntracked.FirstOrDefaultAsync(x => x.Id == dvId);
            return query;
        }

    }
}
