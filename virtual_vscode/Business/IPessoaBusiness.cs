﻿using LojaVirtual.Data.VO;
using System.Collections.Generic;
using Tapioca.HATEOAS.Utils;

namespace LojaVirtual.Business
{
    public interface IPessoaBusiness
    {
        
        PessoaVO FindById(string id);
        
    }
}
