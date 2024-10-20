using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Project.Function
{
    public static class GetOrder
    {
        [FunctionName("GetOrder")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetOrder/{orderId}")] HttpRequest req,
            string orderId, ILogger log)
        {
            log.LogInformation("GetOrder function processed a request.");

            // var setting = RepositoryWrapper.GetRepo().GetSetting(settingId);

            return new OkObjectResult("setting");
        }
    }
}
