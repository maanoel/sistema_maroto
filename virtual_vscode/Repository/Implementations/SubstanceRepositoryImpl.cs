using LojaVirtual.Business;
using LojaVirtual.Model;
using LojaVirtual.Model.Context;
using LojaVirtual.Repository.Generic;
using System.Collections.Generic;
using System.Linq;

namespace LojaVirtual.Repository.Implementations
{
    public class SubstanceRepositoryImpl : GenericRepository<Substance>, ISubstanceRepository
    {
        public SubstanceRepositoryImpl(MySQLContext context) : base(context) { }
     
        public Substance FindByName(string name)
        {
            return _context.Substances.SingleOrDefault(u => u.Name.Equals(name));
        }

    }
}
