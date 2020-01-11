using System.Linq;
using LojaVirtual.Model;
using LojaVirtual.Model.Context;
using LojaVirtual.Repository.Generic;

namespace LojaVirtual.Repository.Implementations
{
    public class CarrinhoRepositoryImpl : GenericRepository<Carrinho>, ICarrinhoRepository
    {

        public CarrinhoRepositoryImpl(MySQLContext context) : base(context)
        {

        }

        public Carrinho FindByUser(long id)
        {
            return _context.Carrinhos.SingleOrDefault(u => u.Id.Equals(id));
        }
    }
}
