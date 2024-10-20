using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluxoCaixa.Interfaces
{
    public interface ISubcategoriaService
    {
        Task<int> ExcluirSubcategoriaPorCategoria(int idCategoria);

    }
}
