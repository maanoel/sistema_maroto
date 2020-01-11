using LojaVirtual.Model;
using LojaVirtual.Repository.Generic;
using System.Collections.Generic;

namespace LojaVirtual.Business
{
    public interface IUserRepository :IRepository<User>
    {
        User FindByLogin(string login);
        List<User> FindByName(string firstName, string lastName);
    }
}
