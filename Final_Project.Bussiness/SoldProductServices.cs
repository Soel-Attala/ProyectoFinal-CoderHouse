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
    public class SoldProductService : ISoldProductService
    {
        private readonly SoldProductRepository _soldProductRepository;

        public SoldProductService(SoldProductRepository soldProductRepository)
        {
            _soldProductRepository = soldProductRepository;
        }

        public async Task<IEnumerable<SoldProduct>> GetAllSoldProducts()
        {
            return await _soldProductRepository.GetAll();
        }

        public async Task<SoldProduct> GetSoldProductById(int id)
        {
            return await _soldProductRepository.Get(id);
        }

        public async Task<bool> AddSoldProduct(SoldProduct soldProduct)
        {
            return await _soldProductRepository.Insert(soldProduct);
        }

        public async Task<bool> UpdateSoldProduct(SoldProduct soldProduct)
        {
            return await _soldProductRepository.Update(soldProduct);
        }

        public async Task<bool> DeleteSoldProduct(int id)
        {
            return await _soldProductRepository.Delete(id);
        }
    }



}
