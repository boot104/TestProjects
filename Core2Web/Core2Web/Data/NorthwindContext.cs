using Core2Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core2Web.Data
{
    public class NorthwindContext : DbContext
    {
        public NorthwindContext(DbContextOptions options) : base(options) { }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
    }
}
