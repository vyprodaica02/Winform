namespace VienHoa.View.DuAnView
{
    partial class FormDuAnFluent
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
            panelBody = new System.Windows.Forms.Panel();
            panel1 = new System.Windows.Forms.Panel();
            label1 = new System.Windows.Forms.Label();
            accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            accordionControlElement1 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            accordionControlElement2 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            tabDoanhNgiep = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            fluentFormDefaultManager1 = new DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager(components);
            fluentDesignFormContainer1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)accordionControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fluentDesignFormControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fluentFormDefaultManager1).BeginInit();
            SuspendLayout();
            // 
            // fluentDesignFormContainer1
            // 
            fluentDesignFormContainer1.Controls.Add(panelBody);
            fluentDesignFormContainer1.Controls.Add(panel1);
            fluentDesignFormContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            fluentDesignFormContainer1.Location = new System.Drawing.Point(200, 39);
            fluentDesignFormContainer1.Name = "fluentDesignFormContainer1";
            fluentDesignFormContainer1.Size = new System.Drawing.Size(448, 560);
            fluentDesignFormContainer1.TabIndex = 0;
            // 
            // panelBody
            // 
            panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            panelBody.Location = new System.Drawing.Point(0, 40);
            panelBody.Name = "panelBody";
            panelBody.Size = new System.Drawing.Size(448, 520);
            panelBody.TabIndex = 1;
            panelBody.Paint += panelBody_Paint;
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.FromArgb(217, 217, 217);
            panel1.Controls.Add(label1);
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(448, 40);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(10, 10);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(82, 16);
            label1.TabIndex = 0;
            label1.Text = "Thêm dự án";
            // 
            // accordionControl1
            // 
            accordionControl1.Appearance.AccordionControl.BackColor = System.Drawing.Color.Silver;
            accordionControl1.Appearance.AccordionControl.Options.UseBackColor = true;
            accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] { accordionControlElement1, accordionControlElement2, tabDoanhNgiep });
            accordionControl1.Location = new System.Drawing.Point(0, 39);
            accordionControl1.Name = "accordionControl1";
            accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            accordionControl1.Size = new System.Drawing.Size(200, 560);
            accordionControl1.TabIndex = 1;
            // 
            // accordionControlElement1
            // 
            accordionControlElement1.Height = 32;
            accordionControlElement1.Name = "accordionControlElement1";
            accordionControlElement1.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            // 
            // accordionControlElement2
            // 
            accordionControlElement2.Height = 30;
            accordionControlElement2.Name = "accordionControlElement2";
            accordionControlElement2.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            accordionControlElement2.Text = "Dự án";
            accordionControlElement2.Click += accordionControlElement2_Click;
            // 
            // tabDoanhNgiep
            // 
            tabDoanhNgiep.Height = 30;
            tabDoanhNgiep.Name = "tabDoanhNgiep";
            tabDoanhNgiep.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            tabDoanhNgiep.Text = "Doanh nghiệp";
            tabDoanhNgiep.Click += tabDoanhNgiep_Click;
            // 
            // fluentDesignFormControl1
            // 
            fluentDesignFormControl1.FluentDesignForm = this;
            fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            fluentDesignFormControl1.Manager = fluentFormDefaultManager1;
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
            // FormDuAnFluent
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(648, 599);
            ControlContainer = fluentDesignFormContainer1;
            Controls.Add(fluentDesignFormContainer1);
            Controls.Add(accordionControl1);
            Controls.Add(fluentDesignFormControl1);
            FluentDesignFormControl = fluentDesignFormControl1;
            MaximumSize = new System.Drawing.Size(650, 600);
            MinimumSize = new System.Drawing.Size(650, 600);
            Name = "FormDuAnFluent";
            NavigationControl = accordionControl1;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "FormDuAnFluent";
            Load += FormDuAnFluent_Load;
            fluentDesignFormContainer1.ResumeLayout(false);
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
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager fluentFormDefaultManager1;
        private System.Windows.Forms.Panel panelBody;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement2;
        private DevExpress.XtraBars.Navigation.AccordionControlElement tabDoanhNgiep;
    }
}