using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Company.Function;

namespace Project.Function
{
    public static class DeleteOrder
    {
        [FunctionName("DeleteOrder")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "DeleteOrder/{orderId}")] HttpRequest req,
            string orderId, ILogger log)
        {
            log.LogInformation("DeleteOrder function processed a request.");

            GoogleSheetService.DeleteRowById(orderId);

            return new OkObjectResult("setting");
        }
    }
}
