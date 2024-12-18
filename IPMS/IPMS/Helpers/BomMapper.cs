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
                Id = ef.Id,
                Name = ef.Name,
                ProductId = ef.ProductId,
                Quantity = ef.Quantity
            };
        }
        public static BillOfMaterials GetEfromDto(BomDto dto)
        {
            return new BillOfMaterials()
            {
                Id = dto.Id,
                Name = dto.Name,
                ProductId = dto.ProductId,
                Quantity = dto.Quantity
            };
        }
    }
}
