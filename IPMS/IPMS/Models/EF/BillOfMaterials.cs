using System.ComponentModel.DataAnnotations;

namespace IPMS.Models.EF
{
    public class BillOfMaterials
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Cost { get; set; }
        public int Quantity { get; set; }
        public string ProductId { get; set; } = string.Empty; //Links to a product 
    }
}
