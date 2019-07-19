using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityBiblioteca
{
    internal class BibliotecaContext :DbContext
    {
        public BibliotecaContext()
        {

        }
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BibliotecaDB;Trusted_Connection=true;");
            }
        }
    }
}
