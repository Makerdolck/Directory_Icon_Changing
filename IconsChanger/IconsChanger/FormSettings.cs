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


namespace IconsChanger
{
    public partial class FormSettings : Form
    {
        formMain mainForm;

        public FormSettings(formMain f)
        {
            InitializeComponent();
            mainForm = f;

            folderFontSize.Value = (decimal)mainForm.treeViewFolders.Font.Size;
            iconFolderFontSize.Value = (decimal)mainForm.treeViewIcons.Font.Size;
            iconsSize.Value = (decimal)mainForm.imageListIcons.ImageSize.Height;

        }

        private void FormSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainForm.Enabled = true;
            mainForm.buttonShowSettings.Enabled = true;

            var rr = mainForm.listViewIcons.Font.Size / mainForm.imageListIcons.ImageSize.Height * (int)iconsSize.Value;
            mainForm.listViewIcons.Font = new Font("Microsoft Sans Serif", (float)(rr));
            mainForm.imageListIcons.ImageSize = new Size((int)iconsSize.Value, (int)iconsSize.Value);

            //rr = mainForm.imageListFolders.ImageSize.Height / mainForm.treeViewFolders.Font.Size * (float)folderFontSize.Value;
            //mainForm.imageListFolders.ImageSize = new Size((int)rr, (int)rr);
            mainForm.treeViewFolders.Font = new Font("Microsoft Sans Serif", (float)folderFontSize.Value);

            //rr = mainForm.imageListIconsFolders.ImageSize.Height / mainForm.treeViewIcons.Font.Size * (float)iconFolderFontSize.Value;
            //mainForm.imageListIconsFolders.ImageSize = new Size((int)rr, (int)rr);
            mainForm.treeViewIcons.Font = new Font("Microsoft Sans Serif", (float)iconFolderFontSize.Value);
            
            
            if (mainForm.oldIconFolderColor != null)
                mainForm.treeViewIcons_NodeMouseClick(mainForm.treeViewIcons, mainForm.forIconsUpdating);


            //Icon ic = null;
            //mainForm.imageListIconsFolders.Images.Clear();

            //ic = mainForm.GetIcon(@".", false);
            //mainForm.imageListIconsFolders.Images.Add(ic);
            //mainForm.indexIconsFolders = 1;
            //foreach (TreeNode nodeToRestore in mainForm.treeViewIcons.Nodes)
            //{
            //    TreeIconFoldersUpdate(nodeToRestore);
            //}
            
        }

        //private void TreeIconFoldersUpdate(TreeNode nodeToRestore)
        //{
        //    Icon ic = null;
        //    if (nodeToRestore != null && nodeToRestore.FullPath != null)
        //    {

        //        ic = mainForm.GetIcon(((DirectoryInfo)nodeToRestore.Tag).FullName, true);
        //        if (ic == null)
        //        {
        //            nodeToRestore.ImageIndex = 0;
        //            //return;
        //        }
        //        else
        //            mainForm.imageListIconsFolders.Images.Add(ic);
        //        if (nodeToRestore.ImageIndex == -1)
        //        {
        //            nodeToRestore.ImageIndex = mainForm.indexIconsFolders;
        //            mainForm.indexIconsFolders++;
        //        }
        //    }

        //    foreach (TreeNode childNode in nodeToRestore.Nodes)
        //    {
        //        TreeIconFoldersUpdate(childNode);
        //    }
        //}
    }
}
