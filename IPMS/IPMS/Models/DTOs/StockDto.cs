namespace IPMS.Models.DTOs
{
    public class StockDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Cost { get; set; }
        public decimal Quantity { get; set; }
    }
}
