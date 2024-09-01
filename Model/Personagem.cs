using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIAnime.Model;
public class Personagem
{
    [Key]
    public int PersonagemId { get; set; }

    [Required(ErrorMessage = "Precisamos do nome do personagem", AllowEmptyStrings = false)]
    public string? Name { get; set; }
    
    [Required(ErrorMessage = "O resumo é campo que precisa ser enviado!", AllowEmptyStrings = false)]
    public string? Resumo { get; set; }

    [Required(ErrorMessage = "Precisamos de uma foto!", AllowEmptyStrings = false)]
    public string? Foto { get; set; }

    [ForeignKey("DesenhoId")]
    public int DesenhoId { get; set; }

    [JsonIgnore]
    public Desenho? Desenho { get; set; }
}

