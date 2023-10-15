using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa.Common;
using VienHoa.DataEx;
using VienHoa.Entity;
using VienHoa.Enums;
using VienHoa.IService;

namespace VienHoa.Service
{
    public class QLDoanhNghiepServices : IQLDoanhNghiep
    {
        public readonly IRepository<DoanhNghiep> _repository;
        private readonly AppDbContext dbContext;
        public QLDoanhNghiepServices()
        {
            dbContext = new AppDbContext();
            _repository = new ExRepository<DoanhNghiep>();
        }

        public async Task<DoanhNghiep> GetId(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
        //Load
        public async Task<IQueryable<DoanhNghiep>> GetAllDoanhNghiep()
        {
            return _repository.TableUntracked;
        }
        //Thêm
        public async Task<InputHellperDoanhNghiep> AddDoanhNgiep(DoanhNghiep doanhNghiep)
        {
            if (doanhNghiep == null)
            {
                return InputHellperDoanhNghiep.thatBai;
            }
            if (string.IsNullOrEmpty(doanhNghiep.DiaChi) ||
                string.IsNullOrEmpty(doanhNghiep.TenCongTy) ||
                string.IsNullOrEmpty(doanhNghiep.DienThoai) ||
                string.IsNullOrEmpty(doanhNghiep.NguoiLienHe))
            {
                return InputHellperDoanhNghiep.thieuThongTin;
            }
            await _repository.AddAsync(doanhNghiep);
            return InputHellperDoanhNghiep.thanhCong;
        }

        //Update
        public async Task<InputHellperDoanhNghiep> UpdateDoanhNghiep(DoanhNghiep doanhNghiep)
        {
            if (doanhNghiep == null)
            {
                return InputHellperDoanhNghiep.thatBai;
            }
            if (string.IsNullOrEmpty(doanhNghiep.DiaChi) ||
                string.IsNullOrEmpty(doanhNghiep.TenCongTy) ||
                string.IsNullOrEmpty(doanhNghiep.DienThoai) ||
                string.IsNullOrEmpty(doanhNghiep.NguoiLienHe))
            {
                return InputHellperDoanhNghiep.thieuThongTin;
            }
            await _repository.UpdateAsync(doanhNghiep);

            return InputHellperDoanhNghiep.thanhCong;
        }
        //Xóa
        public async Task<InputHellperDoanhNghiep> DeleteDoanhNghiep(DoanhNghiep doanhNghiep)
        {
            if (await GetId(doanhNghiep.Id) != null)
            {
                var obj = await GetId(doanhNghiep.Id);
                await _repository.DeleteAsync(obj);
                return InputHellperDoanhNghiep.thanhCong;
            }
            return InputHellperDoanhNghiep.thatBai;
        }

        public async Task<InputHellperDoanhNghiep> ListDeleteDoanhNghiep(IEnumerable<DoanhNghiep> list)
        {
            if (list == null || !list.Any())
            {
                return InputHellperDoanhNghiep.thatBai; 
            }
            foreach (var doanhNghiep in list)
            {
                if (doanhNghiep == null)
                {
                    return InputHellperDoanhNghiep.thatBai; 
                }
            }
            await _repository.DeleteRangeAsync(list);
            return InputHellperDoanhNghiep.thanhCong; 
        }

    }
}
