using Entities.Database;
using Entities.Models;
using Business.DTOs;
using FinalProject.Business.Mappers;

namespace Business.Services
{
    public class ProductServices

    {
        private CoderContext coderContext;
        public ProductServices(CoderContext coderContext)
        {
            this.coderContext = coderContext;
        }

        public bool AddProducts(ProductDTO productDto)
        {
            Product p = ProductMapper.MappingDtoProduct(productDto);
            this.coderContext.Products.Add(p);
            this.coderContext.SaveChanges();
            return true;

        }
        public bool UpdateProductById(int id, ProductDTO productDTO)
        {
            Product? product = this.coderContext.Products.FirstOrDefault(p => p.Id == id);

            if (product != null)
            {
                // No modifiques la propiedad Id, ya que es parte de la clave primaria.
                product.Descriptions = productDTO.Descriptions;
                product.SalePrice = productDTO.SalePrice;
                product.Stock = productDTO.Stock;
                product.Cost = productDTO.Cost;
                product.UserId = productDTO.UserId;

                this.coderContext.SaveChanges();
                return true;
            }

            return false;
        }

        public bool DeleteProductById(int id)
        {
            Product? product = this.coderContext.Products.Where(product => product.Id == id).FirstOrDefault();
            if (product != null)
            {
                this.coderContext.Remove(product);
                this.coderContext.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Product> GetProductList()
        {
            return this.coderContext.Products.ToList();
        }


    }
}
