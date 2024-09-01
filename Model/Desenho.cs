using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIAnime.Model;
public class Desenho
{
    public Desenho()
    {
        Personagens = new Collection<Personagem>();
    }

    [Key]
    public int DesenhoId { get; set; }

    [Required]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "Precisamos do ano para cadastro")]
    public int AnoDeLancamento { get; set; }

    [ForeignKey("GeneroId")]
    public int GeneroId { get; set; }

    [JsonIgnore]
    public Genero? Genero { get; set; }
    public ICollection <Personagem> Personagens { get; set; }

}

