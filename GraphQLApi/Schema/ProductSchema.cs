using System;
using GraphQLApi.Mutation;
using GraphQLApi.Query;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQLApi.Schema
{
    public class ProductSchema : GraphQL.Types.Schema
    {
        public ProductSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<ProductQuery>();
            Mutation = provider.GetRequiredService<ProductMutation>();
        }
    }
}
