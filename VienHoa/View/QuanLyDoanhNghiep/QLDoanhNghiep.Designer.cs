using DevExpress.Data;
using System;

namespace VienHoa.View
{
    partial class QLDoanhNghiep
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QLDoanhNghiep));
            panel1 = new System.Windows.Forms.Panel();
            panel3 = new System.Windows.Forms.Panel();
            tbleDoanhNghiep = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            imageCollection1 = new DevExpress.Utils.ImageCollection(components);
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbleDoanhNghiep).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imageCollection1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel3);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Margin = new System.Windows.Forms.Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(794, 607);
            panel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(tbleDoanhNghiep);
            panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            panel3.Location = new System.Drawing.Point(0, 0);
            panel3.Margin = new System.Windows.Forms.Padding(2);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(794, 607);
            panel3.TabIndex = 1;
            // 
            // tbleDoanhNghiep
            // 
            tbleDoanhNghiep.Dock = System.Windows.Forms.DockStyle.Fill;
            tbleDoanhNghiep.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            tbleDoanhNghiep.Location = new System.Drawing.Point(0, 0);
            tbleDoanhNghiep.MainView = gridView1;
            tbleDoanhNghiep.Margin = new System.Windows.Forms.Padding(2);
            tbleDoanhNghiep.Name = "tbleDoanhNghiep";
            tbleDoanhNghiep.Size = new System.Drawing.Size(794, 607);
            tbleDoanhNghiep.TabIndex = 0;
            tbleDoanhNghiep.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // gridView1
            // 
            gridView1.DetailHeight = 294;
            gridView1.GridControl = tbleDoanhNghiep;
            gridView1.Name = "gridView1";
            gridView1.OptionsBehavior.AllowIncrementalSearch = true;
            gridView1.OptionsCustomization.CustomizationFormSearchBoxVisible = true;
            gridView1.OptionsFind.SearchInPreview = true;
            gridView1.OptionsView.ShowIndicator = false;
            gridView1.CustomUnboundColumnData += gridView1_CustomUnboundColumnData;
            // 
            // imageCollection1
            // 
            imageCollection1.ImageStream = (DevExpress.Utils.ImageCollectionStreamer)resources.GetObject("imageCollection1.ImageStream");
            imageCollection1.Images.SetKeyName(0, "update");
            imageCollection1.Images.SetKeyName(1, "delete");
            // 
            // QLDoanhNghiep
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(794, 607);
            Controls.Add(panel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Margin = new System.Windows.Forms.Padding(2);
            Name = "QLDoanhNghiep";
            Text = "QLDoanhNghiep";
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)tbleDoanhNghiep).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)imageCollection1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraGrid.GridControl tbleDoanhNghiep;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.Utils.ImageCollection imageCollection1;
    }
}