using Final_Project.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_Pre_Release
{
    public interface ISaleInterface
    {
        Sale GetSaleById(int id);
        List<Sale> GetAllSales();
        bool AddSale(Sale sale);
        bool DeleteSaleById(int id);
        bool UpdateSaleById(int id, Sale sale);
    }
}
