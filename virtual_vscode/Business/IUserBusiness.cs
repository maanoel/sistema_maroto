using LojaVirtual.Data.VO;
using System.Collections.Generic;
using Tapioca.HATEOAS.Utils;
using LojaVirtual.Model;

namespace LojaVirtual.Business
{
    public interface IUserBusiness
    {
        UserVO Create(UserVO user);
        UserVO FindById(long id);
        List<UserVO> FindAll();
        List<UserVO> FindByName(string fristName, string lastName);
        UserVO Update(UserVO user);
        void Delete(long id);
        PagedSearchDTO<UserVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page);
    }
}
