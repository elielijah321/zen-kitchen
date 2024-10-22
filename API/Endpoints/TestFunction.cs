using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Company.Function;
using System.Collections.Generic;

namespace Project.Function
{
    public static class TestFunction
    {
        [FunctionName("TestFunction")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("TestFunction function processed a request.");

            // MenuHelper.UpdateMenuSpreadSheet();


            GoogleSheetService.DeleteRowById("8a19d481-2f59-48ff-a96f-bcd3006d352c");


            return new OkObjectResult("");
        }
    }
}
