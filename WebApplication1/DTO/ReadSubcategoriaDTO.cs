using FluxoCaixa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace FluxoCaixa.DTO
{
    public class ReadSubcategoriaDTO
    {
        public int IdSubcategoria { get; set; }
        public string DscTipoSubcategoria { get; set; }
        public int IdCategoria { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual ICollection<Registro> Registros { get; set; }
    }
}
