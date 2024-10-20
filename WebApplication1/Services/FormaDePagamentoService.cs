using AutoMapper;
using FluxoCaixa.Context;
using FluxoCaixa.DTO;
using FluxoCaixa.Interfaces;
using FluxoCaixa.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluxoCaixa.Services
{
    public class FormaDePagamentoService : IFormaDePagamentoService
    {
        private readonly FluxoContext _context;
        private readonly IMapper _mapper;

        public FormaDePagamentoService(FluxoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        public async Task<bool> AlterarFormaDePagamento(int id, UpdateFormaDePagamentoDTO dto)
        {
            var formaDePagamento = await _context.FormasDePagamento
                .FirstOrDefaultAsync(f => f.IdFormaDePagamento == id);

            if (formaDePagamento == null)
            {
                return false; // Forma de pagamento não encontrada
            }

            _mapper.Map(dto, formaDePagamento); // Atualiza os dados da forma de pagamento
            await _context.SaveChangesAsync(); // Salva as alterações no banco de dados

            return true; // Atualização bem-sucedida
        }

        public Task<bool> AlterarFormaDePagamento(int id, FormaDePagamento novaFormaDePagamento)
        {
            throw new NotImplementedException();
        }

    }
}
