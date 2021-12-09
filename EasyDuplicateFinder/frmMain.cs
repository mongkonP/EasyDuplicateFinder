using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    }
}
