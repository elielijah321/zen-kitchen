using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Project.Function;

namespace Company.Function
{
    public static class PostSetting
    {
        [FunctionName("PostSetting")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("PostSetting function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<Setting>(requestBody);

            if (data.Id == Guid.Empty)
            {
                RepositoryWrapper.GetRepo().AddNewSetting(data);
            }else{
                RepositoryWrapper.GetRepo().UpdateSetting(data);
            }

            return new OkObjectResult("");
        }
    }
}
