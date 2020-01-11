using LojaVirtual.Model;
using LojaVirtual.Model.Base;
using System.Collections.Generic;

namespace LojaVirtual.Repository.Generic
{
    public interface IReparoRepository : IRepository<Reparo>
    {
        List<Reparo> FindByName(string titulo);
        List<Reparo> FindAll();
    }
}
