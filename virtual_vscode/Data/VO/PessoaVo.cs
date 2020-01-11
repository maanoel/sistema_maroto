using Tapioca.HATEOAS;
using System.Collections.Generic;
using System;

namespace LojaVirtual.Data.VO
{
    public class PessoaVO : ISupportsHyperMedia
    {
        public long? Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public DateTime DtNasc { get; set; }
        public string Endereco { get; set; }
        public string Complemento { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string PessoaUserId { get; set; }


        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();

    }
}
