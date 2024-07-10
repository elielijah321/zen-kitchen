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
    public static class DeleteDefendant
    {
        [FunctionName("DeleteDefendant")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "DeleteDefendant/{id}")] HttpRequest req,
            string id, ILogger log)
        {
            log.LogInformation("DeleteDefendant function processed a request.");

            // RepositoryWrapper.GetRepo().DeleteDefendant(id);

            return new OkObjectResult("");
        }
    }
}
