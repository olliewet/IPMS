using IPMS.Models.DTOs;
using IPMS.Models.EF;
using Microsoft.EntityFrameworkCore;

namespace IPMS.Helpers
{
    public class ProductMapper
    {
        public static ProductDto GetDtoFromEFModel(ProductManagement ef)
        {
            return new ProductDto()
            {
                Id = ef.Id,   
                QuantitySold = ef.QuantitySold,
                QuantityAvaliable = ef.QuantityAvaliable,
                SKU = ef.SKU
            };
        }
        public static ProductManagement GetEfromDto(ProductDto dto)
        {
            return new ProductManagement()
            {
                Id = dto.Id,
                QuantitySold = dto.QuantitySold,
                QuantityAvaliable = dto.QuantityAvaliable,
                SKU = dto.SKU
            };
        }
    }
}
