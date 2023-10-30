using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SmartWatch_MVC.Models.Authentication
{
    public class Authorization : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetString("LoaiUser") != "1")
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {   
                        {"Controller","Access" },
                        {"Action","Login" }
                    }

                    );
            }
        }
    }
}