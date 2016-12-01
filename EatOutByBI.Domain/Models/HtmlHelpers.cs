using System;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace EatOutByBI.Domain.Models
{
    public static class HtmlHelpers
    {
        public static MvcHtmlString IsActive(this HtmlHelper htmlHelper, string action, string controller, string activeClass, string inActiveClass = "")
        {
            var routeData = htmlHelper.ViewContext.RouteData;

            var routeAction = routeData.Values["action"].ToString();
            var routeController = routeData.Values["controller"].ToString();

            var returnActive = (controller == routeController && action == routeAction);

            return new MvcHtmlString(returnActive ? activeClass : inActiveClass);
        }

        public static MvcHtmlString MenuLink(
    this HtmlHelper helper,
    string text, string action, string controller)
        {
            var routeData = helper.ViewContext.RouteData.Values;
            var currentController = routeData["controller"];
            var currentAction = routeData["action"];

            if (String.Equals(action, currentAction as string,
                      StringComparison.OrdinalIgnoreCase)
                &&
               String.Equals(controller, currentController as string,
                       StringComparison.OrdinalIgnoreCase))

            {
                return helper.ActionLink(
                    text, action, controller, null,
                    new { @class = "currentMenuItem" }
                    );
            }
            return helper.ActionLink(text, action, controller);
        }
    }


}