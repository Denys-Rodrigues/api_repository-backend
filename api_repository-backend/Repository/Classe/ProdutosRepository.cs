using api_repository_backend.Context;
using api_repository_backend.Model;
using api_repository_backend.Repository.Interfaces;

namespace api_repository_backend.Repository.Classe
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(AppDbContext repositoryContext) : base(repositoryContext) { }
    }
}
