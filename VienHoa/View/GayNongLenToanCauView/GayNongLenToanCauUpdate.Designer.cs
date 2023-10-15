namespace VienHoa.View
{
    partial class GayNongLenToanCauUpdate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GayNongLenToanCauUpdate));
            panel1 = new System.Windows.Forms.Panel();
            btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            btnCancel = new DevExpress.XtraEditors.SimpleButton();
            panel2 = new System.Windows.Forms.Panel();
            errorGiaTri = new System.Windows.Forms.Label();
            errorKhiPhatThai = new System.Windows.Forms.Label();
            cbbKhiPhatThai = new DevExpress.XtraEditors.ComboBoxEdit();
            lbGiaTri = new System.Windows.Forms.Label();
            txtGiaTri = new DevExpress.XtraEditors.TextEdit();
            lbKhiPhatThai = new System.Windows.Forms.Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cbbKhiPhatThai.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtGiaTri.Properties).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnUpdate);
            panel1.Controls.Add(btnCancel);
            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.Location = new System.Drawing.Point(50, 167);
            panel1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(344, 30);
            panel1.TabIndex = 0;
            // 
            // btnUpdate
            // 
            btnUpdate.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("btnUpdate.ImageOptions.Image");
            btnUpdate.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            btnUpdate.ImageOptions.ImageToTextIndent = 15;
            btnUpdate.Location = new System.Drawing.Point(50, 0);
            btnUpdate.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            btnUpdate.MaximumSize = new System.Drawing.Size(100, 30);
            btnUpdate.MinimumSize = new System.Drawing.Size(100, 30);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new System.Drawing.Size(100, 30);
            btnUpdate.TabIndex = 2;
            btnUpdate.Text = "Sửa";
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnCancel
            // 
            btnCancel.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("btnCancel.ImageOptions.Image");
            btnCancel.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            btnCancel.ImageOptions.ImageToTextIndent = 15;
            btnCancel.Location = new System.Drawing.Point(199, 0);
            btnCancel.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            btnCancel.MaximumSize = new System.Drawing.Size(100, 30);
            btnCancel.MinimumSize = new System.Drawing.Size(100, 30);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(100, 30);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Hủy";
            btnCancel.Click += btnCancel_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(errorGiaTri);
            panel2.Controls.Add(errorKhiPhatThai);
            panel2.Controls.Add(cbbKhiPhatThai);
            panel2.Controls.Add(lbGiaTri);
            panel2.Controls.Add(txtGiaTri);
            panel2.Controls.Add(lbKhiPhatThai);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(50, 25);
            panel2.Margin = new System.Windows.Forms.Padding(0);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(344, 142);
            panel2.TabIndex = 0;
            // 
            // errorGiaTri
            // 
            errorGiaTri.ForeColor = System.Drawing.Color.Red;
            errorGiaTri.Location = new System.Drawing.Point(144, 92);
            errorGiaTri.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            errorGiaTri.Name = "errorGiaTri";
            errorGiaTri.Size = new System.Drawing.Size(200, 20);
            errorGiaTri.TabIndex = 4;
            errorGiaTri.Text = "error";
            errorGiaTri.Visible = false;
            // 
            // errorKhiPhatThai
            // 
            errorKhiPhatThai.ForeColor = System.Drawing.Color.Red;
            errorKhiPhatThai.Location = new System.Drawing.Point(144, 32);
            errorKhiPhatThai.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            errorKhiPhatThai.Name = "errorKhiPhatThai";
            errorKhiPhatThai.Size = new System.Drawing.Size(197, 20);
            errorKhiPhatThai.TabIndex = 4;
            errorKhiPhatThai.Text = "error";
            errorKhiPhatThai.Visible = false;
            // 
            // cbbKhiPhatThai
            // 
            cbbKhiPhatThai.Location = new System.Drawing.Point(144, 0);
            cbbKhiPhatThai.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            cbbKhiPhatThai.MaximumSize = new System.Drawing.Size(200, 30);
            cbbKhiPhatThai.MinimumSize = new System.Drawing.Size(200, 30);
            cbbKhiPhatThai.Name = "cbbKhiPhatThai";
            cbbKhiPhatThai.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cbbKhiPhatThai.Properties.Appearance.Options.UseFont = true;
            cbbKhiPhatThai.Properties.AutoHeight = false;
            cbbKhiPhatThai.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cbbKhiPhatThai.Properties.Name = "cbbKhiPhatThai";
            cbbKhiPhatThai.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            cbbKhiPhatThai.Size = new System.Drawing.Size(200, 30);
            cbbKhiPhatThai.TabIndex = 0;
            // 
            // lbGiaTri
            // 
            lbGiaTri.AutoSize = true;
            lbGiaTri.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lbGiaTri.Location = new System.Drawing.Point(0, 67);
            lbGiaTri.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbGiaTri.Name = "lbGiaTri";
            lbGiaTri.Size = new System.Drawing.Size(47, 17);
            lbGiaTri.TabIndex = 1;
            lbGiaTri.Text = "Giá trị:";
            // 
            // txtGiaTri
            // 
            txtGiaTri.Location = new System.Drawing.Point(144, 60);
            txtGiaTri.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            txtGiaTri.MaximumSize = new System.Drawing.Size(200, 30);
            txtGiaTri.MinimumSize = new System.Drawing.Size(200, 30);
            txtGiaTri.Name = "txtGiaTri";
            txtGiaTri.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtGiaTri.Properties.Appearance.Options.UseFont = true;
            txtGiaTri.Properties.AutoHeight = false;
            txtGiaTri.Size = new System.Drawing.Size(200, 30);
            txtGiaTri.TabIndex = 1;
            // 
            // lbKhiPhatThai
            // 
            lbKhiPhatThai.AutoSize = true;
            lbKhiPhatThai.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lbKhiPhatThai.Location = new System.Drawing.Point(0, 7);
            lbKhiPhatThai.Margin = new System.Windows.Forms.Padding(4, 0, 35, 0);
            lbKhiPhatThai.Name = "lbKhiPhatThai";
            lbKhiPhatThai.Size = new System.Drawing.Size(89, 17);
            lbKhiPhatThai.TabIndex = 1;
            lbKhiPhatThai.Text = "Khí phát thải:";
            // 
            // GayNongLenToanCauUpdate
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(444, 222);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            Name = "GayNongLenToanCauUpdate";
            Padding = new System.Windows.Forms.Padding(50, 25, 50, 25);
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Sửa dữ liệu";
            Load += GayNongLenToanCauUpdate_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cbbKhiPhatThai.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtGiaTri.Properties).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.ComboBoxEdit cbbKhiPhatThai;
        private System.Windows.Forms.Label lbGiaTri;
        private DevExpress.XtraEditors.TextEdit txtGiaTri;
        private System.Windows.Forms.Label lbKhiPhatThai;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private System.Windows.Forms.Label errorGiaTri;
        private System.Windows.Forms.Label errorKhiPhatThai;
    }
}