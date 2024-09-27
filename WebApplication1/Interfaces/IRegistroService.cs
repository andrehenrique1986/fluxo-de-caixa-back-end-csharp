using FluxoCaixa.DTO;
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
        Task<bool> AddRegistro(CreateRegistroDTO dto);
        Task<double> CalcularRegistroPorCategoria(int categoriaId);
        Task<double> CalcularRegistroPorFormaDePagamento(int formaDePagamentoId);
        Task<double> CalcularRegistroPorCusto(int custoId);
        Task<double> CalcularTotalGeral();
        Task<RegistroPorFluxoDTO> CalcularRegistroPorFluxo(int idFluxo);
        Task<double> CalcularPorcentagemPorCusto(int custoId);
        //Task<double> CalcularPorcentagemCustos();
    }
}
