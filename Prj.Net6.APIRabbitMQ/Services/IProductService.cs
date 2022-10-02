using Prj.Net6.APIRabbitMQ.Models;

namespace Prj.Net6.APIRabbitMQ.Services
{
    public interface IProductService
    {
        public IEnumerable<ProductRabbitMQ> GetProductList();
        public ProductRabbitMQ GetProductById(int id);
        public ProductRabbitMQ AddProduct(ProductRabbitMQ product);
        public ProductRabbitMQ UpdateProduct(ProductRabbitMQ product);
        public bool DeleteProduct(int Id);
    }
}
