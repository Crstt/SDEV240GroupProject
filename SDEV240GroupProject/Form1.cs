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

        public Form1()
        {
            InitializeComponent();

            // Iterate through the DataGridView's columns
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                columnNames.Add(column.HeaderText); // Use .Name if you have explicitly set column names
            }
        }

        /*private void calcAllSubtotals(List<Item> items)
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
        }*/

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
                        //for (int k = i; k < dataGridView1.Rows.Count; k++)
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

                        /*if (nextCategory == null || !nextCategory.Contains("Subtotal"))
                        {
                            // Insert a subtotal row before the current row
                            dataGridView1.Rows.Insert(k, $"{category} - Subtotal", "", "", "", "", subtotalCosts[category]);
                            dataGridView1.Rows[k].ReadOnly = true;

                            // Update the current category
                            currentCategory = category;
                        }*/

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
    }
}