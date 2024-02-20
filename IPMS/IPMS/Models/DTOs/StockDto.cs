namespace IPMS.Models.DTOs
{
    public class StockDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public float Cost { get; set; }
        public int Quantity { get; set; }
    }
}
