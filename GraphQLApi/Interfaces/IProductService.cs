using System.Collections.Generic;
using GraphQLApi.Models;

namespace GraphQLApi.Interfaces
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Product AddProduct(Product product);
        Product UpdateProduct(int id, Product product);
        void DeleteProduct(int id);
        Product GetProductById(int id);
    }
}
