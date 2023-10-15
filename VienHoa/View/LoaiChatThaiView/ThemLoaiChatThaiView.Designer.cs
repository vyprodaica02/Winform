namespace VienHoa.View
{
    partial class ThemLoaiChatThaiView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThemLoaiChatThaiView));
            panel1 = new System.Windows.Forms.Panel();
            labelLoaiChatThai = new System.Windows.Forms.Label();
            textEditTenLoaiChatThai = new DevExpress.XtraEditors.TextEdit();
            label2 = new System.Windows.Forms.Label();
            btnHuy = new DevExpress.XtraEditors.SimpleButton();
            btnThem = new DevExpress.XtraEditors.SimpleButton();
            panel2 = new System.Windows.Forms.Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)textEditTenLoaiChatThai.Properties).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(labelLoaiChatThai);
            panel1.Controls.Add(textEditTenLoaiChatThai);
            panel1.Controls.Add(label2);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(50, 25);
            panel1.Margin = new System.Windows.Forms.Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(348, 328);
            panel1.TabIndex = 3;
            // 
            // labelLoaiChatThai
            // 
            labelLoaiChatThai.AutoSize = true;
            labelLoaiChatThai.ForeColor = System.Drawing.Color.Red;
            labelLoaiChatThai.Location = new System.Drawing.Point(148, 34);
            labelLoaiChatThai.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelLoaiChatThai.Name = "labelLoaiChatThai";
            labelLoaiChatThai.Size = new System.Drawing.Size(0, 16);
            labelLoaiChatThai.TabIndex = 4;
            // 
            // textEditTenLoaiChatThai
            // 
            textEditTenLoaiChatThai.Location = new System.Drawing.Point(148, 0);
            textEditTenLoaiChatThai.Margin = new System.Windows.Forms.Padding(41, 4, 4, 4);
            textEditTenLoaiChatThai.MaximumSize = new System.Drawing.Size(200, 30);
            textEditTenLoaiChatThai.MinimumSize = new System.Drawing.Size(200, 30);
            textEditTenLoaiChatThai.Name = "textEditTenLoaiChatThai";
            textEditTenLoaiChatThai.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textEditTenLoaiChatThai.Properties.Appearance.Options.UseFont = true;
            textEditTenLoaiChatThai.Properties.AutoHeight = false;
            textEditTenLoaiChatThai.Size = new System.Drawing.Size(200, 30);
            textEditTenLoaiChatThai.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(0, 7);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(116, 17);
            label2.TabIndex = 2;
            label2.Text = "Tên loại chất thải:";
            // 
            // btnHuy
            // 
            btnHuy.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("btnHuy.ImageOptions.Image");
            btnHuy.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            btnHuy.ImageOptions.ImageToTextIndent = 15;
            btnHuy.Location = new System.Drawing.Point(199, 0);
            btnHuy.Margin = new System.Windows.Forms.Padding(58, 4, 4, 4);
            btnHuy.MaximumSize = new System.Drawing.Size(100, 30);
            btnHuy.MinimumSize = new System.Drawing.Size(100, 30);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new System.Drawing.Size(100, 30);
            btnHuy.TabIndex = 5;
            btnHuy.Text = "Hủy";
            btnHuy.Click += btnHuy_Click;
            // 
            // btnThem
            // 
            btnThem.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("btnThem.ImageOptions.Image");
            btnThem.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            btnThem.ImageOptions.ImageToTextIndent = 15;
            btnThem.Location = new System.Drawing.Point(50, 0);
            btnThem.Margin = new System.Windows.Forms.Padding(58, 4, 4, 4);
            btnThem.MaximumSize = new System.Drawing.Size(100, 30);
            btnThem.MinimumSize = new System.Drawing.Size(100, 30);
            btnThem.Name = "btnThem";
            btnThem.Size = new System.Drawing.Size(100, 30);
            btnThem.TabIndex = 4;
            btnThem.Text = "Thêm";
            btnThem.Click += btnThem_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnHuy);
            panel2.Controls.Add(btnThem);
            panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel2.Location = new System.Drawing.Point(50, 323);
            panel2.Margin = new System.Windows.Forms.Padding(4);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(348, 30);
            panel2.TabIndex = 4;
            // 
            // ThemLoaiChatThaiView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(448, 378);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new System.Windows.Forms.Padding(4);
            Name = "ThemLoaiChatThaiView";
            Padding = new System.Windows.Forms.Padding(50, 25, 50, 25);
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "ThemLoaiChatThaiView";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)textEditTenLoaiChatThai.Properties).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnHuy;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private DevExpress.XtraEditors.TextEdit textEditTenLoaiChatThai;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelLoaiChatThai;
    }
}