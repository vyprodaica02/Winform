using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VienHoa.Common;
using VienHoa.DataEx;
using VienHoa.Entity;
using VienHoa.EnumNhaMay;
using VienHoa.IService;

namespace VienHoa.Service
{
    public class CongSuatThietKeService : ICongSuatThietKe
    {
        private IRepository<CongSuatThietKe> Repository;

        public CongSuatThietKeService()
        {
            Repository = new ExRepository<CongSuatThietKe>();
        }
        public async Task AddAsync(Entity.CongSuatThietKe item)
        {
            if (!Repository.DbSet().Any(x => x.CongSuatDinhMuc == item.CongSuatDinhMuc))
            {
                await Repository.AddAsync(item);
                XtraMessageBox.Show(ErrorInfo.ThaoTacThanhCong, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                XtraMessageBox.Show(ErrorInfo.DoiTuongCanThemBiTrung, "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task<IQueryable> GetAllData()
        {
            return Repository.Table;
        }
    }
}
