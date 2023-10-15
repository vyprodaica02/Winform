namespace VienHoa.View
{
    partial class GayNongLenToanCauFluentForm
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
            fluentDesignFormContainer1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            panel2 = new System.Windows.Forms.Panel();
            panel1 = new System.Windows.Forms.Panel();
            headertitle = new System.Windows.Forms.Label();
            accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            accordionControlElement1 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            btnGayNongLenToanCau = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            btnKhiPhatThai = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            fluentFormDefaultManager1 = new DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager(components);
            fluentDesignFormContainer1.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)accordionControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fluentDesignFormControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fluentFormDefaultManager1).BeginInit();
            SuspendLayout();
            // 
            // fluentDesignFormContainer1
            // 
            fluentDesignFormContainer1.Controls.Add(panel2);
            fluentDesignFormContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            fluentDesignFormContainer1.Location = new System.Drawing.Point(171, 31);
            fluentDesignFormContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            fluentDesignFormContainer1.Name = "fluentDesignFormContainer1";
            fluentDesignFormContainer1.Size = new System.Drawing.Size(386, 463);
            fluentDesignFormContainer1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel1);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(0, 0);
            panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(386, 463);
            panel2.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.FromArgb(217, 217, 217);
            panel1.Controls.Add(headertitle);
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(386, 32);
            panel1.TabIndex = 2;
            // 
            // headertitle
            // 
            headertitle.AutoSize = true;
            headertitle.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            headertitle.Location = new System.Drawing.Point(9, 8);
            headertitle.Name = "headertitle";
            headertitle.Size = new System.Drawing.Size(166, 13);
            headertitle.TabIndex = 0;
            headertitle.Text = "Thêm gây nóng lên toàn cầu";
            // 
            // accordionControl1
            // 
            accordionControl1.Appearance.AccordionControl.BackColor = System.Drawing.Color.Silver;
            accordionControl1.Appearance.AccordionControl.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            accordionControl1.Appearance.AccordionControl.Options.UseBackColor = true;
            accordionControl1.Appearance.AccordionControl.Options.UseFont = true;
            accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] { accordionControlElement1, btnGayNongLenToanCau, btnKhiPhatThai });
            accordionControl1.Location = new System.Drawing.Point(0, 31);
            accordionControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            accordionControl1.Name = "accordionControl1";
            accordionControl1.OptionsMinimizing.AllowMinimizeMode = DevExpress.Utils.DefaultBoolean.False;
            accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            accordionControl1.Size = new System.Drawing.Size(171, 463);
            accordionControl1.TabIndex = 1;
            // 
            // accordionControlElement1
            // 
            accordionControlElement1.Height = 32;
            accordionControlElement1.Name = "accordionControlElement1";
            accordionControlElement1.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            // 
            // btnGayNongLenToanCau
            // 
            btnGayNongLenToanCau.Name = "btnGayNongLenToanCau";
            btnGayNongLenToanCau.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            btnGayNongLenToanCau.Text = "Gây nóng lên toàn cầu";
            btnGayNongLenToanCau.Click += btnGayNongLenToanCau_Click;
            // 
            // btnKhiPhatThai
            // 
            btnKhiPhatThai.Name = "btnKhiPhatThai";
            btnKhiPhatThai.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            btnKhiPhatThai.Text = "Khí phát thải";
            btnKhiPhatThai.Click += btnKhiPhatThai_Click;
            // 
            // fluentDesignFormControl1
            // 
            fluentDesignFormControl1.FluentDesignForm = this;
            fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            fluentDesignFormControl1.Manager = fluentFormDefaultManager1;
            fluentDesignFormControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            fluentDesignFormControl1.Size = new System.Drawing.Size(557, 31);
            fluentDesignFormControl1.TabIndex = 2;
            fluentDesignFormControl1.TabStop = false;
            fluentDesignFormControl1.Visible = false;
            // 
            // fluentFormDefaultManager1
            // 
            fluentFormDefaultManager1.Form = this;
            fluentFormDefaultManager1.MaxItemId = 1;
            fluentFormDefaultManager1.ShowFullMenus = true;
            // 
            // GayNongLenToanCauFluentForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(557, 494);
            ControlBox = false;
            ControlContainer = fluentDesignFormContainer1;
            Controls.Add(fluentDesignFormContainer1);
            Controls.Add(accordionControl1);
            Controls.Add(fluentDesignFormControl1);
            FluentDesignFormControl = fluentDesignFormControl1;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            MaximumSize = new System.Drawing.Size(650, 600);
            MinimumSize = new System.Drawing.Size(650, 600);
            Name = "GayNongLenToanCauFluentForm";
            NavigationControl = accordionControl1;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "GayNongLenToanCauFluentForm";
            fluentDesignFormContainer1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)accordionControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)fluentDesignFormControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)fluentFormDefaultManager1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer fluentDesignFormContainer1;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btnGayNongLenToanCau;
        private DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager fluentFormDefaultManager1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btnKhiPhatThai;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement1;
        private System.Windows.Forms.Label headertitle;
    }
}