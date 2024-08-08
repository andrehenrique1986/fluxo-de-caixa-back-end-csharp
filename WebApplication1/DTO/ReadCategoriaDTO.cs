using FluxoCaixa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace FluxoCaixa.DTO
{
    public class ReadCategoriaDTO
    {
        
        public int IdCategoria { get; set; }
        public string DscTipoCategoria { get; set; }
        public virtual ICollection<Subcategoria> Subcategorias { get; set; }
        public virtual ICollection<Registro> Registros { get; set; }

    }
}
