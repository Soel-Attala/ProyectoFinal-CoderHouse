using Final_Project.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.Bussiness
{
    public interface ISoldProductService
    {
        Task<bool> AddSoldProduct(SoldProduct soldProduct);
        Task<bool> UpdateSoldProduct(SoldProduct soldProduct);
        Task<bool> DeleteSoldProduct(int id);
        Task<SoldProduct> GetSoldProductById(int id);
        Task<IEnumerable<SoldProduct>> GetAllSoldProducts();
    }
}
