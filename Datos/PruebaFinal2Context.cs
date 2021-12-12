using Entidad;
using Microsoft.EntityFrameworkCore;
using System;

namespace Datos
{
    public class PruebaFinal2Context : DbContext
    {
        public PruebaFinal2Context(DbContextOptions contextOptions) : base(contextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Evento> Eventos { get; set; }
    }
}
