using System;

namespace RR.CoursesCenter.Domain.Validation.Base
{
    public class OfAgeValidation
    {
        public static bool Validate(DateTime birthDate)
        {
            int age = DateTime.Now.Year - birthDate.Year;
            if (DateTime.Now.Month < birthDate.Month || (DateTime.Now.Month == birthDate.Month && DateTime.Now.Day < birthDate.Day))
                age--;

            return age >= 18;
        }
    }
}
