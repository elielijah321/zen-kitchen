using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Linq;
using AzureFunctions.Mappers;
// using AzureFunctions.Models;

namespace Project.Function
{
    public static class GetAllRecipes
    {
        [FunctionName("GetAllRecipes")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("GetAllRecipes function processed a request.");

            var repo = RepositoryWrapper.GetRepo();

            var list = repo.GetAllRecipes().Select(r => r.ToResponse());

            return new OkObjectResult(list);
        }
    }
}
