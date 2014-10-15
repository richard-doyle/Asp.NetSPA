namespace SportsStore.Data.Context
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    using SportsStore.Data.Entities;

    public class SportsStoreContext : DbContext
    {
        public SportsStoreContext()
            : base("SportsStoreContext")
        {
        }

        public virtual IDbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
