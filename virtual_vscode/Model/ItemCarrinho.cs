using System;
using System.ComponentModel.DataAnnotations.Schema;
using LojaVirtual.Model;
using LojaVirtual.Model.Base;

namespace LojaVirtual.Model
{
    [Table("ItemCarrinho")]
    public class ItemCarrinho : BaseEntity
    {
        [Column("product_id")]
        public int ProductId {get; set;}

        [Column("quantidade")]        
        public int Quantidade { get; set; }
        
        [ForeignKey("Carrinho")]
        [Column("carrinho_id")] 
        public long? CarrinhoId{get; set;}
        public Carrinho Carrinho {get;set;}
        
    }
}