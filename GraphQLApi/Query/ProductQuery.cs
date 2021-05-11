using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
                arguments: new QueryArguments(new List<QueryArgument>
                {
                    new QueryArgument<IntGraphType> {Name = "id"},
                    new QueryArgument<StringGraphType> {Name = "name"},
                    new QueryArgument<FloatGraphType> {Name = "price"}

                }),
                resolve: async context =>
                {
                    var query = await productService.GetAllProducts();
                    var id = context.GetArgument<int?>("id");
                    if (id.HasValue)
                    {
                        return query.Where(q => q.Id == id.Value);
                    }

                    var name = context.GetArgument<string>("name");
                    if (!string.IsNullOrEmpty(name))
                    {
                        return query.Where(q => q.Name == name);
                    }

                    var price = context.GetArgument<double?>("price");
                    if (price.HasValue)
                    {
                        return query.Where(q => q.Price == price.Value);
                    }

                    return query.ToList();
                });

            FieldAsync<ProductType>("product",
                description: "will return a single product for a given id",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: async context => await productService.GetProductById(context.GetArgument<int>("id")));
        }
    }
}
