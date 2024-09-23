using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluxoCaixa.Contracts.Models
{
    public class Registros
    {
        public int IdRegistro { get; set; }
        public DateTime DataRegistro { get; set; }
        public int IdCategoria { get; set; }
        public string CategoriaNome { get; set; }
        public int IdSubcategoria { get; set; }
        public string SubcategoriaNome { get; set; }
        public string TipoDeCusto { get; set; }
        public string TipoDeFluxo { get; set; }
        public string FormaDePagamento { get; set; }
        public double Valor { get; set; }
    }
}
