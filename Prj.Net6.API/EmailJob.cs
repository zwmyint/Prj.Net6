using Hangfire;
using System.Net.Mail;

namespace Prj.Net6.API
{
    public class EmailJob
    {
        private readonly ILogger<EmailJob> logger;
        //private readonly ISendGridClient sendGridClient;
        public EmailJob(ILogger<EmailJob> logger)
        {
            this.logger = logger;
            //this.sendGridClient = sendGridClient;
        }

        public async Task SendEmail()
        {
            logger.LogInformation($"Greeting from Email Job {DateTime.Now}");
            await Task.Delay(1000); // wait 1 second

            //var msg = new SendGridMessage()
            //{
            //    From = new EmailAddress("[SENDER_EMAIL]", "[SENDER_NAME]"),
            //    Subject = "A Recurring Email using Twilio SendGrid",
            //    PlainTextContent = "Hello and welcome to the world of periodic emails with Hangfire and SendGrid. "
            //};
            //msg.AddTo(new EmailAddress("[RECIPIENT_EMAIL]", "[RECIPIENT_NAME]"));

            //var response = await sendGridClient.SendEmailAsync(msg);

            //if (response.IsSuccessStatusCode) logger.LogInformation("Email queued successfully!");
            //else throw new Exception("Failed to queue email");

        }
    }
}
