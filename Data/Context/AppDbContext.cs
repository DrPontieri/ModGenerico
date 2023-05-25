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
            modelBuilder.Entity<DadosPessoais>()
                .HasOne<Pessoa>(e => e.Pessoa)
                .WithMany(f => f.lstDadosPessoais)
                .HasForeignKey(s => s.Fk_Pessoa_DadosPessoais)
                .IsRequired();
        }

        public DbSet<Carro> Carros { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<DadosPessoais> DadosPessoaisS { get; set; }
    }
}
