using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
// using AzureFunctions.Models;

namespace Project.Function
{
    public static class DeleteIngredient
    {
        [FunctionName("DeleteIngredient")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "DeleteIngredient/{id}")] HttpRequest req,
            string id, ILogger log)
        {
            log.LogInformation("DeleteIngredient function processed a request.");

            RepositoryWrapper.GetRepo().DeleteIngredientById(id);

            return new OkObjectResult("");
        }
    }
}
