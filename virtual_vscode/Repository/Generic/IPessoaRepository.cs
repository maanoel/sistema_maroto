using LojaVirtual.Model;
using LojaVirtual.Model.Base;
using System.Collections.Generic;

namespace LojaVirtual.Repository.Generic
{
    public interface IPessoaRepository : IRepository<Pessoa>
    {
        Pessoa FindById(string id);
    }
}
