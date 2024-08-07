using Enums;
using FluxoCaixa.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FluxoCaixa.Models
{
    [Table("FormaDePagamento")]
    public class FormaDePagamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int IdFormaDePagamento { get; set; }
        [Required(ErrorMessage = "A Descrição da Forma de Pagamento é obrigatória")]
        public string TipoFormaDePagamento { get; set; }
        public virtual ICollection<Registro> Registros { get; set; }
    }
}
