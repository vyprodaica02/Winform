namespace VienHoa.View
{
    partial class FormSanPhamFluent
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            acb = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            tabNhaMay = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            tabDuAn = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            tabLoaiLoNung = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            tabSanPham = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            tab_nhamay = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            tab_duan = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            fluentFormDefaultManager1 = new DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager(components);
            panelBody = new System.Windows.Forms.Panel();
            label1 = new System.Windows.Forms.Label();
            panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)accordionControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fluentDesignFormControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fluentFormDefaultManager1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // accordionControl1
            // 
            accordionControl1.Appearance.AccordionControl.BackColor = System.Drawing.Color.Silver;
            accordionControl1.Appearance.AccordionControl.Options.UseBackColor = true;
            accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] { acb, tabSanPham, tab_nhamay, tab_duan });
            accordionControl1.Location = new System.Drawing.Point(0, 39);
            accordionControl1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            accordionControl1.Name = "accordionControl1";
            accordionControl1.OptionsMinimizing.AllowMinimizeMode = DevExpress.Utils.DefaultBoolean.False;
            accordionControl1.Padding = new System.Windows.Forms.Padding(0, 30, 0, 0);
            accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Fluent;
            accordionControl1.ShowFilterControl = DevExpress.XtraBars.Navigation.ShowFilterControl.Auto;
            accordionControl1.Size = new System.Drawing.Size(200, 560);
            accordionControl1.TabIndex = 1;
            // 
            // acb
            // 
            acb.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] { tabNhaMay, tabDuAn, tabLoaiLoNung });
            acb.Expanded = true;
            acb.Height = 32;
            acb.Name = "acb";
            acb.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            // 
            // tabNhaMay
            // 
            tabNhaMay.Name = "tabNhaMay";
            tabNhaMay.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            tabNhaMay.Text = "Nhà máy";
            tabNhaMay.Visible = false;
            // 
            // tabDuAn
            // 
            tabDuAn.Name = "tabDuAn";
            tabDuAn.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            tabDuAn.Text = "Dự án";
            tabDuAn.Visible = false;
            // 
            // tabLoaiLoNung
            // 
            tabLoaiLoNung.Name = "tabLoaiLoNung";
            tabLoaiLoNung.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            tabLoaiLoNung.Text = "Loại lò nung";
            tabLoaiLoNung.Visible = false;
            // 
            // tabSanPham
            // 
            tabSanPham.Name = "tabSanPham";
            tabSanPham.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            tabSanPham.Text = "Sản phẩm";
            tabSanPham.Click += tabSanPham_Click_1;
            // 
            // tab_nhamay
            // 
            tab_nhamay.Name = "tab_nhamay";
            tab_nhamay.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            tab_nhamay.Text = "Nhà máy";
            tab_nhamay.Click += tab_nhamay_Click;
            // 
            // tab_duan
            // 
            tab_duan.Name = "tab_duan";
            tab_duan.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            tab_duan.Text = "Dự án";
            tab_duan.Click += tab_duan_Click;
            // 
            // fluentDesignFormControl1
            // 
            fluentDesignFormControl1.FluentDesignForm = this;
            fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            fluentDesignFormControl1.Manager = fluentFormDefaultManager1;
            fluentDesignFormControl1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            fluentDesignFormControl1.Size = new System.Drawing.Size(648, 39);
            fluentDesignFormControl1.TabIndex = 2;
            fluentDesignFormControl1.TabStop = false;
            fluentDesignFormControl1.Visible = false;
            // 
            // fluentFormDefaultManager1
            // 
            fluentFormDefaultManager1.Form = this;
            // 
            // panelBody
            // 
            panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            panelBody.Location = new System.Drawing.Point(200, 78);
            panelBody.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            panelBody.Name = "panelBody";
            panelBody.Size = new System.Drawing.Size(448, 521);
            panelBody.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(10, 10);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(118, 17);
            label1.TabIndex = 0;
            label1.Text = "Thêm sản phẩm";
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.FromArgb(217, 217, 217);
            panel1.Controls.Add(label1);
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(200, 39);
            panel1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(24, 0, 0, 0);
            panel1.Size = new System.Drawing.Size(448, 39);
            panel1.TabIndex = 3;
            // 
            // FormSanPhamFluent
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(648, 599);
            Controls.Add(panelBody);
            Controls.Add(panel1);
            Controls.Add(accordionControl1);
            Controls.Add(fluentDesignFormControl1);
            FluentDesignFormControl = fluentDesignFormControl1;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            MaximumSize = new System.Drawing.Size(650, 600);
            MinimumSize = new System.Drawing.Size(650, 600);
            Name = "FormSanPhamFluent";
            NavigationControl = accordionControl1;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "FormSanPhamFluent";
            Load += FormSanPhamFluent_Load;
            ((System.ComponentModel.ISupportInitialize)accordionControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)fluentDesignFormControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)fluentFormDefaultManager1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement acb;
        private DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager fluentFormDefaultManager1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement tabNhaMay;
        private DevExpress.XtraBars.Navigation.AccordionControlElement tabDuAn;
        private DevExpress.XtraBars.Navigation.AccordionControlElement tabLoaiLoNung;
        private System.Windows.Forms.Panel panelBody;
        private DevExpress.XtraBars.Navigation.AccordionControlElement tabSanPham;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement tab_nhamay;
        private DevExpress.XtraBars.Navigation.AccordionControlElement tab_duan;
    }
}