using InfnetMVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InfnetMVC.DAL
{
    public class InfnetDbContext : IdentityDbContext
    {
        public InfnetDbContext(DbContextOptions<InfnetDbContext> options) : base(options)
        {

        }

        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Funcionario>()
                .HasOne(f => f.Endereco)             // Um funcionário tem um endereço
                .WithMany(e => e.Funcionarios)       // Um endereço pode ter vários funcionários
                .HasForeignKey(f => f.EnderecoId);   // Chave estrangeira

            modelBuilder.Entity<Funcionario>()
                .HasOne(f => f.Departamento)            // Um funcionário tem um departamento
                .WithMany(d => d.Funcionarios)          // Um departamento pode ter vários funcionários
                .HasForeignKey(f => f.DepartamentoId);  // Chave estrangeira
        }
    }
}