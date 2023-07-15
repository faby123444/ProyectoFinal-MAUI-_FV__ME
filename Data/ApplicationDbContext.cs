using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_MAUI__FV__ME.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Registro_F> Registro_F { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-162TOV5;Initial Catalog=ProyectoFinalProgra;Integrated Security=True;TrustServerCertificate=true");

        }
    }
}//probandi commits numero 2
