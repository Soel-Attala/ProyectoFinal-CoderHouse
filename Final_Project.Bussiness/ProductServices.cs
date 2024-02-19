using Final_Project.Data;
using Final_Project.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.Bussiness
{
    public static class ProductService
    {
        public static List<Product> GetAllProducts()
        {
            DatabaseManager databaseManager = new DatabaseManager();
            return databaseManager.GetProductById();
        }

    }
}
