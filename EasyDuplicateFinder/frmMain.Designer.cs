
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
            components = new System.ComponentModel.Container();
            tabControl1 = new System.Windows.Forms.TabControl();
            tabPage1 = new System.Windows.Forms.TabPage();
            listView1 = new System.Windows.Forms.ListView();
            clPath = new System.Windows.Forms.ColumnHeader();
            panel1 = new System.Windows.Forms.Panel();
            button3 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            button1 = new System.Windows.Forms.Button();
            treeViewDirectory1 = new TreeViewDirectory();
            tabPage2 = new System.Windows.Forms.TabPage();
            dataGridView1 = new System.Windows.Forms.DataGridView();
            panel3 = new System.Windows.Forms.Panel();
            lblTime = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            button5 = new System.Windows.Forms.Button();
            button4 = new System.Windows.Forms.Button();
            timer1 = new System.Windows.Forms.Timer(components);
            myProgressBar1 = new clss.MyProgressBar();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            panel1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl1.Location = new System.Drawing.Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(1442, 581);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(listView1);
            tabPage1.Controls.Add(panel1);
            tabPage1.Controls.Add(treeViewDirectory1);
            tabPage1.Location = new System.Drawing.Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new System.Windows.Forms.Padding(3);
            tabPage1.Size = new System.Drawing.Size(1434, 553);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Path";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            listView1.AllowDrop = true;
            listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { clPath });
            listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            listView1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            listView1.Location = new System.Drawing.Point(731, 3);
            listView1.Name = "listView1";
            listView1.Size = new System.Drawing.Size(700, 547);
            listView1.TabIndex = 2;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = System.Windows.Forms.View.Details;
            listView1.Click += listView1_Click;
            listView1.DragDrop += listView1_DragDrop;
            listView1.DragEnter += listView1_DragEnter;
            // 
            // clPath
            // 
            clPath.Text = "Path";
            clPath.Width = 500;
            // 
            // panel1
            // 
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Dock = System.Windows.Forms.DockStyle.Left;
            panel1.Location = new System.Drawing.Point(598, 3);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(133, 547);
            panel1.TabIndex = 1;
            // 
            // button3
            // 
            button3.BackgroundImage = Properties.Resources._118917_edit_clear_icon;
            button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            button3.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button3.Location = new System.Drawing.Point(6, 278);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(121, 120);
            button3.TabIndex = 2;
            button3.Text = "Clear";
            button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.BackgroundImage = Properties.Resources._48768_delete_folder_icon;
            button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            button2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button2.Location = new System.Drawing.Point(6, 152);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(121, 120);
            button2.TabIndex = 1;
            button2.Text = "Remove";
            button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackgroundImage = Properties.Resources._48767_add_folder_icon;
            button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            button1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button1.Location = new System.Drawing.Point(6, 26);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(121, 120);
            button1.TabIndex = 0;
            button1.Text = "Add";
            button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // treeViewDirectory1
            // 
            treeViewDirectory1.Dock = System.Windows.Forms.DockStyle.Left;
            treeViewDirectory1.ImageIndex = 0;
            treeViewDirectory1.Location = new System.Drawing.Point(3, 3);
            treeViewDirectory1.Name = "treeViewDirectory1";
            treeViewDirectory1.SelectedImageIndex = 0;
            treeViewDirectory1.Size = new System.Drawing.Size(595, 547);
            treeViewDirectory1.TabIndex = 3;
            treeViewDirectory1.BeforeSelect += treeViewDirectory1_BeforeSelect;
            treeViewDirectory1.MouseClick += treeViewDirectory1_MouseClick;
            treeViewDirectory1.MouseDown += treeViewDirectory1_MouseDown;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dataGridView1);
            tabPage2.Controls.Add(panel3);
            tabPage2.Location = new System.Drawing.Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new System.Windows.Forms.Padding(3);
            tabPage2.Size = new System.Drawing.Size(1434, 553);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "FindDuplicate";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            dataGridView1.Location = new System.Drawing.Point(3, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new System.Drawing.Size(1428, 413);
            dataGridView1.TabIndex = 2;
            dataGridView1.DataBindingComplete += dataGridView1_DataBindingComplete;
            dataGridView1.Sorted += dataGridView1_Sorted;
            // 
            // panel3
            // 
            panel3.Controls.Add(myProgressBar1);
            panel3.Controls.Add(lblTime);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(button5);
            panel3.Controls.Add(button4);
            panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel3.Location = new System.Drawing.Point(3, 416);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(1428, 134);
            panel3.TabIndex = 1;
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.BackColor = System.Drawing.Color.FromArgb(255, 224, 192);
            lblTime.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblTime.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
            lblTime.Location = new System.Drawing.Point(248, 40);
            lblTime.Name = "lblTime";
            lblTime.Size = new System.Drawing.Size(112, 32);
            lblTime.TabIndex = 5;
            lblTime.Text = "00:00:00";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(248, 3);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(52, 21);
            label1.TabIndex = 3;
            label1.Text = "Status";
            // 
            // button5
            // 
            button5.BackgroundImage = Properties.Resources._48768_delete_folder_icon;
            button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            button5.Dock = System.Windows.Forms.DockStyle.Left;
            button5.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button5.Location = new System.Drawing.Point(121, 0);
            button5.Name = "button5";
            button5.Size = new System.Drawing.Size(121, 134);
            button5.TabIndex = 2;
            button5.Text = "Delete";
            button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.BackgroundImage = Properties.Resources._48770_folder_search_icon;
            button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            button4.Dock = System.Windows.Forms.DockStyle.Left;
            button4.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button4.Location = new System.Drawing.Point(0, 0);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(121, 134);
            button4.TabIndex = 1;
            button4.Text = "Find Dup";
            button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // myProgressBar1
            // 
            myProgressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            myProgressBar1.Location = new System.Drawing.Point(242, 75);
            myProgressBar1.Name = "myProgressBar1";
            myProgressBar1.Size = new System.Drawing.Size(1186, 59);
            myProgressBar1.TabIndex = 6;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1442, 581);
            Controls.Add(tabControl1);
            Name = "frmMain";
            Text = "Duplicate Finder by TOR";
            Load += frmMain_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
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


        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private TreeViewDirectory treeViewDirectory1;
        private clss.MyProgressBar myProgressBar1;
    }
}