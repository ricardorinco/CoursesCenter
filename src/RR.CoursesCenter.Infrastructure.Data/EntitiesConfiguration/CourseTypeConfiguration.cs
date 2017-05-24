using RR.CoursesCenter.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace RR.CoursesCenter.Infrastructure.Data.EntitiesConfiguration
{
    public class CourseTypeConfiguration : EntityTypeConfiguration<CourseType>
    {
        public CourseTypeConfiguration()
        {
            HasKey(ct => ct.Id);

            Property(ct => ct.Identification)
                .IsRequired();

            Ignore(s => s.ValidationResult);
        }
    }
}
