namespace VienHoa.View
{
    partial class FormNhienLieu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNhienLieu));
            panel1 = new System.Windows.Forms.Panel();
            simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            panel2 = new System.Windows.Forms.Panel();
            cb_tdv = new DevExpress.XtraEditors.ComboBoxEdit();
            cb_lnl = new DevExpress.XtraEditors.ComboBoxEdit();
            txt_ntr = new DevExpress.XtraEditors.TextEdit();
            txt_thttt = new DevExpress.XtraEditors.TextEdit();
            txt_tnl = new DevExpress.XtraEditors.TextEdit();
            label3 = new System.Windows.Forms.Label();
            lb_tnl = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            lb_thttt = new System.Windows.Forms.Label();
            lb_tdv = new System.Windows.Forms.Label();
            lb_lnl = new System.Windows.Forms.Label();
            lb_ntr = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cb_tdv.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cb_lnl.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txt_ntr.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txt_thttt.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txt_tnl.Properties).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(simpleButton1);
            panel1.Controls.Add(simpleButton2);
            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            panel1.Location = new System.Drawing.Point(64, 411);
            panel1.Margin = new System.Windows.Forms.Padding(4);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(64, 30, 64, 30);
            panel1.Size = new System.Drawing.Size(448, 36);
            panel1.TabIndex = 0;
            // 
            // simpleButton1
            // 
            simpleButton1.Appearance.Options.UseFont = true;
            simpleButton1.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("simpleButton1.ImageOptions.Image");
            simpleButton1.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            simpleButton1.ImageOptions.ImageToTextIndent = 15;
            simpleButton1.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            simpleButton1.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            simpleButton1.Location = new System.Drawing.Point(64, 0);
            simpleButton1.Margin = new System.Windows.Forms.Padding(64, 4, 64, 4);
            simpleButton1.Name = "simpleButton1";
            simpleButton1.Size = new System.Drawing.Size(129, 36);
            simpleButton1.TabIndex = 17;
            simpleButton1.Text = "Thêm";
            simpleButton1.Click += simpleButton1_Click;
            // 
            // simpleButton2
            // 
            simpleButton2.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("simpleButton2.ImageOptions.Image");
            simpleButton2.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            simpleButton2.ImageOptions.ImageToTextIndent = 15;
            simpleButton2.ImageOptions.ImageUri.Uri = "Cancel";
            simpleButton2.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            simpleButton2.Location = new System.Drawing.Point(256, 0);
            simpleButton2.Margin = new System.Windows.Forms.Padding(64, 4, 64, 4);
            simpleButton2.MaximumSize = new System.Drawing.Size(129, 36);
            simpleButton2.MinimumSize = new System.Drawing.Size(129, 36);
            simpleButton2.Name = "simpleButton2";
            simpleButton2.Size = new System.Drawing.Size(129, 36);
            simpleButton2.TabIndex = 18;
            simpleButton2.Text = "Hủy";
            simpleButton2.Click += simpleButton2_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(cb_tdv);
            panel2.Controls.Add(cb_lnl);
            panel2.Controls.Add(txt_ntr);
            panel2.Controls.Add(txt_thttt);
            panel2.Controls.Add(txt_tnl);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(lb_tnl);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(lb_thttt);
            panel2.Controls.Add(lb_tdv);
            panel2.Controls.Add(lb_lnl);
            panel2.Controls.Add(lb_ntr);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label4);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(64, 30);
            panel2.Margin = new System.Windows.Forms.Padding(4);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(448, 381);
            panel2.TabIndex = 19;
            // 
            // cb_tdv
            // 
            cb_tdv.Location = new System.Drawing.Point(190, 285);
            cb_tdv.Margin = new System.Windows.Forms.Padding(4);
            cb_tdv.MaximumSize = new System.Drawing.Size(257, 36);
            cb_tdv.MinimumSize = new System.Drawing.Size(257, 36);
            cb_tdv.Name = "cb_tdv";
            cb_tdv.Properties.Appearance.Options.UseFont = true;
            cb_tdv.Properties.AutoHeight = false;
            cb_tdv.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cb_tdv.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            cb_tdv.Size = new System.Drawing.Size(257, 36);
            cb_tdv.TabIndex = 23;
            // 
            // cb_lnl
            // 
            cb_lnl.Location = new System.Drawing.Point(190, 214);
            cb_lnl.Margin = new System.Windows.Forms.Padding(4);
            cb_lnl.MaximumSize = new System.Drawing.Size(257, 36);
            cb_lnl.MinimumSize = new System.Drawing.Size(257, 36);
            cb_lnl.Name = "cb_lnl";
            cb_lnl.Properties.Appearance.Options.UseFont = true;
            cb_lnl.Properties.AutoHeight = false;
            cb_lnl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cb_lnl.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            cb_lnl.Size = new System.Drawing.Size(257, 36);
            cb_lnl.TabIndex = 22;
            // 
            // txt_ntr
            // 
            txt_ntr.Location = new System.Drawing.Point(190, 142);
            txt_ntr.Margin = new System.Windows.Forms.Padding(4);
            txt_ntr.MaximumSize = new System.Drawing.Size(257, 36);
            txt_ntr.MinimumSize = new System.Drawing.Size(257, 36);
            txt_ntr.Name = "txt_ntr";
            txt_ntr.Properties.Appearance.Options.UseFont = true;
            txt_ntr.Properties.AutoHeight = false;
            txt_ntr.Size = new System.Drawing.Size(257, 36);
            txt_ntr.TabIndex = 21;
            // 
            // txt_thttt
            // 
            txt_thttt.Location = new System.Drawing.Point(190, 71);
            txt_thttt.Margin = new System.Windows.Forms.Padding(4);
            txt_thttt.MaximumSize = new System.Drawing.Size(257, 36);
            txt_thttt.MinimumSize = new System.Drawing.Size(257, 36);
            txt_thttt.Name = "txt_thttt";
            txt_thttt.Properties.Appearance.Options.UseFont = true;
            txt_thttt.Properties.AutoHeight = false;
            txt_thttt.Size = new System.Drawing.Size(257, 36);
            txt_thttt.TabIndex = 20;
            // 
            // txt_tnl
            // 
            txt_tnl.Location = new System.Drawing.Point(189, 0);
            txt_tnl.Margin = new System.Windows.Forms.Padding(4);
            txt_tnl.MaximumSize = new System.Drawing.Size(257, 36);
            txt_tnl.MinimumSize = new System.Drawing.Size(257, 36);
            txt_tnl.Name = "txt_tnl";
            txt_tnl.Properties.Appearance.Options.UseFont = true;
            txt_tnl.Properties.AutoHeight = false;
            txt_tnl.Size = new System.Drawing.Size(257, 36);
            txt_tnl.TabIndex = 19;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label3.Location = new System.Drawing.Point(0, 8);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(116, 19);
            label3.TabIndex = 4;
            label3.Text = "Tên nhiên liệu:";
            // 
            // lb_tnl
            // 
            lb_tnl.AutoSize = true;
            lb_tnl.ForeColor = System.Drawing.Color.Red;
            lb_tnl.Location = new System.Drawing.Point(189, 39);
            lb_tnl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lb_tnl.Name = "lb_tnl";
            lb_tnl.Size = new System.Drawing.Size(51, 19);
            lb_tnl.TabIndex = 8;
            lb_tnl.Text = "label7";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(0, 80);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(159, 19);
            label2.TabIndex = 3;
            label2.Text = "Tên hiện thị tiêu thụ:";
            // 
            // lb_thttt
            // 
            lb_thttt.AutoSize = true;
            lb_thttt.ForeColor = System.Drawing.Color.Red;
            lb_thttt.Location = new System.Drawing.Point(189, 110);
            lb_thttt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lb_thttt.Name = "lb_thttt";
            lb_thttt.Size = new System.Drawing.Size(51, 19);
            lb_thttt.TabIndex = 9;
            lb_thttt.Text = "label8";
            // 
            // lb_tdv
            // 
            lb_tdv.AutoSize = true;
            lb_tdv.ForeColor = System.Drawing.Color.Red;
            lb_tdv.Location = new System.Drawing.Point(190, 324);
            lb_tdv.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lb_tdv.Name = "lb_tdv";
            lb_tdv.Size = new System.Drawing.Size(51, 19);
            lb_tdv.TabIndex = 2;
            lb_tdv.Text = "label1";
            // 
            // lb_lnl
            // 
            lb_lnl.AutoSize = true;
            lb_lnl.ForeColor = System.Drawing.Color.Red;
            lb_lnl.Location = new System.Drawing.Point(190, 253);
            lb_lnl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lb_lnl.Name = "lb_lnl";
            lb_lnl.Size = new System.Drawing.Size(60, 19);
            lb_lnl.TabIndex = 11;
            lb_lnl.Text = "label10";
            // 
            // lb_ntr
            // 
            lb_ntr.AutoSize = true;
            lb_ntr.ForeColor = System.Drawing.Color.Red;
            lb_ntr.Location = new System.Drawing.Point(189, 182);
            lb_ntr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lb_ntr.Name = "lb_ntr";
            lb_ntr.Size = new System.Drawing.Size(51, 19);
            lb_ntr.TabIndex = 10;
            lb_ntr.Text = "label9";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label5.Location = new System.Drawing.Point(0, 151);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(113, 19);
            label5.TabIndex = 6;
            label5.Text = "Nhiệt trị riêng:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label6.Location = new System.Drawing.Point(0, 293);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(96, 19);
            label6.TabIndex = 7;
            label6.Text = "Tên đơn vị :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label4.Location = new System.Drawing.Point(-1, 222);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(118, 19);
            label4.TabIndex = 5;
            label4.Text = "Loai nhiên liệu:";
            // 
            // FormNhienLieu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(576, 477);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Margin = new System.Windows.Forms.Padding(4);
            Name = "FormNhienLieu";
            Padding = new System.Windows.Forms.Padding(64, 30, 64, 30);
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "FormNhienLieu";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cb_tdv.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cb_lnl.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txt_ntr.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txt_thttt.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txt_tnl.Properties).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lb_lnl;
        private System.Windows.Forms.Label lb_ntr;
        private System.Windows.Forms.Label lb_thttt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_tdv;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.TextEdit txt_tnl;
        private System.Windows.Forms.Label lb_tnl;
        private DevExpress.XtraEditors.TextEdit txt_ntr;
        private DevExpress.XtraEditors.TextEdit txt_thttt;
        private DevExpress.XtraEditors.ComboBoxEdit cb_lnl;
        private DevExpress.XtraEditors.ComboBoxEdit cb_tdv;
    }
}