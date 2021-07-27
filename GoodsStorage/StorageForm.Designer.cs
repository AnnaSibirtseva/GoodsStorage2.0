namespace GoodsStorage
{
    partial class StorageForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("New Classifier");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StorageForm));
            this.TableLayoutPanelOne = new System.Windows.Forms.TableLayoutPanel();
            this.TableLayoutPanelTwo = new System.Windows.Forms.TableLayoutPanel();
            this.TreeView = new System.Windows.Forms.TreeView();
            this.FolderContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Create = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateNewFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateNewItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Rename = new System.Windows.Forms.ToolStripMenuItem();
            this.Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.TableLayoutPanelTree = new System.Windows.Forms.TableLayoutPanel();
            this.DataGridView = new System.Windows.Forms.DataGridView();
            this.TableLayoutPanelFour = new System.Windows.Forms.TableLayoutPanel();
            this.TableName = new System.Windows.Forms.Label();
            this.InformButton = new System.Windows.Forms.Button();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.NewFile = new System.Windows.Forms.ToolStripMenuItem();
            this.Save = new System.Windows.Forms.ToolStripMenuItem();
            this.CSVFile = new System.Windows.Forms.ToolStripMenuItem();
            this.Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeImages = new System.Windows.Forms.ImageList(this.components);
            this.ItemContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RenameSth = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteSth = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangeSth = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFileCSV = new System.Windows.Forms.OpenFileDialog();
            this.SaveFileCSV = new System.Windows.Forms.SaveFileDialog();
            this.TableLayoutPanelOne.SuspendLayout();
            this.TableLayoutPanelTwo.SuspendLayout();
            this.FolderContextMenu.SuspendLayout();
            this.TableLayoutPanelTree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
            this.TableLayoutPanelFour.SuspendLayout();
            this.MenuStrip.SuspendLayout();
            this.ItemContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableLayoutPanelOne
            // 
            this.TableLayoutPanelOne.ColumnCount = 1;
            this.TableLayoutPanelOne.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanelOne.Controls.Add(this.TableLayoutPanelTwo, 0, 1);
            this.TableLayoutPanelOne.Controls.Add(this.MenuStrip, 0, 0);
            this.TableLayoutPanelOne.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanelOne.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanelOne.Name = "TableLayoutPanelOne";
            this.TableLayoutPanelOne.RowCount = 2;
            this.TableLayoutPanelOne.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.888889F));
            this.TableLayoutPanelOne.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.11111F));
            this.TableLayoutPanelOne.Size = new System.Drawing.Size(800, 450);
            this.TableLayoutPanelOne.TabIndex = 0;
            // 
            // TableLayoutPanelTwo
            // 
            this.TableLayoutPanelTwo.ColumnCount = 2;
            this.TableLayoutPanelTwo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanelTwo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanelTwo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanelTwo.Controls.Add(this.TreeView, 0, 0);
            this.TableLayoutPanelTwo.Controls.Add(this.TableLayoutPanelTree, 1, 0);
            this.TableLayoutPanelTwo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanelTwo.Location = new System.Drawing.Point(3, 34);
            this.TableLayoutPanelTwo.Name = "TableLayoutPanelTwo";
            this.TableLayoutPanelTwo.RowCount = 1;
            this.TableLayoutPanelTwo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanelTwo.Size = new System.Drawing.Size(794, 413);
            this.TableLayoutPanelTwo.TabIndex = 0;
            // 
            // TreeView
            // 
            this.TreeView.BackColor = System.Drawing.Color.AliceBlue;
            this.TreeView.ContextMenuStrip = this.FolderContextMenu;
            this.TreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeView.Location = new System.Drawing.Point(3, 3);
            this.TreeView.Name = "TreeView";
            treeNode1.ImageIndex = 0;
            treeNode1.Name = "NewClassifier";
            treeNode1.Text = "New Classifier";
            this.TreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.TreeView.Size = new System.Drawing.Size(391, 407);
            this.TreeView.TabIndex = 0;
            this.TreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView_AfterSelect);
            // 
            // FolderContextMenu
            // 
            this.FolderContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.FolderContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Create,
            this.Rename,
            this.Delete});
            this.FolderContextMenu.Name = "GridContextMenu";
            this.FolderContextMenu.Size = new System.Drawing.Size(137, 82);
            // 
            // Create
            // 
            this.Create.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateNewFolder,
            this.CreateNewItem});
            this.Create.Image = ((System.Drawing.Image)(resources.GetObject("Create.Image")));
            this.Create.Name = "Create";
            this.Create.Size = new System.Drawing.Size(136, 26);
            this.Create.Text = "Create";
            // 
            // CreateNewFolder
            // 
            this.CreateNewFolder.Image = ((System.Drawing.Image)(resources.GetObject("CreateNewFolder.Image")));
            this.CreateNewFolder.Name = "CreateNewFolder";
            this.CreateNewFolder.Size = new System.Drawing.Size(168, 26);
            this.CreateNewFolder.Text = "New Folder";
            // 
            // CreateNewItem
            // 
            this.CreateNewItem.Image = ((System.Drawing.Image)(resources.GetObject("CreateNewItem.Image")));
            this.CreateNewItem.Name = "CreateNewItem";
            this.CreateNewItem.Size = new System.Drawing.Size(168, 26);
            this.CreateNewItem.Text = "New Item";
            // 
            // Rename
            // 
            this.Rename.Image = ((System.Drawing.Image)(resources.GetObject("Rename.Image")));
            this.Rename.Name = "Rename";
            this.Rename.Size = new System.Drawing.Size(136, 26);
            this.Rename.Text = "Rename";
            // 
            // Delete
            // 
            this.Delete.Image = ((System.Drawing.Image)(resources.GetObject("Delete.Image")));
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(136, 26);
            this.Delete.Text = "Delete";
            // 
            // TableLayoutPanelTree
            // 
            this.TableLayoutPanelTree.ColumnCount = 1;
            this.TableLayoutPanelTree.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanelTree.Controls.Add(this.DataGridView, 0, 1);
            this.TableLayoutPanelTree.Controls.Add(this.TableLayoutPanelFour, 0, 0);
            this.TableLayoutPanelTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanelTree.Location = new System.Drawing.Point(400, 3);
            this.TableLayoutPanelTree.Name = "TableLayoutPanelTree";
            this.TableLayoutPanelTree.RowCount = 2;
            this.TableLayoutPanelTree.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.82801F));
            this.TableLayoutPanelTree.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.17199F));
            this.TableLayoutPanelTree.Size = new System.Drawing.Size(391, 407);
            this.TableLayoutPanelTree.TabIndex = 1;
            // 
            // DataGridView
            // 
            this.DataGridView.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridView.GridColor = System.Drawing.SystemColors.ControlText;
            this.DataGridView.Location = new System.Drawing.Point(3, 43);
            this.DataGridView.Name = "DataGridView";
            this.DataGridView.RowHeadersVisible = false;
            this.DataGridView.RowHeadersWidth = 51;
            this.DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DataGridView.Size = new System.Drawing.Size(385, 361);
            this.DataGridView.TabIndex = 0;
            this.DataGridView.Text = "dataGridView1";
            // 
            // TableLayoutPanelFour
            // 
            this.TableLayoutPanelFour.ColumnCount = 2;
            this.TableLayoutPanelFour.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.TableLayoutPanelFour.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.TableLayoutPanelFour.Controls.Add(this.TableName, 0, 0);
            this.TableLayoutPanelFour.Controls.Add(this.InformButton, 1, 0);
            this.TableLayoutPanelFour.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanelFour.Location = new System.Drawing.Point(3, 3);
            this.TableLayoutPanelFour.Name = "TableLayoutPanelFour";
            this.TableLayoutPanelFour.RowCount = 1;
            this.TableLayoutPanelFour.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanelFour.Size = new System.Drawing.Size(385, 34);
            this.TableLayoutPanelFour.TabIndex = 2;
            // 
            // TableName
            // 
            this.TableName.AutoSize = true;
            this.TableName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableName.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TableName.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.TableName.Location = new System.Drawing.Point(3, 0);
            this.TableName.Name = "TableName";
            this.TableName.Size = new System.Drawing.Size(340, 34);
            this.TableName.TabIndex = 1;
            this.TableName.Text = "All Items in the Folder";
            this.TableName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InformButton
            // 
            this.InformButton.BackColor = System.Drawing.SystemColors.Info;
            this.InformButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InformButton.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.InformButton.Location = new System.Drawing.Point(349, 3);
            this.InformButton.Name = "InformButton";
            this.InformButton.Size = new System.Drawing.Size(33, 28);
            this.InformButton.TabIndex = 2;
            this.InformButton.Text = "?";
            this.InformButton.UseVisualStyleBackColor = false;
            this.InformButton.Click += new System.EventHandler(this.InformButton_Click);
            // 
            // MenuStrip
            // 
            this.MenuStrip.BackColor = System.Drawing.Color.AliceBlue;
            this.MenuStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(800, 31);
            this.MenuStrip.TabIndex = 1;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // Menu
            // 
            this.Menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewFile,
            this.Save,
            this.CSVFile,
            this.Exit});
            this.Menu.Image = ((System.Drawing.Image)(resources.GetObject("Menu.Image")));
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(80, 27);
            this.Menu.Text = "Menu";
            // 
            // NewFile
            // 
            this.NewFile.Image = ((System.Drawing.Image)(resources.GetObject("NewFile.Image")));
            this.NewFile.Name = "NewFile";
            this.NewFile.Size = new System.Drawing.Size(155, 26);
            this.NewFile.Text = "Open File";
            // 
            // Save
            // 
            this.Save.Image = ((System.Drawing.Image)(resources.GetObject("Save.Image")));
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(155, 26);
            this.Save.Text = "Save";
            // 
            // CSVFile
            // 
            this.CSVFile.Image = ((System.Drawing.Image)(resources.GetObject("CSVFile.Image")));
            this.CSVFile.Name = "CSVFile";
            this.CSVFile.Size = new System.Drawing.Size(155, 26);
            this.CSVFile.Text = "Save CSV";
            // 
            // Exit
            // 
            this.Exit.Image = ((System.Drawing.Image)(resources.GetObject("Exit.Image")));
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(155, 26);
            this.Exit.Text = "Exit";
            // 
            // TreeImages
            // 
            this.TreeImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.TreeImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("TreeImages.ImageStream")));
            this.TreeImages.TransparentColor = System.Drawing.Color.Transparent;
            this.TreeImages.Images.SetKeyName(0, "treefolder (2).png");
            this.TreeImages.Images.SetKeyName(1, "label.png");
            // 
            // ItemContextMenu
            // 
            this.ItemContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ItemContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RenameSth,
            this.DeleteSth,
            this.ChangeSth});
            this.ItemContextMenu.Name = "ItemContextMenu";
            this.ItemContextMenu.Size = new System.Drawing.Size(137, 82);
            // 
            // RenameSth
            // 
            this.RenameSth.Image = ((System.Drawing.Image)(resources.GetObject("RenameSth.Image")));
            this.RenameSth.Name = "RenameSth";
            this.RenameSth.Size = new System.Drawing.Size(136, 26);
            this.RenameSth.Text = "Rename";
            // 
            // DeleteSth
            // 
            this.DeleteSth.Image = ((System.Drawing.Image)(resources.GetObject("DeleteSth.Image")));
            this.DeleteSth.Name = "DeleteSth";
            this.DeleteSth.Size = new System.Drawing.Size(136, 26);
            this.DeleteSth.Text = "Delete";
            // 
            // ChangeSth
            // 
            this.ChangeSth.Image = ((System.Drawing.Image)(resources.GetObject("ChangeSth.Image")));
            this.ChangeSth.Name = "ChangeSth";
            this.ChangeSth.Size = new System.Drawing.Size(136, 26);
            this.ChangeSth.Text = "Change";
            // 
            // OpenFileCSV
            // 
            this.OpenFileCSV.FileName = "openFileDialog1";
            // 
            // StorageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TableLayoutPanelOne);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "StorageForm";
            this.Text = "Goods Storage";
            this.Load += new System.EventHandler(this.StorageForm_Activated);
            this.TableLayoutPanelOne.ResumeLayout(false);
            this.TableLayoutPanelOne.PerformLayout();
            this.TableLayoutPanelTwo.ResumeLayout(false);
            this.FolderContextMenu.ResumeLayout(false);
            this.TableLayoutPanelTree.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
            this.TableLayoutPanelFour.ResumeLayout(false);
            this.TableLayoutPanelFour.PerformLayout();
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.ItemContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TableLayoutPanelOne;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPanelTwo;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem Menu;
        private System.Windows.Forms.ToolStripMenuItem NewFile;
        private System.Windows.Forms.ToolStripMenuItem Save;
        private System.Windows.Forms.ToolStripMenuItem CSVFile;
        private System.Windows.Forms.DataGridView DataGridView;
        private System.Windows.Forms.ContextMenuStrip FolderContextMenu;
        private System.Windows.Forms.ToolStripMenuItem Create;
        private System.Windows.Forms.ToolStripMenuItem Rename;
        private System.Windows.Forms.ToolStripMenuItem Delete;
        public System.Windows.Forms.TreeView TreeView;
        private System.Windows.Forms.ToolStripMenuItem CreateNewFolder;
        private System.Windows.Forms.ToolStripMenuItem CreateNewItem;
        public System.Windows.Forms.ImageList TreeImages;
        private System.Windows.Forms.ContextMenuStrip ItemContextMenu;
        private System.Windows.Forms.ToolStripMenuItem RenameSth;
        private System.Windows.Forms.ToolStripMenuItem DeleteSth;
        private System.Windows.Forms.ToolStripMenuItem ChangeSth;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPanelTree;
        private System.Windows.Forms.Label TableName;
        private System.Windows.Forms.ToolStripMenuItem Exit;
        private System.Windows.Forms.OpenFileDialog OpenFileCSV;
        private System.Windows.Forms.SaveFileDialog SaveFileCSV;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPanelFour;
        private System.Windows.Forms.Button InformButton;
    }
}

