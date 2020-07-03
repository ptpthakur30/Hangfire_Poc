using System.Diagnostics;
using System.Web.Mvc;
using System.Web.Routing;

namespace Hangfire_Poc.Attributes
{

    public class LogAttribute : ActionFilterAttribute
    {
        public LogAttribute()
        {

        }

        public override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
            Log("OnActionExecuted", actionExecutedContext.RouteData);
        }
        public override void OnActionExecuting(ActionExecutingContext actionExecutingContext)
        {
            Log("OnActionExecuting", actionExecutingContext.RouteData);

        }

        private void Log(string methodName, RouteData routeData)
        {
            var controllerName = routeData.Values["Controller"];
            var actionName = routeData.Values["Action"];
            Trace.WriteLine($"Controller : ${controllerName}, Action : ${actionName}, MethodName : ${methodName}");
        }
    }
}