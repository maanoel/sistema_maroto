using LojaVirtual.Data.VO;
using System.Collections.Generic;
using Tapioca.HATEOAS.Utils;

namespace LojaVirtual.Business
{
    public interface IBoletoBusiness
    {
        
        BoletoVO FindById(int id);
        
    }
}
