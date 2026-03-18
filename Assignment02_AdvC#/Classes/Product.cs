using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment02_AdvC_.Classes
{
    public class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }

        public Product(string name, string category, double price, int stock)
        {
            Name = name;
            Category = category;
            Price = price;
            Stock = stock;
        }
    }
}
