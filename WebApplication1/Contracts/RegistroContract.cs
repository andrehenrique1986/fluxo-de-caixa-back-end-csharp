using FluxoCaixa.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluxoCaixa.Contracts
{
    public class RegistroContract : ObjectResponse
    {
        public List<Registros> registros { get; set; }
    }
}
