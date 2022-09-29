using Microsoft.EntityFrameworkCore;

namespace CrudAspNetCoreCodFirst.Models
{
    public class Contexto : DbContext
    {
        public DbSet<Carro> Carros { get; set; }

        public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes) { }        
    }
}
