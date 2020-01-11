using LojaVirtual.Model;
using LojaVirtual.Model.Base;
using System.Collections.Generic;

namespace LojaVirtual.Repository.Generic
{
    public interface IImovelRepository : IRepository<Imovel>
    {
        List<Imovel> FindById(string id);
    }
}
