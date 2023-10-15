namespace VienHoa.View
{
    partial class FormDuAnView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDuAnView));
            tblDuAn = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            imageCollection1 = new DevExpress.Utils.ImageCollection(components);
            ((System.ComponentModel.ISupportInitialize)tblDuAn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imageCollection1).BeginInit();
            SuspendLayout();
            // 
            // tblDuAn
            // 
            tblDuAn.Dock = System.Windows.Forms.DockStyle.Fill;
            tblDuAn.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            tblDuAn.Location = new System.Drawing.Point(0, 0);
            tblDuAn.MainView = gridView1;
            tblDuAn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            tblDuAn.Name = "tblDuAn";
            tblDuAn.Size = new System.Drawing.Size(1314, 686);
            tblDuAn.TabIndex = 0;
            tblDuAn.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // gridView1
            // 
            gridView1.DetailHeight = 416;
            gridView1.GridControl = tblDuAn;
            gridView1.Name = "gridView1";
            gridView1.RowCellClick += gridView1_RowCellClick;
            // 
            // imageCollection1
            // 
            imageCollection1.ImageStream = (DevExpress.Utils.ImageCollectionStreamer)resources.GetObject("imageCollection1.ImageStream");
            imageCollection1.Images.SetKeyName(0, "edit_16x16.png");
            imageCollection1.Images.SetKeyName(1, "cancel_16x16.png");
            // 
            // FormDuAnView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1314, 686);
            Controls.Add(tblDuAn);
            Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            Name = "FormDuAnView";
            Text = "FormDuAnView";
            Load += FormDuAnView_Load;
            ((System.ComponentModel.ISupportInitialize)tblDuAn).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)imageCollection1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraGrid.GridControl gridControlDuAn;
        private DevExpress.XtraGrid.GridControl tblDuAn;
    }
}