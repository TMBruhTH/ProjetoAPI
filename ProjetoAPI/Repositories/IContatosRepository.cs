using ProjetoAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI.Repositories
{
    public interface IContatosRepository
    {
        Task<IEnumerable<Contato>> Get();
        Task<Contato> Create(Contato model);
        Task Update(Contato model);
        Task Delete(int id);
    }
}
