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
    public class LoaiNguyenLieuService : ILoaiNguyenLieu
    {
        private readonly IRepository<LoaiNguyenLieu> _loaiNguyenLieuRepo;

        public LoaiNguyenLieuService()
        {
            _loaiNguyenLieuRepo = new ExRepository<LoaiNguyenLieu>();

        }
        public async Task<List<LoaiNguyenLieu>> GetAllLoaiNguyenLieu()
        {
            return _loaiNguyenLieuRepo.TableUntracked.ToList();
        }
        public async Task ThemLoaiNguyenLieu(LoaiNguyenLieu loaiNguyenLieu)
        {
            await _loaiNguyenLieuRepo.AddAsync(loaiNguyenLieu);
        }
    }
}
