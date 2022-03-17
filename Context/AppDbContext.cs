using Microsoft.EntityFrameworkCore;
using AlunoApi.Model;

namespace AlunoApi.Context
{
    public class AppDbContext : DbContext
    {
        //classe que faz a ponte entre a entity eo banco de dados

        public AppDbContext(DbContextOptions<AppDbContext> options): base(options){
        }

        // vai mapear aluno e criar uma tabela Alunos
        public DbSet<Aluno> Alunos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Aluno>().HasData(
                new Aluno{
                Id = 1,
                Nome = "Maria Shaen",
                Email = "maria@maria.com",
                Idade = 23
                },
                new Aluno{
                    Id = 2,
                    Nome = "Manuel Shin",
                    Email = "manuel@manuel.com",
                    Idade = 22
                }
            );
        }
    }
}