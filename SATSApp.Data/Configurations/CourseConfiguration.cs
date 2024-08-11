using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SATSApp.Data.Entities;

namespace SATSApp.Data.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses", "sats");

            builder.HasKey(x => x.CourseId);

            builder.Property(x => x.CourseId)
                  .HasColumnName("course_id");

            builder.Property(x => x.CourseName)
                   .HasColumnName("course_name")
                  .IsRequired()
                  .HasMaxLength(100);

            builder.Property(x => x.CourseDescription)
                   .HasColumnName("course_description")
                  .HasMaxLength(500);
        }
    }

}
