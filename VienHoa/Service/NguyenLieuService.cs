using DevExpress.Office.Tsp;
using DevExpress.XtraRichEdit.Import.OpenDocument;
using DevExpress.XtraSpreadsheet.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using VienHoa.Common;
using VienHoa.DataEx;
using VienHoa.Entity;
using VienHoa.Enums;
using VienHoa.IService;

namespace VienHoa.Service
{
    public class NguyenLieuService : INguyenLieu
    {  
        private readonly IRepository<NguyenLieu> _repository;
        public NguyenLieuService()
        {
            _repository = new ExRepository<NguyenLieu>();
        }
        public async Task<List<NguyenLieu>> GetAllNguyenLieu()
        {

            return _repository.TableUntracked.Include(x => x.LoaiNguyenLieu).Include(x => x.DonViDoTheoNam).ToList();
        }

        public async Task<List<EnumNguyenLieu>> SuaNguyenLieu(int nguyenLieuId, NguyenLieu nguyenLieu)
        {
            List<EnumNguyenLieu> listError = new List<EnumNguyenLieu>();
            var nguyenlieuct = await _repository.GetByIdAsync(nguyenLieuId);
            if(nguyenlieuct != null)
            {
                nguyenlieuct.TenNguyenLieu = nguyenLieu.TenNguyenLieu;
                nguyenlieuct.LoaiNguyenLieuId = nguyenLieu.LoaiNguyenLieuId;
                nguyenlieuct.DonViDoTheoNamId = nguyenLieu.DonViDoTheoNamId;
                nguyenlieuct.TenHienThiTieuThu = nguyenLieu.TenHienThiTieuThu;
               
                var listNL = ValidateNL(nguyenlieuct);
                if (listNL.Count() == 0)
                {
                    return listNL;
                }
                listError = listNL;
            }
            return listError;

        }

        public async Task< List<EnumNguyenLieu>> ThemNguyenLieu(NguyenLieu nguyenLieu)
        {  
           var listNL = ValidateNL(nguyenLieu);
            if(listNL.Count() == 0)
            {
                return listNL;
            }
            else
            {
                return listNL;
            }
        }
        private List<EnumNguyenLieu> ValidateNL(NguyenLieu nguyenLieu)
        {
            List<EnumNguyenLieu> listError = new List<EnumNguyenLieu>();
            if (string.IsNullOrEmpty(nguyenLieu.TenNguyenLieu))
            {
                 listError.Add(EnumNguyenLieu.TrongTenNL);
            }
            if (string.IsNullOrEmpty(nguyenLieu.TenHienThiTieuThu))
            {
                listError.Add(EnumNguyenLieu.TrongTenHT);
            }
            if (nguyenLieu.LoaiNguyenLieuId == 0)
            {
                listError.Add(EnumNguyenLieu.TrongLoaiNL);
            }
            if (nguyenLieu.DonViDoTheoNamId == 0)
            {
                listError.Add(EnumNguyenLieu.TrongHTTN);
            }         
            return listError;
        }
        public async Task XoaNguyenLieu(int nguyenLieuId)
        {
            var nguyenlieuct = await _repository.GetByIdAsync(nguyenLieuId);
            await _repository.DeleteAsync(nguyenlieuct);
        }
        public async Task<List<NguyenLieu>> TimTenNguyenLieu(string tenNL)
        {
           return _repository.Table.Where(x=>x.TenNguyenLieu.ToLower().Contains(tenNL.ToLower())).ToList();
        }

        public async Task<List<NguyenLieu>> GetNguyenLieuByLoaiNguyenLieuId(int loaiNguyenLieuId)
        {
            return _repository.TableUntracked.Where(x => x.LoaiNguyenLieuId == loaiNguyenLieuId).ToList();
        }
    }
}
