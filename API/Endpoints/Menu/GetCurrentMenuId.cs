using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
// using AzureFunctions.Models;

namespace Project.Function
{
    public static class GetCurrentMenuId
    {
        [FunctionName("GetCurrentMenuId")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("GetMenu function processed a request.");

            var data = RepositoryWrapper.GetRepo().GetCurrentMenuId();

            return new OkObjectResult(JsonConvert.SerializeObject(data));
        }
    }
}
