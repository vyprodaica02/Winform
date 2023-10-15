using DevExpress.DataProcessing.InMemoryDataProcessor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using VienHoa.DataEx;
using VienHoa.Entity;
using VienHoa.IService;

namespace VienHoa.Service
{
    public class GayNongLenToanCauService : IGayNongLenToanCau
    {
        private readonly AppDbContext dbContext;

        public GayNongLenToanCauService()
        {
            dbContext = new AppDbContext();
        }

        public async Task<bool> DeleteAsync(GayNongLenToanCau gayNongLenToanCau)
        {
            try
            {
                if (!dbContext.gayNongLenToanCaus.Any(x => x.Id == gayNongLenToanCau.Id))
                {
                    return false;
                }
                dbContext.Remove(gayNongLenToanCau);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<GayNongLenToanCau>> GetAllAsync()
        {
            try
            {
                return await dbContext.gayNongLenToanCaus.Include(x => x.KhiPhatThai).ToListAsync().ConfigureAwait(false);
            }
            catch
            {
                return null;
            }
        }

        public async Task<ServiceResult> UpdateAsync(GayNongLenToanCau gayNongLenToanCau)
        {
            try
            {
                if (!dbContext.khiPhatThais.Any(x => x.Id == gayNongLenToanCau.KhiPhatThaiId))
                {
                    throw new Exception("Khí phát thải không tồn tại.");
                }
                if (!dbContext.gayNongLenToanCaus.Any(x => x.Id == gayNongLenToanCau.Id))
                {
                    throw new Exception("Hệ số phát thải điện không tồn tại.");
                }
                dbContext.Update(gayNongLenToanCau);
                await dbContext.SaveChangesAsync();
                return ServiceResult.Success("Sửa gây nóng lên toàn cầu thành công.");
            }
            catch
            {
                return ServiceResult.Failed("Sửa gây nóng lên toàn cầu thất bại.");
            }
        }

        public async Task<ServiceResult> AddAsync(GayNongLenToanCau gayNongLenToanCau)
        {
            try
            {
                if(!dbContext.khiPhatThais.Any(x => x.Id == gayNongLenToanCau.KhiPhatThaiId))
                {
                    throw new Exception("Khí phát thải không tồn tại.");
                }
                dbContext.Add(gayNongLenToanCau);
                await dbContext.SaveChangesAsync();
                return ServiceResult.Success("Thêm gây nóng lên toàn cầu thành công.");
            }
            catch (Exception ex)
            {
                return ServiceResult.Failed(ex.Message);
            }
        }

        public async Task<List<KhiPhatThai>> ListKhiPhatThai()
        {
            try
            {
                return await dbContext.khiPhatThais.ToListAsync().ConfigureAwait(false);
            }
            catch
            {
                return null;
            }
        }
    }
}
