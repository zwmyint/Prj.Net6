using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Prj.Net6.Core.Entities;
using Prj.Net6.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Prj.Net6.Infrastructure.Repositories
{
    public class ProductRepositoryDP 
    {
        private readonly IConfiguration _configuration;
        public ProductRepositoryDP(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<bool> Add(Product entity)
        {
            var sql = "INSERT INTO [dbo].[Product] ([Sku], [Name], [Manufacturer],[Price]) VALUES (@Sku, @Name, @Manufacturer, @Price)";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return true;
            }
        }


        public async Task<IEnumerable<Product>> GetAll()
        {
            var sql = "SELECT * FROM Product";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Product>(sql);
                return result.ToList();
            }
        }
        public async Task<Product> GetById(string id)
        {
            var sql = "SELECT * FROM Product WHERE Id = @Id";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Product>(sql, new { Id = id });
                return result;
            }
        }


        public async Task<bool> Remove(string id)
        {
            var sql = "DELETE FROM Products WHERE Id = @Id";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return true;
            }
        }


        public async Task<bool> Update(Product entity)
        {
            var sql = "UPDATE Product SET Sku = @Sku, Name = @Name, Manufacturer = @Manufacturer, Price = @Price WHERE Id = @Id";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                await connection.ExecuteAsync(sql, entity);
                return true;
            }
        }

        //
    }
}
