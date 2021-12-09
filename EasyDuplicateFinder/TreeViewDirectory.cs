using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyDuplicateFinder
{
  public   class TreeViewDirectory: TreeView
    {
        public TreeViewDirectory()
        { 
        
        }
        public void SetDirectory(string dir)
        {
        
            DirectoryInfo dir_info = new DirectoryInfo(dir);

            this.LoadFromDirectory(dir_info.FullName, 0, 1);
            this.ExpandAll();
            this.SelectedNode = this.Nodes[0];

        }
    }
}
