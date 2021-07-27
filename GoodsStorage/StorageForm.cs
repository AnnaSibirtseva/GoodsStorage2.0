using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GoodsStorage
{
    public partial class StorageForm : Form
    {
        public static List<Folder> Folders = new List<Folder>();
        public static List<Item> Items = new List<Item>();
        // A list for all the items that will need to be purchased from the CSV report.
        public static List<Item> FoundItems = new List<Item>();
        public static TreeNode CurrentNode;
        public static Folder CurrentFolder;
        public StorageForm()
        {
            InitializeComponent();
            // Setting the minimum and maximum size of the form.
            MaximumSize = SystemInformation.PrimaryMonitorSize;
            int Width = SystemInformation.PrimaryMonitorSize.Width / 2;
            int Height = SystemInformation.PrimaryMonitorSize.Height / 2;
            MinimumSize = new Size(Width, Height);
            CurrentNode = TreeView.Nodes[0];
            CurrentFolder = new Folder(CurrentNode.Text);
            Folders.Add(CurrentFolder);
            TreeView.ImageList = TreeImages;
            // Limiting the files that can be opened.
            SaveFileCSV.Filter = "JavaScript Object Notation files (*.json)|*.json";
            OpenFileCSV.Filter = "JavaScript Object Notation files (*.json)|*.json";
        }
        /// <summary>
        /// Method that calls other things to rename an element.
        /// </summary>
        private void RenameItem_Click(object sender, EventArgs e)
        {
            // Creating new form to get a new name.
            NewFolder newName = new NewFolder();
            newName.Show();
            // Changing this variable to execute the right part of the code.
            newName.Changes = true;
        }
        /// <summary>
        /// Method for deleting a folder.
        /// </summary>
        private void DeleteFolder_CLick(object sender, EventArgs e)
        {
            Folder foundedFolder = null;
            for (int i = 0; i < Folders.Count; i++)
            {
                if (CurrentNode.Text == Folders[i].Name)
                {
                    // Checking that there are no items nested in this folder.
                    if (Folders[i].AllNodes.Count > 0)
                    {
                        MessageBox.Show("You can't delete folders that have something in them.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    }
                    else
                    {
                        // Removing thr folder from everywhere.
                        if (CurrentNode.Parent != null)
                        {
                            CurrentNode.Parent.Nodes.Remove(CurrentNode);
                            foundedFolder = Folders[i];
                            Folders.Remove(Folders[i]);
                        }
                        else
                        {
                            MessageBox.Show("You can't delete the parent folder.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                        }
                    }
                }
            }
            for (int i = 0; i < Folders.Count; i++)
            {
                FindFolderToDelete(Folders[i], foundedFolder);
            }
        }
        /// <summary>
        /// Method for deleting user selected folder.
        /// </summary>
        /// <param name="currentFolder">Current folder to look in.</param>
        /// <param name="folderToDelete">Folder that we need to delete.</param>
        private static void FindFolderToDelete(Folder currentFolder, Folder folderToDelete)
        {
            if (currentFolder.AllNodes.Count > 0)
            {
                for (int i = 0; i < currentFolder.AllNodes.Count; i++)
                {
                    if (currentFolder.AllNodes[i] is Folder)
                    {
                        if ((currentFolder.AllNodes[i] as Folder).AllNodes.Count > 0)
                        {
                            // Calling this method again to find all folders.
                            FindFolderToDelete(currentFolder.AllNodes[i] as Folder, folderToDelete);
                        }
                        else if (currentFolder.AllNodes[i] == folderToDelete)
                        {
                            currentFolder.AllNodes.Remove(currentFolder.AllNodes[i]);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Method for deleting item from all folders.
        /// </summary>
        /// <param name="currentFolder">Current folder to look for item in.</param>
        /// <param name="itemToDelete">Item that must be deleted.</param>
        private static void FindItemsToDelete(Folder currentFolder, Item itemToDelete)
        {
            for (int i = 0; i < currentFolder.AllNodes.Count; i++)
            {
                if ((currentFolder.AllNodes[i] is Item) && (currentFolder.AllNodes[i] == itemToDelete))
                {
                    currentFolder.AllNodes.Remove(currentFolder.AllNodes[i]);
                }
                else if ((currentFolder.AllNodes[i] is Folder) && (currentFolder.AllNodes[i] as Folder).AllNodes.Count > 0)
                {
                    // Calling this method to find item in all folders.
                    FindItemsToDelete(currentFolder.AllNodes[i] as Folder, itemToDelete);
                }
            }

        }
        /// <summary>
        /// Method for creating a new item.
        /// </summary>
        private void CreateItem_Click(object sender, EventArgs e)
        {
            // A new form that will create a new item later.
            NewItem item = new NewItem();
            item.Show();
        }
        /// <summary>
        /// Method for creating a new folder.
        /// </summary>
        private void CreateFolder_Click(object sender, EventArgs e)
        {
            // A new form that will create a new folder later.
            NewFolder folder = new NewFolder();
            folder.Show();
        }
        /// <summary>
        /// Method for saving the report about items in storage.
        /// </summary>
        private void SaveCSV_Click(object sender, EventArgs e)
        {
            // Creating new form to get a new name.
            NewFolder newCSV = new NewFolder();
            // Changing some labels for better inteface.
            newCSV.Text = " Minimum Quantity";
            newCSV.TextBox.Text = "Enter the minimum quantity of goods in stock";
            Font font = new Font(newCSV.TextBox.Font.FontFamily, 13.0F);
            newCSV.TextBox.Font = font;
            newCSV.Show();
            // Changing this variable to execute the right part of the code.
            newCSV.ForCSVFiles = true;
        }
        /// <summary>
        /// Method for saving current warehouse information.
        /// </summary>
        private void SaveItem_Click(object sender, EventArgs e)
        {
            if (SaveFileCSV.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter streamWriter = new StreamWriter(new FileStream(SaveFileCSV.FileName, FileMode.Create)))
                {
                    JsonSerializer jsonSerializer = new JsonSerializer();
                    // Saving only first folder since it srore all the others folders and items inside.
                    SavedAll(Folders[0]);
                    jsonSerializer.Serialize(streamWriter, Folders[0]);
                }
            }
        }
        /// <summary>
        /// Method for saving everything in the folder.
        /// </summary>
        /// <param name="folder">Current folder for looking in.</param>
        private static void SavedAll(Folder folder)
        {
            for(int i = 0; i < folder.AllNodes.Count; i++)
            {
                if(folder.AllNodes[i] is Folder)
                {
                    // Saving folder to the list that will be deserialize later.
                    folder.AllFolders.Add(folder.AllNodes[i] as Folder);
                    // Calling method again if there are other folders inside.
                    SavedAll(folder.AllNodes[i] as Folder);
                }
                else if(folder.AllNodes[i] is Item)
                {
                    // Saving item to the list that will deserialize later.
                    folder.AllItems.Add(folder.AllNodes[i] as Item);
                }
            }
        }
        /// <summary>
        /// Method for openning saved warehouse.
        /// </summary>
        private void OpenItem_Click(object sender, EventArgs e)
        {
            if (OpenFileCSV.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader streamReader = new StreamReader(new FileStream(OpenFileCSV.FileName, FileMode.Open)))
                {
                    string savedData = streamReader.ReadToEnd();
                    var cSavedThings = JsonConvert.DeserializeObject<Folder>(savedData);
                    // Cleaning the treeview.
                    TreeView.Nodes.Clear();
                    // Cleaning the inner objects in the folder.
                    for (int i = 0; i < Folders.Count; i++)
                    {
                        Folders[i].AllNodes = new List<Node>();
                    }
                    // Removing all the objects from the list inside the folder.
                    Folders = new List<Folder>();
                    Items = new List<Item>();
                    TreeNode folder = new TreeNode { Text = cSavedThings.FolderName, ImageIndex = 0, SelectedImageIndex = 0 };
                    TreeView.Nodes.Add(folder);
                    CurrentNode = TreeView.Nodes[0];
                    CurrentFolder = cSavedThings;
                    Folders.Add(CurrentFolder);
                    Folders[0].Name = Folders[0].FolderName;
                    // Calling method for recreating a tree.
                    CreateATree(Folders[0], TreeView.Nodes[0]);
                }
            }
        }
        /// <summary>
        /// Method for recreating a treeview.
        /// </summary>
        /// <param name="folder">Current folder to start with.</param>
        private static void CreateATree(Folder folder, TreeNode node)
        {
            // Additing all the items in tree firstly.
            for(int i = 0; i < folder.AllItems.Count; i++)
            {
                TreeNode item = new TreeNode { Text = folder.AllItems[i].Name, ImageIndex = 1, SelectedImageIndex = 1 };
                node.Nodes.Add(item);
                Items.Add(folder.AllItems[i]);
                // Add item to list of nodes of current folder.
                folder.AllNodes.Add(folder.AllItems[i]);
            }
            // Additing all the folders in tree secondly.
            for (int i = 0; i < folder.AllFolders.Count; i++)
            {
                TreeNode new_folder = new TreeNode { Text = folder.AllFolders[i].Name, ImageIndex = 0, SelectedImageIndex = 0 };
                node.Nodes.Add(new_folder);
                Folders.Add(folder.AllFolders[i]);
                folder.AllNodes.Add(folder.AllFolders[i]);
                CreateATree(folder.AllFolders[i] as Folder, new_folder);
            }
            
        }
        /// <summary>
        /// Method for finding all items that we need to by later.
        /// </summary>
        /// <param name="folder">Current folder to look in.</param>
        /// <param name="item">Item that we're looking for.</param>
        public static void FindAllLackingItems(Folder folder, Item item)
        {
            bool found = false;
            // Creating a path for the item.
            if (item.Path != "")
            {
                item.Path += "/" + folder.Name;
            }
            else
            {
                item.Path += folder.Name;
            }
            // Trying to find item in the current folder.
            for(int i = 0; i < folder.AllNodes.Count; i++)
            {
                if(folder.AllNodes[i] is Item)
                {
                    if((folder.AllNodes[i] as Item) == item)
                    {
                        FoundItems.Add(item);
                        // If item was found then changing the bool variable.
                        found = true;
                    }
                }
            }
            // If item was not found, trying to look for it in inner folders.
            if (!found)
            {
                for (int i = 0; i < folder.AllNodes.Count; i++)
                {
                    if (folder.AllNodes[i] is Item)
                    {
                        if ((folder.AllNodes[i] as Item) == item)
                        {
                            FoundItems.Add(item);
                        }
                    }
                    else if (folder.AllNodes[i] is Folder)
                    {
                        // Calling this method again to find the item.
                        FindAllLackingItems(folder.AllNodes[i] as Folder, item);
                    }
                }
            }
        }
        /// <summary>
        /// Method for creating some necessary things before the program starts working with the user.
        /// </summary>
        private void StorageForm_Activated(object sender, EventArgs e)
        {
            CreateNewDataGtid();

            // Subscribing all buttons to the corresponding operators.
            NewFile.Click += OpenItem_Click;
            Save.Click += SaveItem_Click;
            CSVFile.Click += SaveCSV_Click;

            CreateNewFolder.Click += CreateFolder_Click;
            CreateNewItem.Click += CreateItem_Click;
            Delete.Click += DeleteFolder_CLick;
            Rename.Click += RenameItem_Click;
            Exit.Click += ExitItem_Click;

            RenameSth.Click += RenameItem_Click;
            ChangeSth.Click += ChangeItem_Click;
            DeleteSth.Click += DeleteItem_Click;

            // Coloring the datagrid in AliceBlue for 
            DataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.AliceBlue;
            DataGridView.EnableHeadersVisualStyles = false;
        }
        /// <summary>
        /// Method for exiting the eplication.
        /// </summary>
        private void ExitItem_Click(object sender, EventArgs e)
        {
            // Closing the form.
            this.Close();
        }
        /// <summary>
        /// Method to find item to delete and remove it from eveywhere.
        /// </summary>
        private void DeleteItem_Click(object sender, EventArgs e)
        {
            Item foundedItem = null;
            for (int i = 0; i < Items.Count; i++)
            {
                if (CurrentNode.Text == Items[i].Name)
                {
                    // Removing from everywhere.
                    CurrentNode.Parent.Nodes.Remove(CurrentNode);
                    foundedItem = Items[i];
                    Items.Remove(Items[i]);
                }
            }
            for (int i = 0; i < Folders.Count; i++)
            {
                // Calling method to delete item in the folder.
                FindItemsToDelete(Folders[i], foundedItem);
            }
        }
        /// <summary>
        /// Method for changing an item.
        /// </summary>
        private void ChangeItem_Click(object sender, EventArgs e)
        {
            // Creating new form to get a new name.
            NewItem newItem = new NewItem();
            newItem.Show();
            // Changing this variable to execute the right part of the code.
            newItem.ChangeItem = true;
        }
        /// <summary>
        /// Changing the context menu depending on where the user clicked.
        /// </summary>
        private void CreateNewDataGtid()
        {
            // Cleaning everything up.
            this.DataGridView.Rows.Clear();
            this.DataGridView.Columns.Clear();
            this.DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            string[] titles = new string[4] { "Product Name", "Article Number", "Quantity", "Price" };
            for (int i = 0; i < 4; i++)
            {
                DataGridViewColumn column = new DataGridViewColumn();
                column.Name = titles[i];
                column.ReadOnly = true;
                column.CellTemplate = new DataGridViewTextBoxCell();
                DataGridView.Columns.Add(column);
                // Coloring DataGrid inside.
                foreach (DataGridViewRow row in DataGridView.Rows)
                {
                    row.DefaultCellStyle.BackColor = Color.AliceBlue;
                }
                foreach (DataGridViewColumn col in DataGridView.Columns)
                {
                    col.DefaultCellStyle.BackColor = Color.AliceBlue;
                }
            }
        }
        /// <summary>
        /// Method for finding all items in folder.
        /// </summary>
        /// <param name="folder">Current folder to check.</param>
        /// <param name="inFolder">String for interface for user to see how deep item is.</param>
        private void FindAllItems(Folder folder, string inFolder)
        {
            inFolder += ">";
            if (folder.AllNodes.Count > 0)
            {
                foreach (var node in folder.AllNodes)
                {
                    if (node is Item)
                    {
                        // Creating a new row int the DataGarid.
                        string[] row = new string[4] { inFolder + (node as Item).Name, (node as Item).VendorСode.ToString(), (node as Item).Amount.ToString(), (node as Item).Price.ToString() };
                        this.DataGridView.Rows.Add(row);
                    }
                    if (node is Folder)
                    {
                        // Calling method again for the next folder.
                        FindAllItems(node as Folder, inFolder);
                    }
                }
            }
        }
        /// <summary>
        /// Method for creating a new DataGrid.
        /// </summary>
        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            CurrentNode = TreeView.SelectedNode;
            CreateNewDataGtid();
            if (CurrentNode != null)
            {
                // If it is a folder, then there is an option to add items in the context menu.
                for (int i = 0; i < Folders.Count; i++)
                {
                    if (CurrentNode.Text == Folders[i].Name)
                    {
                        TreeView.ContextMenuStrip = FolderContextMenu;
                        CurrentFolder = Folders[i];
                        // Calling method to fill in the DataGrid.
                        FindAllItems(Folders[i], " ");
                        TableName.Text = $"All Items in the Folder '{Folders[i].Name}'";
                    }
                }
                // If this is an item, then there is a change in the context menu.
                for (int i = 0; i < Items.Count; i++)
                {
                    if (Items[i].Name == CurrentNode.Text)
                    {
                        TreeView.ContextMenuStrip = ItemContextMenu;
                        // Cleaning up old DataGrid.
                        CreateNewDataGtid();
                        string[] row = new string[4] { Items[i].Name, Items[i].VendorСode.ToString(), Items[i].Amount.ToString(), Items[i].Price.ToString() };
                        DataGridView.Rows.Add(row);
                        TableName.Text = $"Item '{Items[i].Name}' Information";
                    }
                }
            }
        }
        /// <summary>
        /// Showing the information about inner items.
        /// </summary>
        private void InformButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Here you will see information about the products in the folders. \n The '>' icon indicates an attachment somewhere.\nThat is, if the item is nested in some folder.\n If you want to see changes to the product / folder, then click on another item, and then click on the folder / item again.", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
        }
    }
}
