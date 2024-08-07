using Enums;
using FluxoCaixa.Enums;
using FluxoCaixa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluxoCaixa.DTO
{
    public class ReadFormaDePagamentoDTO
    {
        
        public int IdFormaDePagamento { get; set; }
        public string TipoFormaDePagamento { get; set; }
        public virtual ICollection<Registro> Registros { get; set; }
    }
}
