using System.Collections.Generic;
using LojaVirtual.Data.Converter;
using LojaVirtual.Data.VO;
using LojaVirtual.Model;
using System.Linq;

namespace LojaVirtual.Data.Converters
{
    public class ImovelConverter : IParser<ImovelVO, Imovel>, IParser<Imovel, ImovelVO>
    {
        public Imovel Parse(ImovelVO origin)
        {
            if (origin == null) return new Imovel();
            return new Imovel
            {
             
                Nome = origin.Nome,
                Endereco = origin.Endereco,
                UserId = origin.UserId,
                Id = origin.Id
               
            };
        }

        public ImovelVO Parse(Imovel origin)
        {
            if (origin == null) return new ImovelVO();
            return new ImovelVO
            {
                Nome = origin.Nome,
                Endereco = origin.Endereco,
                UserId = origin.UserId,
                Id = origin.Id

            };
        }

        public List<Imovel> ParseList(List<ImovelVO> origin)
        {
            if (origin == null) return new List<Imovel>();
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<ImovelVO> ParseList(List<Imovel> origin)
        {
            if (origin == null) return new List<ImovelVO>();
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
