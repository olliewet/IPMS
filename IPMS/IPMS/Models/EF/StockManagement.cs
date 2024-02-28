namespace IPMS.Models.EF
{
    //Products Held - ie Super Glue Wood Etc
    public class StockManagement
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Cost {  get; set; }
        public int Quantity { get; set; }
    }
}
