using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa.Entity;

namespace VienHoa.IService
{
    public interface IAxitHoa
    {
        public Task AxitHoaTinhToan(List<ThaiDauRa> dssanphamtdr, int spId, int lcaId);
        public Task KetQuaAxitHoa(List<ThaiDauRa> dssanphamtdr);
    }
}
