namespace RR.CoursesCenter.Domain.Validation.Base
{
    public class PriceValidation
    {
        public static bool Validate(decimal price)
        {
            return price > -0.01m;
        }
    }
}
