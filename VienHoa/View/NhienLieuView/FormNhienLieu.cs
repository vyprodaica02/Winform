using DevExpress.XtraEditors;
using DevExpress.XtraPivotGrid.Design;
using DevExpress.XtraSpreadsheet.Commands;
using DevExpress.XtraSpreadsheet.Export;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using VienHoa.Common;
using VienHoa.DataEx;
using VienHoa.Entity;
using VienHoa.Enums;
using VienHoa.IService;
using VienHoa.Service;

namespace VienHoa.View
{
    public partial class FormNhienLieu : DevExpress.XtraEditors.XtraForm
    {
        private NhienLieu nhienLieuView;
        private readonly IRepository<NhienLieu> nhienLieuRepo;
        private readonly IRepository<LoaiNhienLieu> loaiNhienLieuRepo;
        private readonly IRepository<DonViDoTheoNam> donViDoRepo;
        private readonly INhienLieu _nhienLieu;
        private XtraForm parentFormFluent1;
        private bool isCloseParentForm1;
        public FormNhienLieu()
        {
            InitializeComponent();
            _nhienLieu = new NhienLieuService();
            nhienLieuRepo = new ExRepository<NhienLieu>();
            loaiNhienLieuRepo = new ExRepository<LoaiNhienLieu>();
            donViDoRepo = new ExRepository<DonViDoTheoNam>();
            ComBox();
        }
        public FormNhienLieu(XtraForm parentFormFluent, bool isCloseParentForm = false)
        {
            InitializeComponent();
            _nhienLieu = new NhienLieuService();
            nhienLieuRepo = new ExRepository<NhienLieu>();
            loaiNhienLieuRepo = new ExRepository<LoaiNhienLieu>();
            donViDoRepo = new ExRepository<DonViDoTheoNam>();
            ComBox();
            parentFormFluent1 = parentFormFluent;
            isCloseParentForm1 = isCloseParentForm;
        }
        public FormNhienLieu(NhienLieu nhienLieu)
        {
            InitializeComponent();
            _nhienLieu = new NhienLieuService();
            nhienLieuRepo = new ExRepository<NhienLieu>();
            loaiNhienLieuRepo = new ExRepository<LoaiNhienLieu>();
            donViDoRepo = new ExRepository<DonViDoTheoNam>();
            nhienLieuView = nhienLieu;
            ComBox();
        }

        public FormNhienLieu(string nhienLieu)
        {
            InitializeComponent();
            _nhienLieu = new NhienLieuService();
            nhienLieuRepo = new ExRepository<NhienLieu>();
            loaiNhienLieuRepo = new ExRepository<LoaiNhienLieu>();
            donViDoRepo = new ExRepository<DonViDoTheoNam>();
            txt_tnl.Text = nhienLieu;
            ComBox();
        }
        private void ValidateEnum(List<EnumNhienLieu> list)
        {
            if (list.Contains(EnumNhienLieu.TrongTenNL))
            {
                lb_tnl.Text = "Vui lòng nhập tên nhiên liệu";
            }
            else
            {
                lb_tnl.Text = "";
            }
            if (list.Contains(EnumNhienLieu.TrongTenHT))
            {
                lb_thttt.Text = "Vui lòng nhập hiển thị tiêu thụ";

            }
            else
            {
                lb_thttt.Text = "";
            }
            if (list.Contains(EnumNhienLieu.TrongHTTN))
            {
                lb_tdv.Text = "Vui lòng nhập tên đơn vị";
            }
            else
            {
                lb_tdv.Text = "";
            }
            if (list.Contains(EnumNhienLieu.TrongLoaiNL))
            {
                lb_lnl.Text = "Vui lòng nhập loại nhiên liệu";
            }
            else
            {
                lb_lnl.Text = "";
            }
            if (list.Contains(EnumNhienLieu.TrongNTR))
            {
                lb_ntr.Text = "Vui lòng nhập nhiệt trị riêng";
            }
            else
            {
                lb_ntr.Text = "";
            }
        }

        private void ComBox()
        {
            List<DonViDoTheoNam> donViDoTheoNams = donViDoRepo.TableUntracked.ToList();
            foreach (DonViDoTheoNam donViDoTheoNam in donViDoTheoNams)
            {
                cb_tdv.Properties.Items.Add(new CustomCombobox { Id = donViDoTheoNam.Id, Ten = donViDoTheoNam.TenDonVi });
            }
            cb_tdv.SelectedIndex = -1;
            cb_tdv.SelectedIndex = -1;
            //Loại Nhiên liệu 
            List<LoaiNhienLieu> loaiNhienLieus = loaiNhienLieuRepo.TableUntracked.ToList();
            foreach (LoaiNhienLieu loaiNhienLieu in loaiNhienLieus)
            {
                cb_lnl.Properties.Items.Add(new CustomCombobox { Id = loaiNhienLieu.Id, Ten = loaiNhienLieu.TenLoai });
            }
            cb_lnl.SelectedIndex = -1;

            if (nhienLieuView != null)
            {
                this.Text = "Sửa dữ liệu";
                //simpleButton1.ImageOptions.Image = null;
                //simpleButton1.ImageOptions.ImageList = imageCollection1;
                //simpleButton1.ImageOptions.ImageIndex = 1;
                simpleButton1.Text = "Sửa";
                txt_tnl.Text = nhienLieuView.TenNhienLieu;
                txt_thttt.Text = nhienLieuView.TenHienThiTieuThu;
                txt_ntr.Text = nhienLieuView.NhietTriRieng.ToString();
                foreach (CustomCombobox item in cb_lnl.Properties.Items)
                {
                    if (item.Id == nhienLieuView.LoaiNhienLieuId)
                    {
                        cb_lnl.EditValue = item;
                        break;
                    }
                }
                foreach (CustomCombobox item in cb_tdv.Properties.Items)
                {
                    if (item.Id == nhienLieuView.DonViDoTheoNamId)
                    {
                        cb_tdv.EditValue = item;
                        break;
                    }
                }

                lb_lnl.Text = "";
                lb_tdv.Text = "";
                lb_thttt.Text = "";
                lb_tnl.Text = "";
                lb_ntr.Text = "";
            }
            else
            {

                this.Text = "Thêm dữ liệu";
                //simpleButton1.ImageOptions.Image = null;
                //simpleButton1.ImageOptions.ImageList = imageCollection1;
                //simpleButton1.ImageOptions.ImageIndex = 0;
                simpleButton1.Text = "Thêm";
                cb_lnl.SelectedIndex = -1;
                cb_tdv.SelectedItem = -1;
                //txt_tnl.Text = "";
                txt_thttt.Text = "";
                lb_lnl.Text = "";
                lb_tdv.Text = "";
                lb_thttt.Text = "";
                lb_tnl.Text = "";
                lb_ntr.Text = "";
            }


        }

        public async void ThemNhienLieu()
        {
            NhienLieu nhienLieu = new NhienLieu();
            nhienLieu.TenNhienLieu = txt_tnl.Text;
            nhienLieu.TenHienThiTieuThu = txt_thttt.Text;
            nhienLieu.LoaiNhienLieuId = (CustomCombobox)cb_lnl.SelectedItem != null ? ((CustomCombobox)cb_lnl.SelectedItem).Id : 0;
            nhienLieu.DonViDoTheoNamId = (CustomCombobox)cb_tdv.SelectedItem != null ? ((CustomCombobox)cb_tdv.SelectedItem).Id : 0;
            if (double.TryParse(txt_ntr.Text, out double kq))
            {
                nhienLieu.NhietTriRieng = txt_ntr.Text != "" ? kq : -1;
            }
            else
            {
                nhienLieu.NhietTriRieng = -1;
            }
            List<EnumNhienLieu> listNL = await _nhienLieu.ThemNhienLieu(nhienLieu);

            if (listNL.Count() == 0)
            {
                DialogResult dialog = MessageBox.Show("Bạn có chắc chắn muốn thêm nhiên liệu?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialog == DialogResult.OK)
                {
                    DialogResult dialog1 = MessageBox.Show("Bạn đã thêm dữ liệu thành công", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (dialog1 == DialogResult.OK)
                    {
                        await nhienLieuRepo.AddAsync(nhienLieu);
                        isCloseParentForm1 = true;
                        if (isCloseParentForm1)
                        {
                            parentFormFluent1.Close();
                        }
                        this.Close();

                    }
                }
            }
            else
            {
                ValidateEnum(listNL);
            }


        }
        public async void SuaNhienLieu()
        {
            nhienLieuView.TenNhienLieu = txt_tnl.Text;
            nhienLieuView.TenHienThiTieuThu = txt_thttt.Text;
            if (double.TryParse(txt_ntr.Text, out double kq))
            {
                nhienLieuView.NhietTriRieng = txt_ntr.Text != "" ? kq : -1;
            }
            else
            {
                nhienLieuView.NhietTriRieng = -1;
            }
            nhienLieuView.LoaiNhienLieuId = (CustomCombobox)cb_lnl.SelectedItem != null ? ((CustomCombobox)cb_lnl.SelectedItem).Id : 0;
            nhienLieuView.DonViDoTheoNamId = (CustomCombobox)cb_tdv.SelectedItem != null ? ((CustomCombobox)cb_tdv.SelectedItem).Id : 0;
            List<EnumNhienLieu> listNLS = await _nhienLieu.SuaNhienLieu(nhienLieuView.Id, nhienLieuView);

            if (listNLS.Count() == 0)
            {
                DialogResult dialog = MessageBox.Show("Bạn có chắc chắn muốn sửa nhiên liệu?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialog == DialogResult.OK)
                {
                    DialogResult dialog1 = MessageBox.Show("Bạn đã sửa dữ liệu thành công", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (dialog1 == DialogResult.OK)
                    {
                        await nhienLieuRepo.UpdateAsync(nhienLieuView);
                        this.Close();
                    }
                }
            }
            else
            {
                ValidateEnum(listNLS);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (nhienLieuView != null)
            {
                SuaNhienLieu();
            }
            else
            {
                ThemNhienLieu();
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            isCloseParentForm1 = true;
            if (isCloseParentForm1 && parentFormFluent1 != null)
            {
                parentFormFluent1.Close();
            }
            this.Close();
        }
    }
}