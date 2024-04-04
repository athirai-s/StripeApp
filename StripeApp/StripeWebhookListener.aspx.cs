using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Stripe;

namespace StripeApp
{
    public partial class StripeWebhookListener : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StripeConfiguration.ApiKey = "sk_test_51OhdtJAGzritdW5euX6J8dDDG9i0sr04MbIoMPJKlenvnpQZEm4S6moGK4MlzycjAyQVOfUYJJV1izGdvMVfT7Gr004HkrtEAb";
            if (Request.HttpMethod == "POST")
            {
                try
                {
                    string requstBody;
                    using(var reader = new StreamReader(Request.InputStream))
                    {
                        requstBody = reader.ReadToEnd();
                    }

                    Console.WriteLine("Received Webhook Event: ");
                    Console.WriteLine(requstBody);

                    var stripeEvent = EventUtility.ParseEvent(requstBody);

                    //handling the event
                    switch (stripeEvent.Type)
                    {
                        case "payment_intent.succeded":
                            var payemntIntent = stripeEvent.Data.Object as PaymentIntent;
                            break;

                        case "payment_method.attached":
                            var paymentMethod = stripeEvent.Data.Object as PaymentMethod;
                            break;

                        case "customer.created":
                            var customer = stripeEvent.Data.Object as Customer;
                            Console.WriteLine($"Customer created: {customer.Id}");
                            break;

                        default:
                            Console.WriteLine("Unhandled event type: {0}", stripeEvent.Type);
                            break;
                    }

                    Response.StatusCode = 200;
                    Response.End();

                }
                catch (StripeException ex) 
                { 
                    Console.WriteLine("Stripe Exception: {0}", ex.Message);
                    Response.StatusCode = 400;
                }
            }
        }
    }
}