using CadastroEmpresasAPI.Handlers.Contracts;
using CadastroEmpresasAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CadastroEmpresasAPI.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoHandler _produtoHandler;

        public ProdutoController(IProdutoHandler produtoHandler)
        {
            _produtoHandler = produtoHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {

            try
            {
                var produtos = await _produtoHandler.GetAllProdutosAsync();
                if (produtos == null)
                {
                    return NoContent();
                }

                return Ok(produtos);
            }
            catch (Exception err)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar recuperar os produtos. " + err.Message);
            }
           
        }

        [HttpGet("produto/{id}")]
        public async Task<IActionResult> GetProdutoById(int id)
        {
            try
            {

                var produto = await _produtoHandler.GetProdutoByIdAsync(id);

                if (produto == null)
                {
                    return NoContent();
                }

                return Ok(produto);

            }
            catch (Exception err)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar recuperar o produto. " + err.Message);
            }

        }

        [HttpDelete("produto/{id}")]
        public async Task<IActionResult> RemoveProdutoAsync(int id)
        {
            try
            {
                var produto = await _produtoHandler.RemoveProdutoAsync(id);
                if (produto == false)
                {
                    return BadRequest();
                }

                return Ok(produto);
            }
            catch (Exception err)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar excluir o produto. " + err.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddProdutoAsync(Produto produtoModel)
        {
            try
            {
                var produto = await _produtoHandler.AddProdutoAsync(produtoModel);
                if (produto == null)
                {
                    return BadRequest();
                }

                return Ok(produto);

            }
            catch (Exception err)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tenta adicionar o produto. " + err.Message);
            }
        }

        [HttpPut("produto/{id}")]
        public async Task<IActionResult> UpdateProdutoAsync(int id, Produto produtoModel)
        {
            try
            {
                var produto = await _produtoHandler.UpdateProdutoAsync(id, produtoModel);

                if (produto == null)
                {
                    return BadRequest();
                }

                return Ok(produto);


            }
            catch (Exception err)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao alterar o produto. " + err.Message);
            }

        }

    }
}
