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
    public partial class AddItem : Form
    {
        public AddItem()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Retrieve values from input controls
            int itemNo = Convert.ToInt32(txtBoxItemNo.Text);
            string description = txtBoxDescription.Text;
            decimal price = Convert.ToDecimal(txtBoxPrice.Text);

            // Create a new InventoryItem object
            InventoryItem newItem = new InventoryItem
            {
                ItemNo = itemNo,
                Description = description,
                Price = price
            };

            // Get existing items from the database
            List<InventoryItem> existingItems = InventoryDB.GetItems();

            // Add the new item to the existing items list
            existingItems.Add(newItem);

            // Save the updated list of items to the database
            InventoryDB.SaveItems(existingItems);

            // Display a message to the user to confirm the item was added
            MessageBox.Show("Item added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Close the form
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
