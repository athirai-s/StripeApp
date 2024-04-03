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
        private string webhookSigningSecret = "whsec_c368b9f9a6a238065335c0b6e5c2ace8024dac48e844012faea9b045712c42d8";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.HttpMethod == "POST")
            {
                var json = new StreamReader(Request.InputStream).ReadToEnd();
                try 
                {
                    var stripeEvent = EventUtility.ParseEvent(json);

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