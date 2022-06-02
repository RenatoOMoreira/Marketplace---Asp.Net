namespace GetawayPagamento.Dominio.Entidades
{
    public class Cartao
    {
        public int Id { get; set; } 
        public string NumeroCartao { get; set; }   
        public decimal LimiteCartao { get; set; }
    }
}
