using System.ComponentModel.DataAnnotations;

namespace DepoimentosApi.Models;


public class Destinos
{
    public int Id { get; set; }
    [Required]
    public string Foto1 { get; set; }
    [Required]
    public string Foto2 { get; set; }
    [Required]
    public string Nome { get; set; }
    [MaxLength(160)]
    public string Meta { get; set; }
    public int Preco { get; set; }
    public string? TextoDescritivo { get; set; }
}
