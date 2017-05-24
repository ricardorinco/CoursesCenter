namespace RR.CoursesCenter.Domain.Validation
{
    public class IdentificationValidation
    {
        public static bool Validate(string identification)
        {
            return identification.Length > 2;
        }
    }
}