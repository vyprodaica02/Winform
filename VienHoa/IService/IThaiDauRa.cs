using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa.Entity;

namespace VienHoa.IService
{
    public interface IThaiDauRa
    {
        Task<IQueryable<ThaiDauRa>> GetAllThaiDauRa();
        Task<ServiceResult2> Create(ThaiDauRa thaiDauRa);
        Task<ServiceResult2> Update(ThaiDauRa thaiDauRa);
        Task<ServiceResult2> Delete(int id);
        Task<List<ThaiDauRa>> GetThaiDauRaByLcaId(int lcaId);
        Task<ThaiDauRa> GetThaiDauRaByChatThaiId(int chatThaiId);
        Task<List<ThaiDauRa>> GetThaiDauRaByDonViSPId(int dvId);
        Task<ThaiDauRa> GetThaiDauRaByDVIdandChatThaiId(int chatThaiId, int dvId);
        Task<ThaiDauRa> GetThaiDauRaByDVIdandChatThaiIdandSPId(int chatThaiId, int dvId, int spId);

        Task<ThaiDauRa> GetThaiDauRaByLCAIdandChatThaiIdandSPId(int chatThaiId, int lcaId, int spId);
        Task<List<ThaiDauRa>> GetThaiDauRaBySPId(int sanPhamId);
        Task<bool> AddRangeOrUpdateThaiDauRa(List<ThaiDauRa> lstThaiDauRa);
        Task<List<ThaiDauRa>> GetAll();
    }
}
