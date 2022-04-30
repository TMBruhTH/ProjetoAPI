using Microsoft.EntityFrameworkCore;
using ProjetoAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI.Data
{
    public class ContatoContext : DbContext
    {
        public DbSet<Contato> Contatos { get; set; }

        public ContatoContext(DbContextOptions<ContatoContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ProjetoAPIContato;Data Source=.\BRUNOSQL");
        //}
    }
}
