
namespace EasyDuplicateFinder.test
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.TxtBx_Path = new System.Windows.Forms.TextBox();
            this.Tv_Explorer = new System.Windows.Forms.TreeView();
            this.Tv_ImgList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // TxtBx_Path
            // 
            this.TxtBx_Path.Location = new System.Drawing.Point(21, 13);
            this.TxtBx_Path.Name = "TxtBx_Path";
            this.TxtBx_Path.Size = new System.Drawing.Size(379, 23);
            this.TxtBx_Path.TabIndex = 3;
            // 
            // Tv_Explorer
            // 
            this.Tv_Explorer.Location = new System.Drawing.Point(12, 53);
            this.Tv_Explorer.Name = "Tv_Explorer";
            this.Tv_Explorer.Size = new System.Drawing.Size(397, 385);
            this.Tv_Explorer.TabIndex = 2;
            // 
            // Tv_ImgList
            // 
            this.Tv_ImgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.Tv_ImgList.ImageSize = new System.Drawing.Size(16, 16);
            this.Tv_ImgList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 450);
            this.Controls.Add(this.TxtBx_Path);
            this.Controls.Add(this.Tv_Explorer);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox TxtBx_Path;
        internal System.Windows.Forms.TreeView Tv_Explorer;
        internal System.Windows.Forms.ImageList Tv_ImgList;
    }
}