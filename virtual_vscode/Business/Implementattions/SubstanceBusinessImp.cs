using System.Collections.Generic;
using LojaVirtual.Model;
using LojaVirtual.Repository.Generic;
using LojaVirtual.Data.Converters;
using LojaVirtual.Data.VO;
using Tapioca.HATEOAS.Utils;
using LojaVirtual.Business;

namespace LojaVirtual.Business.Implementations
{
    public class SubstanceBusinessImpl : ISubstanceBusiness
    {

        private ISubstanceRepository _repository;

        private readonly SubstanceConverter _converter;

        public SubstanceBusinessImpl(ISubstanceRepository repository)
        {
            _repository = repository;
            _converter = new SubstanceConverter();
        }

        public SubstanceVO Create(SubstanceVO substance)
        {
            var substanceEntity = _converter.Parse(substance);
            substanceEntity = _repository.Create(substanceEntity);
            return _converter.Parse(substanceEntity);
        }

        public SubstanceVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public List<SubstanceVO> FindAll()
        {
            return _converter.ParseList(_repository.FindAll());
        }

        public SubstanceVO FindByName(string name)
        {
            return _converter.Parse(_repository.FindByName(name));
        }

        public SubstanceVO Update(SubstanceVO substance)
        {
            var substanceEntity = _converter.Parse(substance);
            substanceEntity = _repository.Update(substanceEntity);
            return _converter.Parse(substanceEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public PagedSearchDTO<SubstanceVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page)
        {
            page = page > 0 ? page - 1 : 0;
            string query = @"select * from substances p where 1 = 1 ";
            if (!string.IsNullOrEmpty(name)) query = query + $" and p.name like '%{name}%'";
            
            query = query + $" order by p.name {sortDirection} limit {pageSize} offset {page}";

            string countQuery = @"select count(*) from substances p where 1 = 1 ";
            if (!string.IsNullOrEmpty(name)) countQuery = countQuery + $" and p.name like '%{name}%'";

            var users = _repository.FindWithPagedSearch(query);

            int totalResults = _repository.GetCount(countQuery);

            return new PagedSearchDTO<SubstanceVO>
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
