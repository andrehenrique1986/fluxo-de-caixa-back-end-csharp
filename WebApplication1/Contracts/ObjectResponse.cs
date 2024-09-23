using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluxoCaixa.Contracts
{
    public class ObjectResponse 
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
    }
}
