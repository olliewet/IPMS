namespace IPMS.Models.EF
{
    public class OrderManagement
    {
        public Guid Id { get; set; }
        public int OrderNo { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public int ProductID { get; set; }
        public int Quantity { get; set; }
    }
}
