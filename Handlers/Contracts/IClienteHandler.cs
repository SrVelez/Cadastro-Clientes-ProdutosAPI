using CadastroEmpresasAPI.Models;

namespace CadastroEmpresasAPI.Handlers.Contracts
{
    public interface IClienteHandler
    {

     
        Task<Cliente> AddClienteAsync (Cliente cliente);

        Task<bool> RemoveClienteAsync (int clienteId);

        Task<Cliente?> GetClienteByIdAsync (int clienteId);

        Task<List<Cliente>> GetAllClientesAsync ();

        Task<Cliente> UpdateClienteAsync (int clienteId, Cliente cliente);


    
    }
}
