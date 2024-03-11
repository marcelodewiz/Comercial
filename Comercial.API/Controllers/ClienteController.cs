using Comercial.API.Request;
using Comercial.Shared.Dados.Banco;
using Comercial.Shared.Modelos.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace Comercial.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ClienteController:ControllerBase
{
    [HttpGet]
    public IActionResult Listar(
        [FromServices] DAL<Cliente> dal, 
        string nome = null, 
        string email = null, 
        string cpf = null,
        string rg = null)
    {
        var clientes = dal.Listar();

        if (!string.IsNullOrEmpty(nome))
        {
            clientes = clientes.Where(
                c => c.Nome.ToUpper().Contains(nome.ToUpper()));
        }

        if (!string.IsNullOrEmpty(email))
        {
            clientes = clientes.Where(
                c => c.Email.ToUpper().Equals(email.ToUpper()));
        }

        if (!string.IsNullOrEmpty(cpf))
        {
            clientes = clientes.Where(c => c.CPF.Equals(cpf));
        }

        if (!string.IsNullOrEmpty(rg))
        {
            clientes = clientes.Where(c => c.RG.Equals(rg));
        }

        return Ok(clientes);
    }

    [HttpPost]
    public IActionResult CriaCliente([FromServices] DAL<Cliente> dal, [FromBody] ClienteRequest clienteRequest)
    {
        var cliente = new Cliente()
        {
            Nome = clienteRequest.Nome,
            Email = clienteRequest.Email,
            CPF = clienteRequest.CPF,
            RG = clienteRequest.RG
        };
        try
        {
            dal.Adicionar(cliente);
            return Ok(cliente);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult RemoveCliente(int id, [FromServices] DAL<Cliente> dal)
    {
        var cliente = dal.RecuperarPor(a => a.Id == id);
        if(cliente is null)
        {
            return NotFound();
        }
        dal.Deletar(cliente);
        return NoContent();
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaCliente(int id, [FromServices] DAL<Cliente> dal, [FromBody] ClienteRequest clienteRequest)
    {
        var cliente = dal.RecuperarPor(a => a.Id == id);
        if (cliente is null)
        {
            return NotFound();
        }

        cliente.Nome = clienteRequest.Nome;
        cliente.Email = clienteRequest.Email;
        cliente.CPF = clienteRequest.CPF;
        cliente.RG = clienteRequest.RG;

        try
        {
            dal.Atualizar(cliente);
            return Ok(cliente);
        }catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}
