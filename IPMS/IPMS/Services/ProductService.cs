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
                foreach(var material in productItem.Materials)
                {
                    material.ProductId = id.ToString();
                    await _bomRepo.AddBom(material);
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
                    product.Cost = await GetCost(product.Materials);
                }

                return products;
            }
            catch (Exception ex)
            {
                return new();
            }
        }
        public async Task<bool> RemoveProduct(ProductDto productItem)
        {
            try
            {
                var result = await _productRepo.RemoveProduct(productItem);
                
                foreach(var item in productItem.Materials)
                {
                    await _bomRepo.RemoveBom(item);
                }
      
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private async Task<decimal> GetCost(List<BomDto> matrials)
        {
            decimal totalCost = 0;
            var stock = await _stockRepo.GetAllStock();
            foreach (var material in matrials)
            {
                var item = stock.FirstOrDefault(s => s.Id.ToString() == material.StockId);
                if(item != null)
                {
                    totalCost += (item.Cost * material.Quantity);
                }
            }
            return Math.Round(totalCost,2);
        }

    }
}
