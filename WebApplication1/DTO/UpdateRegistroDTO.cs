using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FluxoCaixa.DTO
{
    public class UpdateRegistroDTO
    {
		[Required(ErrorMessage = "A data deverá ser preenchida")]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
		[Range(typeof(DateTime), "01/01/2000", "31/12/2099", ErrorMessage = "A data deve estar entre 01/01/2000 e 31/12/2099.")]
		public DateTime DtRegistro { get; set; }
		public int IdFluxo { get; set; }
		public int IdCategoria { get; set; }
		public int IdSubcategoria { get; set; }
		public int IdCusto { get; set; }
		public int IdFormaDePagamento { get; set; }
		[Required(ErrorMessage = "O valor deverá ser preenchido")]
		[Range(0, double.MaxValue, ErrorMessage = "O Valor deverá ser maior ou igual a zero")]
		public double ValorRegistro { get; set; }
	}
}
