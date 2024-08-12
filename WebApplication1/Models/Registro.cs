using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace FluxoCaixa.Models
{
	[Table("Registro")]
    public class Registro
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Required]
		public int IdRegistro { get; set; }
		[Required(ErrorMessage = "A data deverá ser preenchida")]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
		[Range(typeof(DateTime), "01/01/2000", "31/12/2099", ErrorMessage = "A data deve estar entre 01/01/2000 e 31/12/2099.")]
		public DateTime DtRegistro { get; set; }
		public int IdFluxo { get; set; }
		public virtual Fluxo Fluxo { get; set; }
		public int IdCategoria { get; set; }
		public virtual Categoria Categoria { set; get; }
		public int IdSubcategoria { get; set; }
		public virtual Subcategoria Subcategoria { set; get; }
		public int IdCusto { get; set; }
		public virtual Custo Custo { set; get; }
		public int IdFormaDePagamento { get; set; }
		public virtual FormaDePagamento FormaDePagamento { set; get; }
		[Required(ErrorMessage = "O valor deverá ser preenchido")]
		[Range(0, double.MaxValue, ErrorMessage = "O Valor deverá ser maior ou igual a zero")]
		public double ValorRegistro { get; set; }
	}
}
