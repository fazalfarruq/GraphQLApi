using System.Collections.Generic;
using System.Threading.Tasks;
using GraphQLApi.Models;

namespace GraphQLApi.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts();
        Task<Product> AddProduct(Product product);
        Task<Product> UpdateProduct(int id, Product product);
        Task DeleteProduct(int id);
        Task<Product> GetProductById(int id);
    }
}
