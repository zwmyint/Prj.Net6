using System.ComponentModel.DataAnnotations;

namespace Prj.Net6.APIRabbitMQ.Models
{
    public class ProductRabbitMQ
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductPrice { get; set; }
        public int ProductStock { get; set; }
    }
}
