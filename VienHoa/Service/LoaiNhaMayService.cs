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
    public class LoaiNhaMayService : ILoaiNhaMay
    {
        public readonly IRepository<LoaiNhaMay> _repos;
        public LoaiNhaMayService()
        {
            _repos = new ExRepository<LoaiNhaMay>();
        }

        public async Task AddAsync(LoaiNhaMay entity)
        {
            if (!_repos.DbSet().Any(x => x.TenLoai == entity.TenLoai))
            {
                await _repos.AddAsync(entity);
                XtraMessageBox.Show(ErrorInfo.ThaoTacThanhCong, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                XtraMessageBox.Show(ErrorInfo.DoiTuongCanThemBiTrung, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task<IQueryable<LoaiNhaMay>> GetAll()
        {
            return _repos.Table;
        }
    }
}
