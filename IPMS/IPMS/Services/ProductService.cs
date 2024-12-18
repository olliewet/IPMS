using IPMS.Interfaces;
using IPMS.Models.DTOs;

namespace IPMS.Services
{
    public class ProductService
    {
        private readonly IStockManagementRepository _stockRepo;
        private readonly IProductManagementRepository _productRepo;
        private readonly IBillOfMatrialsManagementRepository _bomRepo;

        public ProductService(IStockManagementRepository stockRepository, IProductManagementRepository productRepository, IBillOfMatrialsManagementRepository bomRepository)
        {
            //Add Validation Checking
            _stockRepo = stockRepository;
            _productRepo = productRepository;
            _bomRepo = bomRepository;
        }
        public async Task<bool> AddProduct(ProductDto productItem)
        {
            try
            {
                var id = await _productRepo.AddProduct(productItem);
                foreach(var matrial in productItem.Materials)
                {
                    matrial.ProductId = id.ToString();
                    await _bomRepo.AddBom(matrial);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> UpdateProductItem(ProductDto productItem)
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

        public async Task<List<ProductDto>> GetAllProducts()
        {
            try
            {
                //Getting all products and materials 
                var products = await _productRepo.GetAllProducts();
                var materials = await _stockRepo.GetAllStock();

                //Looping through each product 
                foreach (var product in products)
                {
                    product.Materials = await _bomRepo.GetAllBomsFromId(product.Id.ToString());
                }

                return products;
            }
            catch (Exception ex)
            {
                return new();
            }
        }

        private decimal GetCost(List<StockDto> stockDtos)
        {
            decimal totalCost = 0;
            foreach (var stock in stockDtos)
            {
                totalCost += stock.Cost;
            }
            return totalCost;
        }
        //
        private int GetQuantity(List<StockDto> stockDtos)
        {
            return 0;
        }
    }
}
