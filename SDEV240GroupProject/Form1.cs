using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SDEV240GroupProject
{
    public partial class Form1 : Form
    {
        int rowIndex = -1;
        bool isEditing = false;
        List<string> columnNames = new List<string>();
        List<int> subtotalRows = new List<int>();
        Dictionary<string, Item> items = new Dictionary<string, Item>();
        string fileName = AppDomain.CurrentDomain.BaseDirectory + "MaterialList.csv";

        public Form1()
        {
            InitializeComponent();

            // Iterate through the DataGridView's columns
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                columnNames.Add(column.HeaderText); // Use .Name if you have explicitly set column names
            }
        }

        private void UpdateSubtotalRows()
        {
            string currentCategory = null;
            subtotalRows = new List<int>();

            Dictionary<string, double> subtotalCosts = new Dictionary<string, double>();

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string category = (string)dataGridView1.Rows[i].Cells[Category.Index].Value;

                if (category.Contains("Subtotal"))
                {
                    dataGridView1.Rows.Remove(dataGridView1.Rows[i]);
                    continue;
                }

                if (category != null)
                {

                    if (category != currentCategory)
                    {
                        int k = i;
                        string nextCategory = null;
                        do
                        {
                            int quantity;
                            if (!int.TryParse(dataGridView1.Rows[k].Cells[Quantity.Index].Value.ToString(), out quantity))
                            {
                                // Handle the case where the conversion failed
                                MessageBox.Show("Invalid quantity value in row " + (k + 1) + ". Please enter a valid integer.", "Conversion Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            double cost;
                            if (!double.TryParse(dataGridView1.Rows[k].Cells[Cost.Index].Value.ToString(), out cost))
                            {
                                // Handle the case where the conversion failed
                                MessageBox.Show("Invalid cost value in row " + (k + 1) + ". Please enter a valid number.", "Conversion Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }


                            // Adds or updates subtotal in dictionary
                            if (!subtotalCosts.ContainsKey(category))
                                subtotalCosts.Add(category, cost);
                            else
                                subtotalCosts[category] += cost;

                            k++;
                            if (k < dataGridView1.Rows.Count)
                                nextCategory = (string)dataGridView1.Rows[k].Cells[Category.Index].Value;

                        } while (nextCategory != null && (nextCategory == category));

                        if (nextCategory == null || !nextCategory.Contains("Subtotal"))
                        {
                            // Insert a subtotal row before the current row
                            dataGridView1.Rows.Insert(k, $"{category} - Subtotal", "", "", "", "", "", subtotalCosts[category]);
                            dataGridView1.Rows[k].ReadOnly = true;

                            // Update the current category
                            currentCategory = category;
                        }
                        else
                        {
                            // Update subtotal
                            dataGridView1.Rows[k].Cells[Cost.Index].Value = subtotalCosts[category];
                        }

                        subtotalRows.Add(k);

                        // Skip to the next row
                        i = k++;
                    }
                }
            }
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            // Check if you want to prevent deletion of a specific row
            if (subtotalRows.IndexOf(e.Row.Index) != -1)
            {
                e.Cancel = true; // Cancel row deletion
            }
        }

        private void dataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            // Removes item from items Dictionary
            string key = e.Row.Cells[Category.Index].Value.ToString() + e.Row.Cells[Item.Index].Value.ToString();
            items.Remove(key);

            UpdateSubtotalRows();
        }

        private void addItemBtn_Click(object sender, EventArgs e)
        {
            // Check if isEditing is true
            if (isEditing)
            {
                // Check if rowIndex is valid
                if (rowIndex >= 0 && rowIndex < dataGridView1.Rows.Count)
                {
                    // Remove the old item from the items dictionary
                    string oldKey = dataGridView1.Rows[rowIndex].Cells[Category.Index].Value.ToString() + dataGridView1.Rows[rowIndex].Cells[Item.Index].Value.ToString();
                    items.Remove(oldKey);

                    // Update the row in the DataGridView
                    dataGridView1.Rows[rowIndex].Cells[Category.Index].Value = categoryCombo.Text;
                    dataGridView1.Rows[rowIndex].Cells[Item.Index].Value = itemCombo.Text;
                    dataGridView1.Rows[rowIndex].Cells[Material.Index].Value = materialCombo.Text;
                    dataGridView1.Rows[rowIndex].Cells[SizeDesc.Index].Value = sizeDescCombo.Text;
                    dataGridView1.Rows[rowIndex].Cells[Quantity.Index].Value = quantityCombo.Text;
                    dataGridView1.Rows[rowIndex].Cells[UnitCost.Index].Value = costCombo.Text;

                    // Create a new item with the updated details
                    Item newItem = new Item(categoryCombo.Text, itemCombo.Text, materialCombo.Text, sizeDescCombo.Text, quantityCombo.Text, costCombo.Text);

                    // Add the new item to the items dictionary
                    string newKey = newItem.Category + newItem.Name;
                    items.Add(newKey, newItem);
                    if (items.ContainsKey(newKey))
                    {
                        Item item = items[newKey];
                        item.Category = categoryCombo.Text;
                        item.Name = itemCombo.Text;
                        item.Material = materialCombo.Text;
                        item.SizeDesc = sizeDescCombo.Text;
                        item.Quantity = int.Parse(quantityCombo.Text);
                        item.UnitCost = double.Parse(costCombo.Text);

                        // Update the dictionary
                        items[newKey] = item;
                    }
                }
                
                if (!categoryCombo.Items.Contains(categoryCombo.Text))
                {
                    categoryCombo.Items.Add(categoryCombo.Text);
                }
                if (!itemCombo.Items.Contains(itemCombo.Text))
                {
                    itemCombo.Items.Add(itemCombo.Text);
                }
                quantityCombo.Items.Add(quantityCombo.Text);
                sizeDescCombo.Items.Add(sizeDescCombo.Text);
                materialCombo.Items.Add(materialCombo.Text);
                costCombo.Items.Add(costCombo.Text);
                materialCombo.Text = "";
                sizeDescCombo.Text = "";
                itemCombo.Text = "";
                quantityCombo.Text = "";
                costCombo.Text = "";

                // Remove unused categories from categoryCombo
                for (int i = categoryCombo.Items.Count - 1; i >= 0; i--)
                {
                    string category = categoryCombo.Items[i].ToString();
                    if (!items.Values.Any(item => item.Category == category))
                    {
                        categoryCombo.Items.RemoveAt(i);
                    }
                }

                // Remove unused items from itemCombo
                for (int i = itemCombo.Items.Count - 1; i >= 0; i--)
                {
                    string itemName = itemCombo.Items[i].ToString();
                    if (!items.Values.Any(item => item.Name == itemName))
                    {
                        itemCombo.Items.RemoveAt(i);
                    }
                }

                itemCombo.DropDownStyle = ComboBoxStyle.DropDownList;
                categoryCombo.DropDownStyle = ComboBoxStyle.DropDownList;
                materialCombo.Enabled = false;
                quantityCombo.Enabled = false;
                sizeDescCombo.Enabled = false;
                costCombo.Enabled = false;

                // Reset isEditing to false
                isEditing = false;

                UpdateSubtotalRows();

                // Refresh the DataGridView
                dataGridView1.Refresh();
            }
            else
            {
                Item newItem;
                try
                {
                    newItem = new Item(categoryCombo.Text.ToString(), itemCombo.Text.ToString(), materialCombo.Text.ToString(), sizeDescCombo.Text.ToString(), quantityCombo.Text.ToString(), costCombo.Text.ToString());

                    if (!items.ContainsKey(newItem.Category + newItem.Name))
                        items.Add(newItem.Category + newItem.Name, newItem);
                    else
                        throw new ArgumentException("Item already present in current category");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                dataGridView1.Rows.Insert(dataGridView1.Rows.Count, newItem.Category, newItem.Name, newItem.Material, newItem.SizeDesc, newItem.Quantity, newItem.UnitCost, newItem.Cost);
                dataGridView1.Sort(Category, ListSortDirection.Ascending);
                UpdateSubtotalRows();

                if (!categoryCombo.Items.Contains(categoryCombo.Text))
                {
                    categoryCombo.Items.Add(categoryCombo.Text);
                }
                if (!itemCombo.Items.Contains(itemCombo.Text))
                {
                    itemCombo.Items.Add(itemCombo.Text);
                }
                quantityCombo.Items.Add(quantityCombo.Text);
                sizeDescCombo.Items.Add(sizeDescCombo.Text);
                materialCombo.Items.Add(materialCombo.Text);
                costCombo.Items.Add(costCombo.Text);
                materialCombo.Text = "";
                sizeDescCombo.Text = "";
                itemCombo.Text = "";
                quantityCombo.Text = "";
                costCombo.Text = "";

            }
 
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // Set the filter to CSV files
            saveFileDialog.Filter = "CSV Files (*.csv)|*.csv";

            // Display the SaveFileDialog dialog box
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the path to the selected file
                string csvFilePath = saveFileDialog.FileName;

                // Save the dictionary to the CSV file
                using (StreamWriter csvWriter = new StreamWriter(csvFilePath))
                {
                    // Write the header row
                    csvWriter.WriteLine("Category,Name,Material,SizeDesc,Quantity,UnitCost,Cost");

                    // Iterate over the dictionary and write each item to the CSV file
                    foreach (KeyValuePair<string, Item> item in items)
                    {
                        Item itemObj = item.Value;

                        csvWriter.WriteLine($"{itemObj.Category},{itemObj.Name},{itemObj.Material},{itemObj.SizeDesc},{itemObj.Quantity},{itemObj.UnitCost},{itemObj.Cost}");
                    }
                }
            }
        }

        private void importBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select a file to Import";
                openFileDialog.Filter = "Text Files (*.csv)|*.csv|All Files (*.*)|*.*";

                // Set the initial directory to the program's base directory
                openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader csvReader = new StreamReader(openFileDialog.FileName))
                    {
                        // Read the header row
                        string headerRow = csvReader.ReadLine();

                        List<string> errItems = new List<string>();

                        // Iterate over the CSV file and add each item to the list
                        while (!csvReader.EndOfStream)
                        {
                            // Read a row from the CSV file
                            string row = csvReader.ReadLine();

                            // Split the row into columns
                            string[] columns = row.Split(',');

                            Item item;
                            try
                            {
                                item = new Item(columns[0], columns[1], columns[2], columns[3], columns[4], columns[5]);

                                if (!items.ContainsKey(item.Category + item.Name))
                                    items.Add(item.Category + item.Name, item);
                                else
                                    throw new ArgumentException($"Item {item.Name} invalid or already present in {item.Category} category");
                            }
                            catch (Exception ex)
                            {
                                errItems.Add(ex.Message + "\n");
                                continue;
                            }
                            dataGridView1.Rows.Insert(dataGridView1.Rows.Count, item.Category, item.Name, item.Material, item.SizeDesc, item.Quantity, item.UnitCost, item.Cost);
                            dataGridView1.Sort(Category, ListSortDirection.Ascending);
                            UpdateSubtotalRows();
                        }
                        if (errItems.Count > 0)
                        {
                            string errorMessage = "";
                            foreach (string err in errItems)
                                errorMessage += err;

                            MessageBox.Show(errorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            // Clear the DataGridView
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();

            // Clear the dictionary
            items.Clear();
        }

        private void calcBtn_Click(object sender, EventArgs e)
        {
            double TotalCost = 0;
            foreach (Item item in items.Values)
            {
                TotalCost += item.Cost;

            }
            totalCostLbl.Text = "$" + Convert.ToString(TotalCost);
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            categoryCombo.Text = "";
            materialCombo.Text = "";
            sizeDescCombo.Text = "";
            itemCombo.Text = "";
            quantityCombo.Text = "";
            costCombo.Text = "";
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            isEditing = true;

            // Set the ComboBoxes to editable
            categoryCombo.DropDownStyle = ComboBoxStyle.DropDown;
            itemCombo.DropDownStyle = ComboBoxStyle.DropDown;
            materialCombo.DropDownStyle = ComboBoxStyle.DropDown;
            sizeDescCombo.DropDownStyle = ComboBoxStyle.DropDown;
            quantityCombo.DropDownStyle = ComboBoxStyle.DropDown;
            costCombo.DropDownStyle = ComboBoxStyle.DropDown;

            // Enable the ComboBoxes
            categoryCombo.Enabled = true;
            itemCombo.Enabled = true;
            materialCombo.Enabled = true;
            sizeDescCombo.Enabled = true;
            quantityCombo.Enabled = true;
            costCombo.Enabled = true;
        }

        private void categoryCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected category
            string selectedCategory = categoryCombo.Text;

            // Clear the existing items in the itemCombo dropdown
            itemCombo.Items.Clear();

            // Filter the items dictionary based on the selected category
            var filteredItems = items.Where(kv => kv.Value.Category == selectedCategory)
                                     .Select(kv => kv.Value)
                                     .ToList();

            // Add the filtered items to the itemCombo dropdown
            foreach (var item in filteredItems)
            {
                itemCombo.Items.Add(item.Name);
            }

            // Enable the itemCombo dropdown
            itemCombo.Enabled = true;

            // Automatically select the first item in the dropdown (if available)
            if (itemCombo.Items.Count > 0)
            {
                itemCombo.SelectedIndex = 0;
            }

            itemCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            categoryCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            materialCombo.Enabled = false;
            quantityCombo.Enabled = false;
            sizeDescCombo.Enabled = false;
            costCombo.Enabled = false;

            // Find the row index
            int rowIndex = -1;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[Category.Index].Value.ToString() == categoryCombo.Text)
                {
                    rowIndex = i;
                    break;
                }
            }

            // Store the row index
            this.rowIndex = rowIndex;
        }

        private void itemCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

            // Get the selected item name
            string selectedItemName = itemCombo.Text;

            // Check if the selected item exists in the dictionary
            if (items.ContainsKey(categoryCombo.Text + selectedItemName))
            {
                // Retrieve the item from the dictionary
                Item selectedItem = items[categoryCombo.Text + selectedItemName];

                // Set the values for the other combo boxes based on the selected item
                materialCombo.Text = selectedItem.Material;
                sizeDescCombo.Text = selectedItem.SizeDesc;

                // Convert the double values to strings before setting them
                quantityCombo.Text = selectedItem.Quantity.ToString();
                costCombo.Text = selectedItem.UnitCost.ToString();
            }
            else
            {
                // Clear the combo box values if the item is not found
                materialCombo.Text = "";
                sizeDescCombo.Text = "";
                quantityCombo.Text = "";
                costCombo.Text = "";
            }

            // Find the row index
            int rowIndex = -1;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[Item.Index].Value.ToString() == itemCombo.Text)
                {
                    rowIndex = i;
                    break;
                }
            }

            // Store the row index
            this.rowIndex = rowIndex;

        }
    }
}