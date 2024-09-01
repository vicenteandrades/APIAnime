using APIAnime.Context;
using APIAnime.Model;

namespace APIAnime.Repository
{
    public class PersonagemRepository : BaseRepository<Personagem>
    {
        public PersonagemRepository(AnimeContext context) : base(context)
        {
        }
    }
}
