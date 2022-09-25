using Prj.Net6.Core.RazorBlog.Enums;

namespace Prj.Net6.WebApp_RazorBlog.ViewModels
{
    public class Notification
    {
        public string Message { get; set; }

        public NotificationType Type { get; set; }
    }
}
