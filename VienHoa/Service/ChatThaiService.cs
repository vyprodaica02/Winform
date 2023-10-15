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
    public class ChatThaiService : IChatThai
    {
        private readonly IRepository<ChatThai> _chatThaiRepo;
        private readonly IRepository<LoaiChatThai> _loaiChatThaiRepo;
        private readonly AppDbContext _db;

        public ChatThaiService()
        {
            _chatThaiRepo = new ExRepository<ChatThai>();
            _loaiChatThaiRepo = new ExRepository<LoaiChatThai>();
            _db = new AppDbContext();
        }

        public async Task<ServiceResult2> Create(ChatThai chatThai)
        {
            try
            {
                await _chatThaiRepo.AddAsync(chatThai);
                return ServiceResult2.Success("Thêm dữ liệu thành công!");
            }
            catch
            {
                return ServiceResult2.Failed("Thêm dữ liệu thất bại!");
            }
        }

        public async Task<ServiceResult2> Delete(int id)
        {
            ChatThai ChatThai = await _chatThaiRepo.GetByIdAsync(id);
            if (ChatThai != null)
            {
                await _chatThaiRepo.DeleteAsync(ChatThai);
                return ServiceResult2.Success("Xóa thành công!");
            }
            return ServiceResult2.Failed("Xóa thất bại, không tìm thấy dữ liệu!");
        }

        public Task<IQueryable<ChatThai>> GetAllChatThai()
        {
            throw new NotImplementedException();
        }

        public  async Task<List<LoaiChatThai>> GetListLoaiChatThai()
        {
            
            try
            {
                return await _db.loaiChatThais.ToListAsync().ConfigureAwait(false);
            }
            catch
            {
                return null; 
            }
        }

        public async Task<ServiceResult2> Update(ChatThai chatThai)
        {
            try
            {

                using (var dbContext = new AppDbContext())
                {
                    dbContext.Entry(chatThai).State = EntityState.Modified;
                    await dbContext.SaveChangesAsync();
                    return ServiceResult2.Success("Sửa dữ liệu thành công!");
                }
            }
            catch(Exception ex)
            {
                return ServiceResult2.Failed(ex.Message);
            }
        }

        public async Task<List<ChatThai>> GetChatThaiByLoaiChatThaiId(int loaiChatThaiId)
        {
            List<ChatThai> lstChatThai = _chatThaiRepo.TableUntracked.Where(x => x.LoaiChatThaiId == loaiChatThaiId).ToList();
            return lstChatThai;
        }


    }
}
