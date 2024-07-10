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
    public static class GetAllCustomers
    {
        [FunctionName("GetAllCustomers")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("GetAllCustomers function processed a request.");

            var repo = RepositoryWrapper.GetRepo();

            string searchTerm = req.Query["searchTerm"].ToString().ToLower();

            List<Customer> data = null;

            if(string.IsNullOrEmpty(searchTerm))
            {
                data = repo.GetAllCustomers().ToList();
            }else{
                data = repo.GetAllCustomers()
                        .Where(c => 
                            c.Name.ToLower().Contains(searchTerm) ||
                            c.Email.ToLower().Contains(searchTerm)
                        ).ToList();
            }

            return new OkObjectResult(data);
        }
    }
}
