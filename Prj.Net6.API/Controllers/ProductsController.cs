using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Prj.Net6.API.Exceptions;
using Prj.Net6.Core.Entities;
using Prj.Net6.Service.Services;

namespace Prj.Net6.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private ILogger<ProductsController> _logger;
        private IConfiguration _configuration;

        public ProductsController(ILogger<ProductsController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet("getproductbyid")]
        public String GetProductById(int Id)
        {
            string a = $"Config (MyKey): {_configuration.GetSection("MyKey")}";
            string b = $"Config (App:Name): {_configuration.GetSection("App:Name")}";
            string c = $"Config (App:Organisation:Email): {_configuration.GetSection("App:Organisation:Email")}";

            var cOptions = new Organisation();
            _configuration.GetSection(Organisation.Name).Bind(cOptions);


            _logger.LogInformation($"Fetch Product with ID: {Id} from the database");
           
            if (Id == 0)
            {
                throw new NotFoundException($"Product ID {Id} not found.");
            }
            _logger.LogInformation($"Returning product with ID: {Id}.");

            return Id.ToString();
        }

        [HttpGet]
        [Route("list")]
        public IDictionary<int, string> Get()
        {
            IDictionary<int, string> list = new Dictionary<int, string>();
            list.Add(1, "IPhone");
            list.Add(2, "Laptop");
            list.Add(3, "Samsung TV");


            return list;
        }



        // Hangfire
        [HttpGet]
        [Route("login")]
        public String Login()
        {
            //Fire - and - Forget Job - this job is executed only once
            var jobId = BackgroundJob.Enqueue(() => Console.WriteLine("Welcome to Shopping World!"));
            return $"Job ID: {jobId}. Welcome mail sent to the user!";
        }
        [HttpGet]
        [Route("productcheckout")]
        public String CheckoutProduct()
        {
            //Delayed Job - this job executed only once but not immedietly after some time.
            var jobId = BackgroundJob.Schedule(() => Console.WriteLine("You checkout new product into your checklist!"), TimeSpan.FromSeconds(20));
            return $"Job ID: {jobId}. You added one product into your checklist successfully!";
        }
        [HttpGet]
        [Route("productpayment")]
        public String ProductPayment()
        {
            //Fire and Forget Job - this job is executed only once
            var parentjobId = BackgroundJob.Enqueue(() => Console.WriteLine("You have done your payment suceessfully!"));
            //Continuations Job - this job executed when its parent job is executed.
            BackgroundJob.ContinueJobWith(parentjobId, () => Console.WriteLine("Product receipt sent!"));
            return "You have done payment and receipt sent on your mail id!";
        }
        [HttpGet]
        [Route("dailyoffers")]
        public String DailyOffers()
        {
            //Recurring Job - this job is executed many times on the specified cron schedule
            RecurringJob.AddOrUpdate(() => Console.WriteLine("Sent similar product offer and suuggestions"), Cron.Daily);
            return "offer sent!";
        }
        // Hangfire

        // Hangfire
        [HttpPost]
        [Route("Welcome")]
        public IActionResult Welcome()
        {
            var JobId = BackgroundJob.Enqueue(() => SendWelcomeEmail("tamam"));
            return Ok($"Job Id: {JobId} SendWelcomeEmail");
        }

        [HttpPost]
        [Route("remember")]
        public IActionResult Remember()
        {
            var JobId = BackgroundJob.Schedule(() => SendWelcomeEmail("tamam"), TimeSpan.FromSeconds(5));
            return Ok($"Job Id: {JobId} SendWelcomeEmail");
        }

        [HttpPost]
        [Route("confirm")]
        public IActionResult confirm()
        {
            var JobId = BackgroundJob.Schedule(() => SendWelcomeEmail("burasi oldu devami gelecek"), TimeSpan.FromSeconds(5));
            BackgroundJob.ContinueJobWith(JobId, () => Console.WriteLine("devami geldi"));
            return Ok("confirmed done ");
        }

        [HttpPost]
        [Route("DbUpdate")]
        public IActionResult DbUpdate()
        {
            RecurringJob.AddOrUpdate(() => Console.WriteLine("updated"), Cron.Minutely);
            //var JobId = BackgroundJob.Schedule(() => SendWelcomeEmail("tamam"), TimeSpan.FromSeconds(5));
            return Ok($"done");
        }
        // Hangfire

        //
        public void SendWelcomeEmail(string text)
        {
            Console.WriteLine(text);

        }


        //
    }
}
