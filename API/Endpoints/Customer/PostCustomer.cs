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
    public static class PostCustomer
    {
        [FunctionName("PostCustomer")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("PostCustomer function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<UpdateCustomerRequestModel>(requestBody);
            var repo = RepositoryWrapper.GetRepo();

            if (string.IsNullOrEmpty(data.Id))
            {
                data.Id = Guid.NewGuid().ToString();
                repo.AddCustomer(data);
            }else
            {
                repo.UpdateCustomer(data);
            }

            return new OkObjectResult(data);
        }
    }
}
