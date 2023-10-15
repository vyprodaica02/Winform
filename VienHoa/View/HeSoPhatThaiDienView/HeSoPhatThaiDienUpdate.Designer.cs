namespace VienHoa.View
{
    partial class HeSoPhatThaiDienUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HeSoPhatThaiDienUpdate));
            errorNam = new System.Windows.Forms.Label();
            errorKhiPhatThai = new System.Windows.Forms.Label();
            cbbKhiPhatThai = new DevExpress.XtraEditors.ComboBoxEdit();
            lbNam = new System.Windows.Forms.Label();
            txtNam = new DevExpress.XtraEditors.TextEdit();
            lbKhiPhatThai = new System.Windows.Forms.Label();
            panel1 = new System.Windows.Forms.Panel();
            errorGiaTri = new System.Windows.Forms.Label();
            lbGiaTri = new System.Windows.Forms.Label();
            txtGiaTri = new DevExpress.XtraEditors.TextEdit();
            panel2 = new System.Windows.Forms.Panel();
            btnCancel = new DevExpress.XtraEditors.SimpleButton();
            btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)cbbKhiPhatThai.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtNam.Properties).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtGiaTri.Properties).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // errorNam
            // 
            errorNam.ForeColor = System.Drawing.Color.Red;
            errorNam.Location = new System.Drawing.Point(123, 75);
            errorNam.Name = "errorNam";
            errorNam.Size = new System.Drawing.Size(171, 16);
            errorNam.TabIndex = 4;
            errorNam.Text = "error";
            errorNam.Visible = false;
            // 
            // errorKhiPhatThai
            // 
            errorKhiPhatThai.BackColor = System.Drawing.Color.Transparent;
            errorKhiPhatThai.ForeColor = System.Drawing.Color.Red;
            errorKhiPhatThai.Location = new System.Drawing.Point(123, 26);
            errorKhiPhatThai.Name = "errorKhiPhatThai";
            errorKhiPhatThai.Size = new System.Drawing.Size(171, 16);
            errorKhiPhatThai.TabIndex = 4;
            errorKhiPhatThai.Text = "error";
            errorKhiPhatThai.Visible = false;
            // 
            // cbbKhiPhatThai
            // 
            cbbKhiPhatThai.Location = new System.Drawing.Point(123, 0);
            cbbKhiPhatThai.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            cbbKhiPhatThai.MaximumSize = new System.Drawing.Size(171, 24);
            cbbKhiPhatThai.MinimumSize = new System.Drawing.Size(171, 24);
            cbbKhiPhatThai.Name = "cbbKhiPhatThai";
            cbbKhiPhatThai.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cbbKhiPhatThai.Properties.Appearance.Options.UseFont = true;
            cbbKhiPhatThai.Properties.AutoHeight = false;
            cbbKhiPhatThai.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cbbKhiPhatThai.Properties.Name = "cbbKhiPhatThai";
            cbbKhiPhatThai.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            cbbKhiPhatThai.Size = new System.Drawing.Size(171, 24);
            cbbKhiPhatThai.TabIndex = 0;
            // 
            // lbNam
            // 
            lbNam.AutoSize = true;
            lbNam.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lbNam.Location = new System.Drawing.Point(0, 54);
            lbNam.Name = "lbNam";
            lbNam.Size = new System.Drawing.Size(32, 13);
            lbNam.TabIndex = 1;
            lbNam.Text = "Năm:";
            // 
            // txtNam
            // 
            txtNam.Location = new System.Drawing.Point(123, 49);
            txtNam.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            txtNam.MaximumSize = new System.Drawing.Size(171, 24);
            txtNam.MinimumSize = new System.Drawing.Size(171, 24);
            txtNam.Name = "txtNam";
            txtNam.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtNam.Properties.Appearance.Options.UseFont = true;
            txtNam.Properties.AutoHeight = false;
            txtNam.Properties.Name = "txtNam";
            txtNam.Size = new System.Drawing.Size(171, 24);
            txtNam.TabIndex = 1;
            // 
            // lbKhiPhatThai
            // 
            lbKhiPhatThai.AutoSize = true;
            lbKhiPhatThai.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lbKhiPhatThai.Location = new System.Drawing.Point(0, 6);
            lbKhiPhatThai.Name = "lbKhiPhatThai";
            lbKhiPhatThai.Size = new System.Drawing.Size(71, 13);
            lbKhiPhatThai.TabIndex = 1;
            lbKhiPhatThai.Text = "Khí phát thải:";
            // 
            // panel1
            // 
            panel1.Controls.Add(lbKhiPhatThai);
            panel1.Controls.Add(errorGiaTri);
            panel1.Controls.Add(errorNam);
            panel1.Controls.Add(cbbKhiPhatThai);
            panel1.Controls.Add(errorKhiPhatThai);
            panel1.Controls.Add(lbGiaTri);
            panel1.Controls.Add(txtGiaTri);
            panel1.Controls.Add(lbNam);
            panel1.Controls.Add(txtNam);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(43, 20);
            panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(295, 187);
            panel1.TabIndex = 5;
            // 
            // errorGiaTri
            // 
            errorGiaTri.ForeColor = System.Drawing.Color.Red;
            errorGiaTri.Location = new System.Drawing.Point(123, 124);
            errorGiaTri.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            errorGiaTri.Name = "errorGiaTri";
            errorGiaTri.Size = new System.Drawing.Size(171, 16);
            errorGiaTri.TabIndex = 4;
            errorGiaTri.Text = "error";
            errorGiaTri.Visible = false;
            // 
            // lbGiaTri
            // 
            lbGiaTri.AutoSize = true;
            lbGiaTri.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lbGiaTri.Location = new System.Drawing.Point(0, 104);
            lbGiaTri.Name = "lbGiaTri";
            lbGiaTri.Size = new System.Drawing.Size(39, 13);
            lbGiaTri.TabIndex = 1;
            lbGiaTri.Text = "Giá trị:";
            // 
            // txtGiaTri
            // 
            txtGiaTri.Location = new System.Drawing.Point(123, 98);
            txtGiaTri.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            txtGiaTri.MaximumSize = new System.Drawing.Size(171, 24);
            txtGiaTri.MinimumSize = new System.Drawing.Size(171, 24);
            txtGiaTri.Name = "txtGiaTri";
            txtGiaTri.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtGiaTri.Properties.Appearance.Options.UseFont = true;
            txtGiaTri.Properties.AutoHeight = false;
            txtGiaTri.Size = new System.Drawing.Size(171, 24);
            txtGiaTri.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnCancel);
            panel2.Controls.Add(btnUpdate);
            panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel2.Location = new System.Drawing.Point(43, 183);
            panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(295, 24);
            panel2.TabIndex = 6;
            // 
            // btnCancel
            // 
            btnCancel.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("btnCancel.ImageOptions.Image");
            btnCancel.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            btnCancel.ImageOptions.ImageToTextIndent = 15;
            btnCancel.Location = new System.Drawing.Point(171, 0);
            btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            btnCancel.MaximumSize = new System.Drawing.Size(86, 24);
            btnCancel.MinimumSize = new System.Drawing.Size(86, 24);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(86, 24);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Hủy";
            btnCancel.Click += btnCancel_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("btnUpdate.ImageOptions.Image");
            btnUpdate.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            btnUpdate.ImageOptions.ImageToTextIndent = 15;
            btnUpdate.Location = new System.Drawing.Point(42, 0);
            btnUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            btnUpdate.MaximumSize = new System.Drawing.Size(86, 24);
            btnUpdate.MinimumSize = new System.Drawing.Size(86, 24);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new System.Drawing.Size(86, 24);
            btnUpdate.TabIndex = 3;
            btnUpdate.Text = "Sửa";
            btnUpdate.Click += btnUpdate_Click;
            // 
            // HeSoPhatThaiDienUpdate
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(381, 227);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Name = "HeSoPhatThaiDienUpdate";
            Padding = new System.Windows.Forms.Padding(43, 20, 43, 20);
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Sửa dữ liệu";
            Load += HeSoPhatThaiDienAdd_Load;
            ((System.ComponentModel.ISupportInitialize)cbbKhiPhatThai.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtNam.Properties).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtGiaTri.Properties).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private DevExpress.XtraEditors.ComboBoxEdit cbbKhiPhatThai;
        private System.Windows.Forms.Label lbNam;
        private DevExpress.XtraEditors.TextEdit txtNam;
        private System.Windows.Forms.Label lbKhiPhatThai;
        private System.Windows.Forms.Label errorKhiPhatThai;
        private System.Windows.Forms.Label errorNam;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private System.Windows.Forms.Label errorGiaTri;
        private System.Windows.Forms.Label lbGiaTri;
        private DevExpress.XtraEditors.TextEdit txtGiaTri;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
    }
}