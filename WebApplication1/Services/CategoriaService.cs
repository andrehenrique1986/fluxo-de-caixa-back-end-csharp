using FluxoCaixa.Context;
using FluxoCaixa.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluxoCaixa.Services
{
    public class CategoriaService: ICategoriaService
    {
        private readonly FluxoContext _context;

        public CategoriaService(FluxoContext context)
        {
            _context = context;
        }

        public async Task<int> ExcluirCategoriaETodasSubcategorias(int idCategoria)
        {
            var categorias = await _context.Categorias
                .Include(c => c.Subcategorias)
                .SingleOrDefaultAsync(c => c.IdCategoria == idCategoria);

            if (categorias == null)
            {
                return 0;
            }

            _context.Subcategorias.RemoveRange(categorias.Subcategorias);

            _context.Categorias.Remove(categorias);

            return await _context.SaveChangesAsync();
        }
    }
}
