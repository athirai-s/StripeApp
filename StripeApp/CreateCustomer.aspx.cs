using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Stripe;

namespace StripeApp
{
    public partial class CreateCustomer : System.Web.UI.Page
    {
        protected void CreateCustomer_Click(object sender, EventArgs e)
        {
            StripeConfiguration.ApiKey = "sk_test_51OhdtJAGzritdW5euX6J8dDDG9i0sr04MbIoMPJKlenvnpQZEm4S6moGK4MlzycjAyQVOfUYJJV1izGdvMVfT7Gr004HkrtEAb";

            //creating new customer
            string name = Name.Text;
            string email = Email.Text;

            var options = new CustomerCreateOptions
            {
                Email = email,
                Name = name,
            };

            var service = new CustomerService();
            var customer = service.Create(options);

            SuccessLabel.Text = "Customer Created Successfully!";
            Response.Write($"Customer created with ID: {customer.Id}");

            //Response.Redirect("~/StripeWebhookListener.aspx");
        }
    }
}