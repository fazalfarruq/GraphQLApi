using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;

namespace GraphQLApi.Types
{
    public sealed class ProductInputType : InputObjectGraphType
    {
        public ProductInputType()
        {
            Field<IntGraphType>().Name("id").Description("this is name");
            Field<StringGraphType>("name");
            Field<FloatGraphType>("price");
        }
    }
}
