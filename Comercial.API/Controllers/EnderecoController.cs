using Comercial.API.Request;
using Comercial.Shared.Dados.Banco;
using Comercial.Shared.Modelos.Modelos;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.ConstrainedExecution;

namespace Comercial.API.Controllers;

[ApiController]
[Route("[controller]")]
public class EnderecoController : ControllerBase
{
    [HttpPost]
    public IActionResult CriaEndereco(
            [FromServices] DAL<Endereco> dal,
            [FromServices] DAL<Cliente> dalCliente,
            [FromBody] EnderecoRequest enderecoRequest)
    {
        var cliente = dalCliente.RecuperarPor(a => a.Id == enderecoRequest.ClienteId);
        if (cliente is null)
        {
            return NotFound();
        }

        var endereco = new Endereco()
        {
            Tipo = enderecoRequest.Tipo,
            CEP = enderecoRequest.CEP,
            Bairro = enderecoRequest.Bairro,
            Cidade = enderecoRequest.Cidade,
            Complemento = enderecoRequest.Complemento,
            Estado = enderecoRequest.Estado,
            Logradouro = enderecoRequest.Logradouro,
            Numero = enderecoRequest.Numero,
            Referencia = enderecoRequest.Referencia, 
            Cliente = cliente
        };

        try
        {
            dal.Adicionar(endereco);
            return Ok(endereco);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult RemoveEndereco(int id, [FromServices] DAL<Endereco> dal)
    {
        var endereco = dal.RecuperarPor(a => a.Id == id);
        if (endereco is null)
        {
            return NotFound();
        }
        dal.Deletar(endereco);
        return NoContent();
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaEndereco(
            int id,
            [FromServices] DAL<Endereco> dal,
            [FromServices] DAL<Cliente> dalCliente,
            [FromBody] EnderecoRequest enderecoRequest)
    {
        var endereco = dal.RecuperarPor(a => a.Id == id);
        var cliente = dalCliente.RecuperarPor(a => a.Id == enderecoRequest.ClienteId);

        if (endereco is null || cliente is null)
        {
            return NotFound();
        }

        endereco.Tipo = enderecoRequest.Tipo;
        endereco.CEP = enderecoRequest.CEP;
        endereco.Bairro = enderecoRequest.Bairro;
        endereco.Cidade = enderecoRequest.Cidade;
        endereco.Complemento = enderecoRequest.Complemento;
        endereco.Estado = enderecoRequest.Estado;
        endereco.Logradouro = enderecoRequest.Logradouro;
        endereco.Numero = enderecoRequest.Numero;
        endereco.Referencia = enderecoRequest.Referencia;
        endereco.Cliente = cliente;

        try
        {
            dal.Atualizar(endereco);
            return Ok(endereco);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }
}
