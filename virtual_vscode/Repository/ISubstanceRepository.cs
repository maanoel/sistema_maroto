using LojaVirtual.Model;
using LojaVirtual.Repository.Generic;
using System.Collections.Generic;

namespace LojaVirtual.Business
{
    public interface ISubstanceRepository :IRepository<Substance>
    {
        Substance FindByName(string name);
    }
}
