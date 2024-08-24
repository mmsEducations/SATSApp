using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SATSApp.Data.Entities;

namespace SATSApp.Data.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses", "satsapp");

            builder.HasKey(x => x.CourseId);

            builder.Property(x => x.CourseId)
                  .HasColumnName("course_id")
                      .ValueGeneratedOnAdd(); // Set auto-increment

            builder.Property(x => x.CourseName)
                   .HasColumnName("course_name")
                  .IsRequired()
                  .HasMaxLength(100);

            builder.Property(x => x.CourseDescription)
                   .HasColumnName("course_description")
                  .HasMaxLength(500);


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
