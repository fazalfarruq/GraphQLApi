using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLApi.Mutation;
using GraphQLApi.Query;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQLApi.Schema
{
    public class ProductSchema : GraphQL.Types.Schema
    {
        public ProductSchema(IServiceProvider provider)
        {
            Query = provider.GetRequiredService<ProductQuery>();
            Mutation = provider.GetRequiredService<ProductMutation>();
        }
    }
}
