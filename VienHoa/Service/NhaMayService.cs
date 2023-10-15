using DevExpress.XtraEditors.Filtering;
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
    public class NhaMayService : INhaMay
    {
        private readonly IRepository<NhaMay> Repository;

        public double TLCP { get; set; }
        public NhaMayService()
        {
            Repository = new ExRepository<NhaMay>();
        }
        public async Task<IQueryable<NhaMay>> GetAllData()
        {
            return Repository.Table;
        }

        public async Task<EnumType> AddObject(NhaMay obj)
        {
            // Validation:
            if (ValidateString(obj.TenNhaMay) == EnumType.ThaoTacThanhCong && ValidateString(obj.ViTri) == EnumType.ThaoTacThanhCong)
            {
              // Check doi tuong da co trong bang hay chua
               if (!Repository.DbSet().Any(x => x.TenNhaMay == obj.TenNhaMay))
                { await Repository.AddAsync(obj); return EnumType.ThaoTacThanhCong; }
                else return EnumType.DoiTuongCanThemBiTrung;
            }
            else if (ValidateString(obj.TenNhaMay) == EnumType.TenNhaMayTrong) return EnumType.TenNhaMayTrong;
            else if (ValidateString(obj.TenNhaMay) == EnumType.TenNhaMayQuaDai) return EnumType.TenNhaMayQuaDai;
            else if (ValidateString(obj.ViTri) == EnumType.ViTriNhaMayTrong) return EnumType.ViTriNhaMayTrong;
            else return EnumType.RutGonLaiDiaChiNhaMay;
        }

        public async Task<EnumType> DeleteObject(int Id)
        {
            if (await GetObjectById(Id) != null)
            {
                var obj = await GetObjectById(Id);
                Repository.Delete(obj);
                return EnumType.ThaoTacThanhCong;
            }
            else return EnumType.DoiTuongKhongCoTrongDanhSach;
        }

        public async Task<NhaMay> GetObjectById(int Id)
        {
            return await Repository.GetByIdAsync(Id);
        }

        public async Task<EnumType> UpdateObj(NhaMay obj)
        {
            // Validation:
            if (ValidateString(obj.TenNhaMay) == EnumType.ThaoTacThanhCong && ValidateString(obj.ViTri) == EnumType.ThaoTacThanhCong)
            {
                if (ValidateDouble(obj.TiLeCoPhan.ToString()))
                {
                    await Repository.UpdateAsync(obj);
                    return EnumType.ThaoTacThanhCong;
                }
                else return EnumType.TyLeCoPhanPhaiLaSoThuc;
            }
            else if (ValidateString(obj.TenNhaMay) == EnumType.TenNhaMayTrong) return EnumType.TenNhaMayTrong;
            else if (ValidateString(obj.TenNhaMay) == EnumType.TenNhaMayQuaDai) return EnumType.TenNhaMayQuaDai;
            else if (ValidateString(obj.ViTri) == EnumType.ViTriNhaMayTrong) return EnumType.ViTriNhaMayTrong;
            else return EnumType.RutGonLaiDiaChiNhaMay;
        }

        #region valid
        private EnumType ValidateString(string str)
        {
            if (str.Length == 0) return EnumType.TenNhaMayTrong;
            else if (str.Length > 150) return EnumType.TenNhaMayQuaDai;
            else return EnumType.ThaoTacThanhCong;
        }

        public bool ValidateDouble(string x)
        {
            double input;
            bool ok = double.TryParse(x, out input);
            if (!ok || input > 100)
            {
                TLCP = -1;
                return false;
            }
            else
            {
                TLCP = input;
                return true;
            }
        }
        #endregion
    }
}
