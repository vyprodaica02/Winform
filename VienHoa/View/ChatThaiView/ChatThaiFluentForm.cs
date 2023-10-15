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
using VienHoa.IService;
using VienHoa.Service;

namespace VienHoa.View
{
    public partial class ChatThaiFluentForm : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        private XtraForm childrenlForm;

        public ChatThaiFluentForm()
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
            XtraForm newForm = new ThemChatThaiView(this);
            label1.Text = "Thêm Chất thải";
            OpenChildrenlForm(newForm);
        }

        private void ElementLoaiChatThai_Click(object sender, EventArgs e)
        {
            if (childrenlForm.Name != "ThemLoaiChatThaiView")
            {
                XtraForm newForm = new ThemLoaiChatThaiView(this, true);
                label1.Text = "Thêm loại chất thải";
                OpenChildrenlForm(newForm);
            }
        }

        private void ElementChatThai_Click(object sender, EventArgs e)
        {
            if (childrenlForm.Name != "ThemChatThaiView")
            {
                XtraForm newForm = new ThemChatThaiView(this);
                label1.Text = "Thêm Chất thải";
                OpenChildrenlForm(newForm);
            }
        }
    }
}
