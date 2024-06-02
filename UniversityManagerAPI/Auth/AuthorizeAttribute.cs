using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace UniversityManagerAPI.Auth
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            var allowAnonymous = filterContext.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous) 
            {
                return;
            }

            var user = filterContext.HttpContext.Items["User"];
            if (user == null)
            {
                filterContext.Result = new JsonResult(new { message = "Unauthorized" }) 
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };

            }
        }
    }
}
