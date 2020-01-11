using System.Collections.Generic;
using LojaVirtual.Data.Converter;
using LojaVirtual.Data.VO;
using LojaVirtual.Model;
using System.Linq;

namespace LojaVirtual.Data.Converters
{
    public class BoletoConverter : IParser<BoletoVO, Boleto>, IParser<Boleto, BoletoVO>
    {
        public Boleto Parse(BoletoVO origin)
        {
            if (origin == null) return new Boleto();
            return new Boleto
            {
                 Id = origin.Id,
                Matricula = origin.Matricula,
                Local = origin.Local,
                DtRef = origin.DtRef,
                Servico1 = origin.Servico1,
                Servico2 = origin.Servico2,
                Servico3 = origin.Servico3,
                ImovelId = origin.ImovelId,
                Total = origin.Total
               
            };
        }

        public BoletoVO Parse(Boleto origin)
        {
            if (origin == null) return new BoletoVO();
            return new BoletoVO
            {
               Id = origin.Id,
                Matricula = origin.Matricula,
                Local = origin.Local,
                DtRef = origin.DtRef,
                Servico1 = origin.Servico1,
                Servico2 = origin.Servico2,
                Servico3 = origin.Servico3,
                ImovelId = origin.ImovelId,
                Total = origin.Total

            };
        }

        public List<Boleto> ParseList(List<BoletoVO> origin)
        {
            if (origin == null) return new List<Boleto>();
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<BoletoVO> ParseList(List<Boleto> origin)
        {
            if (origin == null) return new List<BoletoVO>();
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
