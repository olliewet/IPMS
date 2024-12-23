using IPMS.Models.DTOs;

namespace IPMS.Interfaces
{
    public interface IStockManagementRepository
    {
        Task<bool> AddStockItem(StockDto product);
        Task<bool> RemoveStockItem(StockDto product);
        Task<bool> UpdateStockItem(StockDto product);
        Task<List<StockDto>> GetAllStock();
    }
}
