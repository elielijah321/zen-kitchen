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
    public static class DeleteRecipe
    {
        [FunctionName("DeleteRecipe")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "DeleteRecipe/{id}")] HttpRequest req,
            string id, ILogger log)
        {
            log.LogInformation("DeleteRecipe function processed a request.");

            RepositoryWrapper.GetRepo().DeleteRecipeById(id);

            return new OkObjectResult("");
        }
    }
}
