using LojaVirtual.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace LojaVirtual.Model
{
    [Table("pessoa")]
    public class Pessoa : BaseEntity
    {
        //[Column("FirstName")]
        public long? Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public DateTime DtNasc { get; set; }
        public string Endereco { get; set; }
        public string Complemento { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        [Column("UserId")]
        public string PessoaUserId { get; set; }
    }
}
