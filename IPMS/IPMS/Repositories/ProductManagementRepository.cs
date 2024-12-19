using IPMS.Data;
using IPMS.Helpers;
using IPMS.Interfaces;
using IPMS.Models.DTOs;
using System.Text.RegularExpressions;

namespace IPMS.Repositories
{
    public class ProductManagementRepository : IProductManagementRepository
    {
        ApplicationDBContext _context;

        public ProductManagementRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<int> AddProduct(ProductDto product)
        {
            try
            {
                var entity = ProductMapper.GetEfromDto(product);

                // Add the entity to the context
                _context.ProductManagement.Add(entity);

                // Save changes to the database
                await _context.SaveChangesAsync();

                // Return the generated ID
                return entity.Id;
       
            }
            catch (Exception ex) { }
            {
                return 0;
            }
        }
        public async Task<bool> RemoveProduct(ProductDto product)
        {
            try
            {
     
                var entity = await _context.ProductManagement.FindAsync(product.Id);

                if (entity == null)
                {
                    // Handle the case where the entity does not exist
                    return false;
                }

                // Remove the entity
                _context.ProductManagement.Remove(entity);

                // Save changes to the database
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
