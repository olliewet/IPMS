namespace IPMS.Models.EF
{
    public class ProductManagement
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int QuantitySold { get; set; }
        public int QuantityAvaliable { get; set; }
        public string SKU { get; set; } = string.Empty;
    }
}
