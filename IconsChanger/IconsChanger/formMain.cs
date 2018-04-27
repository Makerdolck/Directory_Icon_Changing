using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

using System.Runtime.InteropServices;

using System.Runtime.Serialization.Formatters.Soap;


namespace IconsChanger
{
    public partial class formMain : Form
    {
        public int indexIconsFolders = 0, indexFolders = 0;

        private bool trueButtonAppointmentFolder = false;
        private TreeNode targetFolders = null, sourceFolders = null;
        private string iconPath = null;

        public TreeNode oldFolderColor, oldIconFolderColor;
        ListViewItem oldListViewIconColor;

        public TreeNodeMouseClickEventArgs forIconsUpdating;

        Dictionary<object, bool> nodeStates = new Dictionary<object, bool>();
        private void SaveExpandedStates(TreeNode nodeToSave)
        {
            if (nodeToSave != null && nodeToSave.FullPath != null)
            {
                if (!nodeStates.ContainsKey(nodeToSave.FullPath))
                {
                    nodeStates.Add(nodeToSave.FullPath, nodeToSave.IsExpanded);
                }
                else
                {
                    nodeStates[nodeToSave.FullPath] = nodeToSave.IsExpanded;
                }
            }

            foreach (TreeNode childNode in nodeToSave.Nodes)
            {
                SaveExpandedStates(childNode);
            }
        }
        private void RestoreExpandedStates(TreeNode nodeToRestore)
        {
            Icon ic;
            if (nodeToRestore != null && nodeToRestore.FullPath != null &&
                nodeStates.ContainsKey(nodeToRestore.FullPath))
            {
                
                //if (!Directory.Exists(nodeToRestore.FullPath))
                //    return;
                

                if (nodeStates[nodeToRestore.FullPath])
                    nodeToRestore.Expand();
                else
                    nodeToRestore.Collapse();

                ic = GetIcon(/*nodeToRestore.FullPath*/((DirectoryInfo)nodeToRestore.Tag).FullName, false);
                
                if (ic == null)
                {
                    nodeToRestore.ImageIndex = 0;
                    //return;
                }
                else
                    imageListFolders.Images.Add(ic);
                if (nodeToRestore.ImageIndex == -1)
                {
                    nodeToRestore.ImageIndex = indexFolders;
                    indexFolders++;
                }
            }

            foreach (TreeNode childNode in nodeToRestore.Nodes)
            {
                RestoreExpandedStates(childNode);
            }
        }

        //---------------------------------------------------------------//

        Dictionary<object, bool> nodeStatesIcons = new Dictionary<object, bool>();
        private void SaveExpandedStatesIcons(TreeNode nodeToSave)
        {
            if (nodeToSave != null && nodeToSave.FullPath != null)
            {
                if (!nodeStatesIcons.ContainsKey(nodeToSave.FullPath))
                {
                    nodeStatesIcons.Add(nodeToSave.FullPath, nodeToSave.IsExpanded);
                }
                else
                {
                    nodeStatesIcons[nodeToSave.FullPath] = nodeToSave.IsExpanded;
                }
            }

            foreach (TreeNode childNode in nodeToSave.Nodes)
            {
                SaveExpandedStatesIcons(childNode);
            }
        }
        private void RestoreExpandedStatesIcons(TreeNode nodeToRestore)
        {
            Icon ic = null;
            if (nodeToRestore != null && nodeToRestore.FullPath != null &&
                nodeStatesIcons.ContainsKey(nodeToRestore.FullPath))
            {
                //if (!Directory.Exists(((DirectoryInfo)nodeToRestore.Tag).FullName))
                //    return;

                if (nodeStatesIcons[nodeToRestore.FullPath])
                    nodeToRestore.Expand();
                else
                    nodeToRestore.Collapse();


                ic = GetIcon(((DirectoryInfo)nodeToRestore.Tag).FullName, false);
                if (ic == null)
                {
                    nodeToRestore.ImageIndex = 0;
                    //return;
                }
                else
                    imageListIconsFolders.Images.Add(ic);
                if (nodeToRestore.ImageIndex == -1)
                {
                    nodeToRestore.ImageIndex = indexIconsFolders;
                    indexIconsFolders++;
                }
            }

            foreach (TreeNode childNode in nodeToRestore.Nodes)
            {
                RestoreExpandedStatesIcons(childNode);
            }
        }

        //---------------------------------------------------------------//
        private void treeViewFolders_OnClose()
        {
            //TreeNode[] tempNodes = new TreeNode[treeViewFolders.Nodes.Count];
            //// заполняем его
            //for (int i = 0; i < treeViewFolders.Nodes.Count; i++)
            //    tempNodes[i] = treeViewFolders.Nodes[i];
            //// сама сериализация
            //FileStream fs = new FileStream("TreeSave.xml", FileMode.Create);
            //SoapFormatter sf = new SoapFormatter();
            //sf.Serialize(fs, tempNodes);
            //fs.Close();

            //foreach (TreeNode nodeToSave in treeViewFolders.Nodes)
            //{
            //    SaveExpandedStates(nodeToSave);
            //}
            TreeNode[] tempNodes = new TreeNode[treeViewFolders.Nodes.Count];
            // заполняем его
            for (int i = 0; i < treeViewFolders.Nodes.Count; i++)
                tempNodes[i] = treeViewFolders.Nodes[i];
            // сама сериализация
            FileStream fs = new FileStream("$etting$\\TreeSave.xml", FileMode.Create);
            SoapFormatter sf = new SoapFormatter();
            sf.Serialize(fs, tempNodes);
            fs.Close();

            foreach (TreeNode nodeToSave in treeViewFolders.Nodes)
            {
                SaveExpandedStates(nodeToSave);
            }

            FileStream fe = new FileStream("$etting$\\Object.soap", FileMode.OpenOrCreate);
            SoapFormatter ef = new SoapFormatter();

            int k = 0;
            object[] obj = new object[nodeStates.Count];
            foreach (var field in nodeStates)
            {
                //ef.Serialize(fe, field.Key);]
                obj[k] = field.Key;
                k++;
            }
            ef.Serialize(fe, obj);
            fe.Close();

            FileStream fn = new FileStream("$etting$\\Bool.soap", FileMode.OpenOrCreate);
            SoapFormatter nf = new SoapFormatter();
            bool[] bols = new bool[nodeStates.Count];

            k = 0;
            foreach (var field in nodeStates)
            {
                //ef.Serialize(fn, field.Value);
                bols[k] = field.Value;
                k++;
            }

            nf.Serialize(fn, bols);

            fn.Close();
        }
        private void treeViewFolders_OnStart()
        {
            //TreeNode[] tempNodes;
            //FileStream fs = new FileStream("TreeSave.xml", FileMode.Open);
            //SoapFormatter sf = new SoapFormatter();
            //tempNodes = (TreeNode[])sf.Deserialize(fs);
            //treeViewFolders.Nodes.AddRange(tempNodes);
            //fs.Close();

            //foreach (TreeNode nodeToRestore in treeViewFolders.Nodes)
            //{
            //    RestoreExpandedStates(nodeToRestore);
            //}

            Icon ic;
            ic = GetIcon(@".", false);
            if (ic == null)
            {

            }
            else
                imageListFolders.Images.Add(ic);
            try
            {
                FileStream fe = new FileStream("$etting$\\Object.soap", FileMode.Open);
                FileStream fn = new FileStream("$etting$\\Bool.soap", FileMode.Open);

                SoapFormatter ef = new SoapFormatter();
                SoapFormatter nf = new SoapFormatter();
                var bols = (bool[])nf.Deserialize(fn);
                var obj = (object[])ef.Deserialize(fe);

                for (int i = 0; i < bols.Length; i++)
                {
                    nodeStates.Add((object)obj[i], (bool)bols[i]);
                }
                fe.Close();
                fn.Close();

                TreeNode[] tempNodes;
                FileStream fs = new FileStream("$etting$\\TreeSave.xml", FileMode.Open);
                SoapFormatter sf = new SoapFormatter();
                tempNodes = (TreeNode[])sf.Deserialize(fs);
                treeViewFolders.Nodes.AddRange(tempNodes);
                fs.Close();

                foreach (TreeNode nodeToRestore in treeViewFolders.Nodes)
                {
                    RestoreExpandedStates(nodeToRestore);
                }
            }
            catch
            {
                treeViewFoldersPopulate();
                //treeViewIconsPopulate();
                return;
            }
        }
        private void treeViewIcons_OnClose()
        {
            TreeNode[] tempNodes = new TreeNode[treeViewIcons.Nodes.Count];
            // заполняем его
            for (int i = 0; i < treeViewIcons.Nodes.Count; i++)
                tempNodes[i] = treeViewIcons.Nodes[i];
            // сама сериализация
            FileStream fs = new FileStream("$etting$\\TreeSaveIcons.xml", FileMode.Create);
            SoapFormatter sf = new SoapFormatter();
            sf.Serialize(fs, tempNodes);
            fs.Close();

            foreach (TreeNode nodeToSave in treeViewIcons.Nodes)
            {
                SaveExpandedStatesIcons(nodeToSave);
            }

            FileStream fe = new FileStream("$etting$\\ObjectIcons.soap", FileMode.OpenOrCreate);
            SoapFormatter ef = new SoapFormatter();

            int k = 0;
            object[] obj = new object[nodeStatesIcons.Count];
            foreach (var field in nodeStatesIcons)
            {
                //ef.Serialize(fe, field.Key);]
                obj[k] = field.Key;
                k++;
            }
            ef.Serialize(fe, obj);
            fe.Close();

            FileStream fn = new FileStream("$etting$\\BoolIcons.soap", FileMode.OpenOrCreate);
            SoapFormatter nf = new SoapFormatter();
            bool[] bols = new bool[nodeStatesIcons.Count];

            k = 0;
            foreach (var field in nodeStatesIcons)
            {
                //ef.Serialize(fn, field.Value);
                bols[k] = field.Value;
                k++;
            }

            nf.Serialize(fn, bols);

            fn.Close();
        }
        private void treeViewIcons_OnStart()
        {
            Icon ic;
            ic = GetIcon(@".", false);
            if (ic == null)
            {

            }
            else
                imageListIconsFolders.Images.Add(ic);
            try
            {
                FileStream fe = new FileStream("$etting$\\ObjectIcons.soap", FileMode.Open);
                FileStream fn = new FileStream("$etting$\\BoolIcons.soap", FileMode.Open);

                SoapFormatter ef = new SoapFormatter();
                SoapFormatter nf = new SoapFormatter();
                var bols = (bool[])nf.Deserialize(fn);
                var obj = (object[])ef.Deserialize(fe);

                for (int i = 0; i < bols.Length; i++)
                {
                    nodeStatesIcons.Add((object)obj[i], (bool)bols[i]);
                }
                fe.Close();
                fn.Close();

                TreeNode[] tempNodes;
                FileStream fs = new FileStream("$etting$\\TreeSaveIcons.xml", FileMode.Open);
                SoapFormatter sf = new SoapFormatter();
                tempNodes = (TreeNode[])sf.Deserialize(fs);
                treeViewIcons.Nodes.AddRange(tempNodes);
                fs.Close();

                foreach (TreeNode nodeToRestore in treeViewIcons.Nodes)
                {
                    RestoreExpandedStatesIcons(nodeToRestore);
                }
            }
            catch
            {
                treeViewIconsPopulate();
            }
        }

        //
        //..................................................................................
        //

        [StructLayout(LayoutKind.Sequential)]
        public struct SHFILEINFO
        {
            public IntPtr hIcon;
            public IntPtr iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        };

        [DllImport("User32.dll")]
        private static extern int DestroyIcon(IntPtr hIcon);

        class Win32
        {
            public const uint SHGFI_ICON = 0x100;
            public const uint SHGFI_LARGEICON = 0x0;
            public const uint SHGFI_SMALLICON = 0x1;

            [DllImport("shell32.dll")]
            public static extern IntPtr SHGetFileInfo(string pszPath,
            uint dwFileAttributes,
            ref SHFILEINFO psfi,
            uint cbSizeFileInfo,
            uint uFlags);
        }
        public Icon GetIcon(string path, bool bolshaya)
        {
            IntPtr hImgSmall;
            IntPtr hImgLarge;
            SHFILEINFO shinfo = new SHFILEINFO();

            if (!bolshaya)
            {
                hImgSmall = Win32.SHGetFileInfo(path, 0, ref shinfo,
                (uint)Marshal.SizeOf(shinfo),
                Win32.SHGFI_ICON |
                Win32.SHGFI_SMALLICON);
            }

            else
            {
                hImgLarge = Win32.SHGetFileInfo(path, 0,
                ref shinfo, (uint)Marshal.SizeOf(shinfo),
                Win32.SHGFI_ICON | Win32.SHGFI_LARGEICON);
            }
            try
            {
                System.Drawing.Icon myIcon = (System.Drawing.Icon)System.Drawing.Icon.FromHandle(shinfo.hIcon).Clone();
                DestroyIcon(shinfo.hIcon);
                return myIcon;
            }
            catch
            {
                return null;
            }
        }

        //// // // // // // // // // // // // // // // // // //
        /// /
        //// // // // // // // // // // // // // // / /// / / / /

        public void treeViewIconsPopulate()
        {
            TreeNode rootNode;
            Icon ic;

            DirectoryInfo info = new DirectoryInfo(".");
            if (info.Exists)
            {
                rootNode = new TreeNode(info.Name);
                rootNode.Tag = info;
                GetDirectories(info.GetDirectories(), rootNode);



                ic = GetIcon(info.FullName, false);
                if (ic == null)
                {
                    rootNode.ImageIndex = 0;
                    treeViewIcons.Nodes.Add(rootNode);
                    treeViewIcons.Nodes[0].Expand();
                    return;
                }
                imageListIconsFolders.Images.Add(ic);
                rootNode.ImageIndex = indexIconsFolders;
                indexIconsFolders++;

                treeViewIcons.Nodes.Add(rootNode);
                treeViewIcons.Nodes[0].Expand();
            }
        }
        private void GetDirectories(DirectoryInfo[] subDirs, TreeNode nodeToAddTo)
        {
            Icon ic;
            for(int i = nodeToAddTo.Nodes.Count-1; i>=0; i--)
                nodeToAddTo.Nodes[i].Remove();
            TreeNode aNode;
            DirectoryInfo[] subSubDirs;          
            foreach (DirectoryInfo subDir in subDirs)
            {
                try
                {

                    aNode = new TreeNode(subDir.Name, 0, 0);
                    if (aNode.Text == "$etting$")
                        continue;
                    aNode.Tag = subDir;
                    aNode.ImageKey = "folder";
                    subSubDirs = subDir.GetDirectories();
                    //
                    if (subSubDirs.Length != 0)
                    {
                        GetDirectories1(subSubDirs, aNode);
                    }
                    //
                    ic = GetIcon(subDir.FullName, false);
                    if (ic==null)
                    {
                        aNode.ImageIndex = 0;
                        nodeToAddTo.Nodes.Add(aNode);
                        return;
                    }
                    else
                        imageListIconsFolders.Images.Add(ic);
                    if (aNode.ImageIndex == -1)
                    {
                        aNode.ImageIndex = indexIconsFolders;
                        indexIconsFolders++;
                    }

                    nodeToAddTo.Nodes.Add(aNode);
                }
                catch { }
            }
        }
        private void GetDirectories1(DirectoryInfo[] subDirs, TreeNode nodeToAddTo)
        {
            Icon ic;

            TreeNode aNode;
            DirectoryInfo[] subSubDirs;
            foreach (DirectoryInfo subDir in subDirs)
            {
                try
                {

                    aNode = new TreeNode(subDir.Name, 0, 0);
                    aNode.Tag = subDir;
                    aNode.ImageKey = "folder";
                    subSubDirs = subDir.GetDirectories();

                    ic = GetIcon(subDir.FullName, false);
                    if (ic == null)
                    {
                        aNode.ImageIndex = 0;
                        nodeToAddTo.Nodes.Add(aNode);
                        return;
                    }
                    else
                        imageListIconsFolders.Images.Add(ic);
                    if (aNode.ImageIndex == -1)
                    {
                        aNode.ImageIndex = indexIconsFolders;
                        indexIconsFolders++;
                    }

                    nodeToAddTo.Nodes.Add(aNode);
                    return;
                }
                catch  { }
            }
        }

        //// // // // // // // // // // // // // // // // // //
        /// /
        //// // // // // // // // // // // // // // / /// / / / /

        public void treeViewFoldersPopulate()
        {
            TreeNode rootNode;
            Icon ic;

            DirectoryInfo info = new DirectoryInfo(@"C:\");

            //DriveInfo[] drives = DriveInfo.GetDrives();
            //try
            //{
            //    foreach (DriveInfo drive in DriveInfo.GetDrives())
            //    {
            //        //TreeNode driveNode = new TreeNode { Text = drive.Name };
            //        //FillTreeNode(driveNode, drive.Name);
            //        //treeView1.Nodes.Add(driveNode);

            //        var directories = Directory.GetDirectories(drive.Name);

            //        foreach (string directPath in directories)
            //        {
            //            info = new DirectoryInfo(directPath);
            //            rootNode = new TreeNode(info.Name);
            //            rootNode.Tag = info;
            //            NGetDirectories(info.GetDirectories(), rootNode);

            //            ic = GetIcon(info.FullName, false);
            //            if (ic == null)
            //            {
            //                rootNode.ImageIndex = 0;
            //                treeViewFolders.Nodes.Add(rootNode);
            //                treeViewFolders.Nodes[0].Expand();
            //                return;
            //            }
            //            imageListFolders.Images.Add(ic);
            //            rootNode.ImageIndex = indexFolders;
            //            indexIconsFolders++;

            //            treeViewFolders.Nodes.Add(rootNode);
            //            treeViewFolders.Nodes[0].Expand();
            //        }
            //    }
            //}
            //catch (Exception ex) { }


            if (info.Exists)
            {
                rootNode = new TreeNode(info.Name);
                rootNode.Tag = info;
                GetDirectoriesFolders(info.GetDirectories(), rootNode);



                ic = GetIcon(info.FullName, false);
                if (ic == null)
                {
                    rootNode.ImageIndex = 0;
                    treeViewFolders.Nodes.Add(rootNode);
                    treeViewFolders.Nodes[0].Expand();
                    return;
                }
                imageListFolders.Images.Add(ic);
                rootNode.ImageIndex = indexFolders;
                indexFolders++;

                treeViewFolders.Nodes.Add(rootNode);
                treeViewFolders.Nodes[0].Expand();
            }
        }
        private void GetDirectoriesFolders(DirectoryInfo[] subDirs, TreeNode nodeToAddTo)
        {
            Icon ic;
            for (int i = nodeToAddTo.Nodes.Count - 1; i >= 0; i--)  //For Removing old nodes
                nodeToAddTo.Nodes[i].Remove();
            TreeNode aNode;
            DirectoryInfo[] subSubDirs;
            foreach (DirectoryInfo subDir in subDirs)
            {
                try
                {

                    aNode = new TreeNode(subDir.Name, 0, 0);
                    aNode.Tag = subDir;
                    aNode.ImageKey = "folder";
                    subSubDirs = subDir.GetDirectories();
                    //
                    if (subSubDirs.Length != 0)
                    {
                        GetDirectories1Folders(subSubDirs, aNode);
                    }
                    //
                    ic = GetIcon(subDir.FullName, false);
                    if (ic == null)
                    {
                        aNode.ImageIndex = 0;
                        nodeToAddTo.Nodes.Add(aNode);
                        return;
                    }
                    else
                        imageListFolders.Images.Add(ic);
                    if (aNode.ImageIndex == -1)
                    {
                        aNode.ImageIndex = indexFolders;
                        indexFolders++;
                    }

                    nodeToAddTo.Nodes.Add(aNode);
                }
                catch { }
            }
        }
        private void GetDirectories1Folders(DirectoryInfo[] subDirs, TreeNode nodeToAddTo)
        {
            Icon ic;

            TreeNode aNode;
            DirectoryInfo[] subSubDirs;
            foreach (DirectoryInfo subDir in subDirs)
            {
                try
                {

                    aNode = new TreeNode(subDir.Name, 0, 0);
                    aNode.Tag = subDir;
                    aNode.ImageKey = "folder";
                    subSubDirs = subDir.GetDirectories();

                    ic = GetIcon(subDir.FullName, false);
                    if (ic == null)
                    {
                        aNode.ImageIndex = 0;
                        nodeToAddTo.Nodes.Add(aNode);
                        return;
                    }
                    else
                        imageListFolders.Images.Add(ic);
                    if (aNode.ImageIndex == -1)
                    {
                        aNode.ImageIndex = indexFolders;
                        indexFolders++;
                    }

                    nodeToAddTo.Nodes.Add(aNode);
                    return;
                }
                catch  { }
            }
        }

        //// // // // // // // // // // // // // // // // // //
        /// /
        //// // // // // // // // // // // // // // / /// / / / /

        public formMain()
        {
            InitializeComponent();
            Directory.CreateDirectory(@"$etting$");
            File.SetAttributes(@"$etting$", FileAttributes.ReadOnly | FileAttributes.Directory | FileAttributes.Hidden);

            imageListIconsFolders.ImageSize = new Size(16, 16);
            imageListFolders.ImageSize = new Size(16, 16);
            imageListIcons.ImageSize = new Size(32, 32);

            //treeViewFoldersPopulate();
            //treeViewIconsPopulate();
            if (Properties.Settings.Default.Firstly)
            {

                treeViewFoldersPopulate();
                treeViewIconsPopulate();
                Properties.Settings.Default.Firstly = false;
                Properties.Settings.Default.Save();
            }
            else
            {
                indexIconsFolders = 1;
                indexFolders = 1;
                treeViewFolders_OnStart();
                treeViewIcons_OnStart();
                try
                {
                    FileStream fn = new FileStream("$etting$\\Settings.soap", FileMode.Open);

                    SoapFormatter nf = new SoapFormatter();
                    float[] settingsArray = (float[])nf.Deserialize(fn);

                    treeViewFolders.Font = new Font("Microsoft Sans Serif", settingsArray[0]);
                    treeViewIcons.Font = new Font("Microsoft Sans Serif", settingsArray[1]);
                    imageListIcons.ImageSize = new Size((int)settingsArray[2], (int)settingsArray[2]);
                    listViewIcons.Font = new Font("Microsoft Sans Serif", settingsArray[3]);
                    //imageListFolders.ImageSize = new Size((int)settingsArray[4], (int)settingsArray[4]);
                    //imageListIconsFolders.ImageSize = new Size((int)settingsArray[5], (int)settingsArray[5]);

                    fn.Close();
                }
                catch { }
            }
        }

        private void formMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(oldIconFolderColor!=null)
                oldIconFolderColor.BackColor = Color.White;
            if (oldFolderColor != null)
                oldFolderColor.BackColor = Color.White;
            if(oldListViewIconColor!=null)
                oldListViewIconColor.BackColor = Color.White;

            treeViewFolders_OnClose();
            treeViewIcons_OnClose();


            FileStream fe = new FileStream("$etting$\\Settings.soap", FileMode.OpenOrCreate);
            SoapFormatter ef = new SoapFormatter();

            float[] settingsArray =
                {
                treeViewFolders.Font.Size,
                treeViewIcons.Font.Size,
                imageListIcons.ImageSize.Height,
                listViewIcons.Font.Size,
                //imageListFolders.ImageSize.Height,
                //imageListIconsFolders.ImageSize.Height
            };
            
            ef.Serialize(fe, settingsArray);
            fe.Close();
        }


        public void treeViewIcons_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            forIconsUpdating = e;

            int nIndex = 0;
            imageListIcons.Images.Clear();
            Icon extractedIcon;

            TreeNode newSelected = e.Node;

            if(oldIconFolderColor!=null)
                oldIconFolderColor.BackColor = Color.White;
            newSelected.BackColor = Color.YellowGreen;
            oldIconFolderColor = newSelected;

            if (listViewIcons.FocusedItem == null)
                buttonAppointment.Enabled = false;

            sourceFolders = newSelected;
            //indexButtonAppointment++;
            //if (indexButtonAppointment >= 3)
            //    buttonAppointment.Enabled = true;

            newSelected.SelectedImageIndex = newSelected.ImageIndex;

            listViewIcons.Items.Clear();
            DirectoryInfo nodeDirInfo = (DirectoryInfo)newSelected.Tag;
            ListViewItem.ListViewSubItem[] subItems;
            ListViewItem item = null;

            try
            {
                DirectoryInfo[] subDirs = nodeDirInfo.GetDirectories();
                //imageListIconsFolders.Images.Add(GetIcon(nodeDirInfo.FullName, true));
                //TreeNodeCollection nodes = treeViewIcons.Nodes;


                GetDirectories(nodeDirInfo.GetDirectories(), newSelected);

                //foreach (DirectoryInfo dir in subDirs)
                //{
                //    item = new ListViewItem(dir.Name, 0);
                //    subItems = new ListViewItem.ListViewSubItem[]
                //              {new ListViewItem.ListViewSubItem(item, "Directory"),
                //       new ListViewItem.ListViewSubItem(item,
                //    dir.LastAccessTime.ToShortDateString())};
                //    item.SubItems.AddRange(subItems);
                //    listViewIcons.Items.Add(item);
                //}
                foreach (FileInfo file in nodeDirInfo.GetFiles())
                {
                    if (!(file.FullName.IndexOf(".ico") > -1)) continue;

                    item = new ListViewItem(file.Name, 1);
                    subItems = new ListViewItem.ListViewSubItem[]
                              { new ListViewItem.ListViewSubItem(item, "File"),
                   new ListViewItem.ListViewSubItem(item,
                file.LastAccessTime.ToShortDateString())};



                    extractedIcon = System.Drawing.Icon.ExtractAssociatedIcon(file.FullName);

                    imageListIcons.Images.Add(extractedIcon);
                    ////////
                    //pictureBox1.Image = extractedIcon.ToBitmap();
                    ////////
                    item.SubItems.AddRange(subItems);
                    //listViewIcons.Items.Add(item);
                    listViewIcons.Items.Add(item.Text, nIndex++);

                }

                listViewIcons.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            catch 
            {
                treeViewFolders.Nodes.Remove(newSelected);
            }

        }

        private void treeViewFolders_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            
            TreeNode newSelected = e.Node;

            targetFolders = newSelected;
            trueButtonAppointmentFolder = true;

            if(oldFolderColor!=null)
                oldFolderColor.BackColor = Color.White;
            newSelected.BackColor = Color.YellowGreen;
            oldFolderColor = newSelected;

            if (trueButtonAppointmentFolder && listViewIcons.FocusedItem != null)
                buttonAppointment.Enabled = true;

            newSelected.SelectedImageIndex = newSelected.ImageIndex;


            DirectoryInfo nodeDirInfo = (DirectoryInfo)newSelected.Tag;
            try
            {
                DirectoryInfo[] subDirs = nodeDirInfo.GetDirectories();

                GetDirectoriesFolders(nodeDirInfo.GetDirectories(), newSelected);
            }
            catch
            {
                treeViewFolders.Nodes.Remove(newSelected);
            }

        }

        private void listViewIcons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(oldListViewIconColor!=null)
                oldListViewIconColor.BackColor = Color.White;
            listViewIcons.FocusedItem.BackColor = Color.YellowGreen;
            oldListViewIconColor = listViewIcons.FocusedItem;
            string Changed = listViewIcons.FocusedItem.Text;

            iconPath = ((DirectoryInfo)sourceFolders.Tag).FullName + @"\" + Changed;

            if (trueButtonAppointmentFolder && listViewIcons.FocusedItem != null)
                buttonAppointment.Enabled = true;
        }


        private void buttonAppointment_Click(object sender, EventArgs e)
        {
            int i = 0;
            string[] filePaths = Directory.GetFiles(((DirectoryInfo)targetFolders.Tag).FullName);
            foreach (var file in filePaths)
            {
                if ((file.IndexOf(".ico") > -1)) i++;
                if ((file.IndexOf(listViewIcons.FocusedItem.Text) > -1)) i--;
            }
            string desktopIniPath = ((DirectoryInfo)targetFolders.Tag).FullName;

            var ff = desktopIniPath + @"\" + listViewIcons.FocusedItem.Text;
            File.Copy(iconPath, ff, true);

            //Magick
            File.SetAttributes(desktopIniPath, FileAttributes.ReadOnly | FileAttributes.Directory);

            FileStream fs = new FileStream(desktopIniPath + @"\desktop.ini", FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine("[.ShellClassInfo]");
            sw.WriteLine("IconResource=" + listViewIcons.FocusedItem.Text + ",0");//+i);
            sw.WriteLine("ConfirmFileOp=0");
            sw.WriteLine("[ViewState]");
            sw.WriteLine("Mode=");
            sw.WriteLine("Vid=");
            sw.WriteLine("FolderType=Generic");

            sw.Close();


            Icon ic = GetIcon(((DirectoryInfo)targetFolders.Tag).FullName, false);
            if (ic == null)
            {
                targetFolders.ImageIndex = 0;
            }
            else
                imageListFolders.Images.Add(ic);
            targetFolders.ImageIndex = indexFolders;
            indexFolders++;


            trueButtonAppointmentFolder = false;
            buttonAppointment.Enabled = false;
        }


        private void buttonShowSettings_Click(object sender, EventArgs e)
        {
            FormSettings formSettings = new FormSettings(this);
            formSettings.Show();
            buttonShowSettings.Enabled = false;
            this.Enabled = false;
        }
    }
}
