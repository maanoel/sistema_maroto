using LojaVirtual.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaVirtual.Model
{
    [Table("reparo")]
    public class Reparo : BaseEntity
    {
         public long? Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string DiaIncidente {get; set; }
        public string DiaConserto {get;set;}
        public string PossuiDebito {get; set;}
    }
}
