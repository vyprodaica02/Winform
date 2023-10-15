namespace VienHoa.View
{
    partial class SuaLoaiChatThaiView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SuaLoaiChatThaiView));
            panel1 = new System.Windows.Forms.Panel();
            label1 = new System.Windows.Forms.Label();
            labelLoaiChatThai = new System.Windows.Forms.Label();
            btnHuy = new DevExpress.XtraEditors.SimpleButton();
            btnSua = new DevExpress.XtraEditors.SimpleButton();
            textEditTenLoaiChatThai = new DevExpress.XtraEditors.TextEdit();
            label2 = new System.Windows.Forms.Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)textEditTenLoaiChatThai.Properties).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(labelLoaiChatThai);
            panel1.Controls.Add(btnHuy);
            panel1.Controls.Add(btnSua);
            panel1.Controls.Add(textEditTenLoaiChatThai);
            panel1.Controls.Add(label2);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(43, 20);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(298, 95);
            panel1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = System.Drawing.Color.Red;
            label1.Location = new System.Drawing.Point(127, 27);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(0, 13);
            label1.TabIndex = 7;
            // 
            // labelLoaiChatThai
            // 
            labelLoaiChatThai.AutoSize = true;
            labelLoaiChatThai.ForeColor = System.Drawing.Color.Red;
            labelLoaiChatThai.Location = new System.Drawing.Point(127, 27);
            labelLoaiChatThai.Name = "labelLoaiChatThai";
            labelLoaiChatThai.Size = new System.Drawing.Size(0, 13);
            labelLoaiChatThai.TabIndex = 6;
            // 
            // btnHuy
            // 
            btnHuy.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("btnHuy.ImageOptions.Image");
            btnHuy.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            btnHuy.ImageOptions.ImageToTextIndent = 15;
            btnHuy.Location = new System.Drawing.Point(171, 68);
            btnHuy.Margin = new System.Windows.Forms.Padding(50, 3, 3, 3);
            btnHuy.MaximumSize = new System.Drawing.Size(86, 24);
            btnHuy.MinimumSize = new System.Drawing.Size(86, 24);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new System.Drawing.Size(86, 24);
            btnHuy.TabIndex = 5;
            btnHuy.Text = "Hủy";
            btnHuy.Click += btnHuy_Click;
            // 
            // btnSua
            // 
            btnSua.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("btnSua.ImageOptions.Image");
            btnSua.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            btnSua.ImageOptions.ImageToTextIndent = 15;
            btnSua.Location = new System.Drawing.Point(43, 68);
            btnSua.Margin = new System.Windows.Forms.Padding(50, 3, 3, 3);
            btnSua.MaximumSize = new System.Drawing.Size(86, 24);
            btnSua.MinimumSize = new System.Drawing.Size(86, 24);
            btnSua.Name = "btnSua";
            btnSua.Size = new System.Drawing.Size(86, 24);
            btnSua.TabIndex = 4;
            btnSua.Text = "Sửa";
            btnSua.Click += btnSua_Click;
            // 
            // textEditTenLoaiChatThai
            // 
            textEditTenLoaiChatThai.Location = new System.Drawing.Point(127, 0);
            textEditTenLoaiChatThai.Margin = new System.Windows.Forms.Padding(3, 3, 3, 41);
            textEditTenLoaiChatThai.MaximumSize = new System.Drawing.Size(171, 24);
            textEditTenLoaiChatThai.MinimumSize = new System.Drawing.Size(171, 24);
            textEditTenLoaiChatThai.Name = "textEditTenLoaiChatThai";
            textEditTenLoaiChatThai.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textEditTenLoaiChatThai.Properties.Appearance.Options.UseFont = true;
            textEditTenLoaiChatThai.Properties.AutoHeight = false;
            textEditTenLoaiChatThai.Size = new System.Drawing.Size(171, 24);
            textEditTenLoaiChatThai.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(0, 6);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(93, 13);
            label2.TabIndex = 2;
            label2.Text = "Tên loại chất thải:";
            // 
            // SuaLoaiChatThaiView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(384, 135);
            Controls.Add(panel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Name = "SuaLoaiChatThaiView";
            Padding = new System.Windows.Forms.Padding(43, 20, 43, 20);
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "SuaLoaiChatThaiView";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)textEditTenLoaiChatThai.Properties).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnHuy;
        private DevExpress.XtraEditors.SimpleButton btnSua;
        private DevExpress.XtraEditors.TextEdit textEditTenLoaiChatThai;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelLoaiChatThai;
        private System.Windows.Forms.Label label1;
    }
}