using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Enums
{
    
    public enum EnTipoFluxo
    {
        [Display(Name = "Entrada")]
        ENTRADA = 1,

        [Display(Name = "Saída")]
        SAIDA = 2

    }

    public enum EnTipoCusto
    {
        [Display(Name = "Fixo")]
        FIXO = 1,

        [Display(Name = "Variável")]
        VARIAVEL = 2
    }


    
}


