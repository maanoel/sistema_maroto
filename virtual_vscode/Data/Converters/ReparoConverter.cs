using System.Collections.Generic;
using LojaVirtual.Data.Converter;
using LojaVirtual.Data.VO;
using LojaVirtual.Model;
using System.Linq;

namespace LojaVirtual.Data.Converters
{
    public class ReparoConverter : IParser<ReparoVO, Reparo>, IParser<Reparo, ReparoVO>
    {
        public Reparo Parse(ReparoVO origin)
        {
            if (origin == null) return new Reparo();
            return new Reparo
            {
                Id = origin.Id,
                Titulo = origin.Titulo,
                Descricao = origin.Descricao,
                DiaIncidente = origin.DiaIncidente,
                DiaConserto = origin.DiaConserto,
                PossuiDebito = origin.PossuiDebito
            };
        }

        public ReparoVO Parse(Reparo origin)
        {
            if (origin == null) return new ReparoVO();
            return new ReparoVO
            {
                Id = origin.Id,
                Titulo = origin.Titulo,
                Descricao = origin.Descricao,
                DiaIncidente = origin.DiaIncidente,
                DiaConserto = origin.DiaConserto,
                PossuiDebito = origin.PossuiDebito
            };
        }

        public List<Reparo> ParseList(List<ReparoVO> origin)
        {
            if (origin == null) return new List<Reparo>();
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<ReparoVO> ParseList(List<Reparo> origin)
        {
            if (origin == null) return new List<ReparoVO>();
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
