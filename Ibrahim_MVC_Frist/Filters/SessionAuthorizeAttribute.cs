using Microsoft.AspNetCore.Mvc.Filters;

namespace Ibrahim_MVC_Frist.Filters
{
    public class SessionAuthorizeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var username = context.HttpContext.Session.GetString("Username");
            if (string.IsNullOrEmpty(username))
            {
                context.HttpContext.Response.Redirect("/Acoount/Login");
            }
            base.OnActionExecuting(context);
        }
    }
}
