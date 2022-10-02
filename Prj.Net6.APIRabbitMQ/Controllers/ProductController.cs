using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prj.Net6.APIRabbitMQ.Models;
using Prj.Net6.APIRabbitMQ.RabitMQ;
using Prj.Net6.APIRabbitMQ.Services;

namespace Prj.Net6.APIRabbitMQ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly IRabbitMQProducer _rabbitMQProducer;
        public ProductController(IProductService _productService, IRabbitMQProducer rabbitMQProducer)
        {
            productService = _productService;
            _rabbitMQProducer = rabbitMQProducer;
        }
        [HttpGet("productlist")]
        public IEnumerable<ProductRabbitMQ> ProductList()
        {
            var productList = productService.GetProductList();
            return productList;
        }
        [HttpGet("getproductbyid")]
        public ProductRabbitMQ GetProductById(int Id)
        {
            return productService.GetProductById(Id);
        }
        [HttpPost("addproduct")]
        public ProductRabbitMQ AddProduct(ProductRabbitMQ product)
        {
            var productData = productService.AddProduct(product);
            //send the inserted product data to the queue and consumer will listening this data from queue
            _rabbitMQProducer.SendProductMessage(productData);
            return productData;
        }
        [HttpPut("updateproduct")]
        public ProductRabbitMQ UpdateProduct(ProductRabbitMQ product)
        {
            return productService.UpdateProduct(product);
        }
        [HttpDelete("deleteproduct")]
        public bool DeleteProduct(int Id)
        {
            return productService.DeleteProduct(Id);
        }

    }
}
