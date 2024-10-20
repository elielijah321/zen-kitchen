using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using Company.Function;
using System.Linq;
using System.Globalization;

namespace Project.Function
{
    public static class GetOrders
    {
        [FunctionName("GetOrders")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("GetOrders function processed a request.");

            var data = GoogleSheetService.GetData();

            var orderList = data.Select(d => {
                var _order = new Order();
                _order.Id = Guid.NewGuid();
                _order.CreatedAt = DateTime.ParseExact(d[0].ToString(), "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                _order.OrderDetails = d[1].ToString().Split(",").Select(od => od.Trim());
                _order.Name = d[2].ToString();
                _order.PhoneNumber = d[3].ToString();;

                return _order;
            }).ToList();

            return new OkObjectResult(orderList);
        }
    }
}
