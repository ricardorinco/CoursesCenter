using RR.CoursesCenter.Domain.Interfaces.Repository;
using RR.CoursesCenter.Domain.Models;
using RR.CoursesCenter.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RR.CoursesCenter.Infrastructure.Data.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        private StringBuilder query = new StringBuilder();

        public CourseRepository(DataContext context) : base (context)
        { }

        public IEnumerable<Course> GetByIdentification(string identification)
        {
            return Search(c => c.Identification.Contains(identification)).ToList();
        }

        public IEnumerable<Course> GetByLimitMaxPrice(decimal price)
        {
            return Search(c => c.Price <= price).ToList();
        }

        public IEnumerable<Course> GetByCourseType(Guid courseTypeId)
        {
            return Search(c => c.CourseTypeId == courseTypeId).ToList(); ;
        }

        public IEnumerable<Course> GetByInstructor(Guid instructorId)
        {
            return Search(c => c.InstructorId == instructorId).ToList();
        }

        public IEnumerable<Course> GetActive()
        {
            //query.AppendLine("SELECT c.Id,");
            //query.AppendLine("       c.Identification,");
            //query.AppendLine("       c.Price,");
            //query.AppendLine("       c.Active,");
            //query.AppendLine("       c.CourseTypeId,");
            //query.AppendLine("       c.InstructorId,");
            //query.AppendLine("       ct.Identification as CourseType,");
            //query.AppendLine("       i.Identification as Instructor");
            //query.AppendLine("  FROM Courses c");
            //query.AppendLine(" INNER JOIN CourseTypes ct");
            //query.AppendLine("    ON ct.Id = c.CourseTypeId");
            //query.AppendLine(" INNER JOIN Instructors i");
            //query.AppendLine("    ON i.Id = c.InstructorId");
            //query.AppendLine(" WHERE c.Active = 1");

            //return Context.Database.SqlQuery<Course>(query.ToString()).ToList();

            return Search(c => c.Active).ToList();
        }

        public IEnumerable<Course> GetInactive()
        {
            //query.AppendLine("SELECT c.Id,");
            //query.AppendLine("       c.Identification,");
            //query.AppendLine("       c.Price,");
            //query.AppendLine("       c.Active,");
            //query.AppendLine("       c.CourseTypeId,");
            //query.AppendLine("       c.InstructorId,");
            //query.AppendLine("       ct.Identification as CourseType,");
            //query.AppendLine("       i.Identification as Instructor");
            //query.AppendLine("  FROM Courses c");
            //query.AppendLine(" INNER JOIN CourseTypes ct");
            //query.AppendLine("    ON ct.Id = c.CourseTypeId");
            //query.AppendLine(" INNER JOIN Instructors i");
            //query.AppendLine("    ON i.Id = c.InstructorId");
            //query.AppendLine(" WHERE c.Active = 0");

            //return Context.Database.SqlQuery<Course>(query.ToString()).ToList();

            return Search(c => !c.Active).ToList();
        }
    }
}
