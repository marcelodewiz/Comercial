namespace Comercial.Shared.Modelos.Modelos;

public class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email {  get; set; }
    public string CPF { get; set; }
    public string RG { get; set; }
    public virtual ICollection<Contato>? Contatos { get; set; }

}
