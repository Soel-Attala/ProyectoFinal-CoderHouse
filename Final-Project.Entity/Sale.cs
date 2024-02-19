using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.Entity
{
    public class Sale
    {
        public int Id { get; set; }
        public int SaleId { get; set; }
        public string Comments { get; set; }

        public Sale(int id, int saleId, string comments)
        {
            Id = id;
            SaleId = saleId;
            Comments = comments;
        }
    }
}
