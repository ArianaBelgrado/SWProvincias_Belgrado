using Microsoft.EntityFrameworkCore;
using SWProvincias_Belgrado.Models;

namespace SWProvincias_Belgrado.Data
{
    public class DBPaisFinalContext : DbContext
    {
        public DBPaisFinalContext(DbContextOptions<DBPaisFinalContext> options) : base(options) { }

        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<Provincia> Provincias { get; set; }
    }
}
