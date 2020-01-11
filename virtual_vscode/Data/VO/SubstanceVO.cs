using Tapioca.HATEOAS;
using System.Collections.Generic;
using System;

namespace LojaVirtual.Model
{
    public class SubstanceVO
    {
        public long Id {get; set;}
        public string Name { get; set; }
        public string NameScientific { get; set; }
        public string Description { get; set; }
        public string Composto { get; set; }
        public DateTime DataRegistro { get; set; }
        public string Base64Image { get; set; }
        
    }
}
