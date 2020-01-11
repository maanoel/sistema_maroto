using LojaVirtual.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace LojaVirtual.Model
{
    [Table("imovel")]
    public class Imovel : BaseEntity
    {
        //[Column("FirstName")]
       public long? Id { get; set; }
       public string Nome { get; set; }
       public string Endereco { get; set; }
       public string UserId { get; set; }
    }
}
