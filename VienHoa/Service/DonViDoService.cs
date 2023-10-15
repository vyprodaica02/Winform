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
    public class DonViDoService : IDonViDo
    {
        private readonly IRepository<DonViDoTheoNam> _repository;
        public DonViDoService()
        {
            _repository = new ExRepository<DonViDoTheoNam>();
        }
        public async Task ThemDonViDo(DonViDoTheoNam donViDoTheoNam)
        {
            await _repository.AddAsync(donViDoTheoNam);
        }
    }
}
