using Comercial.Shared.Dados.Banco;
using Comercial.Shared.Modelos.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace Comercial.API.Endpoints;

public static class ClientesExtensions
{
    public static void AddEndpointsClientes(this WebApplication app)
    {
        app.MapGet("/Clientes", ([FromServices] DAL<Cliente> dal) =>
        {
            return Results.Ok(dal.Listar());
        });
    }
}
