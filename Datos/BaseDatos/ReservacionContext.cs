using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.BaseDatos.Modelos;

namespace Datos.BaseDatos
{
    public class ReservacionContext : DbContext
    {
        public ReservacionContext() : base("name=Reservacion")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Teatros> Teatros { get; set; }
        public DbSet<Reserva> reserva { get; set; }
    }
}
