using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using AzureFunctions.Mappers;

namespace Project.Function
{
    public static class GetRecipe
    {
        [FunctionName("GetRecipe")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetRecipe/{id}")] HttpRequest req,
            string id, ILogger log)
        {
            log.LogInformation("GetRecipe function processed a request.");

            var data = RepositoryWrapper.GetRepo().GetRecipeById(id).ToResponse();

            return new OkObjectResult(data);
        }
    }
}
