using GraphQL;
using GraphQL.Types;
using GraphQLApi.Interfaces;
using GraphQLApi.Types;

namespace GraphQLApi.Query
{
    public class ProductQuery : ObjectGraphType
    {
        public ProductQuery(IProductService productService)
        {
            FieldAsync<ListGraphType<ProductType>>("products",
                description: "will get all products",
                resolve: async context => await productService.GetAllProducts());

            FieldAsync<ProductType>("product",
                description:"will return a single product for a given id",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: async context => await productService.GetProductById(context.GetArgument<int>("id")));
        }
    }
}
