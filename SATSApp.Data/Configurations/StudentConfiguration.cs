using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SATSApp.Data.Entities;

namespace SATSApp.Data.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students", "satsapp");

            builder.HasKey(x => x.StudentId);

            builder.Property(x => x.StudentId)
                  .HasColumnName("student_id")
                  .ValueGeneratedOnAdd(); // Set auto-increment

            builder.Property(x => x.FirstName)
                   .HasColumnName("first_name")
                  .IsRequired()
                  .HasMaxLength(50);

            builder.Property(x => x.LastName)
                  .HasColumnName("last_name")

                  .IsRequired()
                  .HasMaxLength(50);

            builder.Property(x => x.BirthDate)
                   .HasColumnName("birth_date")
                   .IsRequired();

            builder.Property(x => x.Email)
                   .HasColumnName("email")
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.City)
                   .HasColumnName("city")
                   .HasMaxLength(100);

            //Base Entity
            builder.Property(x => x.CreaDate)
                  .HasColumnName("crea_date")
                   .IsRequired()
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");


            builder.Property(x => x.IsDeleted)
                .HasColumnName("is_deleted")
                   .IsRequired();

        }
    }
}
