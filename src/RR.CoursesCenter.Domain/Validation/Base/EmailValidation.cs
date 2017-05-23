using System.Text.RegularExpressions;

namespace RR.CoursesCenter.Domain.Validation.Base
{
    public class EmailValidation
    {
        public static bool Validate(string email)
        {
            return Regex.IsMatch(
                email,
                @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
                RegexOptions.IgnoreCase
            );
        }
    }
}