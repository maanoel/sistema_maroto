using LojaVirtual.Business;
using LojaVirtual.Model;
using LojaVirtual.Model.Context;
using LojaVirtual.Repository.Generic;
using System.Collections.Generic;
using System.Linq;

namespace LojaVirtual.Repository.Implementations
{
    public class UserRepositoryImpl : GenericRepository<User>, IUserRepository
    {
        public UserRepositoryImpl(MySQLContext context) : base(context) { }
     
        public User FindByLogin(string login)
        {
            return _context.Users.SingleOrDefault(u => u.Login.Equals(login));
        }

         public List<User> FindByName(string firstName, string lastName)
        {
            return null;
        }
    }
}
