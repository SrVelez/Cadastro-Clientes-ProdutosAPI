using System.ComponentModel.DataAnnotations;

namespace CadastroEmpresasAPI.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string CNPJ {  get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public IList<Produto> Produtos { get; set; } = [];


    }
}
