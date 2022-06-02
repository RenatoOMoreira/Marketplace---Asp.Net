using GetawayPagamento.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetawayPagamento.Dominio.Interfaces
{
    public interface ICartaoRepositorio
    {
        Cartao Selecionar(string numeroCartao);
    }
}
