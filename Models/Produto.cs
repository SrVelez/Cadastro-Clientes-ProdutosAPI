namespace CadastroEmpresasAPI.Models
{
    public class Produto
    {

        public int Id { get; set; }

        public string ProjectName { get; set; } = string.Empty;

        public int ClienteId { get; set; }

        public Cliente? Cliente { get; set; } = null!;

        public string Description { get; set; } = string.Empty;

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
