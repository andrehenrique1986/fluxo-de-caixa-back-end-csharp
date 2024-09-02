using FluxoCaixa.Context;
using FluxoCaixa.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FluxoCaixa.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly FluxoContext _context;

        public CategoriaService(FluxoContext context)
        {
            _context = context;
        }

        public async Task<int> ExcluirCategoriaETodasSubcategorias(int idCategoria)
        {
            // Obter a categoria com suas subcategorias
            var categoria = await _context.Categorias
                .Include(c => c.Subcategorias)
                .SingleOrDefaultAsync(c => c.IdCategoria == idCategoria);

            // Se a categoria não for encontrada, retornar 0
            if (categoria == null)
            {
                return 0;
            }

            // Remover as subcategorias associadas
            if (categoria.Subcategorias.Any())
            {
                _context.Subcategorias.RemoveRange(categoria.Subcategorias);
            }

            // Remover a categoria
            _context.Categorias.Remove(categoria);

            // Salvar as mudanças e retornar o número de registros afetados
            return await _context.SaveChangesAsync();
        }
    }
}

