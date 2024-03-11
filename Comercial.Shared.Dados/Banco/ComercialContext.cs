using Comercial.Shared.Modelos.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Comercial.Shared.Dados.Banco;

public class ComercialContext : DbContext
{
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Contato> Contatos { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }

    private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Comercial;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer(connectionString)
            .UseLazyLoadingProxies();
    }

}