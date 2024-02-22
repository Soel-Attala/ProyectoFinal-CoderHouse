using Final_Project.Data;
using Final_Project.Data.Repositories;
using Final_Project.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.Bussiness
{
    public class SaleService : ISaleService
    {
        private readonly SaleRepository _saleRepository;

        public SaleService(SaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<IEnumerable<Sale>> GetAllSales()
        {
            return await _saleRepository.GetAll();
        }

        public async Task<Sale> GetSaleById(int id)
        {
            return await _saleRepository.Get(id);
        }

        public async Task<bool> AddSale(Sale sale)
        {
            return await _saleRepository.Insert(sale);
        }

        public async Task<bool> UpdateSale(Sale sale)
        {
            return await _saleRepository.Update(sale);
        }

        public async Task<bool> DeleteSale(int id)
        {
            return await _saleRepository.Delete(id);
        }
    }



}
