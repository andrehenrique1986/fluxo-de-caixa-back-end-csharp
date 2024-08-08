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
    [Table("Fluxo")]
    public class Fluxo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int IdFluxo { get; set; }
        [EnumDataType(typeof(EnTipoFluxo))]
        [Required(ErrorMessage = "A Descrição do Fluxo é obrigatória")]
        public EnTipoFluxo TipoFluxo { get; set; }
        public string DscTipoFluxo => TipoFluxo.GetDisplayName();
        public virtual ICollection<Registro> Registros { get; set; }
    }
}
