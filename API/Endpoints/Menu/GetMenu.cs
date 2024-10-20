using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
// using AzureFunctions.Models;

namespace Project.Function
{
    public static class GetMenu
    {
        [FunctionName("GetMenu")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetMenu/{id}")] HttpRequest req,
            string id, ILogger log)
        {
            log.LogInformation("GetMenu function processed a request.");

            var data = RepositoryWrapper.GetRepo().GetMenuById(id);

            return new OkObjectResult(data);
        }
    }
}
