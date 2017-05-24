using RR.CoursesCenter.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace RR.CoursesCenter.Infrastructure.Data.EntitiesConfiguration
{
    public class InstructorConfiguration : EntityTypeConfiguration<Instructor>
    {
        public InstructorConfiguration()
        {
            HasKey(i => i.Id);

            Property(i => i.Identification)
                .IsRequired()
                .HasMaxLength(150);

            Property(i => i.BirthDate)
                .IsRequired();

            Property(i => i.Email)
                .IsRequired()
                .HasMaxLength(120);

            Property(i => i.LicenseNumber)
                .IsRequired();

            Ignore(i => i.ValidationResult);
        }
    }
}
