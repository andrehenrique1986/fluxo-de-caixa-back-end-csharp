using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FluxoCaixa.DTO
{
    public class CreateSubcategoriaDTO
    {
        [Required(ErrorMessage = "A Descrição da Subcategoria é obrigatória")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "A Descrição da Subcategoria deve ter entre 2 e 40 caracteres.")]
        public string DscTipoSubcategoria { get; set; }
        public int IdCategoria { get; set; }
    }
}
