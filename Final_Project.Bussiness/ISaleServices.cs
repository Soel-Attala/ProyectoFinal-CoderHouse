using Final_Project.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.Bussiness
{
    public interface ISaleService
    {
        Task<bool> AddSale(Sale sale);
        Task<bool> UpdateSale(Sale sale);
        Task<bool> DeleteSale(int id);
        Task<Sale> GetSaleById(int id);
        Task<IEnumerable<Sale>> GetAllSales();
    }
}
