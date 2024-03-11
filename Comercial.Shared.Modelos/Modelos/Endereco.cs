using System.ComponentModel.DataAnnotations;

namespace Comercial.Shared.Modelos.Modelos;

public class Endereco
{
    public int Id { get; set; }
    [Required(ErrorMessage = "O campo Tipo é obrigatório.")]
    public string Tipo { get; set; }
    [Required(ErrorMessage = "O campo CEP é obrigatório.")]
    [RegularExpression(@"^\d{5}-\d{3}$", ErrorMessage = "O campo CEP deve estar no formato XXXXX-XXX.")]
    public string CEP { get; set; }
    [Required(ErrorMessage = "O campo Logradouro é obrigatório.")]
    public string Logradouro { get; set; }
    [Required(ErrorMessage = "O campo Número é obrigatório.")]
    public int Numero { get; set; }
    [Required(ErrorMessage = "O campo Bairro é obrigatório.")]
    public string Bairro { get; set; }
    public string? Complemento { get; set; }
    [Required(ErrorMessage = "O campo Cidade é obrigatório.")]
    public string Cidade { get; set; }
    [Required(ErrorMessage = "O campo Estado é obrigatório.")]
    public string Estado { get; set; }
    public string? Referencia { get; set; }
    [Required(ErrorMessage = "O campo Cliente é obrigatório.")]
    public virtual Cliente Cliente { get; set; }
}
