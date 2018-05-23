using Microsoft.EntityFrameworkCore;
using OdeToFood.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Data
{
    public class OdeToFoodDbContext:DbContext
    {
        public OdeToFoodDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Restaurant> Restuaranets { get; set; }
    }
}
