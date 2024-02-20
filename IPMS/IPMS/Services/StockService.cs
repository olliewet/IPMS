using IPMS.Interfaces;
using IPMS.Models.DTOs;

namespace IPMS.Services
{
    public class StockService
    {
        private readonly IStockManagementRepository _stockRepo;
        public StockService(IStockManagementRepository repository) 
        {
            _stockRepo = repository;
        }

        public async Task<bool> AddStockItem(StockDto StockItem)
        {
            try
            {
                await _stockRepo.AddStockItem(StockItem);
                return true;
            } 
            catch(Exception ex)
            {
                return false;
            }              
        }
        public async Task<bool> UpdateStockItem(StockDto StockItem)
        {
            try
            {
                await _stockRepo.UpdateStockItem(StockItem);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<StockDto>> GetAllStock()
        {
            try
            {
                return await _stockRepo.GetAllStock();
            }
            catch (Exception ex)
            {
                return new List<StockDto>();
            }
        }    
    }
}

