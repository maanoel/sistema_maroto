using System.Collections.Generic;
using LojaVirtual.Model;
using LojaVirtual.Repository.Generic;
using LojaVirtual.Data.Converters;
using LojaVirtual.Data.VO;
using Tapioca.HATEOAS.Utils;

namespace LojaVirtual.Business.Implementations
{
    public class ReparoBusinessImpl : IReparoBusiness
    {

        private IReparoRepository _repository;

        private readonly ReparoConverter _converter;

        public ReparoBusinessImpl(IReparoRepository repository)
        {
            _repository = repository;
            _converter = new ReparoConverter();
        }

        public ReparoVO Create(ReparoVO Reparo)
        {
            var ReparoEntity = _converter.Parse(Reparo);
            ReparoEntity = _repository.Create(ReparoEntity);
            return _converter.Parse(ReparoEntity);
        }

      
    }
}
