using RR.CoursesCenter.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace RR.CoursesCenter.Infrastructure.Data.EntitiesConfiguration
{
    public class StudentConfiguration : EntityTypeConfiguration<Student>
    {
        public StudentConfiguration()
        {
            HasKey(s => s.Id);

            Property(s => s.Identification)
                .IsRequired()
                .HasMaxLength(150);

            Property(s => s.BirthDate)
                .IsRequired();

            Property(s => s.Email)
                .IsRequired()
                .HasMaxLength(180);

            Property(s => s.AcademicRegistration)
                .IsRequired();

            Ignore(s => s.ValidationResult);
        }
    }
}
