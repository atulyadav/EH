namespace EH.Data.Configurations
{
    using EH.Model;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    class ContactConfiguration : EntityTypeConfiguration<Contact>
    {
        public ContactConfiguration()
        {
            this.HasKey(c => c.Id);
            this.ToTable("Contacts");
            this.Property(c => c.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.FirstName).IsRequired().HasMaxLength(150);
            this.Property(c => c.LastName).HasMaxLength(150);
            this.Property(c => c.EmailId).HasMaxLength(255);
            this.Property(c => c.PhoneNumber).HasMaxLength(20);
        }
    }
}
