using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace RaceDayMVC.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class AuthorizeRoleAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string[] _roles;

        public AuthorizeRoleAttribute(params string[] roles)
        {
            _roles = roles;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            if (user?.Identity == null || !user.Identity.IsAuthenticated)
            {
                context.Result = new RedirectToActionResult("Login", "Account", null);
                return;
            }

            if (_roles.Length > 0)
            {
                bool hasRole = false;
                foreach (var role in _roles)
                {
                    if (user.IsInRole(role) || user.HasClaim(ClaimTypes.Role, role))
                    {
                        hasRole = true;
                        break;
                    }
                }

                if (!hasRole)
                {
                    context.Result = new RedirectToActionResult("AccessDenied", "Account", null);
                }
            }
        }
    }
}