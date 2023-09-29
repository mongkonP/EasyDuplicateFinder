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
using EasyDuplicateFinder.clss;
using System.Diagnostics;

namespace EasyDuplicateFinder
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        int t = 0;
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
            lblTime.Text = "00:00:00";
            t = 0;
            timer1.Enabled = true;
            timer1.Start();
            List<string> dirs = new List<string>();
            List<string> Allfiles = new List<string>();
            foreach (ListViewItem item in listView1.Items)
            {
                if (Directory.Exists(item.Text))
                {
                    try
                    {

                        dirs.AddRange(Directory.GetDirectories(item.Text, "*", SearchOption.AllDirectories).ToList());
                        Allfiles.AddRange(Directory.GetFiles(item.Text, "*", SearchOption.AllDirectories).ToList());
                    }
                    catch { }

                }



            }
            MessageBox.Show(Allfiles.Count + "");
            if (Allfiles.Count > 0)
            {


                Task.Factory.StartNew(() =>
                {
                    label1.Invoke(new Action(() => label1.Text = "Set Files"));
                    var get_info =
                    from string f in Allfiles
                    select new
                    {
                        selected = false,
                        FileName = Path.GetFileName(f),
                        FullPath = f,
                        FileSize = new FileInfo(f).Length.ToString(),
                        DateModified = File.GetLastWriteTime(f),
                        MD5 = ""//Ext.CalculateMD5(f)

                    };


                    var group_infos =
                        from info in get_info
                        group info by info.FileSize into g
                        where g.Count() > 1
                        select g;




                    myProgressBar1.Invoke(new Action(() => { myProgressBar1.Maximum = get_info.Count(); myProgressBar1.Value = 0; }));

                    label1.Invoke(new Action(() => label1.Text = "Adding:Files"));

                    DataTable _DataItems = new DataTable();
                    _DataItems = new DataTable();
                    _DataItems.Columns.Add(new DataColumn("selected", typeof(bool)));
                    _DataItems.Columns.Add(new DataColumn("FileName", typeof(string)));
                    _DataItems.Columns.Add(new DataColumn("FullPath", typeof(string)));
                    _DataItems.Columns.Add(new DataColumn("FileSize", typeof(string)));
                    _DataItems.Columns.Add(new DataColumn("MD5", typeof(string)));
                    _DataItems.Columns.Add(new DataColumn("Date Modified", typeof(string)));


                    CancellationTokenSource cts = new CancellationTokenSource();
                    foreach (var g in group_infos)
                    {
                        int c = 0;
                        foreach (var info in g)
                        {
                            DataRow dr = _DataItems.NewRow();
                            dr["selected"] = false; //(c == 0) ? false : true;
                            dr["FileName"] = info.FileName;
                            dr["FullPath"] = info.FullPath;
                            dr["FileSize"] = info.FileSize;
                            dr["MD5"] = info.MD5;
                            dr["Date Modified"] = info.DateModified;

                            _DataItems.Rows.Add(dr);
                            label1.Invoke(new Action(() => label1.Text = "Adding:" + info.FullPath));
                            myProgressBar1.Invoke(new Action(() =>
                            {
                                if (myProgressBar1.Value < myProgressBar1.Maximum)
                                    myProgressBar1.Value++;
                            }));
                            c++;
                        }
                    }
                    myProgressBar1.Invoke(new Action(() =>
                    {
                        myProgressBar1.Value = myProgressBar1.Maximum;
                    }));
                    label1.Invoke(new Action(() => label1.Text = "Adding: complete"));


                    dataGridView1.Invoke(new Action(() =>
                    {
                        dataGridView1.DataSource = _DataItems;
                        this.dataGridView1.Sort(this.dataGridView1.Columns[3], ListSortDirection.Ascending);
                        dataGridView1.Columns[0].Width = 60;
                        dataGridView1.Columns[1].Width = 180;
                        dataGridView1.Columns[2].Width = 400;
                        dataGridView1.Columns[3].Width = 120;
                        dataGridView1.Columns[4].Width = 300;
                        dataGridView1.Columns[5].Width = 120;
                        //Color cl1 = Color.Beige;
                        //Color cl2 = Color.LightGreen;
                        Color cl = Color.Beige;

                        string s1 = "";
                        string s2 = "";
                        string s3 = "";
                        try
                        {
                            dataGridView1.Rows[0].DefaultCellStyle.BackColor = cl;
                            for (int i = 1; i < dataGridView1.Rows.Count - 1; i++)
                            {
                                s1 = dataGridView1[3, i].Value.ToString().Trim();
                                s2 = dataGridView1[3, i - 1].Value.ToString().Trim();
                                try
                                {

                                    s3 = (i < dataGridView1.Rows.Count - 1 && dataGridView1[3, i + 1].Value != null) ? dataGridView1[3, i + 1].Value.ToString().Trim() : "";

                                }
                                catch { }

                                cl = (s1 == s2) ? cl : (cl != Color.Beige) ? Color.Beige : Color.LightGreen;
                                dataGridView1.Rows[i].DefaultCellStyle.BackColor = cl;
                                /* if (cl == Color.LightGreen)
                                     dataGridView1[0, i].Value = true;*/


                            }
                        }
                        catch { }
                    }));

                    // dataGridView1.DataSource = items.DataItems ;


                    // }

                    label1.Invoke(new Action(() => label1.Text = "get Files Complete"));
                    timer1.Stop();
                    timer1.Enabled = false;
                });


            }



        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            t++;
            lblTime.Invoke(new Action(() => lblTime.Text = TimeSpan.FromSeconds(t).ToString()));
            // this.Invoke(new Action(() => this.Text = TimeSpan.FromSeconds(t).ToString()));
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                lblTime.Text = "00:00:00";
                t = 0;
                timer1.Enabled = true;
                timer1.Start();

                Task.Factory.StartNew(() =>
                {

                    myProgressBar1.Invoke(new Action(() =>
                    {
                        myProgressBar1.Maximum = dataGridView1.RowCount - 1;
                        myProgressBar1.Value = 0;
                    }));

                    dataGridView1.Invoke(new Action(() =>
                    {

                        for (int i = 1; i < dataGridView1.Rows.Count - 1; i++)
                        {

                            if ((bool)dataGridView1[0, i].Value)
                            {
                                string f = dataGridView1[2, i].Value.ToString();
                                try { File.Delete(f); } catch { }
                                label1.Invoke(new Action(() => label1.Text = "Delete File:" + f));
                                dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                            }
                            myProgressBar1.Invoke(new Action(() =>
                            {
                                myProgressBar1.Value++;
                            }));
                        }


                    }));
                    label1.Invoke(new Action(() => label1.Text = "Delete File complete.."));
                    timer1.Stop();
                    timer1.Enabled = false;
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
            if ((e.Data.GetDataPresent(DataFormats.Text) || e.Data.GetDataPresent(DataFormats.FileDrop)) && (e.AllowedEffect & DragDropEffects.Copy) != 0)
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
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                if (!string.IsNullOrEmpty(e.Data.GetData(DataFormats.Text).ToString()) && !CheckItem(e.Data.GetData(DataFormats.Text).ToString()))
                {

                    listView1.Items.Add(e.Data.GetData(DataFormats.Text).ToString());
                    SetDirListview();
                }
            }
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                if (!string.IsNullOrEmpty(e.Data.GetData(DataFormats.FileDrop).ToString()) && !CheckItem(e.Data.GetData(DataFormats.FileDrop).ToString()))
                {
                    //https://www.telerik.com/forums/drag-and-drop-files-from-the-desktop-or-windows-explorer-to-radlistview
                    string[] handles = (string[])e.Data.GetData(DataFormats.FileDrop, false);

                    foreach (string path in handles)
                    {
                        listView1.Items.Add(path);

                    }
                }
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

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {


        }

        private void dataGridView1_Sorted(object sender, EventArgs e)
        {

        }

        private void treeViewDirectory1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            // MessageBox.Show(e.Node.Tag.ToString());
        }
    }
}
