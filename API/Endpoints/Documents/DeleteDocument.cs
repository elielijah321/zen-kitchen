using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
// using AzureFunctions.Models;

namespace Project.Function
{
    public static class DeleteDocument
    {
        [FunctionName("DeleteDocument")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("DeleteDocument function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            string data = JsonConvert.DeserializeObject<string>(requestBody);

            await FileHelper.DeleteImage(data);
            
            return new OkObjectResult(data);
        }
    }
}
