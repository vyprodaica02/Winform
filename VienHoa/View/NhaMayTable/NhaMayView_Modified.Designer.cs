namespace VienHoa.View
{
    partial class NhaMayView_Modified
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NhaMayView_Modified));
            HeaderPanel = new System.Windows.Forms.Panel();
            AddFunc = new DevExpress.XtraEditors.SimpleButton();
            textEdit1 = new DevExpress.XtraEditors.TextEdit();
            nhaMayTbl = new DevExpress.XtraGrid.GridControl();
            factorView = new DevExpress.XtraGrid.Views.Grid.GridView();
            panel1 = new System.Windows.Forms.Panel();
            imageCollection1 = new DevExpress.Utils.ImageCollection(components);
            HeaderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)textEdit1.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nhaMayTbl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)factorView).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)imageCollection1).BeginInit();
            SuspendLayout();
            // 
            // HeaderPanel
            // 
            HeaderPanel.Controls.Add(AddFunc);
            HeaderPanel.Controls.Add(textEdit1);
            HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            HeaderPanel.Location = new System.Drawing.Point(0, 0);
            HeaderPanel.Margin = new System.Windows.Forms.Padding(2);
            HeaderPanel.Name = "HeaderPanel";
            HeaderPanel.Size = new System.Drawing.Size(788, 50);
            HeaderPanel.TabIndex = 0;
            // 
            // AddFunc
            // 
            AddFunc.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("AddFunc.ImageOptions.Image");
            AddFunc.Location = new System.Drawing.Point(692, 9);
            AddFunc.Margin = new System.Windows.Forms.Padding(2);
            AddFunc.Name = "AddFunc";
            AddFunc.Size = new System.Drawing.Size(78, 33);
            AddFunc.TabIndex = 1;
            AddFunc.Text = "Thêm";
            // 
            // textEdit1
            // 
            textEdit1.Location = new System.Drawing.Point(38, 15);
            textEdit1.Margin = new System.Windows.Forms.Padding(2);
            textEdit1.Name = "textEdit1";
            textEdit1.Properties.AutoHeight = false;
            textEdit1.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            textEdit1.Properties.ContextImageOptions.Image = (System.Drawing.Image)resources.GetObject("textEdit1.Properties.ContextImageOptions.Image");
            textEdit1.Size = new System.Drawing.Size(225, 22);
            textEdit1.TabIndex = 0;
            // 
            // nhaMayTbl
            // 
            nhaMayTbl.Dock = System.Windows.Forms.DockStyle.Fill;
            nhaMayTbl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            nhaMayTbl.Location = new System.Drawing.Point(0, 0);
            nhaMayTbl.MainView = factorView;
            nhaMayTbl.Margin = new System.Windows.Forms.Padding(2);
            nhaMayTbl.Name = "nhaMayTbl";
            nhaMayTbl.Size = new System.Drawing.Size(788, 414);
            nhaMayTbl.TabIndex = 1;
            nhaMayTbl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { factorView });
            // 
            // factorView
            // 
            factorView.DetailHeight = 294;
            factorView.GridControl = nhaMayTbl;
            factorView.Name = "factorView";
            factorView.OptionsView.ShowIndicator = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(nhaMayTbl);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 50);
            panel1.Margin = new System.Windows.Forms.Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(788, 414);
            panel1.TabIndex = 2;
            // 
            // imageCollection1
            // 
            imageCollection1.ImageStream = (DevExpress.Utils.ImageCollectionStreamer)resources.GetObject("imageCollection1.ImageStream");
            imageCollection1.Images.SetKeyName(0, "edit_16x16.png");
            imageCollection1.Images.SetKeyName(1, "cancel_16x16.png");
            // 
            // NhaMayView_Modified
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(788, 464);
            Controls.Add(panel1);
            Controls.Add(HeaderPanel);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Margin = new System.Windows.Forms.Padding(2);
            Name = "NhaMayView_Modified";
            Text = "NhaMayView_Modified";
            HeaderPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)textEdit1.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)nhaMayTbl).EndInit();
            ((System.ComponentModel.ISupportInitialize)factorView).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)imageCollection1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel HeaderPanel;
        private DevExpress.XtraGrid.GridControl nhaMayTbl;
        private DevExpress.XtraGrid.Views.Grid.GridView factorView;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.SimpleButton AddFunc;
        private DevExpress.Utils.ImageCollection imageCollection1;
    }
}