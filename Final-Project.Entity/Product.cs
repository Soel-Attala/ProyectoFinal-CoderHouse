using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Cost { get; set; }
        public long Stock { get; set; }
        public double SalePrice { get; set; }
        public int UserId { get; set; }

        public Product(int id, string name, string description, double cost, long stock, double salePrice, int userId)
        {
            Id = id;
            Name = name;
            Description = description;
            Cost = cost;
            Stock = stock;
            SalePrice = salePrice;
            UserId = userId;
        }
    }
}
