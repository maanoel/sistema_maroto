using LojaVirtual.Business;
using LojaVirtual.Model;
using LojaVirtual.Model.Context;
using LojaVirtual.Repository.Generic;
using System.Collections.Generic;
using System.Linq;

namespace LojaVirtual.Repository.Implementations
{
    public class CommentRepositoryImpl : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepositoryImpl(MySQLContext context) : base(context) { }
     
      public List<Comment> FindByText( string txt)
        {
            return null;
        }
    

         public Comment FindById(int id)
        {
            return null;
        }
    }
}
