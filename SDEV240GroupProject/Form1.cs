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
        Dictionary<string, double> subtotalCosts = new Dictionary<string, double>();
        List<Item> items = new List<Item>();
        private bool validationDone = false;

        public Form1()
        {
            InitializeComponent();

            // Iterate through the DataGridView's columns
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                columnNames.Add(column.HeaderText); // Use .Name if you have explicitly set column names
            }
        }

        private void calcAllSubtotals(List<Item> items)
        {
            foreach (Item item in items)
            {
                string category = item.Category;
                double cost = item.Cost;

                if (!subtotalCosts.ContainsKey(category))
                {
                    subtotalCosts.Add(category, cost);
                }
                else
                {
                    subtotalCosts[category] += cost;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Sort the DataGridView by the Category column
            dataGridView1.Sort(Category, ListSortDirection.Ascending);
            UpdateSubtotalRows();
        }

        private void UpdateSubtotalRows()
        {
            string currentCategory = null;
            subtotalRows = new List<int>();

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string category = (string)dataGridView1.Rows[i].Cells[Category.Index].Value;

                if (category.Contains("Subtotal")) { 
                    dataGridView1.Rows.Remove(dataGridView1.Rows[i]);
                    continue;
                }

                if (category != null)
                {
                    if (category != currentCategory)
                    {
                        //for (int k = i; k < dataGridView1.Rows.Count; k++)
                        int k = i;
                        string nextCategory = null;
                        do
                        {
                            k++;
                            if (k < dataGridView1.Rows.Count)
                                nextCategory = (string)dataGridView1.Rows[k].Cells[Category.Index].Value;
                        } while (nextCategory != null && (nextCategory == category));

                        if (nextCategory == null || !nextCategory.Contains("Subtotal"))
                        {
                            // Insert a subtotal row before the current row
                            dataGridView1.Rows.Insert(k, $"{category} - Subtotal", "", "", "", "", "");
                            dataGridView1.Rows[k].ReadOnly = true;

                            // Update the current category
                            currentCategory = category;
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

        private void dataGridView1_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            if (!validationDone)
            {
                // Check if any of the required cells are empty (modify the column indices as needed)
                if (string.IsNullOrWhiteSpace(row.Cells[Category.Index].Value?.ToString()) ||
                    string.IsNullOrWhiteSpace(row.Cells[Item.Index].Value?.ToString()) ||
                    string.IsNullOrWhiteSpace(row.Cells[Material.Index].Value?.ToString()) ||
                    string.IsNullOrWhiteSpace(row.Cells[SizeDesc.Index].Value?.ToString()) ||
                    string.IsNullOrWhiteSpace(row.Cells[Quantity.Index].Value?.ToString()) ||
                    string.IsNullOrWhiteSpace(row.Cells[Cost.Index].Value?.ToString()))
                {
                    // Display an error message (you can use a MessageBox or any other method)
                    MessageBox.Show("Please fill in all required cells before moving to the next row.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // Cancel row validation to prevent moving to the next row
                    e.Cancel = true;
                }
                else
                {
                    // Set a flag to indicate validation failure
                    validationDone = true;

                    // Enable the timer to perform sorting after a short delay
                    timer1.Enabled = true;
                }
            }
        }

        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            return;
            // Check if validation done and sorting is pending
            if (validationDone)
            {
                // Sort the DataGridView by the Category column
                dataGridView1.Sort(Category, ListSortDirection.Ascending);
                UpdateSubtotalRows();
                // Reset the flag
                validationDone = false;

                // Disable the timer
                timer1.Enabled = false;
            }
        }

        private void addItemBtn_Click(object sender, EventArgs e)
        {
            Item newItem;
            try
            {
                newItem = new Item(categoryCombo.Text.ToString(), itemCombo.Text.ToString(), materialCombo.Text.ToString(), sizeDescCombo.Text.ToString(), quantityCombo.Text.ToString(), costCombo.Text.ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            items.Add(newItem);

            dataGridView1.Rows.Insert(dataGridView1.Rows.Count, newItem.Category, newItem.Name, newItem.Material, newItem.SizeDesc, newItem.Quantity, newItem.Cost);
            dataGridView1.Sort(Category, ListSortDirection.Ascending);
            UpdateSubtotalRows();
        }

        private void dataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            UpdateSubtotalRows();
        }
    }
}