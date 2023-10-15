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
using VienHoa.View.DuAnView;

namespace VienHoa.View
{
    public partial class FormSanPhamFluent : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public FormSanPhamFluent()
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

        private void FormSanPhamFluent_Load(object sender, EventArgs e)
        {
            FormSanPhamView formSPView = new FormSanPhamView(this);
            OpenChildrenlForm(formSPView);
            currentForm = formSPView;
        }
        private void tab_loailonung_Click(object sender, EventArgs e)
        {
        }
        private void tab_duan_Click(object sender, EventArgs e)
        {
            if (currentForm.Name != "FormDuAn")
            {
                label1.Text = "Thêm dự án";
                FormDuAn frm = new FormDuAn(this, false);
                OpenChildrenlForm(frm);
                currentForm = frm;
            }
        }
        private void tab_nhamay_Click(object sender, EventArgs e)
        {
            if (currentForm.Name != "AddInfor")
            {
                label1.Text = "Thêm nhà máy";
                AddInfor formNMView = new AddInfor(this, false);
                OpenChildrenlForm(formNMView);
                currentForm = formNMView;
            }
        }
        private void tabSanPham_Click_1(object sender, EventArgs e)
        {
            if (currentForm.Name != "FormSanPhamView")
            {
                label1.Text = "Thêm sản phẩm";
                FormSanPhamView formSPView = new FormSanPhamView(this);
                OpenChildrenlForm(formSPView);
                currentForm = formSPView;
            }
        }
    }
}
