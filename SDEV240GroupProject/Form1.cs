using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Windows.Forms;

namespace SDEV240GroupProject
{
    public partial class Form1 : Form
    {
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
                            int quantity = (int)dataGridView1.Rows[k].Cells[Quantity.Index].Value;
                            double cost = (double)dataGridView1.Rows[k].Cells[Cost.Index].Value;

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
    }
}