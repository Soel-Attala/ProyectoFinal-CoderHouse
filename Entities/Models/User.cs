using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class User
    {
        public User()
        {
            Products = new HashSet<Product>();
            Sales = new HashSet<Sale>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
