using RR.CoursesCenter.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace RR.CoursesCenter.Infrastructure.Data.EntitiesConfiguration
{
    public class OrderDetailConfiguration : EntityTypeConfiguration<OrderDetail>
    {
        public OrderDetailConfiguration()
        {
            HasKey(od => od.Id);

            HasRequired(od => od.Course)
                .WithMany(c => c.OrderDetails)
                .HasForeignKey(od => od.CourseId);

            HasRequired(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderId);
        }
    }
}
