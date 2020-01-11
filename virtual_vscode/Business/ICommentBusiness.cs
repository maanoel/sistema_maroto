using LojaVirtual.Data.VO;
using System.Collections.Generic;
using Tapioca.HATEOAS.Utils;
using LojaVirtual.Model;
using System;

namespace LojaVirtual.Business
{
    public interface ICommentBusiness
    {
        CommentVO Create(CommentVO comments);
        CommentVO FindById(long id);
        List<CommentVO> FindAll();
        CommentVO Update(CommentVO comments);
        void Delete(long id);
        PagedSearchDTO<CommentVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page);
    }
}
