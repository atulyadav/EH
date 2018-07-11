namespace EH.Data
{
    using EH.Data.Configurations;
    using EH.Data.Migrations;
    using EH.Model;
    using System.Data.Entity;

    public class EHDataContext : DbContext
    {
        public EHDataContext() : base("name=EHDataContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EHDataContext, Configuration>());
            //Database.SetInitializer<EHDataContext>(new CreateDatabaseIfNotExists<EHDataContext>());
        }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new ContactConfiguration());
        }
    }
}
