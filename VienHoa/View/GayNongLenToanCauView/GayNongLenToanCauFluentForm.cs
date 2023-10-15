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
    public partial class GayNongLenToanCauFluentForm : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        private XtraForm childrenlForm;
        public GayNongLenToanCauFluentForm()
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
            panel2.Controls.Add(AddChildrenlForm);
            AddChildrenlForm.Dock = DockStyle.Fill;
            panel2.Tag = AddChildrenlForm;
            AddChildrenlForm.BringToFront();
            AddChildrenlForm.Show();

        }

        void ShowForm()
        {
            headertitle.Text = "Thêm gây nóng lên toàn cầu";
            XtraForm newForm = new GayNongLenToanCauAdd(this);
            OpenChildrenlForm(newForm);
        }

        private void btnGayNongLenToanCau_Click(object sender, EventArgs e)
        {
            if (childrenlForm.Name != "GayNongLenToanCauAdd")
            {
                ShowForm();
            }
        }

        private void btnKhiPhatThai_Click(object sender, EventArgs e)
        {
            if (childrenlForm.Name != "KhiPhatThaiAdd")
            {
                headertitle.Text = "Thêm khí phát thải";
                XtraForm newForm = new KhiPhatThaiAdd(this, false);
                OpenChildrenlForm(newForm);
            }
        }
    }
}
