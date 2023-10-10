using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Windows.Forms;

namespace SDEV240GroupProject
{
    public partial class Form1 : Form
    {
        // List to store column names
        List<string> columnNames = new List<string>();

        // List to store row indices where subtotals should be displayed
        List<int> subtotalRows = new List<int>();

        // Dictionary to store items with a unique identifier as the key
        Dictionary<string, Item> items = new Dictionary<string, Item>();

        // File name for reading/writing data (CSV file)
        string fileName = AppDomain.CurrentDomain.BaseDirectory + "MaterialList.csv";

        // Initial sorting order for the DataGridView
        ListSortDirection sortingOrder = ListSortDirection.Ascending;

        // Dictionary to store unique values for each column in the DataGridView
        Dictionary<string, HashSet<string>> uniqueValues = new Dictionary<string, HashSet<string>>
        {
            { "Category", new HashSet<string>() },
            { "Item", new HashSet<string>() },
            { "Material", new HashSet<string>() },
            { "SizeDesc", new HashSet<string>() },
            { "Quantity", new HashSet<string>() },
            { "UnitCost", new HashSet<string>() }
        };

        public Form1()
        {
            InitializeComponent();

            // Attach the SortCompare event handler to the DataGridView
            dataGridView1.SortCompare += dataGridView1_SortCompare;

            // Iterate through the DataGridView's columns and add their names to the columnNames list
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                columnNames.Add(column.Name);
            }
        }

        private void UpdateSubtotalRows()
        {
            string currentCategory = null;
            subtotalRows = new List<int>();

            // Dictionary to store subtotal costs for each category
            Dictionary<string, double> subtotalCosts = new Dictionary<string, double>();

            // Iterate through the rows of the DataGridView
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                // Get the value in the "Category" column for the current row
                string category = (string)dataGridView1.Rows[i].Cells[Category.Index].Value;

                // Remove rows with "Subtotal" in the category
                if (category.Contains("Subtotal"))
                {
                    dataGridView1.Rows.Remove(dataGridView1.Rows[i]);
                    continue;
                }

                if (category != null)
                {
                    // Check if the category has changed
                    if (category != currentCategory)
                    {
                        int k = i;
                        string nextCategory = null;

                        // Calculate subtotal for the current category
                        do
                        {
                            int quantity = (int)dataGridView1.Rows[k].Cells[Quantity.Index].Value;
                            double cost = (double)dataGridView1.Rows[k].Cells[Cost.Index].Value;

                            // Adds or updates subtotal in the dictionary
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

                        // Add the index of the subtotal row to the subtotalRows list
                        subtotalRows.Add(k);

                        // Skip to the next row after processing the category
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
            // Removes the item from the items Dictionary based on the Category and Item values
            string key = e.Row.Cells[Category.Index].Value.ToString() + e.Row.Cells[Item.Index].Value.ToString();
            items.Remove(key);

            UpdateSubtotalRows();
            RefreshComboBoxes();
        }

        private void addItemBtn_Click(object sender, EventArgs e)
        {
            Item newItem;
            try
            {
                // Create a new Item object using the values from ComboBoxes
                newItem = new Item(categoryCombo.Text.ToString(), itemCombo.Text.ToString(), materialCombo.Text.ToString(), sizeDescCombo.Text.ToString(), quantityCombo.Text.ToString(), unitCostCombo.Text.ToString());

                // Check if the item already exists in the items Dictionary based on Category and Name
                if (!items.ContainsKey(newItem.Category + newItem.Name))
                    items.Add(newItem.Category + newItem.Name, newItem); // Add the new item
                else
                    throw new ArgumentException("Item already present in current category");
            }
            catch (Exception ex)
            {
                // Show an error message if there's a validation or exception error
                MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the method if there's an error
            }

            // Add unique values to the uniqueValues Dictionary for filtering
            uniqueValues["Category"].Add(newItem.Category);
            uniqueValues["Item"].Add(newItem.Name);
            uniqueValues["Material"].Add(newItem.Material);
            uniqueValues["SizeDesc"].Add(newItem.SizeDesc);
            uniqueValues["Quantity"].Add(newItem.Quantity.ToString());
            uniqueValues["UnitCost"].Add(newItem.UnitCost.ToString());

            // Insert the new item into the DataGridView
            dataGridView1.Rows.Insert(dataGridView1.Rows.Count, newItem.Category, newItem.Name, newItem.Material, newItem.SizeDesc, newItem.Quantity, newItem.UnitCost, newItem.Cost);

            // Sort the DataGridView by Category in ascending order
            dataGridView1.Sort(Category, ListSortDirection.Ascending);

            UpdateSubtotalRows();
            RefreshComboBoxes();
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

                            // Add unique values to the uniqueValues Dictionary for filtering
                            uniqueValues["Category"].Add(item.Category);
                            uniqueValues["Item"].Add(item.Name);
                            uniqueValues["Material"].Add(item.Material);
                            uniqueValues["SizeDesc"].Add(item.SizeDesc);
                            uniqueValues["Quantity"].Add(item.Quantity.ToString());
                            uniqueValues["UnitCost"].Add(item.UnitCost.ToString());

                            // Insert the new item into the DataGridView
                            dataGridView1.Rows.Insert(dataGridView1.Rows.Count, item.Category, item.Name, item.Material, item.SizeDesc, item.Quantity, item.UnitCost, item.Cost);
                            dataGridView1.Sort(Category, ListSortDirection.Ascending);
                            UpdateSubtotalRows();
                            RefreshComboBoxes();
                        }
                        if (errItems.Count > 0) //Shows error message window if any present
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

            // Clear the comboBoxes
            categoryCombo.DataSource = null;
            itemCombo.DataSource = null;
            materialCombo.DataSource = null;
            sizeDescCombo.DataSource = null;
            quantityCombo.DataSource = null;
            unitCostCombo.DataSource = null;
        }

        private void calcBtn_Click(object sender, EventArgs e)
        {
            double TotalCost = 0;

            // Iterate through all items in the items Dictionary
            foreach (Item item in items.Values)
            {
                // Accumulate the cost of each item to calculate the total cost
                TotalCost += item.Cost;
            }

            // Display the total cost in the totalCostLbl label
            totalCostLbl.Text = "$" + Convert.ToString(TotalCost);
        }

        private void RefreshComboBoxes()
        {
            // Recreate the lists of unique values
            List<string> uniqueCategories = new List<string>(uniqueValues["Category"]);
            List<string> uniqueNames = new List<string>(uniqueValues["Item"]);
            List<string> uniqueMaterials = new List<string>(uniqueValues["Material"]);
            List<string> uniqueSizeDescs = new List<string>(uniqueValues["SizeDesc"]);
            List<string> uniqueQuantities = new List<string>(uniqueValues["Quantity"]);
            List<string> uniqueUnitCosts = new List<string>(uniqueValues["UnitCost"]);

            // Update the ComboBox data sources

            foreach (string columnName in columnNames)
            {
                ComboBox comboBox = GetComboBoxByName(columnName);
                if (comboBox != null)
                {
                    string categorySelected = comboBox.Text.ToString();
                    comboBox.DataSource = new List<string>(uniqueValues[columnName]);
                    comboBox.SelectedItem = categorySelected;
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                ComboBox comboBoxToUpdate;
                int colindex = 0;
                foreach (string columnName in columnNames)
                {
                    // Determine which ComboBox to update based on the column name
                    comboBoxToUpdate = GetComboBoxByName(columnName);

                    if (comboBoxToUpdate != null)
                    {
                        // Set the selected item in the ComboBox
                        comboBoxToUpdate.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells[colindex].Value.ToString();
                    }
                    colindex++;
                }
            }
        }

        private ComboBox GetComboBoxByName(string columnName)
        {
            // Convert the column name to the expected ComboBox name format
            string comboBoxName = char.ToLower(columnName[0]) + columnName.Substring(1) + "Combo";

            // Find the control in the form's Controls collection
            return Controls.Find(comboBoxName, true).FirstOrDefault() as ComboBox;
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Sort the DataGridView based on the clicked column and the current sorting order
            dataGridView1.Sort(dataGridView1.Columns[e.ColumnIndex], sortingOrder);

            // Toggle the sorting order (ascending to descending or vice versa) for the next click
            if (sortingOrder == ListSortDirection.Ascending)
                sortingOrder = ListSortDirection.Descending;
            else
                sortingOrder = ListSortDirection.Ascending;

            // After sorting, ensure the DataGridView is always sorted by "Category" in ascending order
            dataGridView1.Sort(dataGridView1.Columns["Category"], ListSortDirection.Ascending);
        }

        private void dataGridView1_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            // Check if the column being sorted is the one with mixed integers and empty strings
            if (e.Column.Name == "Quantity" || e.Column.Name == "UnitCost" || e.Column.Name == "Cost")
            {
                int int1, int2;
                bool isInt1 = int.TryParse(e.CellValue1.ToString(), out int1);
                bool isInt2 = int.TryParse(e.CellValue2.ToString(), out int2);

                // Handle empty strings by considering them as larger than any integer
                if (!isInt1 && !isInt2)
                {
                    e.SortResult = 0; // Both are empty strings, treat them as equal
                }
                else if (!isInt1)
                {
                    e.SortResult = 1; // First value is an empty string, place it at the end
                }
                else if (!isInt2)
                {
                    e.SortResult = -1; // Second value is an empty string, place it at the end
                }
                else
                {
                    e.SortResult = int1.CompareTo(int2); // Compare as integers
                }

                e.Handled = true; // Mark the event as handled
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            Item newItem;
            try
            {
                // Create a new Item object using the values from ComboBoxes
                newItem = new Item(categoryCombo.Text.ToString(), itemCombo.Text.ToString(), materialCombo.Text.ToString(), sizeDescCombo.Text.ToString(), quantityCombo.Text.ToString(), unitCostCombo.Text.ToString());

                // Check if the item exists in the items Dictionary, and update it if found
                if (!items.ContainsKey(newItem.Category + newItem.Name))
                    throw new ArgumentException("Item not present in current category");
                else
                    items[newItem.Category + newItem.Name] = newItem;
            }
            catch (Exception ex)
            {
                // Show an error message if there's a validation or exception error
                MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the method if there's an error
            }

            // Add unique values to the uniqueValues Dictionary for filtering
            uniqueValues["Material"].Add(newItem.Material);
            uniqueValues["SizeDesc"].Add(newItem.SizeDesc);
            uniqueValues["Quantity"].Add(newItem.Quantity.ToString());
            uniqueValues["UnitCost"].Add(newItem.UnitCost.ToString());

            // Iterate through DataGridView rows to find and update the matching item
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Category"].Value.ToString() == newItem.Category && row.Cells["Item"].Value.ToString() == newItem.Name)
                {
                    // Update the item's properties in the DataGridView
                    row.Cells["Material"].Value = newItem.Material;
                    row.Cells["SizeDesc"].Value = newItem.SizeDesc;
                    row.Cells["Quantity"].Value = newItem.Quantity;
                    row.Cells["UnitCost"].Value = newItem.UnitCost;
                    row.Cells["Cost"].Value = newItem.Cost;

                    break; // Exit the loop after updating the item
                }
            }

            // Sort the DataGridView by Category in ascending order
            dataGridView1.Sort(Category, ListSortDirection.Ascending);

            UpdateSubtotalRows();
            RefreshComboBoxes();
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            // Iterate through column names to clear corresponding ComboBoxes
            foreach (string columnName in columnNames)
            {
                // Get the ComboBox control based on the column name
                ComboBox comboBox = GetComboBoxByName(columnName);

                // Check if the ComboBox was found
                if (comboBox != null)
                {
                    // Clear the text in the ComboBox
                    comboBox.Text = "";
                }
            }
        }
    }
}