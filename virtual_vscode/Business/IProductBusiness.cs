using LojaVirtual.Data.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Business
{
    public interface IProductBusiness {
        ProductVO Create(ProductVO book);
        ProductVO FindById(long id);
        List<ProductVO> FindAll();
        ProductVO Update(ProductVO product);
        void Delete(long id);
    }
}
