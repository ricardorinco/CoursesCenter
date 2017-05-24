using Dapper;
using RR.CoursesCenter.Domain.Interfaces.Repository;
using RR.CoursesCenter.Domain.Models;
using RR.CoursesCenter.Infrastructure.Data.Context;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace RR.CoursesCenter.Infrastructure.Data.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private StringBuilder query = new StringBuilder();

        public StudentRepository(DataContext context) : base (context)
        { }

        public override Student Update(Student student)
        {
            var studentUpdate = Context.Entry(student);
            DbSet.Attach(student);
            studentUpdate.State = EntityState.Modified;
            studentUpdate.Property("AcademicRegistration").IsModified = false;

            return student;
        }

        public IEnumerable<Student> GetByIdentification(string identification)
        {
            return Search(s => s.Identification.Contains(identification)).ToList();
        }

        public Student GetByAcademicRegistration(int academicRegistration)
        {
            return Search(s => s.AcademicRegistration == academicRegistration).SingleOrDefault();
        }

        public Student GetByEmail(string email)
        {
            return Search(s => s.Email == email).SingleOrDefault();
        }

        public IEnumerable<Student> GetActive()
        {
            query.Length = 0;
            query.AppendLine("SELECT"); 
            query.AppendLine("  *");
            query.AppendLine("FROM");
            query.AppendLine("  Students");
            query.AppendLine("WHERE");
            query.AppendLine("  Active = 1");

            return Context.Database.Connection.Query<Student>(query.ToString()).ToList();
        }

        public IEnumerable<Student> GetInactive()
        {
            query.Length = 0;
            query.AppendLine("SELECT"); 
            query.AppendLine("  *");
            query.AppendLine("FROM");
            query.AppendLine("  Students");
            query.AppendLine("WHERE");
            query.AppendLine("  Active = 0");

            return Context.Database.Connection.Query<Student>(query.ToString()).ToList();
        }

        public int GetNextAcademicRegistration()
        {
            query.Length = 0;
            query.AppendLine("SELECT");
            query.AppendLine("  TOP 1 AcademicRegistration");
            query.AppendLine("FROM");
            query.AppendLine("  Students");
            query.AppendLine("ORDER BY");
            query.AppendLine("  AcademicRegistration");
            query.AppendLine("DESC");

            return Context.Database.SqlQuery<int>(query.ToString()).SingleOrDefault() + 1;
        }
    }
}
