using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClubPadel.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<TablaHoy> TablaHoy { get; set; }
        public DbSet<TablaMañana> TablaMañana { get; set; }
        public DbSet<TablaPrueba> TablaPrueba { get; set; }
    }
}
