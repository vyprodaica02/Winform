namespace VienHoa.View.NhaMayTable
{
    partial class AddLoaiNM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddLoaiNM));
            ConfirmOK = new DevExpress.XtraEditors.SimpleButton();
            ConfirmCancel = new DevExpress.XtraEditors.SimpleButton();
            FactorTypeName = new System.Windows.Forms.Label();
            errorType = new System.Windows.Forms.Label();
            TenLoaiNm = new DevExpress.XtraEditors.TextEdit();
            panel1 = new System.Windows.Forms.Panel();
            panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)TenLoaiNm.Properties).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // ConfirmOK
            // 
            ConfirmOK.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("ConfirmOK.ImageOptions.Image");
            ConfirmOK.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            ConfirmOK.ImageOptions.ImageToTextIndent = 15;
            ConfirmOK.Location = new System.Drawing.Point(50, 0);
            ConfirmOK.Margin = new System.Windows.Forms.Padding(2);
            ConfirmOK.MaximumSize = new System.Drawing.Size(100, 30);
            ConfirmOK.MinimumSize = new System.Drawing.Size(100, 30);
            ConfirmOK.Name = "ConfirmOK";
            ConfirmOK.Size = new System.Drawing.Size(100, 30);
            ConfirmOK.TabIndex = 6;
            ConfirmOK.Text = "Thêm";
            ConfirmOK.Click += ConfirmOK_Click;
            // 
            // ConfirmCancel
            // 
            ConfirmCancel.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("ConfirmCancel.ImageOptions.Image");
            ConfirmCancel.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            ConfirmCancel.ImageOptions.ImageToTextIndent = 20;
            ConfirmCancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            ConfirmCancel.Location = new System.Drawing.Point(199, 0);
            ConfirmCancel.Margin = new System.Windows.Forms.Padding(2);
            ConfirmCancel.Name = "ConfirmCancel";
            ConfirmCancel.Size = new System.Drawing.Size(100, 30);
            ConfirmCancel.TabIndex = 7;
            ConfirmCancel.Text = "Hủy";
            ConfirmCancel.Click += ConfirmCancel_Click;
            // 
            // FactorTypeName
            // 
            FactorTypeName.AutoSize = true;
            FactorTypeName.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            FactorTypeName.Location = new System.Drawing.Point(0, 7);
            FactorTypeName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            FactorTypeName.Name = "FactorTypeName";
            FactorTypeName.Size = new System.Drawing.Size(98, 17);
            FactorTypeName.TabIndex = 1;
            FactorTypeName.Text = "Loại Nhà Máy: ";
            // 
            // errorType
            // 
            errorType.AutoSize = true;
            errorType.ForeColor = System.Drawing.Color.Red;
            errorType.Location = new System.Drawing.Point(148, 33);
            errorType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            errorType.Name = "errorType";
            errorType.Size = new System.Drawing.Size(41, 16);
            errorType.TabIndex = 9;
            errorType.Text = "label1";
            errorType.Visible = false;
            // 
            // TenLoaiNm
            // 
            TenLoaiNm.Location = new System.Drawing.Point(148, 0);
            TenLoaiNm.Margin = new System.Windows.Forms.Padding(2, 2, 2, 3);
            TenLoaiNm.MaximumSize = new System.Drawing.Size(200, 30);
            TenLoaiNm.MinimumSize = new System.Drawing.Size(200, 30);
            TenLoaiNm.Name = "TenLoaiNm";
            TenLoaiNm.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            TenLoaiNm.Properties.Appearance.Options.UseFont = true;
            TenLoaiNm.Properties.AutoHeight = false;
            TenLoaiNm.Size = new System.Drawing.Size(200, 30);
            TenLoaiNm.TabIndex = 10;
            // 
            // panel1
            // 
            panel1.Controls.Add(ConfirmCancel);
            panel1.Controls.Add(ConfirmOK);
            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.Location = new System.Drawing.Point(50, 335);
            panel1.Margin = new System.Windows.Forms.Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(348, 30);
            panel1.TabIndex = 11;
            // 
            // panel2
            // 
            panel2.Controls.Add(TenLoaiNm);
            panel2.Controls.Add(FactorTypeName);
            panel2.Controls.Add(errorType);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(50, 25);
            panel2.Margin = new System.Windows.Forms.Padding(4);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(348, 310);
            panel2.TabIndex = 12;
            // 
            // AddLoaiNM
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(448, 390);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Margin = new System.Windows.Forms.Padding(2);
            Name = "AddLoaiNM";
            Padding = new System.Windows.Forms.Padding(50, 25, 50, 25);
            Text = "Thêm Loại Nhà Máy";
            ((System.ComponentModel.ISupportInitialize)TenLoaiNm.Properties).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton ConfirmOK;
        private DevExpress.XtraEditors.SimpleButton ConfirmCancel;
        private System.Windows.Forms.Label FactorTypeName;
        private System.Windows.Forms.Label errorType;
        private DevExpress.XtraEditors.TextEdit TenLoaiNm;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }

}