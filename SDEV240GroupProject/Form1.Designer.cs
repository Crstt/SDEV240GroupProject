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
            dataGridView1 = new DataGridView();
            Category = new DataGridViewTextBoxColumn();
            Item = new DataGridViewTextBoxColumn();
            Material = new DataGridViewTextBoxColumn();
            SizeDesc = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            UnitCost = new DataGridViewTextBoxColumn();
            Cost = new DataGridViewTextBoxColumn();
            insertGroup = new GroupBox();
            editBtn = new Button();
            clearBtn = new Button();
            addItemBtn = new Button();
            costCombo = new ComboBox();
            quantityCombo = new ComboBox();
            sizeDescCombo = new ComboBox();
            materialCombo = new ComboBox();
            itemCombo = new ComboBox();
            categoryCombo = new ComboBox();
            totalCostBox = new GroupBox();
            totalCostLbl = new Label();
            calcBtn = new Button();
            groupBox1 = new GroupBox();
            resetBtn = new Button();
            importBtn = new Button();
            saveBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            insertGroup.SuspendLayout();
            totalCostBox.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Category, Item, Material, SizeDesc, Quantity, UnitCost, Cost });
            dataGridView1.Location = new Point(9, 10);
            dataGridView1.Margin = new Padding(2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.RowTemplate.Height = 33;
            dataGridView1.Size = new Size(1103, 666);
            dataGridView1.TabIndex = 0;
            dataGridView1.UserDeletedRow += dataGridView1_UserDeletedRow;
            dataGridView1.UserDeletingRow += dataGridView1_UserDeletingRow;
            // 
            // Category
            // 
            Category.HeaderText = "Category";
            Category.MinimumWidth = 8;
            Category.Name = "Category";
            Category.ReadOnly = true;
            Category.Width = 189;
            // 
            // Item
            // 
            Item.HeaderText = "Item";
            Item.MinimumWidth = 8;
            Item.Name = "Item";
            Item.ReadOnly = true;
            Item.Width = 189;
            // 
            // Material
            // 
            Material.HeaderText = "Material";
            Material.MinimumWidth = 8;
            Material.Name = "Material";
            Material.ReadOnly = true;
            Material.Width = 189;
            // 
            // SizeDesc
            // 
            SizeDesc.HeaderText = "Size / Description";
            SizeDesc.MinimumWidth = 8;
            SizeDesc.Name = "SizeDesc";
            SizeDesc.ReadOnly = true;
            SizeDesc.Width = 189;
            // 
            // Quantity
            // 
            Quantity.HeaderText = "Quantity";
            Quantity.MinimumWidth = 8;
            Quantity.Name = "Quantity";
            Quantity.ReadOnly = true;
            Quantity.Width = 189;
            // 
            // UnitCost
            // 
            UnitCost.HeaderText = "Unit Cost";
            UnitCost.MinimumWidth = 8;
            UnitCost.Name = "UnitCost";
            UnitCost.ReadOnly = true;
            UnitCost.Width = 189;
            // 
            // Cost
            // 
            Cost.HeaderText = "Cost";
            Cost.MinimumWidth = 8;
            Cost.Name = "Cost";
            Cost.ReadOnly = true;
            Cost.Width = 189;
            // 
            // insertGroup
            // 
            insertGroup.Controls.Add(editBtn);
            insertGroup.Controls.Add(clearBtn);
            insertGroup.Controls.Add(addItemBtn);
            insertGroup.Controls.Add(costCombo);
            insertGroup.Controls.Add(quantityCombo);
            insertGroup.Controls.Add(sizeDescCombo);
            insertGroup.Controls.Add(materialCombo);
            insertGroup.Controls.Add(itemCombo);
            insertGroup.Controls.Add(categoryCombo);
            insertGroup.Location = new Point(1121, 90);
            insertGroup.Margin = new Padding(3, 4, 3, 4);
            insertGroup.Name = "insertGroup";
            insertGroup.Padding = new Padding(3, 4, 3, 4);
            insertGroup.Size = new Size(350, 508);
            insertGroup.TabIndex = 2;
            insertGroup.TabStop = false;
            insertGroup.Text = "Add New Items";
            // 
            // editBtn
            // 
            editBtn.Location = new Point(127, 460);
            editBtn.Margin = new Padding(3, 4, 3, 4);
            editBtn.Name = "editBtn";
            editBtn.Size = new Size(86, 30);
            editBtn.TabIndex = 7;
            editBtn.Text = "Edit";
            editBtn.UseVisualStyleBackColor = true;
            // 
            // clearBtn
            // 
            clearBtn.Location = new Point(244, 460);
            clearBtn.Margin = new Padding(3, 4, 3, 4);
            clearBtn.Name = "clearBtn";
            clearBtn.Size = new Size(86, 30);
            clearBtn.TabIndex = 8;
            clearBtn.Text = "Clear";
            clearBtn.UseVisualStyleBackColor = true;
            // 
            // addItemBtn
            // 
            addItemBtn.Location = new Point(6, 460);
            addItemBtn.Margin = new Padding(3, 4, 3, 4);
            addItemBtn.Name = "addItemBtn";
            addItemBtn.Size = new Size(86, 30);
            addItemBtn.TabIndex = 6;
            addItemBtn.Text = "Add";
            addItemBtn.UseVisualStyleBackColor = true;
            addItemBtn.Click += addItemBtn_Click;
            // 
            // costCombo
            // 
            costCombo.FormattingEnabled = true;
            costCombo.Location = new Point(11, 424);
            costCombo.Margin = new Padding(3, 4, 3, 4);
            costCombo.Name = "costCombo";
            costCombo.Size = new Size(323, 28);
            costCombo.TabIndex = 5;
            // 
            // quantityCombo
            // 
            quantityCombo.FormattingEnabled = true;
            quantityCombo.Location = new Point(11, 343);
            quantityCombo.Margin = new Padding(3, 4, 3, 4);
            quantityCombo.Name = "quantityCombo";
            quantityCombo.Size = new Size(323, 28);
            quantityCombo.TabIndex = 4;
            // 
            // sizeDescCombo
            // 
            sizeDescCombo.FormattingEnabled = true;
            sizeDescCombo.Location = new Point(11, 262);
            sizeDescCombo.Margin = new Padding(3, 4, 3, 4);
            sizeDescCombo.Name = "sizeDescCombo";
            sizeDescCombo.Size = new Size(323, 28);
            sizeDescCombo.TabIndex = 3;
            // 
            // materialCombo
            // 
            materialCombo.FormattingEnabled = true;
            materialCombo.Location = new Point(11, 179);
            materialCombo.Margin = new Padding(3, 4, 3, 4);
            materialCombo.Name = "materialCombo";
            materialCombo.Size = new Size(323, 28);
            materialCombo.TabIndex = 2;
            // 
            // itemCombo
            // 
            itemCombo.FormattingEnabled = true;
            itemCombo.Location = new Point(11, 105);
            itemCombo.Margin = new Padding(3, 4, 3, 4);
            itemCombo.Name = "itemCombo";
            itemCombo.Size = new Size(323, 28);
            itemCombo.TabIndex = 1;
            // 
            // categoryCombo
            // 
            categoryCombo.FormattingEnabled = true;
            categoryCombo.Location = new Point(11, 39);
            categoryCombo.Margin = new Padding(3, 4, 3, 4);
            categoryCombo.Name = "categoryCombo";
            categoryCombo.Size = new Size(323, 28);
            categoryCombo.TabIndex = 0;
            // 
            // totalCostBox
            // 
            totalCostBox.Controls.Add(totalCostLbl);
            totalCostBox.Controls.Add(calcBtn);
            totalCostBox.Location = new Point(1117, 604);
            totalCostBox.Margin = new Padding(2);
            totalCostBox.Name = "totalCostBox";
            totalCostBox.Padding = new Padding(2);
            totalCostBox.Size = new Size(350, 72);
            totalCostBox.TabIndex = 7;
            totalCostBox.TabStop = false;
            totalCostBox.Text = "Total Cost";
            // 
            // totalCostLbl
            // 
            totalCostLbl.AutoSize = true;
            totalCostLbl.Location = new Point(15, 31);
            totalCostLbl.Margin = new Padding(2, 0, 2, 0);
            totalCostLbl.Name = "totalCostLbl";
            totalCostLbl.Size = new Size(15, 20);
            totalCostLbl.TabIndex = 8;
            totalCostLbl.Text = "-";
            // 
            // calcBtn
            // 
            calcBtn.Location = new Point(248, 31);
            calcBtn.Margin = new Padding(3, 4, 3, 4);
            calcBtn.Name = "calcBtn";
            calcBtn.Size = new Size(86, 30);
            calcBtn.TabIndex = 7;
            calcBtn.Text = "Calculate";
            calcBtn.UseVisualStyleBackColor = true;
            calcBtn.Click += calcBtn_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(resetBtn);
            groupBox1.Controls.Add(importBtn);
            groupBox1.Controls.Add(saveBtn);
            groupBox1.Location = new Point(1121, 10);
            groupBox1.Margin = new Padding(2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2);
            groupBox1.Size = new Size(349, 74);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Material List";
            // 
            // resetBtn
            // 
            resetBtn.Location = new Point(244, 26);
            resetBtn.Margin = new Padding(3, 4, 3, 4);
            resetBtn.Name = "resetBtn";
            resetBtn.Size = new Size(86, 30);
            resetBtn.TabIndex = 11;
            resetBtn.Text = "Reset";
            resetBtn.UseVisualStyleBackColor = true;
            resetBtn.Click += resetBtn_Click;
            // 
            // importBtn
            // 
            importBtn.Location = new Point(127, 26);
            importBtn.Margin = new Padding(3, 4, 3, 4);
            importBtn.Name = "importBtn";
            importBtn.Size = new Size(86, 30);
            importBtn.TabIndex = 10;
            importBtn.Text = "Import";
            importBtn.UseVisualStyleBackColor = true;
            importBtn.Click += importBtn_Click;
            // 
            // saveBtn
            // 
            saveBtn.Location = new Point(6, 26);
            saveBtn.Margin = new Padding(3, 4, 3, 4);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(86, 30);
            saveBtn.TabIndex = 9;
            saveBtn.Text = "Save";
            saveBtn.UseVisualStyleBackColor = true;
            saveBtn.Click += saveBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1481, 690);
            Controls.Add(groupBox1);
            Controls.Add(totalCostBox);
            Controls.Add(insertGroup);
            Controls.Add(dataGridView1);
            Margin = new Padding(2);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            insertGroup.ResumeLayout(false);
            totalCostBox.ResumeLayout(false);
            totalCostBox.PerformLayout();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private GroupBox insertGroup;
        private Button addItemBtn;
        private ComboBox costCombo;
        private ComboBox quantityCombo;
        private ComboBox sizeDescCombo;
        private ComboBox materialCombo;
        private ComboBox itemCombo;
        private ComboBox categoryCombo;
        private GroupBox totalCostBox;
        private Label totalCostLbl;
        private Button calcBtn;
        private Button editBtn;
        private Button clearBtn;
        private GroupBox groupBox1;
        private Button resetBtn;
        private Button importBtn;
        private Button saveBtn;
        private DataGridViewTextBoxColumn Category;
        private DataGridViewTextBoxColumn Item;
        private DataGridViewTextBoxColumn Material;
        private DataGridViewTextBoxColumn SizeDesc;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn UnitCost;
        private DataGridViewTextBoxColumn Cost;
    }
}