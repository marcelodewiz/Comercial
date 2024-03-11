using Comercial.API.Request;
using Comercial.Shared.Dados.Banco;
using Comercial.Shared.Modelos.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace Comercial.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContatoController: ControllerBase
    {
        [HttpPost]
        public IActionResult CriaContato(
            [FromServices] DAL<Contato> dal, 
            [FromServices] DAL<Cliente> dalCliente, 
            [FromBody] ContatoRequest contatoRequest)
        {
            var cliente = dalCliente.RecuperarPor(a=> a.Id == contatoRequest.ClienteId);
            if(cliente is null)
            {
                return NotFound();
            }

            var contato = new Contato()
            {
                Tipo = contatoRequest.Tipo,
                DDD = contatoRequest.DDD,
                Telefone = contatoRequest.Telefone,
                Cliente = cliente
            };

            try
            {
                dal.Adicionar(contato);
                return Ok(contato);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaContato(
            int id,
            [FromServices] DAL<Contato> dal, 
            [FromServices] DAL<Cliente> dalCliente, 
            [FromBody] ContatoRequest contatoRequest)
        {
            var contato = dal.RecuperarPor(a => a.Id == id);
            var cliente = dalCliente.RecuperarPor(a=>a.Id == contatoRequest.ClienteId);

            if(contato is null || cliente is null)
            {
                return NotFound();
            }

            contato.Tipo = contatoRequest.Tipo;
            contato.DDD = contatoRequest.DDD;
            contato.Telefone = contatoRequest.Telefone;
            contato.Cliente = cliente;
            try
            {
                dal.Atualizar(contato);
                return Ok(contato);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public IActionResult RemoveContato(int id, [FromServices] DAL<Contato> dal)
        {
            var contato = dal.RecuperarPor(a => a.Id==id);
            if (contato is null)
            {
                return NotFound();
            }
            dal.Deletar(contato);
            return NoContent();
        }
    }
}
