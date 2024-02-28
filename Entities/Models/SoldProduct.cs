using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class SoldProduct
    {
        public int Id { get; set; }
        public int Stock { get; set; }
        public int ProductId { get; set; }
        public int SaleId { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual Sale Sale { get; set; } = null!;
    }
}
