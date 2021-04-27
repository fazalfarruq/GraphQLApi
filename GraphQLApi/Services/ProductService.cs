using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using GraphQLApi.Data;
using GraphQLApi.Interfaces;
using GraphQLApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLApi.Services
{
    public class ProductService : IProductService
    {
        private readonly GraphQlDbContext _dbContext;

        public ProductService(GraphQlDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _dbContext.Products.FindAsync(id);
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product> AddProduct(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateProduct(int id, Product product)
        {
            var productObj = await GetProductById(id);
            productObj.Name = product.Name;
            productObj.Price = product.Price;
            await _dbContext.SaveChangesAsync();
            return product;
        }

        public async Task DeleteProduct(int id)
        {
            var productToRemove = await GetProductById(id);
            _dbContext.Products.Remove(productToRemove);
            await _dbContext.SaveChangesAsync();
        }
    }
}
