using IPMS.Models.DTOs;
using IPMS.Models.EF;
using Microsoft.EntityFrameworkCore;

namespace IPMS.Helpers
{
    public class BomMapper
    {
        public static BomDto GetDtoFromEFModel(BillOfMaterials ef)
        {
            return new BomDto()
            {
                Name = ef.Name,
                ProductId = ef.ProductId,
                Quantity = ef.Quantity,
                StockId = ef.StockId
            };
        }
        public static BillOfMaterials GetEfromDto(BomDto dto)
        {
            return new BillOfMaterials()
            {

                Name = dto.Name,
                ProductId = dto.ProductId,
                Quantity = dto.Quantity,
                StockId = dto.StockId
            };
        }
    }
}
