﻿
namespace EasyDuplicateFinder
{
    partial class frmMain
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.clPath = new System.Windows.Forms.ColumnHeader();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.treeViewDirectory1 = new EasyDuplicateFinder.TreeViewDirectory();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblTime = new System.Windows.Forms.Label();
            this.myProgressBar1 = new EasyDuplicateFinder.clss.MyProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1442, 581);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.treeViewDirectory1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1434, 553);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Path";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.AllowDrop = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clPath});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(775, 3);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(656, 547);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.Click += new System.EventHandler(this.listView1_Click);
            this.listView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView1_DragDrop);
            this.listView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView1_DragEnter);
            // 
            // clPath
            // 
            this.clPath.Text = "Path";
            this.clPath.Width = 500;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(642, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(133, 547);
            this.panel1.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::EasyDuplicateFinder.Properties.Resources._118917_edit_clear_icon;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button3.Location = new System.Drawing.Point(6, 278);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(121, 120);
            this.button3.TabIndex = 2;
            this.button3.Text = "Clear";
            this.button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::EasyDuplicateFinder.Properties.Resources._48768_delete_folder_icon;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.Location = new System.Drawing.Point(6, 152);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 120);
            this.button2.TabIndex = 1;
            this.button2.Text = "Remove";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::EasyDuplicateFinder.Properties.Resources._48767_add_folder_icon;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(6, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 120);
            this.button1.TabIndex = 0;
            this.button1.Text = "Add";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // treeViewDirectory1
            // 
            this.treeViewDirectory1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeViewDirectory1.ImageIndex = 0;
            this.treeViewDirectory1.Location = new System.Drawing.Point(3, 3);
            this.treeViewDirectory1.Name = "treeViewDirectory1";
            this.treeViewDirectory1.SelectedImageIndex = 0;
            this.treeViewDirectory1.Size = new System.Drawing.Size(639, 547);
            this.treeViewDirectory1.TabIndex = 3;
            this.treeViewDirectory1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewDirectory1_NodeMouseClick);
            this.treeViewDirectory1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeViewDirectory1_MouseClick);
            this.treeViewDirectory1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeViewDirectory1_MouseDown);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1434, 553);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "FindDuplicate";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(1428, 427);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            this.dataGridView1.Sorted += new System.EventHandler(this.dataGridView1_Sorted);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblTime);
            this.panel3.Controls.Add(this.myProgressBar1);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.button5);
            this.panel3.Controls.Add(this.button4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(3, 430);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1428, 120);
            this.panel3.TabIndex = 1;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.lblTime.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblTime.Location = new System.Drawing.Point(248, 40);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(112, 32);
            this.lblTime.TabIndex = 5;
            this.lblTime.Text = "00:00:00";
            // 
            // myProgressBar1
            // 
            this.myProgressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.myProgressBar1.Location = new System.Drawing.Point(242, 75);
            this.myProgressBar1.Name = "myProgressBar1";
            this.myProgressBar1.Size = new System.Drawing.Size(1186, 45);
            this.myProgressBar1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(248, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Status";
            // 
            // button5
            // 
            this.button5.BackgroundImage = global::EasyDuplicateFinder.Properties.Resources._48768_delete_folder_icon;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button5.Dock = System.Windows.Forms.DockStyle.Left;
            this.button5.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button5.Location = new System.Drawing.Point(121, 0);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(121, 120);
            this.button5.TabIndex = 2;
            this.button5.Text = "Delete";
            this.button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.BackgroundImage = global::EasyDuplicateFinder.Properties.Resources._48770_folder_search_icon;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button4.Dock = System.Windows.Forms.DockStyle.Left;
            this.button4.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button4.Location = new System.Drawing.Point(0, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(121, 120);
            this.button4.TabIndex = 1;
            this.button4.Text = "Find Dup";
            this.button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1442, 581);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmMain";
            this.Text = "Duplicate Finder by TOR";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader clPath;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;

        private TreeViewDirectory treeViewDirectory1;
        private clss.MyProgressBar myProgressBar1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
    }
}