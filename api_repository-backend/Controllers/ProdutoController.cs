using api_repository_backend.Model;
using api_repository_backend.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_repository_backend.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepository repository;

        public ProdutoController(IProdutoRepository _context)
        {
            repository = _context;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProduto()
        {
            var produto = await repository.GetAll();
            if (produto == null)
            {
                return BadRequest();
            }
            return Ok(produto.ToList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProduto(int id)
        {
            var produto = await repository.GetById(id);
            if (produto == null)
            {
                return NotFound("Produto não encontrado");
            }
            return Ok(produto);
        }

        [HttpPost]
        public async Task<IActionResult> PostProduto([FromBody] Produto produto)
        {
            if (produto == null)
            {
                return BadRequest("Produto é null");
            }

            await repository.Insert(produto);
            return CreatedAtAction(nameof(GetProduto), new { id = produto.Id }, produto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduto(int id, Produto produto)
        {
            if (id != produto.Id)
            {
                return BadRequest($"O código do produto {id} não confere");
            }
            try
            {
                await repository.Update(id, produto);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return Ok("Atualização de produto realizada com sucesso");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Produto>> DeleteProduto(int id)
        {
            var produto = await repository.GetById(id);
            if (produto == null)
            {
                return NotFound($"Produto com código {id} não foi encontrado");
            }
            await repository.Delete(id);
            return Ok(produto);
        }
    }
}
