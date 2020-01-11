using LojaVirtual.Model.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaVirtual.Model
{
    [Table("users")]
    public class User : BaseEntity
    {
        
        public string Login { get; set; }
        public string AccessKey { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public String Email {get;set; }
        
    }
}
