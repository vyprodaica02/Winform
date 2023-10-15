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
    public partial class LoaiChatThaiFluentForm : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        private XtraForm childrenlForm;
        public LoaiChatThaiFluentForm()
        {
            InitializeComponent();

            ShowForm();
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
            panel1.Controls.Add(AddChildrenlForm);
            AddChildrenlForm.Dock = DockStyle.Fill;
            panel1.Dock = DockStyle.Fill;
            panel1.Tag = AddChildrenlForm;
            AddChildrenlForm.BringToFront();
            AddChildrenlForm.Show();
        }

        void ShowForm()
        {
            XtraForm newForm = new ThemLoaiChatThaiView(this);
            label1.Text = "Thêm loại chất thải";
            OpenChildrenlForm(newForm);
        }
    }
}
