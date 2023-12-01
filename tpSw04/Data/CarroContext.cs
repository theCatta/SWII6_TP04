namespace tpSw04.Data
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using tpSw04.Models;

    public class CarroContext : DbContext
    {
        public CarroContext(DbContextOptions<CarroContext> options) : base(options) { }

        public DbSet<Carro> Carros { get; set; } = null!;
    }

}
