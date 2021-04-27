using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using GraphQLApi.Data;
using GraphQLApi.Interfaces;
using GraphQLApi.Models;

namespace GraphQLApi.Services
{
    public class ProductService : IProductService
    {
        private readonly GraphQlDbContext _dbContext;

        public ProductService(GraphQlDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Product GetProductById(int id)
        {
            return _dbContext.Products.Find(id);
        }

        public List<Product> GetAllProducts()
        {
            return _dbContext.Products.ToList();
        }

        public Product AddProduct(Product product)
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return product;
        }

        public Product UpdateProduct(int id, Product product)
        {
            var productObj = GetProductById(id);
            productObj.Name = product.Name;
            productObj.Price = product.Price;
            _dbContext.SaveChanges();
            return product;
        }

        public void DeleteProduct(int id)
        {
            var productToRemove = GetProductById(id);
            _dbContext.Products.Remove(productToRemove);
            _dbContext.SaveChanges();
        }
    }
}
