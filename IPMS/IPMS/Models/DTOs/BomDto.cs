namespace IPMS.Models.DTOs
{
    public class BomDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public string ProductId { get; set; } = string.Empty; //Links to a product 
    }
}
