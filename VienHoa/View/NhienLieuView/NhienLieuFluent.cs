using DevExpress.Charts.Model;
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

namespace VienHoa.View.NhienLieuView
{
    public partial class NhienLieuFluent : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        // private XtraForm parentForm;
        private Form currentForm;
        public NhienLieuFluent()
        {
            InitializeComponent();

        }

        private void OpenChildrenlForm(XtraForm AddChildrenlForm)
        {
            if (currentForm != null)
            {
                currentForm.Close();
            }
            currentForm = AddChildrenlForm;
            AddChildrenlForm.TopLevel = false;
            AddChildrenlForm.FormBorderStyle = FormBorderStyle.None;
            panel7.Controls.Add(AddChildrenlForm);
            AddChildrenlForm.Dock = DockStyle.Fill;
            panel7.Dock = DockStyle.Fill;
            panel7.Tag = AddChildrenlForm;
            AddChildrenlForm.BringToFront();
            AddChildrenlForm.Show();
        }

        private void NhienLieuFluent_Load(object sender, EventArgs e)
        {
            FormNhienLieu formNhienLieu = new FormNhienLieu(this);
            OpenChildrenlForm(formNhienLieu);
            currentForm = formNhienLieu;
        }

        private void accordionControlElement5_Click(object sender, EventArgs e)
        {
            // nhiên lieu 
            if (currentForm.Name != "FormNhienLieu")
            {
                label2.Text = "Thêm nhiên liệu";
                FormNhienLieu formNhienLieu = new FormNhienLieu(this);
                OpenChildrenlForm(formNhienLieu);
                currentForm = formNhienLieu;
            }
        }

        private void accordionControlElement6_Click(object sender, EventArgs e)
        {
            // loai nhien lieu 
            if (currentForm.Name != "FormLoaiNhienLieu")
            {
                label2.Text = "Thêm loại nhiên liệu";
                FormLoaiNhienLieu formLoaiNhienLieu = new FormLoaiNhienLieu(this);
                OpenChildrenlForm(formLoaiNhienLieu);
                currentForm = formLoaiNhienLieu;
            }
        }

        private void accordionControlElement7_Click(object sender, EventArgs e)
        {
            // don vi do theo năm 
            if (currentForm.Name != "FormDonViDo")
            {

                label2.Text = "Thêm đơn vị đo theo năm";
                FormDonViDo formDonViDo = new FormDonViDo(this);
                OpenChildrenlForm(formDonViDo);
                currentForm = formDonViDo;
            }
        }
    }
}
