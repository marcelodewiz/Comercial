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
    public IActionResult Index([FromServices] DAL<Cliente> dal)
    {
        return Ok(dal.Listar());
    }

    [HttpPost]
    public IActionResult AdicionaCliente([FromServices] DAL<Cliente> DAL, [FromBody] ClienteRequest clienteRequest)
    {
        try
        {
            var cliente = new Cliente()
            {
                Nome = clienteRequest.Nome,
                Email = clienteRequest.Email,
                CPF = clienteRequest.CPF,
                RG = clienteRequest.RG
            };
            DAL.Adicionar(cliente);
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
        try
        {
            cliente.Nome = clienteRequest.Nome;
            cliente.Email = clienteRequest.Email;
            cliente.CPF = clienteRequest.CPF;
            cliente.RG = clienteRequest.RG;
            dal.Atualizar(cliente);
            return Ok(cliente);
        }catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}
