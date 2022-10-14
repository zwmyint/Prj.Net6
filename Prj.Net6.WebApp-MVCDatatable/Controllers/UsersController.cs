using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prj.Net6.WebApp_MVCDatatable.Data;
using Prj.Net6.WebApp_MVCDatatable.Models;

namespace Prj.Net6.WebApp_MVCDatatable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDBContext _context;

        public UsersController(AppDBContext context)
        {
            _context = context;
        }

        [HttpPost("GetUsers")]
        public IActionResult GetUsers()
        {
            try
            {
                var draw = Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                var searchValue = Request.Form["search[value]"].FirstOrDefault();
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;
                var userData = (from tempuser in _context.tbl_users_fordt select tempuser);
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    userData = userData.OrderBy(s => sortColumn + " " + sortColumnDirection);
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    userData = userData.Where(m => m.FirstName.Contains(searchValue)
                                                || m.LastName.Contains(searchValue)
                                                || m.Contact.Contains(searchValue)
                                                || m.Email.Contains(searchValue)
                                                || m.Address.Contains(searchValue));
                }
                recordsTotal = userData.Count();
                var data = userData.Skip(skip).Take(pageSize).ToList();
                var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data };
                return Ok(jsonData);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
                throw;
            }
        }

        [HttpGet("getAllUsers")]
        public IActionResult getAllUsers()
        {

            List<User2> users2 = new List<User2>();
            users2 = _context.tbl_users_fordt2.Select(u => u).ToList();

            var jsonData = new { data = users2 };
            return Ok(jsonData);
        }

        //
    }
}
