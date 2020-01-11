using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace LojaVirtual.Model.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public long? Id { get; set; }
    }
}
