using System.Collections.Generic;
using LojaVirtual.Data.Converter;
using LojaVirtual.Model;
using System.Linq;
using System;

namespace LojaVirtual.Data.Converters
{
    public class SubstanceConverter : IParser<SubstanceVO, Substance>, IParser<Substance, SubstanceVO>
    {
        public Substance Parse(SubstanceVO origin)
        {
            if (origin == null) return new Substance();
            return new Substance
            {
                Id = origin.Id,
                Name = origin.Name,
                NameScientific = origin.NameScientific,
                Description = origin.Description,
                Composto = origin.Composto,
                DataRegistro = origin.DataRegistro,
                Base64Image = Convert.FromBase64String(origin.Base64Image)
            };
        }

        public SubstanceVO Parse(Substance origin)
        {
            if (origin == null) return new SubstanceVO();
            return new SubstanceVO
            {   
                Id = origin.Id,
                Name = origin.Name,
                NameScientific = origin.NameScientific,
                Description = origin.Description,
                Composto = origin.Composto,
                DataRegistro = origin.DataRegistro,
                Base64Image = Convert.ToBase64String(origin.Base64Image)

            };
        }

        public List<Substance> ParseList(List<SubstanceVO> origin)
        {
            if (origin == null) return new List<Substance>();
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<SubstanceVO> ParseList(List<Substance> origin)
        {
            if (origin == null) return new List<SubstanceVO>();
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
