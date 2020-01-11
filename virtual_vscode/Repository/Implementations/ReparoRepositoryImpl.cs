using LojaVirtual.Model;
using LojaVirtual.Model.Context;
using LojaVirtual.Repository.Generic;
using System.Linq;
using System.Collections.Generic;

namespace LojaVirtual.Repository.Implementations
{
    public class ReparoRepositoryImpl : GenericRepository<Reparo>, IReparoRepository
    {
        public ReparoRepositoryImpl(MySQLContext context) : base (context) {}


        public List<Reparo> FindByName(string titulo){
            return null;
        }
    
     }
}
