using CadastroEmpresasAPI.Handlers.Contracts;
using CadastroEmpresasAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CadastroEmpresasAPI.Controllers
{

    [ApiController]
    [Route("/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteHandler _clienteHandler;

        public ClienteController(IClienteHandler clienteHandler) 
        {
            _clienteHandler = clienteHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClientesAsync()
        {
            try
            {
                var clientes = await _clienteHandler.GetAllClientesAsync();

                if (clientes == null)
                {
                    return NoContent();
                }

                return Ok(clientes);
            }
            catch (Exception err)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar recuperar os cliente. " + err.Message);
            }
        }

        [HttpGet("cliente/{id}")]
        public async Task<IActionResult> GetClienteByIdAsync(int id)
        {
            try
            {
                var cliente = await _clienteHandler.GetClienteByIdAsync(id);

                if (cliente == null)
                {
                    return NoContent();
                }

                return Ok(cliente);
            }
            catch (Exception err)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar recuperar os cliente. " + err.Message);
            }
        }


        [HttpDelete("cliente/{id}")]
        public async Task<IActionResult> RemoveClienteAsync(int id)
        {
            try
            {
                var cliente = await _clienteHandler.RemoveClienteAsync(id);
                if (cliente == false)
                {
                    return BadRequest();
                }

                return Ok(cliente);

            }
            catch (Exception err)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar excluir os cliente. " + err.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddClienteAsync(Cliente clienteModel)
        {
            try
            {
                var cliente = await _clienteHandler.AddClienteAsync(clienteModel);
                if (cliente == null)
                {
                    return BadRequest();
                }

                return Ok(cliente);
            }
            catch (Exception err)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar adicionar os cliente. " + err.Message);
            }
        }

        [HttpPut("cliente/{id}")]
        public async Task<IActionResult> UpdateClienteAsync(int id,  Cliente clienteModel)
        {
            try
            {
                var cliente = await _clienteHandler.UpdateClienteAsync(id, clienteModel);

                if (cliente == null)
                {
                    return BadRequest();
                }

                return Ok(cliente);


            }
            catch (Exception err)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar alterar os cliente. " + err.Message);
            }
        }
    }
}
