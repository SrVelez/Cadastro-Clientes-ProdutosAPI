using CadastroEmpresasAPI.Context;
using CadastroEmpresasAPI.Handlers.Contracts;
using CadastroEmpresasAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroEmpresasAPI.Handlers
{
    public class ClienteHandler(AppDbContext context) : IClienteHandler
    {
        public async Task<Cliente> AddClienteAsync(Cliente cliente)
        {
            try
            {
                await context.Clientes.AddAsync(cliente);
                await context.SaveChangesAsync();
                return cliente;
            }
            catch (Exception err)
            {

                throw new Exception("Nao foi Possivel Cadastrar o cliente. " + err.Message);
            }
        }

        public async Task<List<Cliente>> GetAllClientesAsync()
        {
            try
            {

                var clientes = await context.Clientes
                    .AsNoTracking()
                    .ToListAsync();

                return clientes;

            }
            catch (Exception err)
            {

                throw new Exception("Nao foi Possivel encontrar o cliente. " + err.Message);
            }
        }

        public async Task<Cliente?> GetClienteByIdAsync(int clienteId)
        {
            try
            {
                var clientes = await context.Clientes
                    .Include(x => x.Produtos)
                    .AsNoTracking()
                    .Where(x => x.Id == clienteId)
                    .FirstOrDefaultAsync();

                if (clientes == null)
                {
                    return null;
                }
                return clientes;
            }
            catch (Exception err)
            {

                throw new Exception("Nao foi Possivel localizar o cliente. " + err.Message);
            }
        }

        public async Task<bool> RemoveClienteAsync(int clienteId)
        {

            try
            {
                var cliente = await context.Clientes
                 .Where(x => x.Id == clienteId)
                 .FirstOrDefaultAsync();

                if (cliente == null)
                {
                    throw new Exception("Nao foi Possivel localizar o cliente para deletar.");
                }

                context.Remove(cliente);

                await context.SaveChangesAsync();

                return true;
            }
            catch (Exception err)
            {

                throw new Exception("Nao foi Possivel deletar o cliente." + err.Message);
            }

        }

      

        public async Task<Cliente> UpdateClienteAsync(int clienteId, Cliente clienteModel)
        {

            try
            {
                var cliente = await context.Clientes
                               .Where(x => x.Id == clienteId)
                               .FirstOrDefaultAsync();

                if (cliente == null)
                {
                    throw new Exception("Nao foi Possivel localizar o cliente para alterar.");
                }
               
                cliente.Address = clienteModel.Address;
                cliente.Name = clienteModel.Name;
                cliente.CNPJ = clienteModel.CNPJ;
                cliente.Email = clienteModel.Email;
                cliente.Phone = clienteModel.Phone;
                cliente.CreatedDate = clienteModel.CreatedDate;

                 context.Clientes.Update(cliente);
       
                await context.SaveChangesAsync();

                return clienteModel;
            }
            catch (Exception err)
            {

                throw new Exception("Nao foi Possivel alterar o cliente." + err.Message);
            }

        }
    }
}
