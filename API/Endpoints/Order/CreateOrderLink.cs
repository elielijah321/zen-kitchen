using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Company.Function;
using AremuCoreServices;
using AremuCoreServices.Models.CredentialRecords;
using AremuCoreServices.Helpers;
using AremuCoreServices.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using AzureFunctions.Mappers;
using AremuCoreServices.Models.Enums;

namespace Project.Function
{
    public static class CreateOrderLink
    {
        [FunctionName("CreateOrderLink")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "CreateOrderLink/{orderId}")] HttpRequest req,
            string orderId, ILogger log)
        {
            log.LogInformation("CreateOrderLink function processed a request.");

            var stripeCreds = TestHelper.GetStripeCredentialsRecord();
            var googleCreds = GetGoogleCredentials.Get();

            var sheetInfo = new GoogleSheetInfoRecord(GetGoogleCredentials.SpreadsheetId, "Orders!A2:Z");
            var allRecipres = RepositoryWrapper.GetRepo().GetAllRecipes();

            var data = GoogleSheetService.GetData(googleCreds, sheetInfo);

            var orderList = data != null ? ParseOrders(data, allRecipres) : Array.Empty<Order>();

            var orderItems = orderList.FirstOrDefault(o => o.Id.ToString() == orderId).OrderDetails.Select(od => {
                return new StripeLineItemRecord(od.Name, od.Price, 1);
            });

            var paymentSessionLinkUrl = StripeService.CreateCheckoutSession(stripeCreds, orderItems, new StripePaymentType[] {StripePaymentType.CARD});
            
            string shortenedUrl = await URLShortnerService.Shorten(paymentSessionLinkUrl);

            await TelegramService.SendMessage(shortenedUrl);

            return new OkObjectResult(paymentSessionLinkUrl);
        }

        public static IEnumerable<Order> ParseOrders(IList<IList<object>> data, IEnumerable<Recipe> allRecipres)
        {
            var orderList = data.Select(d => {

                var recipeNames = d[1].ToString().Split(",").Select(od => od.Trim());
                var justDate = d[0].ToString().Split(" ")[0];

                var _order = new Order();
                _order.Id = Guid.Parse(d[4].ToString());
                _order.CreatedAt = DateTime.Now; // DateTime.ParseExact(justDate, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                _order.OrderDetails = allRecipres.Where(r => recipeNames.Contains(r.Name)).Select(r => r.ToResponse());
                _order.Name = d[2].ToString();
                _order.PhoneNumber = d[3].ToString();

                return _order;
            });

            return orderList;
        }
    }
}
