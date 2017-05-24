using RR.CoursesCenter.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace RR.CoursesCenter.Infrastructure.Data.EntitiesConfiguration
{
    public class CourseConfiguration : EntityTypeConfiguration<Course>
    {
        public CourseConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.Identification)
                .IsRequired()
                .HasMaxLength(180);

            Property(c => c.Price)
                .IsRequired();

            HasRequired(c => c.Instructor)
                .WithMany(i => i.Courses)
                .HasForeignKey(c => c.InstructorId);

            Ignore(c => c.ValidationResult);
        }
    }
}
