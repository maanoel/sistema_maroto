using LojaVirtual.Model;
using LojaVirtual.Model.Base;
using System.Collections.Generic;

namespace LojaVirtual.Repository.Generic
{
    public interface IPersonRepository : IRepository<Person>
    {
        List<Person> FindByName(string fristName, string lastName);
    }
}
