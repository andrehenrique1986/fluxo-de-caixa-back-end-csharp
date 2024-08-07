using FluxoCaixa.Context;
using FluxoCaixa.Interfaces;
using FluxoCaixa.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;

namespace FluxoCaixa.Services
{
    public class RegistroService : IRegistroService
    {
        private readonly FluxoContext _context;
        

        public RegistroService(FluxoContext context)
        {
            _context = context;
        }

        
        public async Task<double> CalcularRegistroPorCategoria(int categoriaId)
        {

            var registros = await _context.Registros
                .Where(c => c.IdCategoria == categoriaId)
                .SumAsync(r => r.ValorRegistro);
            return registros;

        }

        public async Task<double> CalcularRegistroPorFormaDePagamento(int formaDePagamentoId)
        {
            var registros = await _context.Registros
                .Where(fpag => fpag.IdFormaDePagamento == formaDePagamentoId)
                .SumAsync(r => r.ValorRegistro);
            return registros;
        }

        public async Task<double> CalcularRegistroPorCusto(int custoId)
        {
            return await _context.Registros
                .Where(c => c.IdCusto == custoId)
                .SumAsync(r => r.ValorRegistro);

        }

        public async Task<double> CalcularTotalGeral()
        {
            return await _context.Registros
                .SumAsync(r => r.ValorRegistro);
        }


        public async Task<double> CalcularPorcentagemPorCusto(int custoId)
        {
            var totalCusto = await CalcularRegistroPorCusto(custoId);
            var totalRegistros = await CalcularTotalGeral();

           

            if (totalRegistros == 0)
            {
                throw new InvalidOperationException("Não é possível calcular a porcentagem com total de registros igual a zero.");
            }

            var porcentagem = (totalCusto / totalRegistros) * 100;

            return porcentagem;
        }

        public async Task<(double entrada, double saida, double saldo)> CalcularRegistroPorFluxo(int idFluxo)
        {
            double entrada = 0;
            double saida = 0;
            

            entrada = await _context.Registros
                .Where(f => f.IdFluxo == 1)
                .SumAsync(r => r.ValorRegistro);

            saida = await _context.Registros
                .Where(f => f.IdFluxo == 2)
                .SumAsync(r => r.ValorRegistro);

            double saldo = entrada - saida;

            return (entrada, saida, saldo);
        }
    }
}
