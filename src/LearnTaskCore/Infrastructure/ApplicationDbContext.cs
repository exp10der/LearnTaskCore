namespace LearnTaskCore.Infrastructure
{
    using System.Data.Entity;
    using Domain;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<ItemDocument> ItemDocuments { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemDocument>()
                .HasKey(id => new {id.ItemId, id.DocumentId});
        }
    }
}