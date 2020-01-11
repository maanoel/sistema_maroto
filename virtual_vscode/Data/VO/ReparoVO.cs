using Tapioca.HATEOAS;
using System.Collections.Generic;

namespace LojaVirtual.Data.VO
{
    public class ReparoVO : ISupportsHyperMedia
    {
        public long? Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string DiaIncidente {get; set; }
        public string DiaConserto {get;set;}
        public string PossuiDebito {get; set;}


        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
