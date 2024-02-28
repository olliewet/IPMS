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

        public async Task<bool> AddProduct(ProductDto product)
        {
            try
            {
                _context.ProductManagement.Add(ProductMapper.GetEfromDto(product));
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) { }
            {
                return false;
            }
        }

        public async Task<List<ProductDto>> GetAllProducts()
        {
            List<ProductDto> result = new List<ProductDto>();
            try
            {
                var list = _context.ProductManagement;
                foreach (var item in list)
                {
                    result.Add(ProductMapper.GetDtoFromEFModel(item));
                }
                await _context.SaveChangesAsync();
                return result;
            }
            catch (Exception ex) { }
            {
                return result;
            }
        }

        public async Task<bool> UpdateProduct(ProductDto product)
        {
            try
            {
                _context.ProductManagement.Update(ProductMapper.GetEfromDto(product));
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
