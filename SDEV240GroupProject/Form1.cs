using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;

namespace SDEV240GroupProject
{
    public partial class Form1 : Form
    {
        List<string> columnNames = new List<string>();
        public Form1()
        {
            InitializeComponent();           

            // Iterate through the DataGridView's columns
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                columnNames.Add(column.HeaderText); // Use .Name if you have explicitly set column names
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

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string category = (string)dataGridView1.Rows[i].Cells[Category.Index].Value;

                if (category != currentCategory && category != "Subtotal")
                {
                    // Insert a subtotal row before the current row
                    dataGridView1.Rows.Insert(i, "Subtotal", "", "", "", "", "");

                    // Update the current category
                    currentCategory = category;

                    // Skip to the next row
                    i++;
                }
            }
        }
    }
}