using System.Collections.Generic;
using LojaVirtual.Model;
using LojaVirtual.Repository.Generic;
using LojaVirtual.Data.Converters;
using LojaVirtual.Data.VO;
using Tapioca.HATEOAS.Utils;

namespace LojaVirtual.Business.Implementations
{
    public class BoletoBusinessImpl : IBoletoBusiness
    {

        private IBoletoRepository _repository;

        private readonly BoletoConverter _converter;

        public BoletoBusinessImpl(IBoletoRepository repository)
        {
            _repository = repository;
            _converter = new BoletoConverter();
        }

       

        public BoletoVO FindById(int id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

     
    }
}
