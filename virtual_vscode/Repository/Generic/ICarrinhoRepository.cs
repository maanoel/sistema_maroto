using LojaVirtual.Model;


namespace LojaVirtual.Repository.Generic
{
    public interface ICarrinhoRepository : IRepository<Carrinho>
    {
        Carrinho FindByUser(long id);
    }
}
