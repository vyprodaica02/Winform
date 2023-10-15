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

namespace VienHoa.View
{
    public partial class FormFluentThemDoanhNghiep : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public FormFluentThemDoanhNghiep()
        {
            InitializeComponent();
            ShowFromThemDoanhNghiep();
        }
        private void OpenChildrenlForm(XtraForm AddChildrenlForm)
        {
            if (childrenlForm != null)
            {
                childrenlForm.Close();
            }
            childrenlForm = AddChildrenlForm;
            AddChildrenlForm.TopLevel = false;
            AddChildrenlForm.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Add(AddChildrenlForm);
            AddChildrenlForm.Dock = DockStyle.Fill;
            panel2.Dock = DockStyle.Fill;
            panel2.Tag = AddChildrenlForm;
            AddChildrenlForm.BringToFront();
            AddChildrenlForm.Show();

        }

        void ShowFromThemDoanhNghiep()
        {
            FormThemDoanhNghiep newForm = new FormThemDoanhNghiep(this);
            OpenChildrenlForm(newForm);
        }
        private XtraForm childrenlForm;
        private void accordionControlElement1_Click(object sender, EventArgs e)
        {
            if(childrenlForm.Name == "FormThemDoanhNghiep")
            {
                ShowFromThemDoanhNghiep();
            }    
        }
    }
}
