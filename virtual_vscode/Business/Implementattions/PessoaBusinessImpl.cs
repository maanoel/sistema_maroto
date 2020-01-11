using System.Collections.Generic;
using LojaVirtual.Model;
using LojaVirtual.Repository.Generic;
using LojaVirtual.Data.Converters;
using LojaVirtual.Data.VO;
using Tapioca.HATEOAS.Utils;

namespace LojaVirtual.Business.Implementations
{
    public class PessoaBusinessImpl : IPessoaBusiness
    {

        private IPessoaRepository _repository;

        private readonly PessoaConverter _converter;

        public PessoaBusinessImpl(IPessoaRepository repository)
        {
            _repository = repository;
            _converter = new PessoaConverter();
        }

       

        public PessoaVO FindById(string id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

     
    }
}
