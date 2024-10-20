using System.Linq;
using System.Threading.Tasks;
using FluxoCaixa.Context;
using FluxoCaixa.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FluxoCaixa.Services
{
    public class SubcategoriaService : ISubcategoriaService
    {
        private readonly FluxoContext _context;

        public SubcategoriaService(FluxoContext context)
        {
            _context = context;
        }

        public async Task<int> ExcluirSubcategoriaPorCategoria(int idCategoria)
        {
            
            var subcategorias = await _context.Subcategorias
                .Where(s => s.IdCategoria == idCategoria)
                .ToListAsync();

            
            _context.Subcategorias.RemoveRange(subcategorias);

            
            return await _context.SaveChangesAsync();
        }
    }
}

