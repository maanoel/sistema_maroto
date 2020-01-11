using LojaVirtual.Data.VO;
using LojaVirtual.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Business
{
    public interface ICarrinhoBusiness {
        Carrinho Create(Carrinho carrinho);
        Carrinho FindByUser(long id);
        Carrinho Update(Carrinho carrinho);
        void Delete(long id);
    }
}
