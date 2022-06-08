using System;

namespace GetawayPagamento.Dominio.Entidades
{
    public class Cartao
    {
        public int Id { get; set; } 
        public Guid Guid { get; set; } = Guid.NewGuid();
        public string NumeroCartao { get; set; }   
        public decimal LimiteCartao { get; set; }
    }
}
