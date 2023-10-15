namespace VienHoa.View.NhaMayTable
{
    partial class AddLoaiLN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddLoaiLN));
            ConfirmOK = new DevExpress.XtraEditors.SimpleButton();
            ConfirmCancel = new DevExpress.XtraEditors.SimpleButton();
            OvenTypeName = new System.Windows.Forms.Label();
            errLoaiLN = new System.Windows.Forms.Label();
            TenLoaiLn = new DevExpress.XtraEditors.TextEdit();
            panel1 = new System.Windows.Forms.Panel();
            panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)TenLoaiLn.Properties).BeginInit();
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
            ConfirmCancel.ImageOptions.ImageToTextIndent = 15;
            ConfirmCancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            ConfirmCancel.Location = new System.Drawing.Point(199, 0);
            ConfirmCancel.Margin = new System.Windows.Forms.Padding(2);
            ConfirmCancel.MaximumSize = new System.Drawing.Size(100, 30);
            ConfirmCancel.MinimumSize = new System.Drawing.Size(100, 30);
            ConfirmCancel.Name = "ConfirmCancel";
            ConfirmCancel.Size = new System.Drawing.Size(100, 30);
            ConfirmCancel.TabIndex = 7;
            ConfirmCancel.Text = "Hủy";
            ConfirmCancel.Click += ConfirmCancel_Click;
            // 
            // OvenTypeName
            // 
            OvenTypeName.AutoSize = true;
            OvenTypeName.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            OvenTypeName.Location = new System.Drawing.Point(0, 7);
            OvenTypeName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            OvenTypeName.Name = "OvenTypeName";
            OvenTypeName.Size = new System.Drawing.Size(97, 17);
            OvenTypeName.TabIndex = 1;
            OvenTypeName.Text = "Loại Lò Nung: ";
            // 
            // errLoaiLN
            // 
            errLoaiLN.AutoSize = true;
            errLoaiLN.ForeColor = System.Drawing.Color.Red;
            errLoaiLN.Location = new System.Drawing.Point(148, 33);
            errLoaiLN.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            errLoaiLN.Name = "errLoaiLN";
            errLoaiLN.Size = new System.Drawing.Size(41, 16);
            errLoaiLN.TabIndex = 9;
            errLoaiLN.Text = "label1";
            errLoaiLN.Visible = false;
            // 
            // TenLoaiLn
            // 
            TenLoaiLn.Location = new System.Drawing.Point(148, 0);
            TenLoaiLn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 3);
            TenLoaiLn.MaximumSize = new System.Drawing.Size(200, 30);
            TenLoaiLn.MinimumSize = new System.Drawing.Size(200, 30);
            TenLoaiLn.Name = "TenLoaiLn";
            TenLoaiLn.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            TenLoaiLn.Properties.Appearance.Options.UseFont = true;
            TenLoaiLn.Properties.AutoHeight = false;
            TenLoaiLn.Size = new System.Drawing.Size(200, 30);
            TenLoaiLn.TabIndex = 10;
            // 
            // panel1
            // 
            panel1.Controls.Add(ConfirmOK);
            panel1.Controls.Add(ConfirmCancel);
            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.Location = new System.Drawing.Point(50, 307);
            panel1.Margin = new System.Windows.Forms.Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(348, 30);
            panel1.TabIndex = 11;
            // 
            // panel2
            // 
            panel2.Controls.Add(TenLoaiLn);
            panel2.Controls.Add(OvenTypeName);
            panel2.Controls.Add(errLoaiLN);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(50, 25);
            panel2.Margin = new System.Windows.Forms.Padding(4);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(348, 282);
            panel2.TabIndex = 12;
            // 
            // AddLoaiLN
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(448, 362);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Margin = new System.Windows.Forms.Padding(2);
            Name = "AddLoaiLN";
            Padding = new System.Windows.Forms.Padding(50, 25, 50, 25);
            Text = "AddLoaiLN";
            ((System.ComponentModel.ISupportInitialize)TenLoaiLn.Properties).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton ConfirmOK;
        private DevExpress.XtraEditors.SimpleButton ConfirmCancel;
        private System.Windows.Forms.Label OvenTypeName;
        private System.Windows.Forms.Label errLoaiLN;
        private DevExpress.XtraEditors.TextEdit TenLoaiLn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}