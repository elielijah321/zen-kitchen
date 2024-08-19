using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
// using AzureFunctions.Models;

namespace Project.Function
{
    public static class GetCaseDocuments
    {
        [FunctionName("GetCaseDocuments")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetCaseDocuments/{caseId}")] HttpRequest req,
            string caseId, ILogger log)
        {
            log.LogInformation("GetCaseDocuments function processed a request.");

            string searchTerm = req.Query["searchTerm"].ToString().ToLower();

            var result = await FileHelper.GetFiles(caseId);
            return new OkObjectResult(result);

            // if(string.IsNullOrEmpty(caseId)){
                
            //     var result = await ElasticsearchHelper.SearchDocuments(searchTerm);
            //     return new OkObjectResult(result);

            // }else{
            //     var result = await ElasticsearchHelper.SearchDocuments(searchTerm);
            //     return new OkObjectResult(result);
            // }

            
        }
    }
}
