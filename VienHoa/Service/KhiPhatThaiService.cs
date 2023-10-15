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
    public class KhiPhatThaiService : IKhiPhatThai
    {
        private readonly AppDbContext dbContext;

        public KhiPhatThaiService()
        {
            dbContext = new AppDbContext();
        }
        public async Task<ServiceResult> AddAsync(KhiPhatThai khiPhatThai)
        {
            try
            {
                if (dbContext.khiPhatThais.Any(x => x.TenKhi == khiPhatThai.TenKhi))
                {
                    throw new Exception("Khí phát thải đã tồn tại");
                }
                dbContext.Add(khiPhatThai);
                await dbContext.SaveChangesAsync();
                return ServiceResult.Success("Thêm thành công!");
            }
            catch (Exception ex)
            {
                return ServiceResult.Failed(ex.Message);
            }
        }

        public Task<bool> DeleteAsync(KhiPhatThai khiPhatThai)
        {
            throw new NotImplementedException();
        }

        public Task<List<KhiPhatThai>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> UpdateAsync(KhiPhatThai khiPhatThai)
        {
            throw new NotImplementedException();
        }
    }
}
