using RR.CoursesCenter.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace RR.CoursesCenter.Infrastructure.Data.EntitiesConfiguration
{
    class OrderConfiguration : EntityTypeConfiguration<Order>
    {
        public OrderConfiguration()
        {
            HasKey(o => o.Id);

            Property(o => o.OrderDateTime)
                .IsRequired();

            HasRequired(o => o.Student)
                .WithMany(s => s.Orders)
                .HasForeignKey(o => o.StudentId);
        }
    }
}
