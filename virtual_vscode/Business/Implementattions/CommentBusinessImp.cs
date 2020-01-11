using System.Collections.Generic;
using LojaVirtual.Model;
using LojaVirtual.Repository.Generic;
using LojaVirtual.Data.Converters;
using LojaVirtual.Data.VO;
using Tapioca.HATEOAS.Utils;
using LojaVirtual.Business;

namespace LojaVirtual.Business.Implementations
{
    public class CommentBusinessImpl : ICommentBusiness
    {

        private ICommentRepository _repository;

        private readonly CommentConverter _converter;

        public CommentBusinessImpl(ICommentRepository repository)
        {
            _repository = repository;
            _converter = new CommentConverter();
        }

        public CommentVO Create(CommentVO comment)
        {
            var commentEntity = _converter.Parse(comment);
            commentEntity = _repository.Create(commentEntity);
            return _converter.Parse(commentEntity);
        }

        public CommentVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public List<CommentVO> FindAll()
        {
            return _converter.ParseList(_repository.FindAll());
        }

        public CommentVO FindById(int id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public CommentVO Update(CommentVO comment)
        {
            var commentEntity = _converter.Parse(comment);
            commentEntity = _repository.Update(commentEntity);
            return _converter.Parse(commentEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public PagedSearchDTO<CommentVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page)
        {
            page = page > 0 ? page - 1 : 0;
            string query = @"select * from comments p where 1 = 1 ";
            if (!string.IsNullOrEmpty(name)) query = query + $" and p.name like '%{name}%'";
            
            query = query + $" order by p.text {sortDirection} limit {pageSize} offset {page}";

            string countQuery = @"select count(*) from comments p where 1 = 1 ";
            if (!string.IsNullOrEmpty(name)) countQuery = countQuery + $" and p.text like '%{name}%'";

            var users = _repository.FindWithPagedSearch(query);

            int totalResults = _repository.GetCount(countQuery);

            return new PagedSearchDTO<CommentVO>
            {
                CurrentPage = page + 1,
                List = _converter.ParseList(users),
                PageSize = pageSize,
                SortDirections = sortDirection,
                TotalResults = totalResults
            };
        }
        public bool Exists(long id)
        {
            return _repository.Exists(id);
        }
    }
}
