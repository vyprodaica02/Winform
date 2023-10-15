using DevExpress.Utils.Extensions;
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
using VienHoa.View.NhaMayTable;

namespace VienHoa.View
{
    public partial class InforAddHub : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        private XtraForm currForm;
        public InforAddHub()
        {
            InitializeComponent();
            ShowForm();
        }

        private void OpendChildForm(XtraForm childform)
        {
            if (currForm != null)
            {
                currForm.Close();
            }
            currForm = childform;
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(childform);
            childform.Dock = DockStyle.Fill;
            panel1.Tag = childform;
            childform.BringToFront();
            childform.Show();
        }

        private void ShowForm()
        {
            label1.Text = "Thêm Nhà Máy";
            XtraForm newForm = new AddInfor(this);
            OpendChildForm(newForm);
        }

        private void accordionControlElement1_Click(object sender, EventArgs e)
        {
            // Addition for Nha May
            if (currForm.Name != "AddInfor")
            {
                label1.Text = "Thêm Nhà Máy";
                XtraForm newForm_A = new AddInfor(this);
                OpendChildForm(newForm_A);
            }
        }

        private void accordionControlElement2_Click(object sender, EventArgs e)
        {
            // Addition for Loại nhà máy
            if (currForm.Name != "AddLoaiNM")
            {
                label1.Text = "Thêm Loại Nhà Máy";
                XtraForm newForm_B = new AddLoaiNM(this, false);
                OpendChildForm(newForm_B);
            }
        }

        private void accordionControlElement3_Click(object sender, EventArgs e)
        {
            // Addition for loại lò nung
            if (currForm.Name != "AddLoaiLN")
            {
                label1.Text = "Thêm Loại Lò Nung";
                XtraForm newForm_C = new AddLoaiLN(this, false);
                OpendChildForm(newForm_C);
            }
        }

        private void accordionControlElement5_Click(object sender, EventArgs e)
        {
            if (currForm.Name != "AddCongSuatThietKe")
            {
                label1.Text = "Thêm Thông số Công suất thiết kế";
                XtraForm newForm = new AddCongSuatThietKe(this, false);
                OpendChildForm(newForm);
            }
        }
    }
}
