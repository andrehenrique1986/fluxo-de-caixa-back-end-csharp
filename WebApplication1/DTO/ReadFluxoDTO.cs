using Enums;
using FluxoCaixa.Enums;
using FluxoCaixa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluxoCaixa.DTO
{
    public class ReadFluxoDTO
    { 
        public int IdFluxo { get; set; }
        public EnTipoFluxo TipoFluxo { get; set; }
        public string DscTipoFluxo => TipoFluxo.GetDisplayName();
        public virtual ICollection<Registro> Registros { get; set; }
    }
}
