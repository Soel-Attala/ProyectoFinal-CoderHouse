using Final_Project.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_Pre_Release
{
    public interface ISoldProductInterface
    {
        SoldProduct GetSoldProductById(int id);
        List<SoldProduct> GetAllSoldProducts();
        bool AddSoldProduct(SoldProduct soldProduct);
        bool DeleteSoldProductById(int id);
        bool UpdateSoldProductById(int id, SoldProduct soldProduct);
        bool UpdateSoldProductStockById(int id, long stock);
    }
}
