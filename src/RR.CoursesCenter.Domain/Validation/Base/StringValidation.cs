namespace RR.CoursesCenter.Domain.Validation.Base
{
    public class StringValidation
    {
        public static bool Validate(string identification)
        {
            return identification.Length > 2;
        }
    }
}
