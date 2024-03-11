using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Comercial.Shared.Modelos.Modelos;

public class Contato
{
    public int Id { get; set; }
    [Required(ErrorMessage = "O campo Tipo é obrigatório.")]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "O campo Tipo deve conter apenas letras.")]
    public string Tipo { get; set; }
    [Required(ErrorMessage = "O campo DDD é obrigatório.")]
    public int DDD { get; set; }
    [Column(TypeName = "decimal(9,0)")]
    [Required(ErrorMessage = "O campo Telefone é obrigatório.")]
    public decimal Telefone { get; set; }
    [Required(ErrorMessage = "O campo Cliente é obrigatório.")]
    public virtual Cliente Cliente { get; set; }

}