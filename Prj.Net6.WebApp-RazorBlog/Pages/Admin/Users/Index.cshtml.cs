using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Prj.Net6.Core.RazorBlog.Interfaces;
using Prj.Net6.WebApp_RazorBlog.ViewModels;

namespace Prj.Net6.WebApp_RazorBlog.Pages.Admin.Users
{
    public class IndexModel : PageModel
    {
        private readonly IUserRepository userRepository;


        public List<User> Users { get; set; }

        [BindProperty]
        public AddUser AddUserRequest { get; set; }

        [BindProperty]
        public Guid SelectedUserId { get; set; }


        public IndexModel(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<IActionResult> OnGet()
        {
            await GetUsers();
            return Page();
        }

        public async Task<IActionResult> OnPostDelete()
        {
            await userRepository.Delete(SelectedUserId);
            return RedirectToPage("/Admin/Users/Index");
        }

        //
        private async Task GetUsers()
        {
            var users = await userRepository.GetAll();

            Users = new List<User>();
            foreach (var user in users)
            {
                Users.Add(new ViewModels.User()
                {
                    Id = Guid.Parse(user.Id),
                    Username = user.UserName,
                    Email = user.Email
                });
            }
        }
        //
    }
}
