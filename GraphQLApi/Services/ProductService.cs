using System.Collections.Generic;
using GraphQLApi.Interfaces;
using GraphQLApi.Models;

namespace GraphQLApi.Services
{
    public class ProductService : IProductService
    {
        private static List<Product> products = new List<Product>
        {
            new Product(){Id = 1,Name = "Coffee",Price= 10},
            new Product(){Id = 2,Name = "Tea",Price= 15},

        };
        public List<Product> GetAllProducts()
        {
            return products;
        }

        public Product AddProduct(Product product)
        {
            products.Add(product);
            return product;
        }

        public Product UpdateProduct(int id, Product product)
        {
            var tempProduct = GetProductById(id);
            var index = products.FindIndex(x => x.Id.Equals(tempProduct.Id));
            products[index] = product;
            return product;
        }

        public void DeleteProduct(int id)
        {
            var productToRemove = GetProductById(id);
            products.Remove(productToRemove);
        }

        public Product GetProductById(int id)
        {
            return products.Find(x => x.Id == id);
        }
    }
}
