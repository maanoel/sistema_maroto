using Tapioca.HATEOAS;
using System.Collections.Generic;
using System;

namespace LojaVirtual.Data.VO
{
    public class BoletoVO : ISupportsHyperMedia
    {
        public long? Id { get; set; }
        public string Matricula { get; set; }
        public string Local { get; set; }
        public DateTime DtRef { get; set; }
        public DateTime DtVenc { get; set; }
        public float Servico1 { get; set; }
        public float Servico2 { get; set; }
        public float Servico3 { get; set; }
        public float Total { get; set; }
        public int ImovelId { get; set; }

        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();

    }
}
