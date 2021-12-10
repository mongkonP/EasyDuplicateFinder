using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.ListViewItem;

namespace EasyDuplicateFinder
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
          treeViewDirectory1.InitializeTreeViewDirectory();
            if (string.IsNullOrEmpty(Properties.Settings.Default.dirList))
            {
                Properties.Settings.Default.dirList.Split('_').ToList<string>()
                    .ForEach(cri => listView1.Items.Add(cri));


            }
        }

        
        bool CheckItem(string str)
        {
            bool b = false;

            try
            {
                if (listView1.Items[0].SubItems.Count > 0)
                {
                    for (int i = 0; i < listView1.Items[0].SubItems.Count; i++)
                    {
                        if (listView1.Items[0].SubItems[i].Text == str)
                        {
                            b = true;
                            return b;
                        }
                    }
                }
            }
            catch { }
          
            return b;
        }
        string dirListClick = "";
        private void listView1_Click(object sender, EventArgs e)
        {
            dirListClick = listView1.SelectedItems[0].Text;
         
        }
        private void button1_Click(object sender, EventArgs e)
        {


            if (!string.IsNullOrEmpty(treeViewDirectory1.TagSelect) && !CheckItem(treeViewDirectory1.TagSelect))
            {

                listView1.Items.Add(treeViewDirectory1.TagSelect);
                SetDirListview();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            if (listView1.Items.Count > 0)
            {
                foreach (ListViewItem item in listView1.Items)
                {
                   
                    if (item.Text == dirListClick)
                    {
                        listView1.Items.Remove(item);

                    }
                }
            }
            SetDirListview();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                listView1.Items.Clear();
                SetDirListview();
            }
            catch { }
        }

      void SetDirListview()
        {
            string listItem = "";
            try
            {
                foreach (ListViewItem item in listView1.Items)
                {

                    listItem += "_" + item.Text;
                }
            }
            catch { }
            Properties.Settings.Default.dirList = listItem;
            Properties.Settings.Default.Save();
        }

        void getFilesToDatagrid(string dir)
        {
            if (Directory.Exists(dir))
            {
                foreach (var f in Directory.GetFiles(dir, "*", SearchOption.AllDirectories))
                {
                    dataGridView1.Invoke(new Action(() =>
                    {
                        dataGridView1.Rows.Add(false, Path.GetFileName(f), f, new FileInfo(f).Length, File.GetLastWriteTime(f), Ext.CalculateMD5(f));
                    }));
                    label1.Invoke(new Action(() => label1.Text = "Adding:" + f));
                }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            List<string> dirs = new List<string>();
            foreach (ListViewItem item in listView1.Items)
            {
                dirs.Add(item.Text);
            }
       
            if (dirs.Count > 0)
            {
               
                Task.Factory.StartNew(() =>
                {
                    List<Task> tasks = new List<Task>();
                    LimitedConcurrencyLevelTaskScheduler lcts = new LimitedConcurrencyLevelTaskScheduler(10);
                    // Create a TaskFactory and pass it our custom scheduler.
                    TaskFactory factory = new TaskFactory(lcts);
                    CancellationTokenSource cts = new CancellationTokenSource();
                    List<string> files = new List<string>();
                    label1.Invoke(new Action(() => label1.Text = "Adding:Files" ));
                    dirs.ForEach(dir =>
                    {
                        tasks.Add(Task.Factory.StartNew(() => { files.AddRange(Directory.GetFiles(dir,"*",SearchOption.AllDirectories));}));
                    });

                    Task.WaitAll(tasks.ToArray());

                    cts.Dispose();
                    if (files.Count > 0)
                    {

                        myProgressBar1.Invoke(new Action(() => { myProgressBar1.Maximum = files.Count; myProgressBar1.Value = 0; }));
                        tasks = new List<Task>();
                        lcts = new LimitedConcurrencyLevelTaskScheduler(5);
                        // Create a TaskFactory and pass it our custom scheduler.
                      factory = new TaskFactory(lcts);
                         cts = new CancellationTokenSource();
                        files.ForEach(f =>
                        {
                           
                              tasks.Add(Task.Factory.StartNew(() => {

                                          System.Threading.Thread.Sleep(200);
                                          dataGridView1.Invoke(new Action(() =>
                                          {
                                              dataGridView1.Rows.Add(false, Path.GetFileName(f), f, new FileInfo(f).Length, File.GetLastWriteTime(f), Ext.CalculateMD5(f));
                                          }));
                                          label1.Invoke(new Action(() => label1.Text = "Adding:" + f));
                                 
                                      myProgressBar1.Invoke(new Action(() => {  myProgressBar1.Value ++; }));
                                 if(myProgressBar1.Value % 100 == 0)
                                      System.Threading.Thread.Sleep(2000);
                              }));
                        });


                        Task.WaitAll(tasks.ToArray());
                        cts.Dispose();
                        dataGridView1.Invoke(new Action(() =>
                        {
                            this.dataGridView1.Sort(this.dataGridView1.Columns[4], ListSortDirection.Ascending);

                            //Color cl1 = Color.Beige;
                            //Color cl2 = Color.LightGreen;
                            Color cl = Color.Beige;

                            string s1 = "";
                            string s2 = "";
                            try
                            {
                                for (int i = 1; i < dataGridView1.Rows.Count - 1; i++)
                                {
                                    s1 = dataGridView1[5, i].Value.ToString();
                                    s2 = dataGridView1[5, i - 1].Value.ToString();
                                    cl = (s1 == s2) ? cl : (cl != Color.Beige) ? Color.Beige : Color.LightGreen;
                                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = cl;

                                }
                            }
                            catch { }

                        }));

                    }
                    
                   label1.Invoke(new Action(() => label1.Text = "get Files Complete"));
                });
               



            }
                


        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                Task.Factory.StartNew(() =>
                {
                    


                    dataGridView1.Invoke(new Action(() =>
                    {
                        
                            for (int i = 1; i < dataGridView1.Rows.Count - 1; i++)
                            {

                            if ((bool)dataGridView1[0, i].Value)
                            {
                                string f = dataGridView1[2, i].Value.ToString();
                                try { File.Delete(f); } catch { }
                                label1.Invoke(new Action(() => label1.Text = "Delete File:" +f ));
                                dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                            }
                            }
                      

                    }));
                    label1.Invoke(new Action(() => label1.Text = "Delete File complete.."));
                });
            }
            
        }

        private void treeViewDirectory1_MouseDown(object sender, MouseEventArgs e)
        {


            try
            {
                listView1.DoDragDrop(treeViewDirectory1.TagSelect, DragDropEffects.Copy);
            }
            catch { }
        }

        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
            
           

            // See if this is a copy and the data includes text.
            if (e.Data.GetDataPresent(DataFormats.Text) &&
                (e.AllowedEffect & DragDropEffects.Copy) != 0)
            {
                // Allow this.
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                // Don't allow any other drop.
                e.Effect = DragDropEffects.None;
            }
        }

        private void listView1_DragDrop(object sender, DragEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data.GetData(DataFormats.Text).ToString()) && !CheckItem(e.Data.GetData(DataFormats.Text).ToString()))
            {

                listView1.Items.Add(e.Data.GetData(DataFormats.Text).ToString());
                SetDirListview();
            }
          //  e.Effect = DragDropEffects.None;
        }

        private void treeViewDirectory1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
           
        }

        private void treeViewDirectory1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }
    }
}
