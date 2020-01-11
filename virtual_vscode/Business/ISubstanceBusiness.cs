using LojaVirtual.Data.VO;
using System.Collections.Generic;
using Tapioca.HATEOAS.Utils;
using LojaVirtual.Model;

namespace LojaVirtual.Business
{
    public interface ISubstanceBusiness
    {
        SubstanceVO Create(SubstanceVO substance);
        SubstanceVO FindById(long id);
        List<SubstanceVO> FindAll();
        SubstanceVO FindByName(string name);
        SubstanceVO Update(SubstanceVO substance);
        void Delete(long id);
        PagedSearchDTO<SubstanceVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page);
    }
}
