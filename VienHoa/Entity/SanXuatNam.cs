using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienHoa.Common;

namespace VienHoa.Entity
{
    public class SanXuatNam : BaseEntity
    {
        public int SanPhamId { get; set; }
        public virtual SanPham SanPham { get; set; }
        public int NhaMayId { get; set; }
        public virtual NhaMay NhaMay { get; set; }
        public int NamSanXuat { get; set; }
        public double DBKK_TieuThuNhienLieu { get; set; }
        public double DBKK_TieuThuDienNang { get; set; }
        public double DBKK_SanXuatDienNang { get; set; }
        public double DBKK_TieuThuNguyenLieu { get; set; }
        public double SLSP_SanLuongSanPham { get; set; }
        public double SLSP_LuongMuaVao { get; set; }
        public double SLSP_LuongBanRa { get; set; }
        public double SLSP_LuongLuuKho { get; set; }
        public double TTDN_TongLuongDien { get; set; }
        public double TTDN_TongLuongSX { get; set; }
        public double TTDN_TongLuongSH { get; set; }
        public double TTDN_TongLuongTuSX { get; set; }
        public virtual IEnumerable<NguyenLieuNam> NguyenLieuNams { get; set; }
    }
}
