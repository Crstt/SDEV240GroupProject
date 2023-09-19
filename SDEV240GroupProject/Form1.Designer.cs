namespace SDEV240GroupProject
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            dataGridView1 = new DataGridView();
            Category = new DataGridViewTextBoxColumn();
            Item = new DataGridViewTextBoxColumn();
            Material = new DataGridViewTextBoxColumn();
            SizeDesc = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            Cost = new DataGridViewTextBoxColumn();
            button1 = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Category, Item, Material, SizeDesc, Quantity, Cost });
            dataGridView1.Location = new Point(8, 7);
            dataGridView1.Margin = new Padding(2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.RowTemplate.Height = 33;
            dataGridView1.Size = new Size(965, 500);
            dataGridView1.TabIndex = 0;
            dataGridView1.RowValidated += dataGridView1_RowValidated;
            dataGridView1.RowValidating += dataGridView1_RowValidating;
            dataGridView1.UserDeletingRow += dataGridView1_UserDeletingRow;
            // 
            // Category
            // 
            Category.HeaderText = "Category";
            Category.MinimumWidth = 8;
            Category.Name = "Category";
            Category.Width = 150;
            // 
            // Item
            // 
            Item.HeaderText = "Item";
            Item.MinimumWidth = 8;
            Item.Name = "Item";
            Item.Width = 150;
            // 
            // Material
            // 
            Material.HeaderText = "Material";
            Material.MinimumWidth = 8;
            Material.Name = "Material";
            Material.Width = 150;
            // 
            // SizeDesc
            // 
            SizeDesc.HeaderText = "Size / Description";
            SizeDesc.MinimumWidth = 8;
            SizeDesc.Name = "SizeDesc";
            SizeDesc.Width = 150;
            // 
            // Quantity
            // 
            Quantity.HeaderText = "Quantity";
            Quantity.MinimumWidth = 8;
            Quantity.Name = "Quantity";
            Quantity.Width = 150;
            // 
            // Cost
            // 
            Cost.HeaderText = "Cost";
            Cost.MinimumWidth = 8;
            Cost.Name = "Cost";
            Cost.Width = 150;
            // 
            // button1
            // 
            button1.Location = new Point(8, 544);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(78, 20);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(985, 713);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Margin = new Padding(2);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button button1;
        private DataGridViewTextBoxColumn Category;
        private DataGridViewTextBoxColumn Item;
        private DataGridViewTextBoxColumn Material;
        private DataGridViewTextBoxColumn SizeDesc;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn Cost;
        private System.Windows.Forms.Timer timer1;
    }
}