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
    public static class PostCase
    {
        [FunctionName("PostCase")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("PostCase function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<UpdateCaseRequestModel>(requestBody);
            var repo = RepositoryWrapper.GetRepo();

            var id = string.Empty;

            if (data.Id == Guid.Empty)
            {
                id = repo.AddCase(data);
            }else
            {
                id = repo.UpdateCase(data);
            }

            if (FileHelper.ShouldUploadFile(data.File))
            {
                FileHelper.UploadImage(id, data.File);
            }

            return new OkObjectResult(data);
        }
    }
}
