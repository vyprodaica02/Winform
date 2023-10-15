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
    public class LoaiLoNungService : ILoaiLoNung
    {
        public readonly IRepository<LoaiLoNung> _repository;
        public LoaiLoNungService()
        {
            _repository = new ExRepository<LoaiLoNung>();
        }

        public async Task AddAsync(LoaiLoNung item)
        {
            if (!_repository.DbSet().Any(x => x.TenLoaiLo == item.TenLoaiLo)) 
            {
                await _repository.AddAsync(item);
                XtraMessageBox.Show(ErrorInfo.ThaoTacThanhCong, "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                XtraMessageBox.Show(ErrorInfo.DoiTuongCanThemBiTrung, "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task<IQueryable<Entity.LoaiLoNung>> GetAllData()
        {
            return _repository.Table;
        }
    }
}
