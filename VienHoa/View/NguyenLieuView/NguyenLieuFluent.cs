using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VienHoa.View.NguyenLieuView;

namespace VienHoa.View.NguyenNhienLieuView
{
    public partial class NguyenLieuFluent : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public NguyenLieuFluent()
        {
            InitializeComponent();
        }
        // private XtraForm parentForm;
        private Form currentForm;
        private void OpenChildrenlForm(XtraForm AddChildrenlForm)
        {
            if (currentForm != null)
            {
                currentForm.Close();
            }
            currentForm = AddChildrenlForm;
            AddChildrenlForm.TopLevel = false;
            AddChildrenlForm.FormBorderStyle = FormBorderStyle.None;
            panel4.Controls.Add(AddChildrenlForm);
            AddChildrenlForm.Dock = DockStyle.Fill;
            panel4.Dock = DockStyle.Fill;
            panel4.Tag = AddChildrenlForm;
            AddChildrenlForm.BringToFront();
            AddChildrenlForm.Show();
        }

        private void NguyenLieuFluent_Load_1(object sender, EventArgs e)
        {
            FormNguyenLieu formNguyenLieu = new FormNguyenLieu(this);
            OpenChildrenlForm(formNguyenLieu);
            currentForm = formNguyenLieu;
        }

        private void item_nguyenlieu_Click(object sender, EventArgs e)
        {
            // nguyen lieu
            if (currentForm.Name != "FormNguyenLieu")
            {
                label1.Text = "Thêm nguyên liệu";
                FormNguyenLieu formNguyenLieu = new FormNguyenLieu(this);
                OpenChildrenlForm(formNguyenLieu);
                currentForm = formNguyenLieu;
            }
        }

        private void accordionControlElement1_Click(object sender, EventArgs e)
        {
            // loại nguyên liệu
            if (currentForm.Name != "FormLoaiNguyenLieu")
            {
                label1.Text = "Thêm loại nguyên liệu";
                FormLoaiNguyenLieu formLoaiNguyenLieu = new FormLoaiNguyenLieu(this);
                OpenChildrenlForm(formLoaiNguyenLieu);
                currentForm = formLoaiNguyenLieu;
            }
        }

        private void accordionControlElement2_Click(object sender, EventArgs e)
        {
            // đơn vị đo 
            if (currentForm.Name != "FormDonViDo")
            {
                label1.Text = "Thêm đơn vị đo theo năm";
                FormDonViDo formDonViDo = new FormDonViDo(this);
                OpenChildrenlForm(formDonViDo);
                currentForm = formDonViDo;
            }
        }
    }
}
