using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLApi.Data
{
    public class GraphQlDbContext : DbContext
    {
        public GraphQlDbContext(DbContextOptions<GraphQlDbContext> options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
    }
}
