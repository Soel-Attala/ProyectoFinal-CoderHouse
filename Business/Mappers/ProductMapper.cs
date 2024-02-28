using Business.DTOs;
using Entities.Models;

namespace FinalProject.Business.Mappers
{
    public static class ProductMapper
    {
        public static Product MappingDtoProduct(ProductDTO productDto)
        {
            Product p = new Product();
            p.Descriptions = productDto.Descriptions;
            p.Id = productDto.Id;
            p.SalePrice = productDto.SalePrice;
            p.Stock = productDto.Stock;
            p.Cost = productDto.Cost;
            p.UserId = productDto.UserId;


            return p;
        }

        public static ProductDTO MapperProductToDto(Product product)
        {
            ProductDTO productDto = new ProductDTO();
            productDto.Descriptions = product.Descriptions;
            productDto.Id = product.Id;
            productDto.SalePrice = product.SalePrice;
            productDto.Stock = product.Stock;
            productDto.Cost = product.Cost;
            productDto.UserId = product.UserId;

            return productDto;
        }
    }
}
