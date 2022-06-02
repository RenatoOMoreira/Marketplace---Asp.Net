using GetawayPagamento.Dominio.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GatewayPagamento.Repositorios.SqlServer.CodeFirst.Tests
{
    [TestClass()]
    public class GatewayPagamentoDbContextTests
    {
        [TestMethod()]
        public void InserirCartaoTeste()
        {
            var contexto = new GatewayPagamentoDbContext();
            contexto.Cartoes.Add(new Cartao {NumeroCartao = "1234123412341234", LimiteCartao= 1000 });
            contexto.SaveChanges();
        }
    }
}