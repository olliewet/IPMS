using IPMS.Models.EF;

namespace IPMS.Models.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string SKU { get; set; } = string.Empty;
        public decimal Cost { get; set; }
        public int QuantitySold { get; set; }
        public int QuantityAvaliable { get; set; }
        public List<BomDto> Materials = new ();
    }
}
