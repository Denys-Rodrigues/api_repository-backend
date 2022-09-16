namespace api_repository_backend.Model
{
    public class Produto
    {
        public int Id{ get; set; }

        public string Produto { get; set; }

        public int Quantidade { get; set; }

        public string UnidadeMedida { get; set; }

        public double Valor { get; set; }

        public string Marca { get; set; }
    }
}