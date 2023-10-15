namespace VienHoa.View
{
    partial class ChatThaiView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatThaiView));
            panel1 = new System.Windows.Forms.Panel();
            btnThem = new DevExpress.XtraEditors.SimpleButton();
            textEdit1 = new DevExpress.XtraEditors.TextEdit();
            chatThaiBindingSource = new System.Windows.Forms.BindingSource(components);
            imageCollection1 = new DevExpress.Utils.ImageCollection(components);
            ChatThaiTbl = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)textEdit1.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chatThaiBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imageCollection1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ChatThaiTbl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnThem);
            panel1.Controls.Add(textEdit1);
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(1022, 60);
            panel1.TabIndex = 0;
            // 
            // btnThem
            // 
            btnThem.Location = new System.Drawing.Point(0, 0);
            btnThem.Name = "btnThem";
            btnThem.Size = new System.Drawing.Size(75, 23);
            btnThem.TabIndex = 0;
            // 
            // textEdit1
            // 
            textEdit1.Location = new System.Drawing.Point(12, 22);
            textEdit1.Name = "textEdit1";
            textEdit1.Properties.AutoHeight = false;
            textEdit1.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            textEdit1.Properties.ContextImageOptions.Image = (System.Drawing.Image)resources.GetObject("textEdit1.Properties.ContextImageOptions.Image");
            textEdit1.Size = new System.Drawing.Size(200, 25);
            textEdit1.TabIndex = 4;
            // 
            // chatThaiBindingSource
            // 
            chatThaiBindingSource.DataSource = typeof(Entity.ChatThai);
            // 
            // imageCollection1
            // 
            imageCollection1.ImageStream = (DevExpress.Utils.ImageCollectionStreamer)resources.GetObject("imageCollection1.ImageStream");
            imageCollection1.Images.SetKeyName(0, "cancel_16x16.png");
            imageCollection1.Images.SetKeyName(1, "edit_16x16.png");
            // 
            // ChatThaiTbl
            // 
            ChatThaiTbl.Dock = System.Windows.Forms.DockStyle.Fill;
            ChatThaiTbl.Location = new System.Drawing.Point(0, 60);
            ChatThaiTbl.MainView = gridView1;
            ChatThaiTbl.Name = "ChatThaiTbl";
            ChatThaiTbl.Size = new System.Drawing.Size(1022, 676);
            ChatThaiTbl.TabIndex = 1;
            ChatThaiTbl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // gridView1
            // 
            gridView1.GridControl = ChatThaiTbl;
            gridView1.Name = "gridView1";
            // 
            // ChatThaiView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1022, 736);
            Controls.Add(ChatThaiTbl);
            Controls.Add(panel1);
            Name = "ChatThaiView";
            Text = "ChatThaiView";
            Load += ChatThaiView_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)textEdit1.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)chatThaiBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)imageCollection1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ChatThaiTbl).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingSource chatThaiBindingSource;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraGrid.GridControl ChatThaiTbl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}