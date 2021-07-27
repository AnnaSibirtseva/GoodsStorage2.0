using System;
using System.Windows.Forms;

namespace GoodsStorage
{
    public partial class NewItem : Form
    {
        // Variable to understand: the user wants to change the item or create a new one.
        public bool ChangeItem;
        public NewItem()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Method for creating new item (there are no comments in it because otherwise there will be to much code lines).
        /// </summary>
        private void ContinButton_Click(object sender, EventArgs e)
        {
            if (ItemAmount.Text != null && ItemAmount.Text != "" && ItemCode.Text != null && ItemCode.Text != "" && ItemName.Text != null && ItemName.Text != "" && ItemPrice.Text != null && ItemPrice.Text != "")
            {
                if (ParseName(ItemName.Text))
                {
                    if (ParseAmount(ItemAmount.Text) && ParsePrice(ItemPrice.Text))
                    {
                        if (ParseCode(ItemCode.Text))
                        {
                            if (!ChangeItem)
                            {
                                CreateNewItem(ItemName.Text, ItemCode.Text, ItemAmount.Text, ItemPrice.Text);
                            }
                            else
                            {
                                ChangeOldItem(ItemName.Text, ItemCode.Text, ItemAmount.Text, ItemPrice.Text);
                            }
                        }
                        else
                        {
                            MessageBox.Show("The code must be a positive number, like ulong.  \nFor example: 123456789 ", "OOPS", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                        }
                    }
                    else
                    {
                        MessageBox.Show("The amount and price must be a positive int types. \nFor example: 228 ", "OOPS", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    }
                }
                else
                {
                    MessageBox.Show("This item already exists.", "OOPS", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }
            }
            else
            {
                MessageBox.Show("You didn't enter a name, so the folder wasn't created.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
            this.Close();
        }
        /// <summary>
        /// Method that creates new item.
        /// </summary>
        /// <param name="name">Name for the item.</param>
        /// <param name="code">Vendor code for item.</param>
        /// <param name="amount">Quantity for the item.</param>
        public static void CreateNewItem(string name, string code, string amount, string price)
        {
            // Creating new item.
            Item newitem = new Item(name, ulong.Parse(code), uint.Parse(amount), uint.Parse(price));
            StorageForm.Items.Add(newitem);
            // Additing it to the TreeView.
            TreeNode node = StorageForm.CurrentNode;
            // Sticking the picture for the new node.
            TreeNode item = new TreeNode { Text = name, ImageIndex = 1, SelectedImageIndex = 1 };
            node.Nodes.Add(item);
            StorageForm.CurrentFolder.AllNodes.Add(newitem);
            (Application.OpenForms[0] as StorageForm).TreeView.ExpandAll();
        }
        /// <summary>
        /// Method for changing item characteristics.
        /// </summary>
        /// <param name="name">New name.</param>
        /// <param name="code">New vendor code.</param>
        /// <param name="amount">New quantity.</param>
        /// <param name="price">New price.</param>
        private static void ChangeOldItem(string name, string code, string amount, string price)
        {
            for(int i = 0; i < StorageForm.Items.Count; i++)
            {
                // Changing all the  information about an item.
                if(StorageForm.Items[i].Name == StorageForm.CurrentNode.Text)
                {
                    StorageForm.Items[i].Name = name;
                    StorageForm.Items[i].VendorСode = ulong.Parse(code);
                    StorageForm.Items[i].Amount = uint.Parse(amount);
                    StorageForm.Items[i].Price = uint.Parse(price);
                    StorageForm.CurrentNode.Text = name;
                }
            }
        }
        /// <summary>
        /// Method to check if name does not exist anywhere else.
        /// </summary>
        /// <param name="name">Name to check it.</param>
        /// <returns>False - if exists and else otherwise.</returns>
        private static bool ParseName(string name)
        {
            for (int i = 0; i < StorageForm.Items.Count; i++)
            {
                if (StorageForm.Items[i].Name == name)
                {
                    return false;
                }
            }
            for (int i = 0; i < StorageForm.Folders.Count; i++)
            {
                if (StorageForm.Folders[i].Name == name)
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Method to check that vendor code is correct ulong number.
        /// </summary>
        /// <param name="code">Number for checking.</param>
        /// <returns>True - if everything is OK and False otherwise.</returns>
        private static bool ParseCode(string code)
        {
            if (ulong.TryParse(code, out ulong number))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Method to check if Quantity is an positive integer number.
        /// </summary>
        /// <param name="amount">The number that needs to be checked.</param>
        /// <returns>True - if everything is OK and False otherwise.</returns>
        private static bool ParseAmount(string amount)
        {
            if (uint.TryParse(amount, out uint number))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Method for checking if string parses or not.
        /// </summary>
        /// <param name="price">String that must be parsed to uint.</param>
        /// <returns>True - if everything is OK and False otherwise.</returns>
        private static bool ParsePrice(string price)
        {
            if(uint.TryParse(price, out uint int_price))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Method showing information about the correct input for name.
        /// </summary>
        private void NameInformation_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The name can be any string in which the letters correspond to Unicode.", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
        }
        /// <summary>
        /// Method showing information about the correct input for vendor code.
        /// </summary>
        private void CodeInformation_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The code must be a positive number, like ulong.  \nFor example: 123456789 ", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
        }
        /// <summary>
        /// Method showing information about the correct input for quantity.
        /// </summary>
        private void AmountInformation_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The amount must be a positive int type. \nFor example: 228 ", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
        }
        /// <summary>
        /// Method showing information about the correct input for price.
        /// </summary>
        private void PriceInformation_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The price must be a positive int type. \nFor example: 420 ", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
        }
    }
}
