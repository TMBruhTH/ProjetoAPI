using Microsoft.EntityFrameworkCore;
using ProjetoAPI.Data;
using ProjetoAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI.Repositories
{
    public class ContatoRepository : IContatosRepository
    {
        public readonly ContatoContext _context;
        public ContatoRepository(ContatoContext context)
        {
            _context = context;
        }

        public async Task<Contato> Create(Contato model)
        {
            var resultado = (from tb in _context.Contatos
                             where tb.cpf.Contains(model.cpf) select tb).FirstOrDefault();

            if (resultado != null)
            {
                return model;
            }

            _context.Contatos.Add(model);
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task Delete(int id)
        {
            var contato_delete = (from tb in _context.Contatos
                                  where tb.id == id
                                  select tb).FirstOrDefault();

            if (contato_delete == null)
            {
                return;
            }

            _context.Contatos.Remove(contato_delete);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Contato>> Get()
        {
           return await _context.Contatos.ToListAsync();
        }

        public async Task Update(Contato model)
        {
            _context.Entry(model).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
    }
}
