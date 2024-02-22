using Final_Project.Data;
using Final_Project.Entity;
using Final_Project.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.Bussiness
{
    public class ProductService : IProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _productRepository.GetAll();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _productRepository.Get(id);
        }

        public async Task<bool> AddProduct(Product product)
        {
            return await _productRepository.Insert(product);
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            return await _productRepository.Update(product);
        }

        public async Task<bool> DeleteProduct(int id)
        {
            return await _productRepository.Delete(id);
        }
    }


}


