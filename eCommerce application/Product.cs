using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce_application
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public Product(int product_Id, string product_Name, decimal price, int stock)
        {
            ProductID = product_Id;
            ProductName = product_Name;
            Price = price;
            Stock = stock;
        }
        public void IncreaseStock(int numbers)
        {
            Stock += numbers;
        }

        public void DecreaseStock(int numbers)
        {
            if (Stock >= numbers)
            {
                Stock -= numbers;
            }
            else
            {
                throw new InvalidOperationException("Cannot decrease stock below 0");
            }
        }
    }
}

    

