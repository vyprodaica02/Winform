using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa.Entity;

namespace VienHoa.IService
{
    public interface ITinhThaiDauRa
    {
        //
        public Task KetQuaPhuDuong(List<ThaiDauRa> dssanphamtdr, int spId, int lcaId);
        public Task KetQuaPhuDuong_Import(List<ThaiDauRa> dssanphamtdr);
        public Task KetQuaOzonHoa(List<ThaiDauRa> dssanphamtdr, int spId, int lcaId);
        public Task KetQuaOzonHoa_Import(List<ThaiDauRa> dssanphamtdr);
        public Task KetQuaPhaHuyOzon(List<ThaiDauRa> dssanphamtdr, int spId, int lcaId);
        public Task KetQuaPhaHuyOzon_Import(List<ThaiDauRa> dssanphamtdr);
        public Task GetChatThaiNguyHai(List<ThaiDauRa> dssanphamtdr, int spId, int lcaId);
        public Task GetChatThaiNguyHai_Import(List<ThaiDauRa> dssanphamtdr);
        public Task GetChatThai(List<ThaiDauRa> dssanphamtdr, int spId, int lcaId);
        public Task GetChatThai_Import(List<ThaiDauRa> dssanphamtdr);
        public Task KetQuaPhatSinhBui(List<ThaiDauRa> dssanphamtdr, int spId, int lcaId);
        public Task KetQuaPhatSinhBui_Import(List<ThaiDauRa> dssanphamtdr);
    }
}