using System.ComponentModel.DataAnnotations;

namespace Comercial.Shared.Modelos.Modelos;

public class Cliente
{
    public int Id { get; set; }
    [MaxLength(100)]
    public string Nome { get; set; }
    [MaxLength(100)]
    public string Email {  get; set; }
    [MaxLength(14)]
    public string CPF { get; set; }
    [MaxLength(12)]
    public string RG { get; set; }
    public virtual ICollection<Contato>? Contatos { get; set; }
    public virtual ICollection<Endereco>? Enderecos { get; set; }

}
