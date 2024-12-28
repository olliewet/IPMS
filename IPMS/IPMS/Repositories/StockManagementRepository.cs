using IPMS.Data;
using IPMS.Helpers;
using IPMS.Interfaces;
using IPMS.Models.Classes;
using IPMS.Models.DTOs;

namespace IPMS.Repositories
{
    public class StockManagementRepository : IStockManagementRepository
    {
        ApplicationDBContext _context; 
        public StockManagementRepository(ApplicationDBContext context) 
        {
          _context = context;
        }

        public async Task<bool> AddStockItem(StockDto product)
        {
            try
            {
                _context.StockManagement.Add(StockMapper.GetEfromDto(product));
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) { }
            {
                return false;
            }
        }

        public async Task<List<StockDto>> GetAllStock()
        {
            List<StockDto> result = new List<StockDto>();
            try
            {
                var list =  _context.StockManagement;
                foreach(var item in list)
                {
                    result.Add(StockMapper.GetDtoFromEFModel(item));
                }
                await _context.SaveChangesAsync();
                return result;
            }
            catch (Exception ex) { }
            {
                return result;
            }
        }

        public async Task<bool> RemoveStockItem(StockDto stockDto)
        {
            try
            {
                var entity = await _context.StockManagement.FindAsync(stockDto.Id);

                if (entity == null)
                {
                    // Handle the case where the entity does not exist
                    return false;
                }

                _context.StockManagement.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) { }
            {
                return false;
            }
        }

        public async Task<bool> UpdateStockItem(StockDto stock)
        {
            try
            {
                var entity = await _context.StockManagement.FindAsync(stock.Id);

                if (entity == null)
                {
                    // Handle the case where the entity does not exist
                    return false;
                }

                entity.Quantity = stock.Quantity;
                entity.Cost = stock.Cost;

                // Remove the entity
                _context.StockManagement.Update(entity);

                // Save changes to the database
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex) { }
            {
                return false;
            }
        }
    }
}
