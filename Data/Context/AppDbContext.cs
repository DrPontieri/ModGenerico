using Domain;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>()
                .HasOne(e => e.DadosPessoais)
                .WithOne(e => e.Pessoa)
                .HasForeignKey<DadosPessoais>(e => e.PessoaId)
                .IsRequired();

            //modelBuilder.Entity<Pessoa>()
            //    .HasMany(e => e.Logradouros)
            //    .WithOne(e => e.Pessoa)
            //    .IsRequired();
        }

        //public DbSet<Carro> Carros { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<DadosPessoais> DadosPessoaisS { get; set; }

        public DbSet<Logradouro> LogradourosS { get; set; }
    }
}
