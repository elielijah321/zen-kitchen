using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Project.Function
{
    public static class GetSetting
    {
        [FunctionName("GetSetting")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetSetting/{settingId}")] HttpRequest req,
            string settingId, ILogger log)
        {
            log.LogInformation("GetSetting function processed a request.");

            var setting = RepositoryWrapper.GetRepo().GetSetting(settingId);

            return new OkObjectResult(setting);
        }
    }
}
