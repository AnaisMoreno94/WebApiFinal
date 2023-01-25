using Microsoft.EntityFrameworkCore;
using SWProvincias_MorenoAnais.Models;

namespace SWProvincias_MorenoAnais.Data
{
    public class DBPaisFinalContext:DbContext
    {
        public DBPaisFinalContext(DbContextOptions<DBPaisFinalContext> options) : base(options) { }

        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }

    }
}
