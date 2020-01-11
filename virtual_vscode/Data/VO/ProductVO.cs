using System.Collections.Generic;
using Tapioca.HATEOAS;

namespace LojaVirtual.Data.VO
{
    public class ProductVO : ISupportsHyperMedia
    {
        public long? Id { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public double Peso { get; set; }
        public string Cor { get; set; }
        public string Categoria { get; set; }
        public string Medida { get; set; }
        public int Quantidade { get; set; }
        public string ImageBas64 { get; set; }
        public string ImageUrl { get; set; }
        public string ImageBas64_2 { get; set; }
        public string ImageUrl_2 { get; set; }
        public string ImageBas64_3 { get; set; }
        public string ImageUrl_3 { get; set; }
        public string ImageBas64_4 { get; set; }
        public string ImageUrl_4 { get; set; }
        public string ImageBas64_5 { get; set; }
        public string ImageUrl_5 { get; set; }

        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();

    }
}
