using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Linq;
// using AzureFunctions.Models;

namespace Project.Function
{
    public static class GetAllDocuments
    {
        [FunctionName("GetAllDocuments")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("GetAllDocuments function processed a request.");

            string searchTerm = req.Query["searchTerm"].ToString().Trim().ToLower();

            var result = await ElasticsearchHelper.SearchDocuments(searchTerm);

            var resultIds = result.Select(r => r.Id);

            var filesFounds = await FileHelper.GetMultipleFiles(resultIds);

            return new OkObjectResult(filesFounds);
        }
    }
}
