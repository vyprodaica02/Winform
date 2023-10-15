using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VienHoa.Common;
using VienHoa.DataEx;
using VienHoa.Entity;
using VienHoa.IService;

namespace VienHoa.Service
{
    internal class LoaiChatThaiServices : ILoaiChatThai
    {
        public readonly IRepository<LoaiChatThai> _repository;

        public LoaiChatThaiServices()
        {
            _repository = new ExRepository<LoaiChatThai>();
        }
        
        public async Task<ServiceResult2> Create(LoaiChatThai loaiChatThai)
        {
            try
            {
                await _repository.AddAsync(loaiChatThai);
                return ServiceResult2.Success("Thêm thành công!");
            }
            catch
            {
                return ServiceResult2.Failed("Thêm thất bại!");
            }

        }

        public async Task<ServiceResult2> Delete(int id)
        {
            LoaiChatThai loaiChatThai = await _repository.GetByIdAsync(id);
            if(loaiChatThai != null)
            {
                await _repository.DeleteAsync(loaiChatThai);
                return ServiceResult2.Success("Xóa thành công!");
            }
            return ServiceResult2.Failed("Xóa thất bại, không tìm thấy dữ liệu!");
        }

        public async Task<IQueryable<LoaiChatThai>> GetAllLoaiChatThai()
        {
            return _repository.TableUntracked;
        }

        public async Task<ServiceResult2> Update(LoaiChatThai loaiChatThai)
        {
            LoaiChatThai loaiChatThaiUpdate = await _repository.GetByIdAsync(loaiChatThai.Id);
            if( loaiChatThaiUpdate != null)
            {
                loaiChatThaiUpdate.TenLoaiChatThai = loaiChatThai.TenLoaiChatThai;
                await _repository.UpdateAsync(loaiChatThaiUpdate);
                return ServiceResult2.Success("Sửa thành công!");
            }
            return ServiceResult2.Failed("Sửa thất bại!");
        }
        public async Task<List<LoaiChatThai>> GetAll()
        {
            return _repository.TableUntracked.ToList();
        }
    }
}
