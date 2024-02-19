using Final_Project.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_Pre_Release
{
    public interface IProductInterface
    {
        Product GetProductById(int id);
        List<Product> GetAllProducts();
        bool AddProduct(Product product);
        bool DeleteProductById(int id);
        bool UpdateProductById(int id, Product product);
        bool UpdateProductCostById(int id, double cost);
    }
}
