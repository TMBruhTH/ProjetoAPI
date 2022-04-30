using Microsoft.AspNetCore.Mvc;
using ProjetoAPI.Model;
using ProjetoAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatosController : Controller
    {
        private readonly IContatosRepository _contatosRepository;
        public ContatosController(IContatosRepository contatosRepository)
        {
            _contatosRepository = contatosRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Contato>> Get()
        {
            return await _contatosRepository.Get();
        }

        [HttpPost]
        public async Task<Contato> Create([FromBody] Contato model)
        {
            return await _contatosRepository.Create(model);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _contatosRepository.Delete(id);

            return NoContent();
        }

        [HttpPut]
        public async Task<Contato> Update(int id, [FromBody] Contato model)
        {
            if (id == model.id)
            {
                await _contatosRepository.Update(model);
            }

            return model;
        }
    }
}
