namespace IPMS.Models.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int QuantitySold { get; set; }
        public int QuantityAvaliable { get; set; }
        public string SKU { get; set; } = string.Empty;
        public string LinkedMaterials { get; set; } = string.Empty;
        public List<StockDto> Materials = new ();
    }
}
