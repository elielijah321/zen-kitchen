using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Company.Function;
using System.Collections.Generic;
using Google.Apis.Calendar.v3.Data;
using System.Linq;
// using AzureFunctions.Models;

namespace Project.Function
{
    public static class CreateCalendarEvent
    {
        [FunctionName("CreateCalendarEvent")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("CreateCalendarEvent function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject(requestBody);

            List<Event> events = GoogleCalendarService.GetListOfEvents();

            var firstEvent = events.FirstOrDefault();

            // var x = firstEvent.Start.DateTime.Value.Date;
            // var y = DateTime.Now.Date;

            var todays = events.Where(e => e.Start.DateTime.Value.Date == DateTime.Now.Date).ToList();

            ;


            // var repo = RepositoryWrapper.GetRepo();

            // if (data.Id == Guid.Empty)
            // {
            //     repo.AddDefendant(data);
            // }else
            // {
            //     repo.UpdateDefendant(data);
            // }

            return new OkObjectResult(data);
        }
    }
}
