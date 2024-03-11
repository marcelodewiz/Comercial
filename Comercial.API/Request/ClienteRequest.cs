using System.ComponentModel.DataAnnotations;

namespace Comercial.API.Request;

public record ClienteRequest {

    [Required(ErrorMessage = "O campo Nome é obrigatório.")]
    [RegularExpression(@"[a-zA-Z\s]+", ErrorMessage = "O campo Nome deve conter apenas letras.")]
    [StringLength(100, MinimumLength = 10, ErrorMessage = "O campo Nome deve ter entre 10 e 100 caracteres.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo Email é obrigatório.")]
    [EmailAddress(ErrorMessage = "O campo Email deve ser um endereço de e-mail válido.")]
    [MaxLength(100, ErrorMessage = "O tamanho do campo email não pode exceder 100 caracteres")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo CPF é obrigatório.")]
    [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "O campo CPF deve estar no formato XXX.XXX.XXX-XX.")]
    public string CPF { get; set; }

    [Required(ErrorMessage = "O campo RG é obrigatório.")]
    [RegularExpression(@"^\d{2}\.\d{3}\.\d{3}-\d{1}$", ErrorMessage = "O campo RG deve estar no formato XX.XXX.XXX-X.")]
    public string RG { get; set; }
} 

