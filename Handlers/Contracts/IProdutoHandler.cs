using CadastroEmpresasAPI.Models;

namespace CadastroEmpresasAPI.Handlers.Contracts
{
    public interface IProdutoHandler
    {

        
        Task<Produto> AddProdutoAsync(Produto produto);

        Task<bool> RemoveProdutoAsync(int produtoId);

        Task<Produto?> GetProdutoByIdAsync(int produtoId);

        Task<List<Produto>> GetAllProdutosAsync();

        Task<Produto> UpdateProdutoAsync(int produtoId, Produto produto);
    }
}
