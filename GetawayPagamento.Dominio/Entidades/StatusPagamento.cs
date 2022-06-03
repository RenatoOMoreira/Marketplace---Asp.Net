using System.ComponentModel;

namespace GetawayPagamento.Dominio.Entidades
{
    public enum StatusPagamento
    {
        SaldoIdisponivel = 1,
        PedidoJaPago = 2,

        [Description("Cartão Inexistente")]
        CartaoInexistente = 3,

        [Description("Pagamento Ok")]
        PagamentoOk = 4

    }
}