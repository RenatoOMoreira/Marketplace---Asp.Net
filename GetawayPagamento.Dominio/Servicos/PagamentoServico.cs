using GetawayPagamento.Dominio.Entidades;
using GetawayPagamento.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetawayPagamento.Dominio.Servicos
{
    public class PagamentoServico
    {
        IPagamentoRepositorio pagamentoRepositorio;
        ICartaoRepositorio cartaoRepositorio;
        
        public PagamentoServico(IPagamentoRepositorio pagamentoRepositorio, ICartaoRepositorio cartaoRepositorio)
        {
            this.pagamentoRepositorio = pagamentoRepositorio;
            this.cartaoRepositorio = cartaoRepositorio;
        }
        public void Inserir(Pagamento pagamento) 
        {
            var cartao = cartaoRepositorio.Selecionar(pagamento.Cartao.NumeroCartao);

            if (cartao == null) 
            {
                pagamento.Status = StatusPagamento.CartaoInexistente;
            }

            var pagamentoExistente = pagamentoRepositorio.Selecionar(p => p.NumeroPedido == pagamento.NumeroPedido);

            if (pagamentoExistente.Any()) 
            {
                pagamento.Status = StatusPagamento.PedidoJaPago;
            }

            if (pagamento.Valor > cartao?.LimiteCartao) 
            {
                pagamento.Status = StatusPagamento.SaldoIdisponivel;
            }
            if (pagamento.Status == StatusPagamento.NaoDefinido)
            {
                pagamento.Status = StatusPagamento.PagamentoOk;

                pagamentoRepositorio.Inserir(pagamento); 
            }

           
        }
    }
}
