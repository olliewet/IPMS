using IPMS.Models.DTOs;
using IPMS.Models.EF;

namespace IPMS.Helpers
{
    public static class StockMapper
    {
        public static StockDto GetDtoFromEFModel(StockManagement ef)
        {
            return new StockDto()
            {
                Id = ef.Id,
                Name = ef.Name,
                Cost = ef.Cost,
                Quantity = ef.Quantity
            };
        }
        public static StockManagement GetEfromDto(StockDto dto)
        {
            return new StockManagement()
            {
                Id = dto.Id,
                Name = dto.Name,
                Cost = dto.Cost,
                Quantity = dto.Quantity
            };
        }
    }
}
