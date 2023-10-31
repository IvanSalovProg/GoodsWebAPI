using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Goods.Models
{
    public class GoodsAppContext : DbContext
        {
            public DbSet<Product> Product { get; set; }

           public DbSet<Group> Groups { get; set; }

        public GoodsAppContext(DbContextOptions<GoodsAppContext> options) : base(options)
            {

            }
        }
    }

