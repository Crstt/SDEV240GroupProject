using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDEV240GroupProject
{
    public class Item : INotifyPropertyChanged
    {
        private string category;
        private string name;
        private string material;
        private string sizeDesc;
        private int quantity;
        private double unitCost;
        private double cost;

        public string Category
        {
            get { return category; }
            set
            {
                if (category != value)
                {
                    category = value;
                    OnPropertyChanged("Category");
                }
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        public string Material
        {
            get { return material; }
            set
            {
                if (material != value)
                {
                    material = value;
                    OnPropertyChanged("Material");
                }
            }
        }
        public string SizeDesc
        {
            get { return sizeDesc; }
            set
            {
                if (sizeDesc != value)
                {
                    sizeDesc = value;
                    OnPropertyChanged("SizeDesc");
                }
            }
        }

        public int Quantity
        {
            get { return quantity; }
            set
            {
                if (quantity != value)
                {
                    quantity = value;
                    OnPropertyChanged("Quantity");
                    UpdateCost();
                }
            }
        }

        public double UnitCost
        {
            get { return unitCost; }
            set
            {
                if (unitCost != value)
                {
                    unitCost = value;
                    OnPropertyChanged("UnitCost");
                    UpdateCost();
                }
            }
        }

        public double Cost
        {
            get { return cost; }
            private set
            {
                if (cost != value)
                {
                    cost = value;
                    OnPropertyChanged("Cost");
                }
            }
        }

        private void UpdateCost()
        {
            Cost = Quantity * UnitCost;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

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
