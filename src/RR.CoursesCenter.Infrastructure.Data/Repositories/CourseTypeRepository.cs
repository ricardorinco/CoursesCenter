using RR.CoursesCenter.Domain.Interfaces.Repository;
using RR.CoursesCenter.Domain.Models;
using RR.CoursesCenter.Infrastructure.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RR.CoursesCenter.Infrastructure.Data.Repositories
{
    public class CourseTypeRepository : Repository<CourseType>, ICourseTypeRepository
    {
        private StringBuilder query = new StringBuilder();

        public CourseTypeRepository(DataContext context) : base(context)
        { }

        public IEnumerable<CourseType> GetByIdentification(string identification)
        {
            return Search(ct => ct.Identification.Contains(identification)).ToList();
        }

        public IEnumerable<CourseType> GetActive()
        {
            query.Length = 0;
            query.AppendLine("SELECT");
            query.AppendLine("  *");
            query.AppendLine("FROM");
            query.AppendLine("  CourseTypes");
            query.AppendLine("WHERE");
            query.AppendLine("  Active = 1");

            return Context.Database.SqlQuery<CourseType>(query.ToString()).ToList();
        }

        public IEnumerable<CourseType> GetInactive()
        {
            query.Length = 0;
            query.AppendLine("SELECT");
            query.AppendLine("  *");
            query.AppendLine("FROM");
            query.AppendLine("  CourseTypes");
            query.AppendLine("WHERE");
            query.AppendLine("  Active = 0");

            return Context.Database.SqlQuery<CourseType>(query.ToString()).ToList();
        }
    }
}
