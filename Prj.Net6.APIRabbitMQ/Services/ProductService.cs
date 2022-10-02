using Prj.Net6.APIRabbitMQ.Data;
using Prj.Net6.APIRabbitMQ.Models;

namespace Prj.Net6.APIRabbitMQ.Services
{
    public class ProductService : IProductService
    {
        private readonly DbContextClass _dbContext;

        public ProductService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<ProductRabbitMQ> GetProductList()
        {
            return _dbContext.Products.ToList();
        }
        public ProductRabbitMQ GetProductById(int id)
        {
            return _dbContext.Products.Where(x => x.ProductId == id).FirstOrDefault();
        }
        public ProductRabbitMQ AddProduct(ProductRabbitMQ product)
        {
            var result = _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return result.Entity;
        }
        public ProductRabbitMQ UpdateProduct(ProductRabbitMQ product)
        {
            var result = _dbContext.Products.Update(product);
            _dbContext.SaveChanges();
            return result.Entity;
        }
        public bool DeleteProduct(int Id)
        {
            var filteredData = _dbContext.Products.Where(x => x.ProductId == Id).FirstOrDefault();
            var result = _dbContext.Remove(filteredData);
            _dbContext.SaveChanges();
            return result != null ? true : false;
        }


    }
}
