using LojaVirtual.Model;
using LojaVirtual.Model.Context;
using LojaVirtual.Repository.Generic;
using System.Linq;
using System.Collections.Generic;

namespace LojaVirtual.Repository.Implementations
{
    public class BoletoRepositoryImpl : GenericRepository<Boleto>, IBoletoRepository
    {
        public BoletoRepositoryImpl(MySQLContext context) : base (context) {}


        public Boleto FindById(int id)
        {
           
            return _context.Boleto.Where(p=> p.ImovelId == id).FirstOrDefault();
        }
    }
}
