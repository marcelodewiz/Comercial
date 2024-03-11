using System.ComponentModel.DataAnnotations;

namespace Comercial.Shared.Modelos.Modelos;

public class Endereco
{
    public int Id { get; set; }
    [MaxLength(20)]
    public string Tipo { get; set; }
    [MaxLength(20)]
    public string CEP { get; set; }
    [MaxLength(200)]
    public string Logradouro { get; set; }
    public int Numero { get; set; }
    [MaxLength(100)]
    public string Bairro { get; set; }
    [MaxLength(100)]
    public string? Complemento { get; set; }
    [MaxLength(100)]
    public string Cidade { get; set; }
    [MaxLength(2)]
    public string Estado { get; set; }
    [MaxLength(100)]
    public string? Referencia { get; set; }
    public virtual Cliente Cliente { get; set; }
}
