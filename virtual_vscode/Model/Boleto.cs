using LojaVirtual.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace LojaVirtual.Model
{
    [Table("boleto")]
    public class Boleto : BaseEntity
    {
        //[Column("FirstName")]
        //[Column("FirstName")]
        public long? Id { get; set; }
        public string Matricula { get; set; }
        public string Local { get; set; }
        public DateTime DtRef { get; set; }
        public DateTime DtVenc { get; set; }
        public float Servico1 { get; set; }
        public float Servico2 { get; set; }
        public float Servico3 { get; set; }
        public float Total { get; set; }
        public int ImovelId { get; set; }
    }

/*
matricula varchar(255),
local varchar(255),
digitoLocal varchar(255),
nome varchar(255),
endereco varchar(255),
dtRef datetime,
dtVenc datetime
servico1 float,
servico2 float,
total float,
*/
}
