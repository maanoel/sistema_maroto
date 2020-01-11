using System.Collections.Generic;
using LojaVirtual.Data.Converters;
using LojaVirtual.Data.VO;
using LojaVirtual.Repository.Generic;
using System.IO;
using LojaVirtual.Business.Implementations;
using LojaVirtual.Model;

namespace LojaVirtual.Business.Implementations
{
    public class CarrinhoBusinessImpl : ICarrinhoBusiness
    {
        private ICarrinhoRepository _repository;
        
        public CarrinhoBusinessImpl(ICarrinhoRepository repository)
        {
            _repository = repository;
        }   

        public Carrinho Create(Carrinho carrinho)
        {
            var productEntity = carrinho;
            productEntity = _repository.Create(productEntity);

            return productEntity;
        }

        public Carrinho FindByUser(long id)
        {
            return _repository.FindByUser(id);
        }
        public Carrinho Update(Carrinho carrinho)
        {   
            return _repository.Update(carrinho);
            
        }

        public void Delete(long id){

            
        }

        public Carrinho FindById(long id)
        {
           return null;
        }

    }
}