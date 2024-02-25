
using System.Text.RegularExpressions;

namespace RoutingImplementation.Models.Constraints
{
    public class AlphabetWithNumericConstraint : IRouteConstraint
    {
        bool IRouteConstraint.Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if(httpContext == null) 
                throw new ArgumentNullException("nameOf(httepContext)");
            if(route==null) 
                throw new ArgumentNullException(nameof(route));
            if(values==null) 
                throw new ArgumentNullException(nameof(values));

            if(values.TryGetValue(routeKey, out object? routeValue))
            {
                var userInput=Convert.ToString(routeValue);
                string pattern = @"^[a-zA-Z0-9]+$";

                if(Regex.IsMatch(userInput??String.Empty, pattern)) 
                {
                    return true;
                }
                else
                    return false;
            }
            return false;

        }
    }
}
