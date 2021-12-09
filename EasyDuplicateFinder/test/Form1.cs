using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyDuplicateFinder.test
{
    //https://www.dreamincode.net/forums/topic/400525-treeview-drive-folder-and-file-explorer/
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Tv_Explorer.BeforeExpand += new TreeViewCancelEventHandler(TV_Explorer_BeforeExpand);
            Tv_Explorer.AfterSelect += new TreeViewEventHandler(TV_Explorer_AfterSelect);
            Tv_Explorer.AfterCollapse += new TreeViewEventHandler(TV_Explorer_AfterCollapse);
            Tv_Explorer.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(TV_Explorer_NodeMouseDoubleClick);
        }
        private enum SpecialNodeFolders : int
        {
            Desktop = Environment.SpecialFolder.Desktop,
            Favorites = Environment.SpecialFolder.Favorites,
            History = Environment.SpecialFolder.History,
            MyDocuments = Environment.SpecialFolder.MyDocuments,
            MyMusic = Environment.SpecialFolder.MyMusic,
            MyPictures = Environment.SpecialFolder.MyPictures,
            MyVideos = Environment.SpecialFolder.MyVideos,
            Recent = Environment.SpecialFolder.Recent,
            UserProfile = Environment.SpecialFolder.UserProfile
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Tv_ImgList.ImageSize = new Size(20, 20);
            Tv_Explorer.ImageList = Tv_ImgList;

            AddSpecialAndStandardFolderImages();

            AddSpecialFolderRootNode(SpecialNodeFolders.Desktop);
            AddSpecialFolderRootNode(SpecialNodeFolders.MyDocuments);
            AddDriveRootNodes();
        }

        private void TV_Explorer_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            bool DrvIsReady = (from d in DriveInfo.GetDrives()
                               where d.Name == e.Node.ImageKey
                               select d.IsReady).FirstOrDefault();

            if ((e.Node.ImageKey != "Desktop" && !e.Node.ImageKey.Contains(@":\")) || DrvIsReady || Directory.Exists(e.Node.ImageKey))
            {
                e.Node.Nodes.Clear();
                AddChildNodes(e.Node, e.Node.Tag.ToString());
            }
            else if (e.Node.ImageKey == "Desktop")
            {
                e.Node.Nodes.Clear();
                string PublicDesktopFolder = Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory);
                string CurrentUserDesktopFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                AddChildNodes(e.Node, CurrentUserDesktopFolder);
                AddChildNodes(e.Node, PublicDesktopFolder);
            }
            else
            {
                e.Cancel = true;
                MessageBox.Show("The CD or DVD drive is empty.", "Drive Info...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void TV_Explorer_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            e.Node.Nodes.Clear();
            e.Node.Nodes.Add("Empty");
        }

        private void TV_Explorer_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TxtBx_Path.Text = e.Node.Tag.ToString();
        }

        private void TV_Explorer_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left && File.Exists(e.Node.Tag.ToString()))
            {
                try
                {
                    Process.Start(e.Node.Tag.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AddSpecialFolderRootNode(SpecialNodeFolders SpecialFolder)
        {
            string SpecialFolderPath = Environment.GetFolderPath((Environment.SpecialFolder)SpecialFolder);
            string SpecialFolderName = Path.GetFileName(SpecialFolderPath);

            AddImageToImgList(SpecialFolderPath, SpecialFolderName);

            TreeNode DesktopNode = new TreeNode(SpecialFolderName);
            {
                var withBlock = DesktopNode;
                withBlock.Tag = SpecialFolderPath;
                withBlock.ImageKey = SpecialFolderName;
                withBlock.SelectedImageKey = SpecialFolderName;
                withBlock.Nodes.Add("Empty");
            }

            Tv_Explorer.Nodes.Add(DesktopNode);
        }

        private void AddDriveRootNodes()
        {
            foreach (DriveInfo drv in DriveInfo.GetDrives())
            {
                AddImageToImgList(drv.Name);
                TreeNode DriveNode = new TreeNode(drv.Name);
                {
                    var withBlock = DriveNode;
                    withBlock.Tag = drv.Name;
                    withBlock.ImageKey = drv.Name;
                    withBlock.SelectedImageKey = drv.Name;
                    withBlock.Nodes.Add("Empty");
                }
                Tv_Explorer.Nodes.Add(DriveNode);
            }
        }

        private void AddCustomFolderRootNode(string folderpath)
        {
            if (Directory.Exists(folderpath))
            {
                string FolderName = new DirectoryInfo(folderpath).Name;
                AddImageToImgList(folderpath);
                TreeNode rootNode = new TreeNode(FolderName);
                {
                    var withBlock = rootNode;
                    withBlock.Tag = folderpath;
                    withBlock.ImageKey = folderpath;
                    withBlock.SelectedImageKey = folderpath;
                    if (Directory.GetDirectories(folderpath).Count() > 0 || Directory.GetFiles(folderpath).Count() > 0)
                        withBlock.Nodes.Add("Empty");
                }
                Tv_Explorer.Nodes.Add(rootNode); // add this root node to the treeview
            }
        }

        private void AddChildNodes(TreeNode tn, string DirPath)
        {
            DirectoryInfo DirInfo = new DirectoryInfo(DirPath);
            try
            {
                foreach (DirectoryInfo di in DirInfo.GetDirectories())
                {
                    if (di.Attributes != FileAttributes.Hidden)
                    {
                        TreeNode FolderNode = new TreeNode(di.Name);
                        {
                            var withBlock = FolderNode;
                            withBlock.Tag = di.FullName;
                            if (Tv_ImgList.Images.Keys.Contains(di.FullName))
                            {
                                withBlock.ImageKey = di.FullName;
                                withBlock.SelectedImageKey = di.FullName;
                            }
                            else
                            {
                                withBlock.ImageKey = "Folder";
                                withBlock.SelectedImageKey = "Folder";
                            }
                            withBlock.Nodes.Add("*Empty*");
                        }
                        tn.Nodes.Add(FolderNode);
                    }
                }
                foreach (FileInfo fi in DirInfo.GetFiles())
                {
                    if (fi.Attributes != FileAttributes.Hidden)
                    {
                        string ImgKey = AddImageToImgList(fi.FullName);
                        TreeNode FileNode = new TreeNode(fi.Name);
                        {
                            var withBlock = FileNode;
                            withBlock.Tag = fi.FullName;
                            withBlock.ImageKey = ImgKey;
                            withBlock.SelectedImageKey = ImgKey;
                        }
                        tn.Nodes.Add(FileNode);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddSpecialAndStandardFolderImages()
        {
            AddImageToImgList(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Folder");

            List<Environment.SpecialFolder> SpecialFolders = new List<Environment.SpecialFolder>();
            {
                var withBlock = SpecialFolders;
                withBlock.Add(Environment.SpecialFolder.Desktop);
                withBlock.Add(Environment.SpecialFolder.MyDocuments);
                withBlock.Add(Environment.SpecialFolder.Favorites);
                withBlock.Add(Environment.SpecialFolder.Recent);
                withBlock.Add(Environment.SpecialFolder.MyMusic);
                withBlock.Add(Environment.SpecialFolder.MyVideos);
                withBlock.Add(Environment.SpecialFolder.Fonts);
                withBlock.Add(Environment.SpecialFolder.History);
                withBlock.Add(Environment.SpecialFolder.MyPictures);
                withBlock.Add(Environment.SpecialFolder.UserProfile);
            }

            foreach (Environment.SpecialFolder sf in SpecialFolders)
                AddImageToImgList(Environment.GetFolderPath(sf));
        }

        private string AddImageToImgList(string FullPath, string SpecialImageKeyName = "")
        {
            string ImgKey = SpecialImageKeyName == "" ? FullPath : SpecialImageKeyName;
            bool LoadFromExt = false;

            if (ImgKey == FullPath && File.Exists(FullPath))
            {
                string ext = Path.GetExtension(FullPath).ToLower();
                if (ext != "" && ext != ".exe" && ext != ".lnk" && ext != ".url")
                {
                    ImgKey = Path.GetExtension(FullPath).ToLower();
                    LoadFromExt = true;
                }
            }

            if (!Tv_ImgList.Images.Keys.Contains(ImgKey))
                Tv_ImgList.Images.Add(ImgKey, Iconhelper.GetIconImage(LoadFromExt ? ImgKey : FullPath, IconSizes.Large32x32));

            return ImgKey;
        }

        
    }
}
