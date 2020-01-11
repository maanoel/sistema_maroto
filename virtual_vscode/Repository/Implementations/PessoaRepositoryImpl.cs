using LojaVirtual.Model;
using LojaVirtual.Model.Context;
using LojaVirtual.Repository.Generic;
using System.Linq;
using System.Collections.Generic;

namespace LojaVirtual.Repository.Implementations
{
    public class PessoaRepositoryImpl : GenericRepository<Pessoa>, IPessoaRepository
    {
        public PessoaRepositoryImpl(MySQLContext context) : base (context) {}


        public Pessoa FindById(string id)
        {
           
            return _context.Pessoa.Where(p=> p.PessoaUserId == id).FirstOrDefault();
        }
    }
}
