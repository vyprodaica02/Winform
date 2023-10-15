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

    public class LoaiNhienLieuService : ILoaiNhienLieu
    {
        private readonly IRepository<LoaiNhienLieu> _loaiNhienLieuRepo;

        public LoaiNhienLieuService()
        {
            _loaiNhienLieuRepo = new ExRepository<LoaiNhienLieu>();

        }

        public async Task<List<LoaiNhienLieu>> GetAllLoaiNhienLieu()
        {
            return _loaiNhienLieuRepo.TableUntracked.ToList();
        }
        public async Task ThemLoaiNhienLieu(LoaiNhienLieu loaiNhienLieu)
        {
            await _loaiNhienLieuRepo.AddAsync(loaiNhienLieu);
        }
    }
}
