using System.ComponentModel.DataAnnotations;

namespace APIAnime.Model;
public class Genero
{
    [Key]
    public int GeneroId { get; set; }

    [Required(ErrorMessage = "Precisamos do nome para cadastro do anime!", AllowEmptyStrings = false)]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "Precisamos da descrição para cadastro do anime!", AllowEmptyStrings = false)]

    public string? Descricao { get; set; }
}

