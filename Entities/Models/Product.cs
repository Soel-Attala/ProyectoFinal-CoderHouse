using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Product
    {
        public Product()
        {
            SoldProducts = new HashSet<SoldProduct>();
        }

        public int Id { get; set; }
        public string Descriptions { get; set; } = null!;
        public decimal? Cost { get; set; }
        public decimal SalePrice { get; set; }
        public int Stock { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<SoldProduct> SoldProducts { get; set; }
    }
}
