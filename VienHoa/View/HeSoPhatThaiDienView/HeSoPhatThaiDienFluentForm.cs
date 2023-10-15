using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VienHoa.Entity;

namespace VienHoa.View
{
    public partial class HeSoPhatThaiDienFluentForm : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        private XtraForm childrenlForm;
        public HeSoPhatThaiDienFluentForm()
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
            panel1.Tag = AddChildrenlForm;
            AddChildrenlForm.BringToFront();
            AddChildrenlForm.Show();

        }

        void ShowForm()
        {
            headertitle.Text = "Thêm hệ số phát thải điện";
            XtraForm newForm = new HeSoPhatThaiDienAdd(this);
            OpenChildrenlForm(newForm);
        }

        private void btnHeSoPhatThaiDien_Click(object sender, EventArgs e)
        {
            ShowForm();
        }

        private void btnKhiPhatThai_Click(object sender, EventArgs e)
        {
            headertitle.Text = "Thêm khí phát thải";
            XtraForm newForm = new KhiPhatThaiAdd(this, false);
            OpenChildrenlForm(newForm);
        }
    }
}
