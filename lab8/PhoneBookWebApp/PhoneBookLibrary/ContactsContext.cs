using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PhoneBookLibrary
{
    public partial class ContactsContext : DbContext, IContactsContext
    {
        public ContactsContext()
        {
        }

        public ContactsContext(DbContextOptions<ContactsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
        public virtual DbSet<PhoneBooks> PhoneBooks { get; set; }

        public int SaveDbChangesAsync()
        {
            return this.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=VITALIY-DELL;Initial Catalog=Contacts;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<PhoneBooks>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.TelephoneNumber)
                    .IsRequired()
                    .HasMaxLength(15);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
