using Tapioca.HATEOAS;
using System.Collections.Generic;
using LojaVirtual.Model.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaVirtual.Model
{
    public class CommentVO
    {
        [Column("Id")]
        public long Id {get; set;}
        [Column("com_user_id")]
        public int User { get; set; }
        [Column("com_dt_reg")]
        public DateTime DtReg { get; set; }
        [Column("com_texto")]
        public string Texto {get;set;}
        
    }
}
