using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using tpSw04.Models;

namespace API.Data
{
    public class CarroContext : DbContext
    {
        public CarroContext (DbContextOptions<CarroContext> options)
            : base(options)
        {
        }

        public DbSet<tpSw04.Models.Carro> Carro { get; set; } = default!;
    }
}
