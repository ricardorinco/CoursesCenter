using RR.CoursesCenter.Domain.Interfaces.Repository;
using RR.CoursesCenter.Domain.Models;
using RR.CoursesCenter.Infrastructure.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RR.CoursesCenter.Infrastructure.Data.Repositories
{
    public class InstructorRepository : Repository<Instructor>, IInstructorRepository
    {
        private StringBuilder query = new StringBuilder();

        public InstructorRepository(DataContext context) : base(context)
        { }

        public IEnumerable<Instructor> GetByIdentification(string identification)
        {
            return Search(i => i.Identification.Contains(identification)).ToList();
        }

        public Instructor GetByLicenseNumber(int licenseNumber)
        {
            return Search(i => i.LicenseNumber == licenseNumber).SingleOrDefault();
        }

        public Instructor GetByEmail(string email)
        {
            return Search(i => i.Email == email).SingleOrDefault();
        }

        public IEnumerable<Instructor> GetActive()
        {
            query.Length = 0;
            query.AppendLine("SELECT");
            query.AppendLine("  *");
            query.AppendLine("FROM");
            query.AppendLine("  Instructors");
            query.AppendLine("WHERE");
            query.AppendLine("  Active = 1");

            return Context.Database.SqlQuery<Instructor>(query.ToString()).ToList();
        }

        public IEnumerable<Instructor> GetInactive()
        {
            query.Length = 0;
            query.AppendLine("SELECT");
            query.AppendLine("  *");
            query.AppendLine("FROM");
            query.AppendLine("  Instructors");
            query.AppendLine("WHERE");
            query.AppendLine("  Active = 0");

            return Context.Database.SqlQuery<Instructor>(query.ToString()).ToList();
        }
    }
}
