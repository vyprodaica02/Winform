using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa.DataEx;
using VienHoa.Entity;
using VienHoa.IService;

namespace VienHoa.Service
{
    public class HeSoPhatThaiDienService : IHeSoPhatThaiDien
    {
        private readonly AppDbContext dbContext;

        public HeSoPhatThaiDienService()
        {
            dbContext = new AppDbContext();
        }

        public async Task<ServiceResult> AddAsync(HeSoPhatThaiDien heSoPhatThaiDien)
        {
            try
            {
                if (!dbContext.khiPhatThais.Any(x => x.Id == heSoPhatThaiDien.KhiPhatThaiId))
                {
                    throw new Exception("Khí phát thải không tồn tại.");
                }
                dbContext.Add(heSoPhatThaiDien);
                await dbContext.SaveChangesAsync();
                return ServiceResult.Success("Thêm hệ số phát thải điện thành công.");
            }
            catch (Exception ex)
            {
                return ServiceResult.Failed(ex.Message);
            }
        }

        public async Task<bool> DeleteAsync(HeSoPhatThaiDien heSoPhatThaiDien)
        {
            try
            {
                if (!dbContext.heSoPhatThaiDiens.Any(x => x.Id == heSoPhatThaiDien.Id))
                {
                    return false;
                }
                dbContext.Remove(heSoPhatThaiDien);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<HeSoPhatThaiDien>> GetAllAsync()
        {
            try
            {
                return await dbContext.heSoPhatThaiDiens.Include(x => x.KhiPhatThai).ToListAsync().ConfigureAwait(false);
            }
            catch
            {
                return null;
            }
        }

        public async Task<ServiceResult> UpdateAsync(HeSoPhatThaiDien heSoPhatThaiDien)
        {
            try
            {
                if (!dbContext.khiPhatThais.Any(x => x.Id == heSoPhatThaiDien.KhiPhatThaiId))
                {
                    throw new Exception("Khí phát thải không tồn tại.");
                }
                if(!dbContext.heSoPhatThaiDiens.Any(x => x.Id == heSoPhatThaiDien.Id))
                {
                    throw new Exception("Hệ số phát thải điện không tồn tại.");
                }
                dbContext.Update(heSoPhatThaiDien);
                await dbContext.SaveChangesAsync();
                return ServiceResult.Success("Sửa hệ số phát thải điện thành công.");
            }
            catch(Exception ex)
            {
                return ServiceResult.Failed(ex.Message);
            }
        }
    }
}
