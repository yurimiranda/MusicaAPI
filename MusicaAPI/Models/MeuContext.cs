using System.Data.Entity;

namespace MusicaAPI.Models
{
    public class MeuContext : DbContext
    {
        public MeuContext() : base("name=MeuContext")
        {
        }

        public DbSet<Musica> Musicas { get; set; }
    }
}