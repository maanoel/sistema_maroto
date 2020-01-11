using LojaVirtual.Model.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaVirtual.Model
{
    [Table("comments")]
    public class Comment : BaseEntity
    {
        [Column("com_id")]
        public long Id { get; set; }

        [Column("com_user_id")]
        public int User { get; set; }

        [Column("com_dt_reg")]
        public DateTime DtReg { get; set; }

        [Column("com_texto")]
        public string Texto { get; set; }
        
    }
}
