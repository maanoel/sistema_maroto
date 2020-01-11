using Tapioca.HATEOAS;
using System.Collections.Generic;
using System;

namespace LojaVirtual.Data.VO
{
    public class ImovelVO : ISupportsHyperMedia
    {
        public long? Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string UserId { get; set; }

        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();

    }
}
