using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
// using AzureFunctions.Models;

namespace Project.Function
{
    public static class GetAllAllergies
    {
        [FunctionName("GetAllAllergies")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("GetAllAllergies function processed a request.");

            var repo = RepositoryWrapper.GetRepo();

            var list = repo.GetAllAllergies();

            return new OkObjectResult(list);
        }
    }
}
