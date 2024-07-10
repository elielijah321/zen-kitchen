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
    public static class DeleteCase
    {
        [FunctionName("DeleteCase")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "DeleteCase/{id}")] HttpRequest req,
            string id, ILogger log)
        {
            log.LogInformation("DeleteCase function processed a request.");

            // RepositoryWrapper.GetRepo().DeleteDefendant(id);

            return new OkObjectResult("");
        }
    }
}
