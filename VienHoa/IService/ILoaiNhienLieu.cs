using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa.Entity;

namespace VienHoa.IService
{
    public interface ILoaiNhienLieu
    {
        Task<List<LoaiNhienLieu>> GetAllLoaiNhienLieu();
        Task ThemLoaiNhienLieu(LoaiNhienLieu loaiNhienLieu);
    }
}
