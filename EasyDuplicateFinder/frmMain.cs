using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
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

        private void button4_Click(object sender, EventArgs e)
        {
            List<string> dirs = new List<string>();
            foreach (ListViewItem item in listView1.Items)
            {
                dirs.Add(item.Text);
            }
       
            if (dirs.Count > 0)
            {
               // MessageBox.Show(dirs.Count.ToString());
                Task.Factory.StartNew(() =>
                {
                    List<Task> tasks = new List<Task>();

                    dirs.ForEach(dir =>
                    {
                        label1.Invoke(new Action(() => label1.Text = "get Files"));
                        tasks.Add(Task.Factory.StartNew(() =>
                        {
                            foreach (var f in Directory.GetFiles(dir))
                            {
                                dataGridView1.Invoke(new Action(() =>
                                {
                                    dataGridView1.Rows.Add(false, Path.GetFileName(f), f, new FileInfo(f).Length, File.GetLastWriteTime(f), Ext.CalculateMD5(f));
                                }));
                                label1.Invoke(new Action(() => label1.Text = "Adding:" + f));
                            }

                        }));
                    }
                    );

                    Task.WaitAll(tasks.ToArray());


                    dataGridView1.Invoke(new Action(() =>
                    {
                        this.dataGridView1.Sort(this.dataGridView1.Columns[5], ListSortDirection.Ascending);

                        //Color cl1 = Color.Beige;
                        //Color cl2 = Color.LightGreen;
                        Color cl = Color.Beige;
                        
                        string s1 = "";
                        string s2 = "";
                        try
                        {
                            for (int i = 1; i < dataGridView1.Rows.Count - 1; i++)
                            {
                                s1 =dataGridView1[5, i].Value.ToString();
                                s2 = dataGridView1[5, i-1].Value.ToString();
                                cl = (s1 == s2) ? cl : (cl != Color.Beige) ? Color.Beige : Color.LightGreen;
                                dataGridView1.Rows[i].DefaultCellStyle.BackColor = cl;


                            }
                        }
                        catch { }

                    }));
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
                            }
                            }
                      

                    }));
                    label1.Invoke(new Action(() => label1.Text = "Delete File complete.."));
                });
            }
            
        }
    }
}
