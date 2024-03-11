using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Comercial.API.Request;

public record ContatoRequest
{
    [Required(ErrorMessage = "O campo Tipo é obrigatório.")]
    [ValidaTipoContato(ErrorMessage = "O campo Tipo deve ser 'Residencial', 'Comercial' ou Celular.")]
    public string Tipo { get; set; }
    
    [Required(ErrorMessage = "O campo DDD é obrigatório.")]
    public int DDD { get; set; }
    
    [Column(TypeName = "decimal(9,0)")]
    [Required(ErrorMessage = "O campo Telefone é obrigatório.")]
    public decimal Telefone { get; set; }

    [Required(ErrorMessage = "Cliente não encontrado")]
    public int ClienteId { get; set; }
}

public class ValidaTipoContatoAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var allowedTiposContato = new List<string> { "Residencial", "Comercial", "Celular" };

        if (value != null && !allowedTiposContato.Contains(value.ToString()))
        {
            return new ValidationResult(ErrorMessage);
        }

        return ValidationResult.Success;
    }
}