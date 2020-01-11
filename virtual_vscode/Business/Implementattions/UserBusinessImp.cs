using System.Collections.Generic;
using LojaVirtual.Model;
using LojaVirtual.Repository.Generic;
using LojaVirtual.Data.Converters;
using LojaVirtual.Data.VO;
using Tapioca.HATEOAS.Utils;
using LojaVirtual.Business;

namespace LojaVirtual.Business.Implementations
{
    public class UserBusinessImpl : IUserBusiness
    {

        private IUserRepository _repository;

        private readonly UserConverter _converter;

        public UserBusinessImpl(IUserRepository repository)
        {
            _repository = repository;
            _converter = new UserConverter();
        }

        public UserVO Create(UserVO user)
        {
            var personEntity = _converter.Parse(user);
            personEntity = _repository.Create(personEntity);
            return _converter.Parse(personEntity);
        }

        public UserVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public List<UserVO> FindAll()
        {
            return _converter.ParseList(_repository.FindAll());
        }

        public List<UserVO> FindByName(string firstName, string lastName)
        {
            return _converter.ParseList(_repository.FindByName(firstName, lastName));
        }

        public UserVO Update(UserVO user)
        {
            var personEntity = _converter.Parse(user);
            personEntity = _repository.Update(personEntity);
            return _converter.Parse(personEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public PagedSearchDTO<UserVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page)
        {
            page = page > 0 ? page - 1 : 0;
            string query = @"select * from users p where 1 = 1 ";
            if (!string.IsNullOrEmpty(name)) query = query + $" and p.firstName like '%{name}%'";
            
            query = query + $" order by p.firstName {sortDirection} limit {pageSize} offset {page}";

            string countQuery = @"select count(*) from users p where 1 = 1 ";
            if (!string.IsNullOrEmpty(name)) countQuery = countQuery + $" and p.firstName like '%{name}%'";

            var users = _repository.FindWithPagedSearch(query);

            int totalResults = _repository.GetCount(countQuery);

            return new PagedSearchDTO<UserVO>
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
