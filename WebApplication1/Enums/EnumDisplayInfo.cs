using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluxoCaixa.Enums
{
    public class EnumDisplayInfo<T>
    {
        public T Value { get; set; }
        public string DisplayName { get; set; }
    }
}
