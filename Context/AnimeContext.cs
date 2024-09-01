using APIAnime.Model;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace APIAnime.Context
{
    public class AnimeContext : DbContext
    {
        public NpgsqlConnection Connection { get; set; }

        public AnimeContext(DbContextOptions<AnimeContext> options) : base(options)
        {
            Connection = new NpgsqlConnection("Host=localhost; Port=5432; Database=postgres; Username=postgres; Password=1440;");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Connection);
        }

        public DbSet<Desenho> Desenho { get; set; }
        public DbSet<Personagem> Personagem { get; set; }
        public DbSet<Genero> Genero { get; set; }
    }

}
