using Final_Project.Data;
using Final_Project.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.Bussiness
{
    public static class SoldProductService
    {
        public static List<SoldProduct> GetAllSoldProducts()
        {
            DatabaseManager databaseManager = new DatabaseManager();
            return databaseManager.GetSoldProductById();
        }
    }

    public interface ISoldProductService
    {
        Task<bool> AddSoldProduct(SoldProduct soldProduct);
        Task<bool> UpdateSoldProduct(SoldProduct soldProduct);
        Task<bool> DeleteSoldProduct(int id);
        Task<SoldProduct> GetSoldProductById(int id);
        Task<IEnumerable<SoldProduct>> GetAllSoldProducts();
    }
}
