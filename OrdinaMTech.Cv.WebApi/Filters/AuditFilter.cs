using Microsoft.AspNetCore.Mvc.Filters;
using OrdinaMTech.Cv.WebApi.Services;
using System.Security.Claims;

namespace OrdinaMTech.Cv.WebApi.Filters
{
    public class AuditFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            AuditLog.LaatstGeraadpleegdDoor = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "Anonymous";
        }
    }
}
