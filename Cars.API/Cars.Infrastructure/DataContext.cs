using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cars.Domain;
using Microsoft.EntityFrameworkCore;

namespace Cars.Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<Car> Cars { get; set; }
    }
}
