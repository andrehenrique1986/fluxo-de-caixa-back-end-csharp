using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Enums
{
    
    public enum EnTipoFluxo
    {
        [Display(Name = "Entrada")]
        ENTRADA = 0,

        [Display(Name = "Saída")]
        SAIDA = 1

    }

    public enum EnTipoCusto
    {
        [Display(Name = "Fixo")]
        FIXO = 0,

        [Display(Name = "Variável")]
        VARIAVEL = 1
    }


    
}


