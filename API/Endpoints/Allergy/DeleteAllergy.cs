using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
// using AzureFunctions.Models;

namespace Project.Function
{
    public static class DeleteAllergy
    {
        [FunctionName("DeleteAllergy")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "DeleteAllergy/{id}")] HttpRequest req,
            string id, ILogger log)
        {
            log.LogInformation("DeleteAllergy function processed a request.");

            RepositoryWrapper.GetRepo().DeleteAllergyById(id);

            return new OkObjectResult("");
        }
    }
}
