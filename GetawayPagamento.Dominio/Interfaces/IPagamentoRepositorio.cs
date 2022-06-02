using GetawayPagamento.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GetawayPagamento.Dominio.Interfaces
{
    public interface IPagamentoRepositorio
    {
        void Inserir(Pagamento pagamento);
        List<Pagamento> Selecionar(string numeroCartao);
        List<Pagamento> Selecionar(Expression<Func<Pagamento, bool>> condicao);
    }
}
