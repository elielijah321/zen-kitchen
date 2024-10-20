using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
// using AzureFunctions.Models;

namespace Project.Function
{
    public static class DeleteMenu
    {
        [FunctionName("DeleteMenu")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "DeleteMenu/{id}")] HttpRequest req,
            string id, ILogger log)
        {
            log.LogInformation("DeleteMenu function processed a request.");

            RepositoryWrapper.GetRepo().DeleteMenuById(id);

            return new OkObjectResult("");
        }
    }
}
