using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using Stripe;

namespace StripeApp
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            StripeConfiguration.ApiKey = "sk_test_51OhdtJAGzritdW5euX6J8dDDG9i0sr04MbIoMPJKlenvnpQZEm4S6moGK4MlzycjAyQVOfUYJJV1izGdvMVfT7Gr004HkrtEAb";
        }
    }
}