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
    public partial class ThaiDauRaFluentForm : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        private XtraForm childrenlForm;
        public ThaiDauRaFluentForm()
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
            XtraForm newForm = new ThemThaiDauRaView(this);
            label1.Text = "Thêm thải đầu ra";
            OpenChildrenlForm(newForm);
        }

        private void ElementThaiDauRa_Click(object sender, EventArgs e)
        {
            if (childrenlForm.Name != "ThemThaiDauRaView")
            {
                XtraForm newForm = new ThemThaiDauRaView(this);
                label1.Text = "Thêm thải đầu ra";
                OpenChildrenlForm(newForm);
            }

        }

        private void ElementChatThai_Click(object sender, EventArgs e)
        {
            if (childrenlForm.Name != "ThemChatThaiView")
            {
                XtraForm newForm = new ThemChatThaiView(this, true);
                label1.Text = "Thêm chất thải";
                OpenChildrenlForm(newForm);

            }
        }
    }
}
