using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Sale
    {
        public Sale()
        {
            SoldProducts = new HashSet<SoldProduct>();
        }

        public int Id { get; set; }
        public string? Comments { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<SoldProduct> SoldProducts { get; set; }
    }
}
