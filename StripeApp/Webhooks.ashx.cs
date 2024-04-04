using Stripe;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace StripeApp
{
    /// <summary>
    /// //localhost:8000/Webhooks.ashx
    /// Summary description for Webhooks
    /// </summary>
    public class Webhooks : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            Console.WriteLine("process request invloked");
            var endpointSecret = "whsec_c368b9f9a6a238065335c0b6e5c2ace8024dac48e844012faea9b045712c42d8";
            var json = new StreamReader(context.Request.InputStream).ReadToEnd();
            var signature = context.Request.Headers["Stripe-Signature"];

            try
            {
                Console.WriteLine($"Stripe Signature: {signature}");
                var stripeEvent = EventUtility.ConstructEvent( json, context.Request.Headers["Stripe-Signature"], endpointSecret );
                switch (stripeEvent.Type)
                {
                    case Events.CustomerCreated:
                        var customer = stripeEvent.Data.Object as Customer;
                        Console.WriteLine($"Customer created : {customer.Id} for {customer.Name} and {customer.Email}");
                        break;
                    default:
                        Console.WriteLine($"Got event {stripeEvent.Type}");
                        break;
                }
            }
            catch(StripeException ex)
            {
                Console.WriteLine($"exe: {ex.Message}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}