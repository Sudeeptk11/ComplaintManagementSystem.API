using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;

namespace ComplaintManagementSystem.API.Filters
{
    public class AuditLogFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context) 
        { 
            Log.Information("Executing {Action}",
                context.ActionDescriptor.DisplayName);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Log.Information("Executed {Action}",
                context.ActionDescriptor.DisplayName);
        }
    }
}
