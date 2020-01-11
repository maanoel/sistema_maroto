using LojaVirtual.Model;
using LojaVirtual.Model.Context;
using LojaVirtual.Repository.Generic;
using System.Linq;
using System.Collections.Generic;

namespace LojaVirtual.Repository.Implementations
{
    public class ImovelRepositoryImpl : GenericRepository<Imovel>, IImovelRepository
    {
        public ImovelRepositoryImpl(MySQLContext context) : base (context) {}


        public List<Imovel> FindById(string id)
        {
           
            return _context.Imovel.Where(p=> p.UserId == id).ToList();
        }
    }
}
