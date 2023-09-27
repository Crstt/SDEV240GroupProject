using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDEV240GroupProject
{
    public class Item
    {
        public string Category { get; set; }
        public string Name { get; set; }
        public string Material { get; set; }
        public string SizeDesc { get; set; }
        public int Quantity { get; set; }
        public double UnitCost { get; set; }
        public double Cost { get; set; }

        public Item(string category, string name, string material, string sizeDesc, string quantityStr, string unitCostStr)
        {
            int quantity;
            double unitCost;

            // Check if all required fields are filled in
            if (string.IsNullOrWhiteSpace(category) ||
                string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(material) ||
                string.IsNullOrWhiteSpace(sizeDesc))
            {
                throw new ArgumentNullException("All required fields must be filled in.");
            }

            // Check if the quantity and cost values are valid numbers
            if (!int.TryParse(quantityStr.ToString(), out quantity) ||
                !double.TryParse(unitCostStr.ToString(), out unitCost))
            {
                throw new ArgumentOutOfRangeException("The quantity and unit cost values must be valid numbers.");
            }

            // Check if the quantity and cost values are within the allowed range
            if (quantity <= 0 || unitCost < 0)
            {
                throw new ArgumentOutOfRangeException("The quantity must be greater than zero and the unit cost must be greater than or equal to zero.");
            }

            this.Category = category;
            this.Name = name;
            this.Material = material;
            this.SizeDesc = sizeDesc;
            this.Quantity = quantity;
            this.UnitCost = unitCost;
            this.Cost = this.Quantity * this.UnitCost;
        }
    }

}
