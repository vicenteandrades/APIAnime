using APIAnime.Context;
using APIAnime.Model;

namespace APIAnime.Repository;
public class GeneroRepository : BaseRepository<Genero>
{
    public GeneroRepository(AnimeContext context) : base(context)
    {
    }
}

