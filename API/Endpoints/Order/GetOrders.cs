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
using System.Collections.Generic;

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

            var allRecipres = RepositoryWrapper.GetRepo().GetAllRecipes();

            var data = GoogleSheetService.GetData();

            var orderList = data != null ? ParseOrders(data, allRecipres) : Array.Empty<Order>();

            return new OkObjectResult(orderList);
        }

        public static IEnumerable<Order> ParseOrders(IList<IList<object>> data, IEnumerable<Recipe> allRecipres)
        {
            var orderList = data.Select(d => {

                var recipeNames = d[1].ToString().Split(",").Select(od => od.Trim());
                var justDate = d[0].ToString().Split(" ")[0];

                var _order = new Order();
                _order.Id = Guid.Parse(d[4].ToString());
                _order.CreatedAt = DateTime.ParseExact(justDate, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                _order.OrderDetails = allRecipres.Where(r => recipeNames.Contains(r.Name));
                _order.Name = d[2].ToString();
                _order.PhoneNumber = d[3].ToString();

                return _order;
            });

            return orderList;
        }
    }
}
