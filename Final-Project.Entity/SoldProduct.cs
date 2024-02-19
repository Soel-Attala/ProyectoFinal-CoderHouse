using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.Entity
{
    public class SoldProduct
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SaleId { get; set; }
        public long Stock { get; set; }

        public SoldProduct(int id, int productId, int saleId, long stock)
        {
            Id = id;
            ProductId = productId;
            SaleId = saleId;
            Stock = stock;
        }
    }
}
