namespace VienHoa.View
{
    partial class SanPhamView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SanPhamView));
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            panel1 = new System.Windows.Forms.Panel();
            simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            txSearch = new DevExpress.XtraEditors.ButtonEdit();
            panel2 = new System.Windows.Forms.Panel();
            gridControlDataSP = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            imageCollection1 = new DevExpress.Utils.ImageCollection(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txSearch.Properties).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridControlDataSP).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imageCollection1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.White;
            panel1.Controls.Add(simpleButton1);
            panel1.Controls.Add(txSearch);
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(1002, 60);
            panel1.TabIndex = 0;
            // 
            // simpleButton1
            // 
            simpleButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            simpleButton1.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("simpleButton1.ImageOptions.Image");
            simpleButton1.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            simpleButton1.Location = new System.Drawing.Point(936, 16);
            simpleButton1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            simpleButton1.Name = "simpleButton1";
            simpleButton1.Size = new System.Drawing.Size(58, 26);
            simpleButton1.TabIndex = 2;
            simpleButton1.Text = "Thêm";
            simpleButton1.Click += simpleButton1_Click;
            // 
            // txSearch
            // 
            txSearch.Location = new System.Drawing.Point(12, 12);
            txSearch.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            txSearch.Name = "txSearch";
            txSearch.Properties.AutoHeight = false;
            txSearch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            editorButtonImageOptions1.Image = (System.Drawing.Image)resources.GetObject("editorButtonImageOptions1.Image");
            txSearch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default) });
            txSearch.Size = new System.Drawing.Size(240, 39);
            txSearch.TabIndex = 0;
            txSearch.ButtonClick += txSearch_ButtonClick;
            // 
            // panel2
            // 
            panel2.Controls.Add(gridControlDataSP);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(0, 60);
            panel2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(1002, 438);
            panel2.TabIndex = 1;
            // 
            // gridControlDataSP
            // 
            gridControlDataSP.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            gridControlDataSP.Location = new System.Drawing.Point(0, 10);
            gridControlDataSP.MainView = gridView1;
            gridControlDataSP.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            gridControlDataSP.Name = "gridControlDataSP";
            gridControlDataSP.Size = new System.Drawing.Size(1002, 398);
            gridControlDataSP.TabIndex = 0;
            gridControlDataSP.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // gridView1
            // 
            gridView1.GridControl = gridControlDataSP;
            gridView1.Name = "gridView1";
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.RowCellClick += gridView1_RowCellClick;
            // 
            // imageCollection1
            // 
            imageCollection1.ImageStream = (DevExpress.Utils.ImageCollectionStreamer)resources.GetObject("imageCollection1.ImageStream");
            imageCollection1.Images.SetKeyName(0, "cancel_16x16.png");
            imageCollection1.Images.SetKeyName(1, "edit_16x16.png");
            imageCollection1.Images.SetKeyName(2, "viewmergeddata_16x16.png");
            // 
            // SanPhamView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1002, 498);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            Name = "SanPhamView";
            Text = "Sản phẩm";
            Load += SanPhamView_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txSearch.Properties).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridControlDataSP).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)imageCollection1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraGrid.GridControl gridControlDataSP;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.ButtonEdit txSearch;
    }
}