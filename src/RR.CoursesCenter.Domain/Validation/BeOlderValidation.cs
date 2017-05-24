using System;

namespace RR.CoursesCenter.Domain.Validation
{
    public class BeOlderValidation
    {
        public static bool Validate(DateTime birthDate)
        {
            int studentAge = DateTime.Now.Year - birthDate.Year;
            if (DateTime.Now.Month < birthDate.Month || (DateTime.Now.Month == birthDate.Month && DateTime.Now.Day < birthDate.Day))
            {
                studentAge--;
            }

            return studentAge >= 18;
        }
    }
}
