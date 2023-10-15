using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VienHoa.View.DuAnView
{
    public partial class FormDuAnFluent : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public FormDuAnFluent()
        {
            InitializeComponent();
        }

        private Form currentForm;
        private void OpenChildrenlForm(Form AddChildrenlForm)
        {
            if (currentForm != null)
            {
                currentForm.Close();
            }
            currentForm = AddChildrenlForm;
            AddChildrenlForm.TopLevel = false;
            AddChildrenlForm.FormBorderStyle = FormBorderStyle.None;
            panelBody.Controls.Add(AddChildrenlForm);
            AddChildrenlForm.Dock = DockStyle.Fill;
            panelBody.Dock = DockStyle.Fill;
            panelBody.Tag = AddChildrenlForm;
            AddChildrenlForm.BringToFront();
            AddChildrenlForm.Show();
        }

        private void panelBody_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormDuAnFluent_Load(object sender, EventArgs e)
        {
            label1.Text = "Thêm doanh nghiệp";
            FormDuAn formDAView = new FormDuAn(this);
            OpenChildrenlForm(formDAView);
            currentForm = formDAView;
        }

        private void tabDoanhNgiep_Click(object sender, EventArgs e)
        {
            label1.Text = "Thêm doanh nghiệp";
            FormThemDoanhNghiep formDNView = new FormThemDoanhNghiep(this, false);
            OpenChildrenlForm(formDNView);
            currentForm = formDNView;
        }

        private void accordionControlElement2_Click(object sender, EventArgs e)
        {
            if (currentForm.Name != "FormDuAn")
            {
                label1.Text = "Thêm dự án";
                FormDuAn formDAView = new FormDuAn(this);
                OpenChildrenlForm(formDAView);
                currentForm = formDAView;
            }
        }
    }
}
