using System.Collections.Generic;
using LojaVirtual.Model;
using LojaVirtual.Repository.Generic;
using LojaVirtual.Data.Converters;
using LojaVirtual.Data.VO;
using Tapioca.HATEOAS.Utils;

namespace LojaVirtual.Business.Implementations
{
    public class ImovelBusinessImpl : IImovelBusiness
    {

        private IImovelRepository _repository;

        private readonly ImovelConverter _converter;

        public ImovelBusinessImpl(IImovelRepository repository)
        {
            _repository = repository;
            _converter = new ImovelConverter();
        }

       

        public List<ImovelVO> FindById(string id)
        {
            return _converter.ParseList(_repository.FindById(id));
        }

     
    }
}
