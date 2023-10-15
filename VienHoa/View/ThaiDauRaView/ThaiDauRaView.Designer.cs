namespace VienHoa.View
{
    partial class ThaiDauRaView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThaiDauRaView));
            panel1 = new System.Windows.Forms.Panel();
            btnThem = new DevExpress.XtraEditors.SimpleButton();
            textEdit1 = new DevExpress.XtraEditors.TextEdit();
            tblThaiDauRa = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            imageCollection1 = new DevExpress.Utils.ImageCollection(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)textEdit1.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tblThaiDauRa).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imageCollection1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnThem);
            panel1.Controls.Add(textEdit1);
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Margin = new System.Windows.Forms.Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(1192, 74);
            panel1.TabIndex = 0;
            // 
            // btnThem
            // 
            btnThem.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("btnThem.ImageOptions.Image");
            btnThem.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            btnThem.ImageOptions.ImageToTextIndent = 15;
            btnThem.Location = new System.Drawing.Point(1062, 15);
            btnThem.Margin = new System.Windows.Forms.Padding(4);
            btnThem.Name = "btnThem";
            btnThem.Size = new System.Drawing.Size(117, 49);
            btnThem.TabIndex = 7;
            btnThem.Text = "Thêm";
            btnThem.Click += btnThem_Click;
            // 
            // textEdit1
            // 
            textEdit1.Location = new System.Drawing.Point(14, 27);
            textEdit1.Margin = new System.Windows.Forms.Padding(4);
            textEdit1.Name = "textEdit1";
            textEdit1.Properties.AutoHeight = false;
            textEdit1.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            textEdit1.Properties.ContextImageOptions.Image = (System.Drawing.Image)resources.GetObject("textEdit1.Properties.ContextImageOptions.Image");
            textEdit1.Size = new System.Drawing.Size(233, 31);
            textEdit1.TabIndex = 6;
            // 
            // tblThaiDauRa
            // 
            tblThaiDauRa.Dock = System.Windows.Forms.DockStyle.Fill;
            tblThaiDauRa.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            tblThaiDauRa.Location = new System.Drawing.Point(0, 74);
            tblThaiDauRa.MainView = gridView1;
            tblThaiDauRa.Margin = new System.Windows.Forms.Padding(4);
            tblThaiDauRa.Name = "tblThaiDauRa";
            tblThaiDauRa.Size = new System.Drawing.Size(1192, 832);
            tblThaiDauRa.TabIndex = 1;
            tblThaiDauRa.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // gridView1
            // 
            gridView1.DetailHeight = 431;
            gridView1.GridControl = tblThaiDauRa;
            gridView1.Name = "gridView1";
            // 
            // imageCollection1
            // 
            imageCollection1.ImageStream = (DevExpress.Utils.ImageCollectionStreamer)resources.GetObject("imageCollection1.ImageStream");
            imageCollection1.Images.SetKeyName(0, "cancel_16x16.png");
            imageCollection1.Images.SetKeyName(1, "edit_16x16.png");
            // 
            // ThaiDauRaView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1192, 906);
            Controls.Add(tblThaiDauRa);
            Controls.Add(panel1);
            Margin = new System.Windows.Forms.Padding(4);
            Name = "ThaiDauRaView";
            Text = "ThaiDauRaView";
            Load += ThaiDauRaView_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)textEdit1.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)tblThaiDauRa).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)imageCollection1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private DevExpress.XtraGrid.GridControl tblThaiDauRa;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.Utils.ImageCollection imageCollection1;
    }
}