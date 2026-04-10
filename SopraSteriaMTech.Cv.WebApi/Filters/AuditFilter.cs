using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace SopraSteriaMTech.Cv.WebApi.Filters;

public class AuditFilter : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        AuditLog.LaatstGeraadpleegdDoor = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "Anonymous";
    }
}
