using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerWebApi.Models.Context
{
    public class BeerContext:DbContext
    {
        public BeerContext(DbContextOptions<BeerContext> options):base(options)
        {
        }
        public DbSet<Beer> Beers { get; set; }
        public DbSet<BeerRating> BeerRatings{ get; set; }

    }
}
