using System.ComponentModel;

namespace GetawayPagamento.Dominio.Entidades
{
    public enum StatusPagamento
    {
        [Description("Não definido")]
        NaoDefinido = 0,

        [Description("Saldo indisponível. ")]
        SaldoIdisponivel = 1,

        [Description("Pedido já pago.")]
        PedidoJaPago = 2,

        [Description("Cartão Inexistente")]
        CartaoInexistente = 3,

        [Description("Pagamento Ok")]
        PagamentoOk = 4

    }
}