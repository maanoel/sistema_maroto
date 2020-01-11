using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using LojaVirtual.Model;
using LojaVirtual.Model.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LojaVirtual.Model
{
    [Table("Carrinho")]
    public class Carrinho : BaseEntity
    {
        public List <ItemCarrinho> ItensCarrinho {get;set;}
        
        [Column("user_id")]
        public int UserId { get; set; }
    
        public double Total = 0.0;
        public  double Frete = 0.0;
        
        [Column("end_bairro")]
        public String EndBairro{get; set;}

        [Column("end_rua")]
        public String EndRua {get;set;}
        
        [Column("end_numero")]
        public int EndNumero {get;set;}

         [Column("end_cep")]
        public String EndCep {get;set;}

        
        [Column("end_complemento")]
        public String EndComplemento{get;set;}

        [Column("end_cidade")]
        public String EndCidade {get;set;}
        
        [Column("end_estado")]
        public String EndEstado {get;set;}
        
    }
}