using System.ComponentModel.DataAnnotations;

namespace api_repository_backend.Model
{
    public class Produto
    {
        [Key]
        public int Id{ get; set; }

        public string Nome { get; set; }

        public int Quantidade { get; set; }

        public string UnidadeMedida { get; set; }

        public decimal Preco { get; set; }

        public string Marca { get; set; }
    }
}