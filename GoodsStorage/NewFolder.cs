using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace GoodsStorage
{
    public partial class NewFolder : Form
    {
        // A variable to check whether we are making changes or just creating a new element.
        public bool Changes;
        // Variable to understand that we need a report.
        public bool ForCSVFiles;
        public NewFolder()
        {
            InitializeComponent();
            // Limiting the files that can be opened.
            SaveFileDialog.Filter = "Comma-Separated Values (*.csv)|*.csv";
        }
        /// <summary>
        /// Method for creating a folder or for changing the node name.
        /// </summary>
        private void ContinueButton_Click(object sender, EventArgs e)
        {
            // Checking what are we going to do: create or rename.
            if (!Changes)
            {
                if (!ForCSVFiles)
                {
                    if (this.NameBox.Text != null && this.NameBox.Text != "")
                    {
                        // If folder does not exists.
                        if (ContainsFolder(NameBox.Text))
                        {
                            CreateFolder(NameBox.Text);
                        }
                        else
                        {
                            MessageBox.Show("The folder with this name already exists.", "OOPS", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                        }

                    }
                    else
                    {
                        MessageBox.Show("You didn't enter a name, so the folder wasn't created.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    }
                }
                else
                {
                    FindNumber(NameBox.Text, SaveFileDialog);
                }
            }
            else
            {
                // Calling method for renaming. 
                CreateNewName(NameBox.Text);
                Changes = false;
            }
            this.Close();
        }
        /// <summary>
        /// Method for finding all items whose number is less than the one specified by the user.
        /// </summary>
        /// <param name="number">Number that user inputed.</param>
        /// <param name="saveFile">Just a file dialog for saving a CSV report.</param>
        public static void FindNumber(string number, SaveFileDialog saveFile)
        {
            // Checking that user input was correct.
            if (uint.TryParse(number, out uint intNumber))
            {
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    StorageForm.FoundItems = new List<Item>();
                    for(int i = 0; i < StorageForm.Items.Count; i++)
                    {
                        if(StorageForm.Items[i].Amount < intNumber)
                        {
                            StorageForm.Items[i].Path = "";
                            // Calling the method for creating an item path.
                            StorageForm.FindAllLackingItems(StorageForm.Folders[0], StorageForm.Items[i]);
                        }
                    }
                    // Creating a new CSV report.
                    var report = new StringBuilder();
                    string line = "Item path" + ";" +"Vendor Code" + ";" + "Name" + ";" + "Quantity";
                    report.AppendLine(line);
                    for (int i = 0; i < StorageForm.FoundItems.Count; i++)
                    {
                        line = StorageForm.FoundItems[i].Path + ";" + StorageForm.FoundItems[i].VendorСode + ";" + StorageForm.FoundItems[i].Name + ";" + StorageForm.FoundItems[i].Amount;
                        report.AppendLine(line);
                    }
                    File.WriteAllText(saveFile.FileName, report.ToString());
                }
            }
        }
        /// <summary>
        /// Method for creating a new folder.
        /// </summary>
        /// <param name="name">New folder name.</param>
        public static void CreateFolder(string name)
        {
            Folder new_folder = new Folder(name);
            StorageForm.Folders.Add(new_folder);
            StorageForm.CurrentFolder.AllNodes.Add(new_folder);
            // Attaching the picture to the node.
            TreeNode folder = new TreeNode { Text = name, ImageIndex = 0, SelectedImageIndex = 0 };
            StorageForm.CurrentNode.Nodes.Add(folder);
            // Opening all the nodes.
            (Application.OpenForms[0] as StorageForm).TreeView.ExpandAll();
        }
        /// <summary>
        /// Method for renaming the folder/item.
        /// </summary>
        /// <param name="name">Name that user inputed in the textbox.</param>
        public static void CreateNewName(string name)
        {
            // If element was in the Items list then we skip the part of checking the Folders list.
            bool flag = false;
            for (int i = 0; i < StorageForm.Items.Count; i++)
            {
                if (StorageForm.CurrentNode.Text == StorageForm.Items[i].Name)
                {
                    // If something with this name alredy exists then an error shows.
                    if (StorageForm.Items[i].Name == name)
                    {
                        MessageBox.Show("The element was not renamed because the name is already taken.", "OOPS", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                        flag = true;
                    }
                    else
                    {
                        StorageForm.CurrentNode.Text = name;
                        StorageForm.Items[i].Name = name;
                    }
                }
            }
            if (!flag)
            {
                for (int j = 0; j < StorageForm.Folders.Count; j++)
                {
                    if (StorageForm.CurrentNode.Text == StorageForm.Folders[j].Name)
                    {
                        if (StorageForm.Folders[j].Name == name)
                        {
                            MessageBox.Show("The element was not renamed because the name is already taken.", "OOPS", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                        }
                        else
                        {
                            StorageForm.CurrentNode.Text = name;
                            StorageForm.Folders[j].Name = name;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Method for checking if something with inputed name already exists.
        /// </summary>
        /// <param name="name">The name that user inputed.</param>
        /// <returns>True if it does not exist and False otherwise.</returns>
        public static bool ContainsFolder(string name)
        {
            // Going through all the Folders.
            for (int i = 0; i < StorageForm.Folders.Count; i++)
            {
                if (StorageForm.Folders[i].Name == name)
                {
                    return false;
                }
            }
            // Going through all the Items.
            for (int i = 0; i < StorageForm.Items.Count; i++)
            {
                if (StorageForm.Items[i].Name == name)
                {
                    return false;
                }
            }
            return true;
        }
    }

}
