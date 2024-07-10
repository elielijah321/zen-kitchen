using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Stripe;
// using AzureFunctions.Models;

namespace Project.Function
{
    public static class TestStripePaymentWebhook
    {
        [FunctionName("TestStripePaymentWebhook")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("TestStripePaymentWebhook function processed a request.");
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            try
            {
                var stripeEvent = EventUtility.ConstructEvent(
                    requestBody,
                    req.Headers["Stripe-Signature"],
                    StripeService.TestWebhookSigningKey
                );

                var invoice = stripeEvent.Data.Object as Invoice;
                var email = invoice.CustomerEmail;
                var status = invoice.Status; 


                var repo = RepositoryWrapper.GetRepo();

                var customer = repo.GetCustomerByEmail(email);
                customer.PaymentStatus = status;

                if (status == "paid")
                {
                    customer.LastPaymentDate = DateTime.Now;
                }

                repo.UpdateCustomer(customer);
                
                // await TelegramService.SendMessage($"{email} - {status}");


                // var stripeEventObject = stripeEvent.Data.ToJson();

                // log.LogInformation(stripeEventObject);


                // var data = JsonConvert.DeserializeObject<StripeInvoiceResponse>(stripeEventObject);


                // var tr = stripeEventObject[""];
                // await TelegramService.SendMessage(data.Data.Object.CustomerEmail);

                // switch (stripeEvent.Type){
                    
                //     case Events.InvoiceCreated:
                //     var invoice = stripeEvent.Data.Object as Invoice;

                //     var email = invoice.CustomerEmail;
                //     break;

                //     case Events.InvoicePaymentSucceeded:
                //     break;

                //     case Events.InvoicePaid:
                //     break;

                //     case Events.InvoiceMarkedUncollectible:
                //     break;

                //     case Events.InvoiceUpcoming:
                //     break;

                //     default:
                //     break;
                // }


// invoice.created
// invoice.deleted
// invoice.finalization_failed
// invoice.finalized
// invoice.marked_uncollectible
// invoice.overdue
// invoice.paid
// invoice.payment_action_required
// invoice.payment_failed
// invoice.payment_succeeded
// invoice.sent
// invoice.upcoming
// invoice.updated
// invoice.voided
// invoice.will_be_due







                // if (stripeEvent.Type == Events.InvoicePaymentSucceeded)
                // {
                //     var invoice = stripeEvent.Data.Object as Invoice;

                //     invoice.Status
                //     // Handle the successful invoice payment
                // }else{
                    
                //     await TelegramService.SendMessage(stripeEvent.Type);

                // }

                return new OkObjectResult("");
            }
            catch (StripeException e)
            {
                return new BadRequestObjectResult("");
            }
        }
    }
}
