using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Company.Function;
using AremuCoreServices;
using AremuCoreServices.Models.CredentialRecords;

namespace Project.Function
{
    public static class DeleteOrder
    {
        [FunctionName("DeleteOrder")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "DeleteOrder/{orderId}")] HttpRequest req,
            string orderId, ILogger log)
        {
            log.LogInformation("DeleteOrder function processed a request.");

            var creds = GetGoogleCredentials.Get();
            var sheetInfo = new GoogleSheetInfoRecord(GetGoogleCredentials.SpreadsheetId, "Orders!A2:Z");

            GoogleSheetService.DeleteRowById(creds, sheetInfo, orderId);

            return new OkObjectResult("setting");
        }
    }
}
