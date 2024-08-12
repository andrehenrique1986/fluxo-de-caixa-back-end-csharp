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
    [Table("Custo")]
    public class Custo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int IdCusto { get; set; }
        [EnumDataType(typeof(EnTipoCusto))]
        [Required(ErrorMessage = "A Descrição do Custo é obrigatória")]
        public EnTipoCusto TipoCusto { get; set; }
        public string DscTipoCusto => TipoCusto.GetDisplayName();
        public virtual ICollection<Registro> Registros { get; set; }
    }
}
