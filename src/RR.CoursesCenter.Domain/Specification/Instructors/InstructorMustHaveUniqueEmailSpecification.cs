using DomainValidation.Interfaces.Specification;
using RR.CoursesCenter.Domain.Interfaces.Repository;
using RR.CoursesCenter.Domain.Models;

namespace RR.CoursesCenter.Domain.Specification.Instructors
{
    public class InstructorMustHaveUniqueEmailSpecification : ISpecification<Instructor>
    {
        private readonly IInstructorRepository instructorRepository;

        public InstructorMustHaveUniqueEmailSpecification(IInstructorRepository instructorRepository)
        {
            this.instructorRepository = instructorRepository;
        }

        public bool IsSatisfiedBy(Instructor instructor)
        {
            return instructorRepository.GetByEmail(instructor.Email) == null;
        }
    }
}
