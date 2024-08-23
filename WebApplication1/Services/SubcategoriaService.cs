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
            // Obtém todas as subcategorias associadas à categoria fornecida
            var subcategorias = await _context.Subcategorias
                .Where(s => s.IdCategoria == idCategoria)
                .ToListAsync();

            if (subcategorias == null || !subcategorias.Any())
            {
                // Nenhuma subcategoria encontrada para a categoria fornecida
                return 0;
            }

            // Remove todas as subcategorias associadas
            _context.Subcategorias.RemoveRange(subcategorias);

            // Salva as alterações no banco de dados
            return await _context.SaveChangesAsync();
        }
    }
}

