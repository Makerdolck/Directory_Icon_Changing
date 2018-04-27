namespace IconsChanger
{
    partial class formMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formMain));
            this.imageListIconsFolders = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonShowSettings = new System.Windows.Forms.Button();
            this.buttonAppointment = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeViewFolders = new System.Windows.Forms.TreeView();
            this.imageListFolders = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.listViewIcons = new System.Windows.Forms.ListView();
            this.imageListIcons = new System.Windows.Forms.ImageList(this.components);
            this.treeViewIcons = new System.Windows.Forms.TreeView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageListIconsFolders
            // 
            this.imageListIconsFolders.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListIconsFolders.ImageStream")));
            this.imageListIconsFolders.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListIconsFolders.Images.SetKeyName(0, "system.ico");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonShowSettings);
            this.panel1.Controls.Add(this.buttonAppointment);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(845, 56);
            this.panel1.TabIndex = 0;
            // 
            // buttonShowSettings
            // 
            this.buttonShowSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonShowSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonShowSettings.Location = new System.Drawing.Point(77, 9);
            this.buttonShowSettings.Margin = new System.Windows.Forms.Padding(0);
            this.buttonShowSettings.Name = "buttonShowSettings";
            this.buttonShowSettings.Size = new System.Drawing.Size(178, 44);
            this.buttonShowSettings.TabIndex = 1;
            this.buttonShowSettings.Text = "Настройки";
            this.buttonShowSettings.UseVisualStyleBackColor = true;
            this.buttonShowSettings.Click += new System.EventHandler(this.buttonShowSettings_Click);
            // 
            // buttonAppointment
            // 
            this.buttonAppointment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAppointment.Enabled = false;
            this.buttonAppointment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAppointment.Location = new System.Drawing.Point(521, 9);
            this.buttonAppointment.Margin = new System.Windows.Forms.Padding(0);
            this.buttonAppointment.Name = "buttonAppointment";
            this.buttonAppointment.Size = new System.Drawing.Size(178, 44);
            this.buttonAppointment.TabIndex = 0;
            this.buttonAppointment.Text = "Назначить иконку";
            this.buttonAppointment.UseVisualStyleBackColor = true;
            this.buttonAppointment.Click += new System.EventHandler(this.buttonAppointment_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 56);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeViewFolders);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(845, 546);
            this.splitContainer1.SplitterDistance = 353;
            this.splitContainer1.TabIndex = 1;
            // 
            // treeViewFolders
            // 
            this.treeViewFolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewFolders.ImageIndex = 0;
            this.treeViewFolders.ImageList = this.imageListFolders;
            this.treeViewFolders.Location = new System.Drawing.Point(0, 0);
            this.treeViewFolders.Name = "treeViewFolders";
            this.treeViewFolders.SelectedImageIndex = 0;
            this.treeViewFolders.Size = new System.Drawing.Size(353, 546);
            this.treeViewFolders.TabIndex = 0;
            this.treeViewFolders.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewFolders_NodeMouseClick);
            // 
            // imageListFolders
            // 
            this.imageListFolders.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageListFolders.ImageSize = new System.Drawing.Size(32, 32);
            this.imageListFolders.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(32, 256);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(282, 212);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.listViewIcons);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.treeViewIcons);
            this.splitContainer2.Size = new System.Drawing.Size(488, 546);
            this.splitContainer2.SplitterDistance = 147;
            this.splitContainer2.TabIndex = 0;
            // 
            // listViewIcons
            // 
            this.listViewIcons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewIcons.LargeImageList = this.imageListIcons;
            this.listViewIcons.Location = new System.Drawing.Point(0, 0);
            this.listViewIcons.Name = "listViewIcons";
            this.listViewIcons.Size = new System.Drawing.Size(488, 147);
            this.listViewIcons.TabIndex = 1;
            this.listViewIcons.UseCompatibleStateImageBehavior = false;
            this.listViewIcons.SelectedIndexChanged += new System.EventHandler(this.listViewIcons_SelectedIndexChanged);
            // 
            // imageListIcons
            // 
            this.imageListIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageListIcons.ImageSize = new System.Drawing.Size(16, 16);
            this.imageListIcons.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // treeViewIcons
            // 
            this.treeViewIcons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewIcons.ImageIndex = 0;
            this.treeViewIcons.ImageList = this.imageListIconsFolders;
            this.treeViewIcons.Location = new System.Drawing.Point(0, 0);
            this.treeViewIcons.Name = "treeViewIcons";
            this.treeViewIcons.SelectedImageIndex = 0;
            this.treeViewIcons.Size = new System.Drawing.Size(488, 395);
            this.treeViewIcons.StateImageList = this.imageListIconsFolders;
            this.treeViewIcons.TabIndex = 0;
            this.treeViewIcons.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewIcons_NodeMouseClick);
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 602);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formMain";
            this.Text = "Icons Changer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formMain_FormClosing);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.ImageList imageListIconsFolders;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.TreeView treeViewFolders;
        public System.Windows.Forms.ListView listViewIcons;
        public System.Windows.Forms.TreeView treeViewIcons;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        public System.Windows.Forms.ImageList imageListIcons;
        public System.Windows.Forms.ImageList imageListFolders;
        private System.Windows.Forms.Button buttonAppointment;
        public System.Windows.Forms.Button buttonShowSettings;
    }
}

