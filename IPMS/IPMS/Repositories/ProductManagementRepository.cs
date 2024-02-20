using IPMS.Data;
using IPMS.Helpers;
using IPMS.Interfaces;
using IPMS.Models.DTOs;

namespace IPMS.Repositories
{
    public class ProductManagementRepository : IProductManagementRepository
    {
        ApplicationDBContext _context;

        public ProductManagementRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public Task<bool> AddProduct(StockDto product)
        {
            throw new NotImplementedException();
        }

        public Task<List<StockDto>> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateProduct(StockDto product)
        {
            throw new NotImplementedException();
        }
    }
}
