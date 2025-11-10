using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Holcim.Middleware
{
    public class EnforceFromQueryAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var request = context.HttpContext.Request;

            if (request.Method == HttpMethods.Get &&
                !request.Query.ContainsKey("lang"))
            {
                context.Result = new BadRequestObjectResult(new
                {
                    error = "Missing 'lang' query parameter"
                });
            }

            if (request.Query.TryGetValue("lang", out var langValues))
            {
                var lang = langValues.FirstOrDefault();
                context.HttpContext.Items["lang"] = lang;
            }

            base.OnActionExecuting(context);
        }

    }
}
