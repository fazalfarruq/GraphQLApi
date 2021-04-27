using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using GraphQLApi.Interfaces;
using GraphQLApi.Models;
using GraphQLApi.Types;

namespace GraphQLApi.Mutation
{
    public class ProductMutation : ObjectGraphType
    {
        public ProductMutation(IProductService productService)
        {
            FieldAsync<ProductType>("createProduct",
                arguments: new QueryArguments(new QueryArgument<ProductInputType> { Name = "product" }),
                resolve: async context => await productService.AddProduct(context.GetArgument<Product>("product")));

            FieldAsync<ProductType>("updateProduct",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "id" },
                    new QueryArgument<ProductInputType> { Name = "product" }),
                resolve: async context => await productService.UpdateProduct(context.GetArgument<int>("id"),
                    context.GetArgument<Product>("product")));

            FieldAsync<StringGraphType>("deleteProduct",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: async context =>
                {
                    var productId = context.GetArgument<int>("id");
                    await productService.DeleteProduct(productId);
                    return $"The product against the {productId} has been deleted.";
                });
        }
    }
}
