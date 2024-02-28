using IPMS.Interfaces;
using IPMS.Models.DTOs;

namespace IPMS.Services
{
    public class ProductService
    {
        private readonly IStockManagementRepository _stockRepo;
        private readonly IProductManagementRepository _productRepo;

        public ProductService(IStockManagementRepository stockRepository, IProductManagementRepository productRepository)
        {
            //Add Validation Checking
            _stockRepo = stockRepository;
            _productRepo = productRepository;
        }
        public async Task<bool> AddProduct(ProductDto productItem)
        {
            try
            {
                await _productRepo.AddProduct(productItem);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> UpdateStockItem(ProductDto productItem)
        {
            try
            {
                await _productRepo.UpdateProduct(productItem);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<ProductDto>> GetAllProduct(ProductDto productItem)
        {
            try
            {
                //Getting all products and materials 
                var products = await _productRepo.GetAllProducts();
                var materials = await _stockRepo.GetAllStock();

                //Looping through each product 
                foreach (var product in products)
                {
                    //Getting the materials from the SKU
                    var individualMaterials = product.LinkedMaterials.Split(",");
                    foreach(var id in individualMaterials)
                    {
                        var foundMaterial = materials.FirstOrDefault(t => t.Equals(id));
                        if(foundMaterial != null)
                        {
                            product.Materials.Add(foundMaterial);
                        }                     
                    }
                }

                return products;
            }
            catch (Exception ex)
            {
                return new();
            }
        }
    }
}
