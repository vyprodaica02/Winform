using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa.Entity;

namespace VienHoa.IService
{
    public interface IChiSoKhac
    {
        //
        public Task KetQuaSuDungNLTaiTao(List<NhienLieuSanPham> nlsp, int spId, int lcaId);
        public Task KetQuaSuDungNLTaiTao_Import(List<NhienLieuSanPham> nlsp);
        public Task KetQuaSuDungNLKoTaiTao(List<NhienLieuSanPham> nlsp, int spId, int lcaId);
        public Task KetQuaSuDungNLKoTaiTao_Import(List<NhienLieuSanPham> nlsp);
        public Task SuDungPTuNLThayThe(List<NhienLieuSanPham> nlsp, int spId, int lcaId);
        public Task SuDungPTuNLThayThe_Import(List<NhienLieuSanPham> nlsp);
        public Task KetQuaSDNuoc(List<NhienLieuSanPham> nlsp, int spId, int lcaId);
        public Task KetQuaSDNuoc_Import(List<NhienLieuSanPham> nlsp);
        public Task KetQuaTaoNL(List<NhienLieuSanPham> nlsp, int spId, int lcaId);
        public Task KetQuaTaoNL_Import(List<NhienLieuSanPham> nlsp);
    }
}