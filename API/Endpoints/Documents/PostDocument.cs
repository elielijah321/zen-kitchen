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
    public static class PostDocument
    {
        [FunctionName("PostDocument")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("PostDocument function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            DocumentObject data = JsonConvert.DeserializeObject<DocumentObject>(requestBody);
            data.Id = $"{data.CaseId}-{GuidGenerator.CreateGuid()}";

            if (FileHelper.ShouldUploadFile(data.File))
            {
                FileHelper.UploadFile(data);
            }

            return new OkObjectResult(data);
        }
    }
}
