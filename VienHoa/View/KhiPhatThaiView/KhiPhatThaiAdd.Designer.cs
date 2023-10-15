namespace VienHoa.View
{
    partial class KhiPhatThaiAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KhiPhatThaiAdd));
            lbTenKhi = new System.Windows.Forms.Label();
            txtTenKhi = new DevExpress.XtraEditors.TextEdit();
            panel1 = new System.Windows.Forms.Panel();
            btnCancel = new DevExpress.XtraEditors.SimpleButton();
            btnAdd = new DevExpress.XtraEditors.SimpleButton();
            panel2 = new System.Windows.Forms.Panel();
            errorTenKhi = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)txtTenKhi.Properties).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // lbTenKhi
            // 
            lbTenKhi.AutoSize = true;
            lbTenKhi.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lbTenKhi.Location = new System.Drawing.Point(0, 7);
            lbTenKhi.Margin = new System.Windows.Forms.Padding(4, 0, 35, 0);
            lbTenKhi.Name = "lbTenKhi";
            lbTenKhi.Size = new System.Drawing.Size(57, 17);
            lbTenKhi.TabIndex = 0;
            lbTenKhi.Text = "Tên khí:";
            // 
            // txtTenKhi
            // 
            txtTenKhi.Location = new System.Drawing.Point(144, 0);
            txtTenKhi.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            txtTenKhi.MaximumSize = new System.Drawing.Size(200, 30);
            txtTenKhi.MinimumSize = new System.Drawing.Size(200, 30);
            txtTenKhi.Name = "txtTenKhi";
            txtTenKhi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtTenKhi.Properties.Appearance.Options.UseFont = true;
            txtTenKhi.Properties.AutoHeight = false;
            txtTenKhi.Size = new System.Drawing.Size(200, 30);
            txtTenKhi.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnCancel);
            panel1.Controls.Add(btnAdd);
            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.Location = new System.Drawing.Point(50, 205);
            panel1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(344, 30);
            panel1.TabIndex = 2;
            // 
            // btnCancel
            // 
            btnCancel.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("btnCancel.ImageOptions.Image");
            btnCancel.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            btnCancel.ImageOptions.ImageToTextIndent = 15;
            btnCancel.Location = new System.Drawing.Point(200, 0);
            btnCancel.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            btnCancel.MaximumSize = new System.Drawing.Size(100, 30);
            btnCancel.MinimumSize = new System.Drawing.Size(100, 30);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(100, 30);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Hủy";
            btnCancel.Click += btnCancel_Click;
            // 
            // btnAdd
            // 
            btnAdd.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("btnAdd.ImageOptions.Image");
            btnAdd.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            btnAdd.ImageOptions.ImageToTextIndent = 15;
            btnAdd.Location = new System.Drawing.Point(49, 0);
            btnAdd.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            btnAdd.MaximumSize = new System.Drawing.Size(100, 30);
            btnAdd.MinimumSize = new System.Drawing.Size(100, 30);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(100, 30);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Thêm";
            btnAdd.Click += btnAdd_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(errorTenKhi);
            panel2.Controls.Add(lbTenKhi);
            panel2.Controls.Add(txtTenKhi);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(50, 25);
            panel2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(344, 180);
            panel2.TabIndex = 3;
            // 
            // errorTenKhi
            // 
            errorTenKhi.AutoSize = true;
            errorTenKhi.ForeColor = System.Drawing.Color.Red;
            errorTenKhi.Location = new System.Drawing.Point(144, 32);
            errorTenKhi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            errorTenKhi.Name = "errorTenKhi";
            errorTenKhi.Size = new System.Drawing.Size(36, 16);
            errorTenKhi.TabIndex = 2;
            errorTenKhi.Text = "error";
            errorTenKhi.Visible = false;
            // 
            // KhiPhatThaiAdd
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(444, 260);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            Name = "KhiPhatThaiAdd";
            Padding = new System.Windows.Forms.Padding(50, 25, 50, 25);
            Text = "KhiPhatThaiAdd";
            ((System.ComponentModel.ISupportInitialize)txtTenKhi.Properties).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lbTenKhi;
        private DevExpress.XtraEditors.TextEdit txtTenKhi;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label errorTenKhi;
    }
}