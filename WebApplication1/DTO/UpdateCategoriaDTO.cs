using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FluxoCaixa.DTO
{
    public class UpdateCategoriaDTO
    {
        [Required(ErrorMessage = "A Descrição da Categoria é obrigatória")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "A Descrição da Subcategoria deve ter entre 2 e 40 caracteres.")]
        public string DscTipoCategoria { get; set; }
    }
}
