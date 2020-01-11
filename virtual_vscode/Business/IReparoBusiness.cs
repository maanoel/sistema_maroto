using LojaVirtual.Data.VO;
using System.Collections.Generic;
using Tapioca.HATEOAS.Utils;

namespace LojaVirtual.Business
{
    public interface IReparoBusiness
    {
        ReparoVO Create(ReparoVO Reparo);
        List<ReparoVO> FindAll();
        
    }
}
