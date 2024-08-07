using FluxoCaixa.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace FluxoCaixa.DTO
{
    public class ReadRegistroDTO
    {
        public int IdRegistro { get; set; }
        public DateTime DtRegistro { get; set; }
        public int IdFluxo { get; set; }
        public int IdCategoria { get; set; }
        public int IdSubcategoria { get; set; }
        public int IdCusto { get; set; }
        public int IdFormaDePagamento { get; set; }
        public double ValorRegistro { get; set; }
    }
}
