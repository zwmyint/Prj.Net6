using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Prj.Net6.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailsenderController : ControllerBase
    {
        // Hangfire
        [HttpGet]
        [Route("sendemail")]
        public void EmailSending()
        {
            // send email job
            RecurringJob.AddOrUpdate<EmailJob>(emailJob => emailJob.SendEmail(), "*/15 * * * * *");
        }
    }
}

//#region Job Scheduling Tasks  
//// Recurring Job for every 5 min  
//recurringJobManager.AddOrUpdate("Insert Employee : Runs Every 1 Min", () => jobscheduler.JobAsync(), "*/5 * * * *");
////Fire and forget job   
//var jobId = backgroundJobClient.Enqueue(() => jobscheduler.JobAsync());
////Continous the Job  
//backgroundJobClient.ContinueJobWith(jobId, () => jobscheduler.JobAsync());
////Schedule Job  
//backgroundJobClient.Schedule(() => jobscheduler.JobAsync(), TimeSpan.FromDays(5));
//#endregion