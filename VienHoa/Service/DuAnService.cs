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
    public class DuAnService : IDuAn
    {
        public readonly IRepository<DuAn> _repository;

        public DuAnService()
        {
            _repository = new ExRepository<DuAn>();
        }

        public async Task<bool> AddDuAn(DuAn duAn)
        {
            bool check = ValidateDA(duAn);

            if (check)
            {
                await _repository.AddAsync(duAn);
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteDuAn(DuAn duAn)
        {
            await _repository.DeleteAsync(duAn);
            return true;
        }

        public async Task<List<DuAn>> GetAllDuAn()
        {
            var query = _repository.TableUntracked.Include(x => x.DoanhNghiep);
            return query.ToList();
        }

        public async Task<bool> UpdateDuAn(DuAn duAn)
        {
            bool check = ValidateDA(duAn);
            if (check)
            {
                await _repository.UpdateAsync(duAn);
                return true;
            }
            return false;
        }

        private bool ValidateDA(DuAn duAn)
        {
            if (string.IsNullOrEmpty(duAn.TenDuAn))
            {
                return false;
            }
            else if (duAn.NgayBatDau == null)
            {
                return false;
            }
            else if (duAn.NgayKetThuc == null)
            {
                return false;
            }
            else if (duAn.DoanhNghiepId == 0)
            {
                return false;
            }
           

            return true;
        }
    }
}
