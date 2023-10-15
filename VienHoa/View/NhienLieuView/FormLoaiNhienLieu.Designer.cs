namespace VienHoa.View.NhienLieuView
{
    partial class FormLoaiNhienLieu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLoaiNhienLieu));
            panel1 = new System.Windows.Forms.Panel();
            simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            panel2 = new System.Windows.Forms.Panel();
            txt_lnl = new DevExpress.XtraEditors.TextEdit();
            lb_lnl = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txt_lnl.Properties).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(simpleButton2);
            panel1.Controls.Add(simpleButton1);
            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.Location = new System.Drawing.Point(50, 505);
            panel1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(50, 25, 50, 25);
            panel1.Size = new System.Drawing.Size(348, 30);
            panel1.TabIndex = 0;
            // 
            // simpleButton2
            // 
            simpleButton2.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("simpleButton2.ImageOptions.Image");
            simpleButton2.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            simpleButton2.ImageOptions.ImageToTextIndent = 15;
            simpleButton2.Location = new System.Drawing.Point(199, 0);
            simpleButton2.Margin = new System.Windows.Forms.Padding(50, 2, 50, 2);
            simpleButton2.MaximumSize = new System.Drawing.Size(100, 30);
            simpleButton2.MinimumSize = new System.Drawing.Size(100, 30);
            simpleButton2.Name = "simpleButton2";
            simpleButton2.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            simpleButton2.Size = new System.Drawing.Size(100, 30);
            simpleButton2.TabIndex = 4;
            simpleButton2.Text = "Hủy";
            simpleButton2.Click += simpleButton2_Click;
            // 
            // simpleButton1
            // 
            simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            simpleButton1.Appearance.Options.UseFont = true;
            simpleButton1.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("simpleButton1.ImageOptions.Image");
            simpleButton1.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            simpleButton1.ImageOptions.ImageToTextIndent = 15;
            simpleButton1.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            simpleButton1.Location = new System.Drawing.Point(50, 0);
            simpleButton1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            simpleButton1.MaximumSize = new System.Drawing.Size(100, 30);
            simpleButton1.MinimumSize = new System.Drawing.Size(100, 30);
            simpleButton1.Name = "simpleButton1";
            simpleButton1.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            simpleButton1.Size = new System.Drawing.Size(100, 30);
            simpleButton1.TabIndex = 3;
            simpleButton1.Text = "Thêm";
            simpleButton1.Click += simpleButton1_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(txt_lnl);
            panel2.Controls.Add(lb_lnl);
            panel2.Controls.Add(label1);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(50, 25);
            panel2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(348, 480);
            panel2.TabIndex = 0;
            // 
            // txt_lnl
            // 
            txt_lnl.Location = new System.Drawing.Point(148, 0);
            txt_lnl.Margin = new System.Windows.Forms.Padding(4, 2, 4, 3);
            txt_lnl.MaximumSize = new System.Drawing.Size(200, 30);
            txt_lnl.MinimumSize = new System.Drawing.Size(200, 30);
            txt_lnl.Name = "txt_lnl";
            txt_lnl.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txt_lnl.Properties.Appearance.Options.UseFont = true;
            txt_lnl.Properties.AutoHeight = false;
            txt_lnl.Size = new System.Drawing.Size(200, 30);
            txt_lnl.TabIndex = 2;
            // 
            // lb_lnl
            // 
            lb_lnl.AutoSize = true;
            lb_lnl.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lb_lnl.ForeColor = System.Drawing.Color.Red;
            lb_lnl.Location = new System.Drawing.Point(148, 33);
            lb_lnl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lb_lnl.Name = "lb_lnl";
            lb_lnl.Size = new System.Drawing.Size(41, 16);
            lb_lnl.TabIndex = 1;
            lb_lnl.Text = "label2";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(0, 7);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(97, 17);
            label1.TabIndex = 0;
            label1.Text = "Loại nhiên liệu:";
            // 
            // FormLoaiNhienLieu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(448, 560);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            Name = "FormLoaiNhienLieu";
            Padding = new System.Windows.Forms.Padding(50, 25, 50, 25);
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "FormLoaiNhienLieu";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txt_lnl.Properties).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.TextEdit txt_lnl;
        private System.Windows.Forms.Label lb_lnl;
        private System.Windows.Forms.Label label1;
    }
}