using Enums;
using FluxoCaixa.Enums;
using FluxoCaixa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluxoCaixa.DTO
{
    public class ReadCustoDTO
    {
        public int IdCusto { get; set; }
        public EnTipoCusto TipoCusto { get; set; }
        public string DscTipoCusto => TipoCusto.GetDisplayName();
        public virtual ICollection<Registro> Registros { get; set; }
    }
}
