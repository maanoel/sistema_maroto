using LojaVirtual.Model.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaVirtual.Model
{
    [Table("substances")]
    public class Substance : BaseEntity
    {
        [Column("id")]
        public long Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("name_scie")]
        public string NameScientific { get; set; }

        [Column("descricao")]
        public string Description { get; set; }
        
        [Column("composto")]
        public string Composto { get; set; }

        [Column("dt_reg")]
        public DateTime DataRegistro { get; set; }

        [Column("photo")]
        public Byte[] Base64Image { get; set; }
        
    }
}
