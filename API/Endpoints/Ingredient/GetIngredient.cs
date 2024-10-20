using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
// using AzureFunctions.Models;

namespace Project.Function
{
    public static class GetIngredient
    {
        [FunctionName("GetIngredient")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetIngredient/{id}")] HttpRequest req,
            string id, ILogger log)
        {
            log.LogInformation("GetIngredient function processed a request.");

            var data = RepositoryWrapper.GetRepo().GetIngredientById(id);

            return new OkObjectResult(data);
        }
    }
}
