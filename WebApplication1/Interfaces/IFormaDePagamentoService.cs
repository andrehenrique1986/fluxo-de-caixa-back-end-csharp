using FluxoCaixa.DTO;
using FluxoCaixa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluxoCaixa.Interfaces
{
    public interface IFormaDePagamentoService
    {
        Task<bool> AlterarFormaDePagamento(int id, UpdateFormaDePagamentoDTO dto);
        
    }
}
