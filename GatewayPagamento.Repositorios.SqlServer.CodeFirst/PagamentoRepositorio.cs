using GetawayPagamento.Dominio.Entidades;
using GetawayPagamento.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace GatewayPagamento.Repositorios.SqlServer.CodeFirst
{
    public class PagamentoRepositorio : IPagamentoRepositorio
    {
        public void Inserir(Pagamento pagamento)
        { 
            using(var contexto = new GatewayPagamentoDbContext())
            {
                pagamento.Cartao = contexto.Cartoes.SingleOrDefault(c => c.NumeroCartao == pagamento.Cartao.NumeroCartao);  

                contexto.Pagamentos.Add(pagamento);
                contexto.SaveChanges();
            }
        }
        public List<Pagamento> Selecionar(Expression<Func<Pagamento, bool>> condicao)
        {
            using (var contexto = new GatewayPagamentoDbContext())
            {
                return contexto.Pagamentos
                    .Where(condicao)
                    .ToList();
            }
        }

        public List<Pagamento> Selecionar(string numeroCartao)
        {
            using (var contexto = new GatewayPagamentoDbContext())
            {
                return contexto.Pagamentos
                    //.Include(Cartao)
                    .Include(p => p.Cartao)
                    .Where(p => p.Cartao.NumeroCartao == numeroCartao)
                    .ToList();
            }
        }
    }
}
