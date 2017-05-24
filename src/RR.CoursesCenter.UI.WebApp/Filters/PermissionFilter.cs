using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace RR.CoursesCenter.UI.WebApp.Filters
{
    public static class PermissionFilter
    {
        public static MvcHtmlString IfClaimHelper(this MvcHtmlString value, string claimName, string claimValue)
        {
            return ValidityPermission(claimName, claimValue) ? value : MvcHtmlString.Empty;
        }

        public static bool IfClaim(this WebViewPage page, string claimName, string claimValue)
        {
            return ValidityPermission(claimName, claimValue);
        }

        public static bool ValidityPermission(string claimName, string claimValue)
        {
            var identity = (ClaimsIdentity)HttpContext.Current.User.Identity;
            var claim = identity.Claims.FirstOrDefault(c => c.Type == claimName);

            return claim != null && claim.Value.Contains(claimValue);
        }
    }
}