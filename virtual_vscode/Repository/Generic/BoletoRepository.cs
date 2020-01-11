using LojaVirtual.Model;
using LojaVirtual.Model.Base;
using System.Collections.Generic;

namespace LojaVirtual.Repository.Generic
{
    public interface IBoletoRepository : IRepository<Boleto>
    {
        Boleto FindById(int id);
    }
}
