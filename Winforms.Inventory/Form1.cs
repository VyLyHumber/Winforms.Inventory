using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winforms.Inventory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadItemsToListBox();
        }

        private void LoadItemsToListBox()
        {
            // Clear existing items in ListBox
            listBoxItem.Items.Clear();

            List<InventoryItem> items = InventoryDB.GetItems();

            foreach (InventoryItem item in items)
            {
                listBoxItem.Items.Add(item); // This will call the overridden ToString() method to display the item in the ListBox
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddItem addItemForm = new AddItem();
            addItemForm.ShowDialog();
            LoadItemsToListBox();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listBoxItem.SelectedItem != null)
            {
                // Prompt user for confirmation
                DialogResult result = MessageBox.Show("Are you sure you want to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Retrieve selected item
                    InventoryItem selectedItem = (InventoryItem)listBoxItem.SelectedItem;

                    // Remove item from data source
                    InventoryDB.DeleteItem(selectedItem);

                    // Reload items into ListBox
                    LoadItemsToListBox();
                }
            }
            else
            {
                MessageBox.Show("Please select an item to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
