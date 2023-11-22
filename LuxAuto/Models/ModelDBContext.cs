using LuxAuto.Migrations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace LuxAuto.Models
{
    public partial class ModelDBContext : DbContext
    {
        public ModelDBContext()
            : base("name=ModelDBContext")
        {
        }

        public virtual DbSet<Asta> Asta { get; set; }
        public virtual DbSet<Autovettura> Autovettura { get; set; }
        public virtual DbSet<Marchio> Marchio { get; set; }
        public virtual DbSet<Offerta> Offerta { get; set; }
        public virtual DbSet<Optional> Optional { get; set; }
        public virtual DbSet<OptionalAuto> OptionalAuto { get; set; }
        public virtual DbSet<User> User { get; set; }

        public virtual DbSet <ListaClienti> ListaClienti { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autovettura>()
                .Property(e => e.Prezzo)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Offerta>()
                .Property(e => e.OffertaFatta)
                .HasPrecision(19, 4);

           
        }
    }
}
