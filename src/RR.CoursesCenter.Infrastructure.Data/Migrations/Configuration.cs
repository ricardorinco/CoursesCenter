using RR.CoursesCenter.Infrastructure.Data.Context;
using System.Data.Entity.Migrations;

namespace RR.CoursesCenter.Infrastructure.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DataContext context)
        { }
    }
}
