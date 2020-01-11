using System.Collections.Generic;
using LojaVirtual.Data.Converters;
using LojaVirtual.Data.VO;
using LojaVirtual.Repository.Generic;
using System.IO;
using LojaVirtual.Business.Implementations;

namespace LojaVirtual.Business.Implementations
{
    public class ProductBusinessImpl : IProductBusiness
    {
        private IProductRepository _repository;
        private readonly ProductConverter _converter;

        public ProductBusinessImpl(IProductRepository repository)
        {
            _repository = repository;
            _converter = new ProductConverter();
        }

        public ProductVO Create(ProductVO product)
        {
            var productEntity = _converter.Parse(product);
            productEntity = _repository.Create(productEntity);
            SaveImageProduct  imageProducts= new SaveImageProduct(productEntity);
            imageProducts.Save();

            return _converter.Parse(productEntity);
        }

        public List<ProductVO> FindAll()
        {
            return _converter.ParseList(_repository.FindAll());
        }

        public ProductVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }
        public ProductVO Update(ProductVO product)
        {   
            var productEntity = _repository.FindById(product.Id?? 0); 
            SaveImageProduct  imageProducts = new SaveImageProduct(_converter.Parse(product, productEntity));
            imageProducts.Save();
            return _converter.Parse(_repository.Update(_converter.Parse(product, productEntity)));
        }

        public void Delete(long id){

            
        }
    }
}