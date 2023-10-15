namespace VienHoa.View
{
    partial class HeSoPhatThaiDienView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HeSoPhatThaiDienView));
            GayNongLenToanCauTbl = new DevExpress.XtraGrid.GridControl();
            gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            buttonicon = new DevExpress.Utils.ImageCollection(components);
            ((System.ComponentModel.ISupportInitialize)GayNongLenToanCauTbl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)buttonicon).BeginInit();
            SuspendLayout();
            // 
            // GayNongLenToanCauTbl
            // 
            GayNongLenToanCauTbl.Dock = System.Windows.Forms.DockStyle.Fill;
            GayNongLenToanCauTbl.Location = new System.Drawing.Point(0, 0);
            GayNongLenToanCauTbl.MainView = gridView;
            GayNongLenToanCauTbl.Name = "GayNongLenToanCauTbl";
            GayNongLenToanCauTbl.Size = new System.Drawing.Size(1022, 510);
            GayNongLenToanCauTbl.TabIndex = 1;
            GayNongLenToanCauTbl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView });
            // 
            // gridView
            // 
            gridView.GridControl = GayNongLenToanCauTbl;
            gridView.Name = "gridView";
            gridView.OptionsView.ShowIndicator = false;
            gridView.CustomUnboundColumnData += gridView_CustomUnboundColumnData;
            // 
            // buttonicon
            // 
            buttonicon.ImageStream = (DevExpress.Utils.ImageCollectionStreamer)resources.GetObject("buttonicon.ImageStream");
            buttonicon.Images.SetKeyName(0, "edit_16x16.png");
            buttonicon.Images.SetKeyName(1, "cancel_16x16.png");
            // 
            // HeSoPhatThaiDienView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1022, 510);
            Controls.Add(GayNongLenToanCauTbl);
            Name = "HeSoPhatThaiDienView";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Hệ số phát thải điện";
            Load += GayNongLenToanCauView_Load;
            ((System.ComponentModel.ISupportInitialize)GayNongLenToanCauTbl).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)buttonicon).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.GridControl GayNongLenToanCauTbl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.TextEdit search;
        private DevExpress.Utils.ImageCollection buttonicon;
    }
}