using System;
using System.ComponentModel.DataAnnotations.Schema;
using LojaVirtual.Model.Base;

namespace LojaVirtual.Model
{
    [Table("Product")]
    public class Product : BaseEntity
    {
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public string Categoria { get; set; }
        public double Peso { get; set; }
        public string Cor { get; set; }
        public string Medida { get; set; }
        public int Quantidade { get; set; }
        public byte[] Image { get; set; }
        public byte[] Image_2 { get; set; }
        public byte[] Image_3 { get; set; }
        public byte[] Image_4 { get; set; }
        public byte[] Image_5 { get; set; }
    }
}
