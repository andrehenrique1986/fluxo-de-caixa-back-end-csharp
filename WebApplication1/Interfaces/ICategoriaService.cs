using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluxoCaixa.Interfaces
{
    public interface ICategoriaService
    {
        Task<int> ExcluirCategoriaETodasSubcategorias(int idCategoria);
    }
}
