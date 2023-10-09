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
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            updateBtn = new Button();
            clearBtn = new Button();
            addItemBtn = new Button();
            unitCostCombo = new ComboBox();
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
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Category, Item, Material, SizeDesc, Quantity, UnitCost, Cost });
            dataGridView1.Location = new Point(11, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.RowTemplate.Height = 33;
            dataGridView1.Size = new Size(1379, 833);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            dataGridView1.ColumnHeaderMouseClick += dataGridView1_ColumnHeaderMouseClick;
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
            insertGroup.Controls.Add(label6);
            insertGroup.Controls.Add(label5);
            insertGroup.Controls.Add(label4);
            insertGroup.Controls.Add(label3);
            insertGroup.Controls.Add(label2);
            insertGroup.Controls.Add(label1);
            insertGroup.Controls.Add(updateBtn);
            insertGroup.Controls.Add(clearBtn);
            insertGroup.Controls.Add(addItemBtn);
            insertGroup.Controls.Add(unitCostCombo);
            insertGroup.Controls.Add(quantityCombo);
            insertGroup.Controls.Add(sizeDescCombo);
            insertGroup.Controls.Add(materialCombo);
            insertGroup.Controls.Add(itemCombo);
            insertGroup.Controls.Add(categoryCombo);
            insertGroup.Location = new Point(1401, 113);
            insertGroup.Margin = new Padding(4, 5, 4, 5);
            insertGroup.Name = "insertGroup";
            insertGroup.Padding = new Padding(4, 5, 4, 5);
            insertGroup.Size = new Size(437, 509);
            insertGroup.TabIndex = 2;
            insertGroup.TabStop = false;
            insertGroup.Text = "Add New Items";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(7, 379);
            label6.Name = "label6";
            label6.Size = new Size(85, 25);
            label6.TabIndex = 14;
            label6.Text = "Unit Cost";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(7, 311);
            label5.Name = "label5";
            label5.Size = new Size(80, 25);
            label5.TabIndex = 13;
            label5.Text = "Quantity";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(7, 243);
            label4.Name = "label4";
            label4.Size = new Size(150, 25);
            label4.TabIndex = 12;
            label4.Text = "Size / Description";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(7, 175);
            label3.Name = "label3";
            label3.Size = new Size(75, 25);
            label3.TabIndex = 11;
            label3.Text = "Material";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 107);
            label2.Name = "label2";
            label2.Size = new Size(100, 25);
            label2.TabIndex = 10;
            label2.Text = "Item Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 39);
            label1.Name = "label1";
            label1.Size = new Size(84, 25);
            label1.TabIndex = 9;
            label1.Text = "Category";
            // 
            // updateBtn
            // 
            updateBtn.Location = new Point(158, 452);
            updateBtn.Margin = new Padding(4, 5, 4, 5);
            updateBtn.Name = "updateBtn";
            updateBtn.Size = new Size(107, 38);
            updateBtn.TabIndex = 7;
            updateBtn.Text = "Update";
            updateBtn.UseVisualStyleBackColor = true;
            updateBtn.Click += updateBtn_Click;
            // 
            // clearBtn
            // 
            clearBtn.Location = new Point(304, 452);
            clearBtn.Margin = new Padding(4, 5, 4, 5);
            clearBtn.Name = "clearBtn";
            clearBtn.Size = new Size(107, 38);
            clearBtn.TabIndex = 8;
            clearBtn.Text = "Clear";
            clearBtn.UseVisualStyleBackColor = true;
            clearBtn.Click += clearBtn_Click;
            // 
            // addItemBtn
            // 
            addItemBtn.Location = new Point(7, 452);
            addItemBtn.Margin = new Padding(4, 5, 4, 5);
            addItemBtn.Name = "addItemBtn";
            addItemBtn.Size = new Size(107, 38);
            addItemBtn.TabIndex = 6;
            addItemBtn.Text = "Add";
            addItemBtn.UseVisualStyleBackColor = true;
            addItemBtn.Click += addItemBtn_Click;
            // 
            // unitCostCombo
            // 
            unitCostCombo.FormattingEnabled = true;
            unitCostCombo.Location = new Point(7, 409);
            unitCostCombo.Margin = new Padding(4, 5, 4, 5);
            unitCostCombo.Name = "unitCostCombo";
            unitCostCombo.Size = new Size(403, 33);
            unitCostCombo.TabIndex = 5;
            // 
            // quantityCombo
            // 
            quantityCombo.FormattingEnabled = true;
            quantityCombo.Location = new Point(7, 341);
            quantityCombo.Margin = new Padding(4, 5, 4, 5);
            quantityCombo.Name = "quantityCombo";
            quantityCombo.Size = new Size(403, 33);
            quantityCombo.TabIndex = 4;
            // 
            // sizeDescCombo
            // 
            sizeDescCombo.FormattingEnabled = true;
            sizeDescCombo.Location = new Point(8, 273);
            sizeDescCombo.Margin = new Padding(4, 5, 4, 5);
            sizeDescCombo.Name = "sizeDescCombo";
            sizeDescCombo.Size = new Size(403, 33);
            sizeDescCombo.TabIndex = 3;
            // 
            // materialCombo
            // 
            materialCombo.FormattingEnabled = true;
            materialCombo.Location = new Point(7, 205);
            materialCombo.Margin = new Padding(4, 5, 4, 5);
            materialCombo.Name = "materialCombo";
            materialCombo.Size = new Size(403, 33);
            materialCombo.TabIndex = 2;
            // 
            // itemCombo
            // 
            itemCombo.FormattingEnabled = true;
            itemCombo.Location = new Point(8, 137);
            itemCombo.Margin = new Padding(4, 5, 4, 5);
            itemCombo.Name = "itemCombo";
            itemCombo.Size = new Size(403, 33);
            itemCombo.TabIndex = 1;
            // 
            // categoryCombo
            // 
            categoryCombo.FormattingEnabled = true;
            categoryCombo.Location = new Point(9, 69);
            categoryCombo.Margin = new Padding(4, 5, 4, 5);
            categoryCombo.Name = "categoryCombo";
            categoryCombo.Size = new Size(403, 33);
            categoryCombo.TabIndex = 0;
            // 
            // totalCostBox
            // 
            totalCostBox.Controls.Add(totalCostLbl);
            totalCostBox.Controls.Add(calcBtn);
            totalCostBox.Location = new Point(1396, 755);
            totalCostBox.Name = "totalCostBox";
            totalCostBox.Size = new Size(437, 90);
            totalCostBox.TabIndex = 7;
            totalCostBox.TabStop = false;
            totalCostBox.Text = "Total Cost";
            // 
            // totalCostLbl
            // 
            totalCostLbl.AutoSize = true;
            totalCostLbl.Location = new Point(19, 39);
            totalCostLbl.Name = "totalCostLbl";
            totalCostLbl.Size = new Size(19, 25);
            totalCostLbl.TabIndex = 8;
            totalCostLbl.Text = "-";
            // 
            // calcBtn
            // 
            calcBtn.Location = new Point(310, 39);
            calcBtn.Margin = new Padding(4, 5, 4, 5);
            calcBtn.Name = "calcBtn";
            calcBtn.Size = new Size(107, 38);
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
            groupBox1.Location = new Point(1401, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(436, 93);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Material List";
            // 
            // resetBtn
            // 
            resetBtn.Location = new Point(305, 32);
            resetBtn.Margin = new Padding(4, 5, 4, 5);
            resetBtn.Name = "resetBtn";
            resetBtn.Size = new Size(107, 38);
            resetBtn.TabIndex = 11;
            resetBtn.Text = "Reset";
            resetBtn.UseVisualStyleBackColor = true;
            resetBtn.Click += resetBtn_Click;
            // 
            // importBtn
            // 
            importBtn.Location = new Point(159, 32);
            importBtn.Margin = new Padding(4, 5, 4, 5);
            importBtn.Name = "importBtn";
            importBtn.Size = new Size(107, 38);
            importBtn.TabIndex = 10;
            importBtn.Text = "Import";
            importBtn.UseVisualStyleBackColor = true;
            importBtn.Click += importBtn_Click;
            // 
            // saveBtn
            // 
            saveBtn.Location = new Point(7, 32);
            saveBtn.Margin = new Padding(4, 5, 4, 5);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(107, 38);
            saveBtn.TabIndex = 9;
            saveBtn.Text = "Save";
            saveBtn.UseVisualStyleBackColor = true;
            saveBtn.Click += saveBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1851, 863);
            Controls.Add(groupBox1);
            Controls.Add(totalCostBox);
            Controls.Add(insertGroup);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            insertGroup.ResumeLayout(false);
            insertGroup.PerformLayout();
            totalCostBox.ResumeLayout(false);
            totalCostBox.PerformLayout();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private GroupBox insertGroup;
        private Button addItemBtn;
        private ComboBox unitCostCombo;
        private ComboBox quantityCombo;
        private ComboBox sizeDescCombo;
        private ComboBox materialCombo;
        private ComboBox itemCombo;
        private ComboBox categoryCombo;
        private GroupBox totalCostBox;
        private Label totalCostLbl;
        private Button calcBtn;
        private Button updateBtn;
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
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}