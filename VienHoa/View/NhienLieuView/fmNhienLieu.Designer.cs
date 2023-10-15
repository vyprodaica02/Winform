namespace VienHoa.View
{
    partial class fmNhienLieu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmNhienLieu));
            panel1 = new System.Windows.Forms.Panel();
            nhienLieutbl = new DevExpress.XtraGrid.GridControl();
            gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            imageCollection1 = new DevExpress.Utils.ImageCollection(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nhienLieutbl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imageCollection1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(nhienLieutbl);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(448, 260);
            panel1.TabIndex = 0;
            // 
            // nhienLieutbl
            // 
            nhienLieutbl.Dock = System.Windows.Forms.DockStyle.Fill;
            nhienLieutbl.Location = new System.Drawing.Point(0, 0);
            nhienLieutbl.MainView = gridView2;
            nhienLieutbl.Name = "nhienLieutbl";
            nhienLieutbl.Size = new System.Drawing.Size(448, 260);
            nhienLieutbl.TabIndex = 0;
            nhienLieutbl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView2 });
            // 
            // gridView2
            // 
            gridView2.GridControl = nhienLieutbl;
            gridView2.Name = "gridView2";
            gridView2.RowCellClick += gridView2_RowCellClick_1;
            // 
            // imageCollection1
            // 
            imageCollection1.ImageStream = (DevExpress.Utils.ImageCollectionStreamer)resources.GetObject("imageCollection1.ImageStream");
            imageCollection1.Images.SetKeyName(0, "cancel_16x16.png");
            imageCollection1.Images.SetKeyName(1, "edit_16x16.png");
            // 
            // fmNhienLieu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(448, 260);
            Controls.Add(panel1);
            Name = "fmNhienLieu";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "fmNhienLieu";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nhienLieutbl).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)imageCollection1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.GridControl nhienLieutbl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.Utils.ImageCollection imageCollection1;
    }
}