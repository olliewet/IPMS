using IPMS.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace IPMS.Interfaces
{
    public interface IProductManagementRepository
    {
        Task<bool> AddProduct(StockDto product);
        Task<bool> UpdateProduct(StockDto product);
        Task<List<StockDto>> GetAllProducts();
    }
}
