using IPMS.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace IPMS.Interfaces
{
    public interface IProductManagementRepository
    {
        Task<int> AddProduct(ProductDto product);
        Task<bool> UpdateProduct(ProductDto product);
        Task<bool> RemoveProduct(ProductDto product);
        Task<List<ProductDto>> GetAllProducts();
    }
}
