using D.A.L.Concrete.Contexts.EntityFramework.Mappings;
using Entitiess.Concrete;
using Microsoft.EntityFrameworkCore;

namespace D.A.L.Concrete.Contexts.EntityFramework
{
    public class ETicaretContext : DbContext
    {
        public DbSet<Products> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<AutoBasket> AutoBasket { get; set; }


        //public ETicaretContext(DbContextOptions<ETicaretContext> options):base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=NUMANPC\MSSQLSERVER01;Database=MyETicaret;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
            modelBuilder.ApplyConfiguration(new CategoriesMap());
            modelBuilder.ApplyConfiguration(new CustomersMap());
            modelBuilder.ApplyConfiguration(new OrderDetailsMap());
            modelBuilder.ApplyConfiguration(new OrderInformationsMap());
            modelBuilder.ApplyConfiguration(new OrderNotesMap());
            modelBuilder.ApplyConfiguration(new OrdersMap());
            modelBuilder.ApplyConfiguration(new PImagesMap());
            modelBuilder.ApplyConfiguration(new ProductsMap());
            modelBuilder.ApplyConfiguration(new TempBasketsMap());
            modelBuilder.ApplyConfiguration(new UsersAdminMap());
            modelBuilder.ApplyConfiguration(new VariantsMap());
        }
    }
}
