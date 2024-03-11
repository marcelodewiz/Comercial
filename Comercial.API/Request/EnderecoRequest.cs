using Comercial.Shared.Modelos.Modelos;
using System.ComponentModel.DataAnnotations;

namespace Comercial.API.Request;

public record EnderecoRequest
{
    [Required(ErrorMessage = "O campo Tipo é obrigatório.")]
    [ValidaTipoEndereco(ErrorMessage = "O campo Tipo deve ser 'Preferencial', 'Entrega' ou Cobrança.")]
    [MaxLength(20)]
    public string Tipo { get; set; }

    [Required(ErrorMessage = "O campo CEP é obrigatório.")]
    [RegularExpression(@"^\d{5}-\d{3}$", ErrorMessage = "O campo CEP deve estar no formato XXXXX-XXX.")]
    [MaxLength(20)]
    public string CEP { get; set; }

    [Required(ErrorMessage = "O campo Logradouro é obrigatório.")]
    [MaxLength(200)]
    public string Logradouro { get; set; }

    [Required(ErrorMessage = "O campo Número é obrigatório.")]
    public int Numero { get; set; }

    [Required(ErrorMessage = "O campo Bairro é obrigatório.")]
    [MaxLength(100)]
    public string Bairro { get; set; }

    [MaxLength(100)]
    public string? Complemento { get; set; }

    [Required(ErrorMessage = "O campo Cidade é obrigatório.")]
    [MaxLength(100)]
    public string Cidade { get; set; }

    [Required(ErrorMessage = "O campo Estado é obrigatório.")]
    [RegularExpression(@"^[A-Z]{2}$", ErrorMessage = "O campo Estado deve conter exatamente duas letras maiúsculas.")]
    [MaxLength(2)]
    public string Estado { get; set; }

    [MaxLength(100)]
    public string? Referencia { get; set; }

    [Required(ErrorMessage = "O campo Cliente é obrigatório.")]
    public int ClienteId { get; set; }
}

public class ValidaTipoEnderecoAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var allowedTiposContato = new List<string> { "Preferencial", "Entrega", "Cobrança" };

        if (value != null && !allowedTiposContato.Contains(value.ToString()))
        {
            return new ValidationResult(ErrorMessage);
        }

        return ValidationResult.Success;
    }
}
