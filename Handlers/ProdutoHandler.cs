using CadastroEmpresasAPI.Context;
using CadastroEmpresasAPI.Controllers;
using CadastroEmpresasAPI.Handlers.Contracts;
using CadastroEmpresasAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace CadastroEmpresasAPI.Handlers
{


    public class ProdutoHandler(AppDbContext context) : IProdutoHandler
    {
        public async Task<Produto> AddProdutoAsync(Produto produto)
        {
            
            try
            {
                await context.Produtos.AddAsync(produto);
                await context.SaveChangesAsync();

                return produto;
            }
            catch (Exception err)
            {

                throw new Exception("Nao foi Possivel Cadastrar o produto. " + err.Message);
            }

        }

        public async Task<List<Produto>> GetAllProdutosAsync()
        {
            try
            {
                var produto = await context.Produtos
                    .Include(x => x.Cliente)
                    .AsNoTracking()
                    .ToListAsync();

                return produto;


            }
            catch (Exception err)
            {

                throw new Exception("Nao foi Possivel encontrar os produtos. " + err.Message);
            }
        }

        public async Task<Produto?> GetProdutoByIdAsync(int produtoId)
        {
            try
            {
                var produto = await context.Produtos
                    .AsNoTracking()
                    .Where(x => x.Id == produtoId)
                    .FirstOrDefaultAsync();

                if (produto == null)
                {
                    return null;
                }
                return produto;
            }
            catch (Exception err)
            {

                throw new Exception("Nao foi Possivel localizar os produtos. " + err.Message);
            }
        }

        public async Task<bool> RemoveProdutoAsync(int produtoId)
        {

            try
            {
                var produto = await context.Produtos
               .Where(x => x.Id == produtoId)
               .FirstOrDefaultAsync();

                if (produto == null)
                {
                    throw new Exception("Nao foi Possivel localizar o produto para deletar.");
                }

                context.Remove(produto);

                await context.SaveChangesAsync();

                return true;
            } 
            catch (Exception err)
            {

                throw new Exception("Nao foi Possivel deletar o produto." + err.Message);
            }

        }

        public async Task<Produto> UpdateProdutoAsync(int produtoId, Produto produto)
        {
            try
            {
                var produtoSearch = await context.Produtos
                    .Where(x => x.Id == produtoId)
                    .FirstOrDefaultAsync();

                if (produtoSearch == null)
                {
                    throw new Exception("Nao foi Possivel localizar o produto para alterar.");
                }

                produtoSearch.ProjectName = produto.ProjectName;
                produtoSearch.ClienteId = produto.ClienteId;
                produtoSearch.Description = produto.Description;
                produtoSearch.StartDate= produto.StartDate;
                produtoSearch.EndDate= produto.EndDate;



                context.Produtos.Update(produtoSearch);

                await context.SaveChangesAsync();

                return produtoSearch;
            }
            catch (Exception err)
            {

                throw new Exception("Nao foi Possivel alterar o produto." + err.Message);
            }
        }
    }
}
