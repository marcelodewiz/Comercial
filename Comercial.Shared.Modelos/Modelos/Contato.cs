using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Comercial.Shared.Modelos.Modelos;

public class Contato
{
    public int Id { get; set; }
    [MaxLength(20)]
    public string Tipo { get; set; }
    public int DDD { get; set; }
    [Column(TypeName = "decimal(9,0)")]
    public decimal Telefone { get; set; }
    public virtual Cliente Cliente { get; set; }

}