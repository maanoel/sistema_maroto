using System.Collections.Generic;
using LojaVirtual.Data.Converter;
using LojaVirtual.Data.VO;
using LojaVirtual.Model;
using System.Linq;

namespace LojaVirtual.Data.Converters
{
    public class PessoaConverter : IParser<PessoaVO, Pessoa>, IParser<Pessoa, PessoaVO>
    {
        public Pessoa Parse(PessoaVO origin)
        {
            if (origin == null) return new Pessoa();
            return new Pessoa
            {
                Id = origin.Id,
                Nome = origin.Nome,
                SobreNome = origin.SobreNome,
                DtNasc = origin.DtNasc,
                Endereco = origin.Endereco,
                Complemento = origin.Complemento,
                Telefone = origin.Telefone,
                Celular = origin.Celular,
                PessoaUserId = origin.PessoaUserId
            };
        }

        public PessoaVO Parse(Pessoa origin)
        {
            if (origin == null) return new PessoaVO();
            return new PessoaVO
            {
               Id = origin.Id,
                Nome = origin.Nome,
                SobreNome = origin.SobreNome,
                DtNasc = origin.DtNasc,
                Endereco = origin.Endereco,
                Complemento = origin.Complemento,
                Telefone = origin.Telefone,
                Celular = origin.Celular,
                PessoaUserId = origin.PessoaUserId
            };
        }

        public List<Pessoa> ParseList(List<PessoaVO> origin)
        {
            if (origin == null) return new List<Pessoa>();
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<PessoaVO> ParseList(List<Pessoa> origin)
        {
            if (origin == null) return new List<PessoaVO>();
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
