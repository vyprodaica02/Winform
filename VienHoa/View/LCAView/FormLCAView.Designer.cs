namespace VienHoa.View
{
    partial class FormLCAView
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
            panel2 = new System.Windows.Forms.Panel();
            btnSaveLCA = new DevExpress.XtraEditors.SimpleButton();
            btnCalcResult = new DevExpress.XtraEditors.SimpleButton();
            panelContainer = new System.Windows.Forms.Panel();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(btnSaveLCA);
            panel2.Controls.Add(btnCalcResult);
            panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel2.Location = new System.Drawing.Point(24, 829);
            panel2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            panel2.Name = "panel2";
            panel2.Padding = new System.Windows.Forms.Padding(0, 0, 40, 0);
            panel2.Size = new System.Drawing.Size(1395, 50);
            panel2.TabIndex = 1;
            // 
            // btnSaveLCA
            // 
            btnSaveLCA.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnSaveLCA.Location = new System.Drawing.Point(1083, 15);
            btnSaveLCA.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            btnSaveLCA.Name = "btnSaveLCA";
            btnSaveLCA.Size = new System.Drawing.Size(120, 34);
            btnSaveLCA.TabIndex = 1;
            btnSaveLCA.Text = "Lưu";
            btnSaveLCA.Visible = false;
            btnSaveLCA.Click += btnSaveLCA_Click;
            // 
            // btnCalcResult
            // 
            btnCalcResult.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnCalcResult.Location = new System.Drawing.Point(1235, 15);
            btnCalcResult.Margin = new System.Windows.Forms.Padding(30, 2, 4, 2);
            btnCalcResult.Name = "btnCalcResult";
            btnCalcResult.Size = new System.Drawing.Size(120, 34);
            btnCalcResult.TabIndex = 0;
            btnCalcResult.Text = "Kết quả tính toán";
            btnCalcResult.Click += btnCalcResult_Click;
            // 
            // panelContainer
            // 
            panelContainer.AutoScroll = true;
            panelContainer.AutoScrollMinSize = new System.Drawing.Size(0, 700);
            panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            panelContainer.Location = new System.Drawing.Point(24, 25);
            panelContainer.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            panelContainer.Name = "panelContainer";
            panelContainer.Padding = new System.Windows.Forms.Padding(24, 0, 24, 0);
            panelContainer.Size = new System.Drawing.Size(1395, 804);
            panelContainer.TabIndex = 2;
            // 
            // FormLCAView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1419, 904);
            Controls.Add(panelContainer);
            Controls.Add(panel2);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            MaximumSize = new System.Drawing.Size(1421, 944);
            Name = "FormLCAView";
            Padding = new System.Windows.Forms.Padding(24, 25, 0, 25);
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "FormLCAView";
            Load += FormLCAView_Load;
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelBody;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelContainer;
        private DevExpress.XtraEditors.SimpleButton btnCalcResult;
        private DevExpress.XtraEditors.SimpleButton btnSaveLCA;
    }
}