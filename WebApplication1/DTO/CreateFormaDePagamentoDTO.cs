using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FluxoCaixa.DTO
{
	public class CreateFormaDePagamentoDTO
	{
		[Required(ErrorMessage = "A Descrição da Forma de Pagamento é obrigatória")]
		public string TipoFormaDePagamento { get; set; }
	}
}
