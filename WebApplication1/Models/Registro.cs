using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Models;

namespace FluxoCaixa.Models
{
    [Table("Registro")]
    public class Registro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRegistro { get; set; }

        [Required(ErrorMessage = "A data deverá ser preenchida")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "01/01/2000", "31/12/2099", ErrorMessage = "A data deve estar entre 01/01/2000 e 31/12/2099.")]
        public DateTime DtRegistro { get; set; }

        [Required]
        public int IdFluxo { get; set; }
        [ForeignKey("IdFluxo")]
        public virtual Fluxo Fluxo { get; set; }

        [Required]
        public int IdCategoria { get; set; }
        [ForeignKey("IdCategoria")]
        public virtual Categoria Categoria { get; set; }

        [Required]
        public int IdSubcategoria { get; set; }
        [ForeignKey("IdSubcategoria")]
        public virtual Subcategoria Subcategoria { get; set; }

        [Required]
        public int IdCusto { get; set; }
        [ForeignKey("IdCusto")]
        public virtual Custo Custo { get; set; }

        [Required]
        public int IdFormaDePagamento { get; set; }
        [ForeignKey("IdFormaDePagamento")]
        public virtual FormaDePagamento FormaDePagamento { get; set; }

        [Required(ErrorMessage = "O valor deverá ser preenchido")]
        [Range(0, double.MaxValue, ErrorMessage = "O Valor deverá ser maior ou igual a zero")]
        public double ValorRegistro { get; set; }
    }
}
