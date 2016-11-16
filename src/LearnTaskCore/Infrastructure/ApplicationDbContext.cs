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

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}