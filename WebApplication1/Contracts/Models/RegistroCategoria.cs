using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluxoCaixa.Contracts.Models
{
    public class RegistroCategoria : ObjectResponse
    {
        public int CategoriaId { get; set; }
        public string ValorTotalCategoria { get; set; }
    }
}
