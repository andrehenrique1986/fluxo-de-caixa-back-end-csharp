using FluxoCaixa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace FluxoCaixa.Interfaces
{
    public interface IRegistroService
    {
        Task<double> CalcularRegistroPorCategoria(int categoriaId);
        Task<double> CalcularRegistroPorFormaDePagamento(int formaDePagamentoId);
        Task<double> CalcularRegistroPorCusto(int custoId);
        Task<double> CalcularTotalGeral();
        Task<(double entrada, double saida, double saldo)> CalcularRegistroPorFluxo(int idFluxo);
        Task<double> CalcularPorcentagemPorCusto(int custoId);
    }
}
