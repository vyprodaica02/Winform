namespace VienHoa.View
{
    partial class ChatThaiFluentForm
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
            panel1 = new System.Windows.Forms.Panel();
            panel2 = new System.Windows.Forms.Panel();
            label1 = new System.Windows.Forms.Label();
            accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            accordionControlElement1 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            ElementChatThai = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            ElementLoaiChatThai = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            fluentFormDefaultManager1 = new DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager(components);
            fluentDesignFormContainer1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)accordionControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fluentDesignFormControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fluentFormDefaultManager1).BeginInit();
            SuspendLayout();
            // 
            // fluentDesignFormContainer1
            // 
            fluentDesignFormContainer1.Controls.Add(panel1);
            fluentDesignFormContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            fluentDesignFormContainer1.Location = new System.Drawing.Point(200, 39);
            fluentDesignFormContainer1.Margin = new System.Windows.Forms.Padding(4);
            fluentDesignFormContainer1.Name = "fluentDesignFormContainer1";
            fluentDesignFormContainer1.Size = new System.Drawing.Size(448, 560);
            fluentDesignFormContainer1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(panel2);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Margin = new System.Windows.Forms.Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(448, 560);
            panel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.BackColor = System.Drawing.Color.FromArgb(217, 217, 217);
            panel2.Controls.Add(label1);
            panel2.Dock = System.Windows.Forms.DockStyle.Top;
            panel2.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            panel2.Location = new System.Drawing.Point(0, 0);
            panel2.Margin = new System.Windows.Forms.Padding(4);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(448, 40);
            panel2.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(12, 12);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(48, 17);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // accordionControl1
            // 
            accordionControl1.Appearance.AccordionControl.BackColor = System.Drawing.Color.Silver;
            accordionControl1.Appearance.AccordionControl.Options.UseBackColor = true;
            accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] { accordionControlElement1, ElementChatThai, ElementLoaiChatThai });
            accordionControl1.Location = new System.Drawing.Point(0, 39);
            accordionControl1.Margin = new System.Windows.Forms.Padding(4);
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
            // ElementChatThai
            // 
            ElementChatThai.Name = "ElementChatThai";
            ElementChatThai.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            ElementChatThai.Text = "Chất thải";
            ElementChatThai.Click += ElementChatThai_Click;
            // 
            // ElementLoaiChatThai
            // 
            ElementLoaiChatThai.Name = "ElementLoaiChatThai";
            ElementLoaiChatThai.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            ElementLoaiChatThai.Text = "Loại chất thải";
            ElementLoaiChatThai.Click += ElementLoaiChatThai_Click;
            // 
            // fluentDesignFormControl1
            // 
            fluentDesignFormControl1.FluentDesignForm = this;
            fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            fluentDesignFormControl1.Manager = fluentFormDefaultManager1;
            fluentDesignFormControl1.Margin = new System.Windows.Forms.Padding(4);
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
            // ChatThaiFluentForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(648, 599);
            ControlContainer = fluentDesignFormContainer1;
            Controls.Add(fluentDesignFormContainer1);
            Controls.Add(accordionControl1);
            Controls.Add(fluentDesignFormControl1);
            FluentDesignFormControl = fluentDesignFormControl1;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Margin = new System.Windows.Forms.Padding(4);
            MaximumSize = new System.Drawing.Size(650, 600);
            MinimumSize = new System.Drawing.Size(650, 600);
            Name = "ChatThaiFluentForm";
            NavigationControl = accordionControl1;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "ChatThaiFluentForm";
            fluentDesignFormContainer1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)accordionControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)fluentDesignFormControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)fluentFormDefaultManager1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer fluentDesignFormContainer1;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager fluentFormDefaultManager1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ElementChatThai;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ElementLoaiChatThai;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement1;
    }
}