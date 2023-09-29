using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyDuplicateFinder
{
    //http://csharphelper.com/blog/2017/11/initialize-a-treeview-control-to-display-a-directory-hierarchy-in-c/#google_vignette
    //https://www.c-sharpcorner.com/article/display-sub-directories-and-files-in-treeview/
    public static class TreeViewExtensions
    {
        // Initialize the TreeView from a directory,
        // its subdirectories, and their files.
        public static void LoadFromDirectory(this TreeView trv, string directory, int folder_img, int file_img)
        {
            DirectoryInfo dir_info = new DirectoryInfo(directory);
            AddDirectoryNodes(trv, dir_info, null, folder_img, file_img);
        }

        // Add this directory's node and sub-nodes.
        public static void AddDirectoryNodes(TreeView trv, DirectoryInfo dir_info, TreeNode parent, int folder_img, int file_img)
        {
            // Add the directory's node.
            TreeNode dir_node;
            if (parent == null) dir_node = trv.Nodes.Add(dir_info.Name);
            else dir_node = parent.Nodes.Add(dir_info.Name);

            // Add the folder image.
            if (folder_img >= 0) dir_node.ImageIndex = folder_img;

            // Add subdirectories.
            foreach (DirectoryInfo subdir in dir_info.GetDirectories())
                AddDirectoryNodes(trv, subdir, dir_node, folder_img, file_img);

            // Add file nodes.
            foreach (FileInfo file_info in dir_info.GetFiles())
            {
                TreeNode file_node = dir_node.Nodes.Add(file_info.Name);
                if (file_img >= 0) file_node.ImageIndex = file_img;
            }
        }
    }

}
