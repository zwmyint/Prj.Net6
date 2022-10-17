using System.ComponentModel.DataAnnotations;

namespace Prj.Net6.WebApp_MVCDatatable.Models
{
    public class User2
    {
        [Key]
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string middleName { get; set; }
        public string contact { get; set; }
    }
}
