using System.Reflection;
using EstacionamentoDotnet6.Models;
using Microsoft.EntityFrameworkCore;

namespace EstacionamentoDotnet6.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pessoa>().HasKey(p => p.PessoaId);
            modelBuilder.Entity<Carro>().HasKey(c => c.CarroId);
            modelBuilder.Entity<Estadia>().HasKey(e => e.Id);
            modelBuilder.Entity<Pagamento>().HasKey(p => p.Id); 
        }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Carro> Carros { get; set; }
        public DbSet<Estadia> Estadias { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }

    }
}