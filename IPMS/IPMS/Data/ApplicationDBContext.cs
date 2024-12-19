using IPMS.Models.EF;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Xml;


namespace IPMS.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductManagement>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd(); // This line configures the ID to be generated automatically
            modelBuilder.Entity<StockManagement>()
               .Property(e => e.Id)
               .ValueGeneratedOnAdd();
    
            modelBuilder.Entity<BillOfMaterials>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd(); // Ensures the database generates the value
        }

        public DbSet<ProductManagement> ProductManagement { get; set; }
        public DbSet<StockManagement> StockManagement { get; set; }
        public DbSet<OrderManagement> OrderManagement { get; set; }
        public DbSet<BillOfMaterials> BomManagement { get; set; }
    }
}
