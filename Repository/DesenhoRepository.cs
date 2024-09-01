using APIAnime.Context;
using APIAnime.Model;

namespace APIAnime.Repository;
public class DesenhoRepository : BaseRepository<Desenho>
{
    public DesenhoRepository(AnimeContext context) : base(context)
    {
    }
}

