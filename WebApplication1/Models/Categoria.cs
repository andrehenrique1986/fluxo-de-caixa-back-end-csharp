using FluxoCaixa.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    [Table("Categoria")]
    public class Categoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int IdCategoria { get; set; }
        [Required(ErrorMessage = "A Descrição da Categoria é obrigatória")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "A Descrição da Subcategoria deve ter entre 2 e 40 caracteres.")]
        public string DscTipoCategoria { get; set; }
        public virtual ICollection<Subcategoria> Subcategorias { get; set; }
        public virtual ICollection<Registro> Registros { get; set; }

    }
}
