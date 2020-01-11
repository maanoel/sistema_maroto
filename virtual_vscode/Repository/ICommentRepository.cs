using LojaVirtual.Model;
using LojaVirtual.Repository.Generic;
using System.Collections.Generic;

namespace LojaVirtual.Business
{
    public interface ICommentRepository :IRepository<Comment>
    {
        List<Comment> FindByText(string text);
        Comment FindById(int id);
    }
}
