namespace VienHoa.View
{
    partial class LoaiChatThaiView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoaiChatThaiView));
            LoaiChatThaiTbl = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            loaiChatThaiBindingSource = new System.Windows.Forms.BindingSource(components);
            imageCollection1 = new DevExpress.Utils.ImageCollection(components);
            ((System.ComponentModel.ISupportInitialize)LoaiChatThaiTbl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)loaiChatThaiBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imageCollection1).BeginInit();
            SuspendLayout();
            // 
            // LoaiChatThaiTbl
            // 
            LoaiChatThaiTbl.Dock = System.Windows.Forms.DockStyle.Fill;
            LoaiChatThaiTbl.Location = new System.Drawing.Point(0, 0);
            LoaiChatThaiTbl.MainView = gridView1;
            LoaiChatThaiTbl.Name = "LoaiChatThaiTbl";
            LoaiChatThaiTbl.Size = new System.Drawing.Size(1022, 736);
            LoaiChatThaiTbl.TabIndex = 1;
            LoaiChatThaiTbl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // gridView1
            // 
            gridView1.GridControl = LoaiChatThaiTbl;
            gridView1.Name = "gridView1";
            gridView1.OptionsView.ShowIndicator = false;
            // 
            // loaiChatThaiBindingSource
            // 
            loaiChatThaiBindingSource.DataSource = typeof(Entity.LoaiChatThai);
            // 
            // imageCollection1
            // 
            imageCollection1.ImageStream = (DevExpress.Utils.ImageCollectionStreamer)resources.GetObject("imageCollection1.ImageStream");
            imageCollection1.Images.SetKeyName(0, "edit_16x16.png");
            imageCollection1.Images.SetKeyName(1, "cancel_16x16.png");
            // 
            // LoaiChatThaiView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1022, 736);
            Controls.Add(LoaiChatThaiTbl);
            Name = "LoaiChatThaiView";
            Text = "LoaiChatThaiView";
            Load += LoaiChatThaiView_Load;
            ((System.ComponentModel.ISupportInitialize)LoaiChatThaiTbl).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)loaiChatThaiBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)imageCollection1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DevExpress.XtraGrid.GridControl LoaiChatThaiTbl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource loaiChatThaiBindingSource;
        private DevExpress.Utils.ImageCollection imageCollection1;
    }
}