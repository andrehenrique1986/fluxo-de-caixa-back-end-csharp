using AutoMapper;
using FluxoCaixa.Context;
using FluxoCaixa.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace FluxoCaixa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubcategoriaController: ControllerBase
    {
        private readonly FluxoContext _context;
        private readonly IMapper _mapper;

        public SubcategoriaController(FluxoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Adiciona uma nova Subcategoria
        [HttpPost]
        public IActionResult AdicionarSubcategoria(
            [FromBody] CreateSubcategoriaDTO subcategoriaDTO)
        {
            Subcategoria subcategoria = _mapper.Map<Subcategoria>(subcategoriaDTO);
            _context.Subcategorias.Add(subcategoria);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperarSubcategoriasPorId),
                new { id = subcategoria.IdSubcategoria},
                subcategoria);
        }

        [HttpGet]
        public IActionResult RecuperaSubcategoria()
        {
            var subcategorias = _context.Subcategorias
                .Include(s => s.Categoria)
                .Select(s => new 
                { Id = s.IdSubcategoria, 
                    Nome = s.DscTipoSubcategoria,
                    CategoriaNome = s.Categoria.DscTipoCategoria 
                })
                .ToList();
            if (subcategorias == null) return NotFound();
            return Ok(subcategorias);
        }



        // Recupera todas as Categorias pelo Id
        [HttpGet("{id}")]
        public IActionResult RecuperarSubcategoriasPorId(int id)
        {
            var subcategorias = _context.Subcategorias
                .Include(s => s.Categoria)
                .Where(s => s.IdSubcategoria == id)
                .Select(s => 
                new { 
                    s.IdSubcategoria, 
                    s.DscTipoSubcategoria, 
                    CategoriaNome = s.Categoria.DscTipoCategoria
                }).ToList();
            if (subcategorias == null) return NotFound();
            return Ok(subcategorias);
        }

        // Realiza a Alteração das Categorias
        [HttpPut("{id}")]
        public IActionResult AtualizarSubcategoria(int id, [FromBody] UpdateSubcategoriaDTO subcategoriaDto)
        {
            Subcategoria subcategoria = _context.Subcategorias.FirstOrDefault(subcategoria => subcategoria.IdSubcategoria == id);
            if (subcategoria == null)
            {
                return NotFound();
            }
            _mapper.Map(subcategoriaDto, subcategoria);
            _context.SaveChanges();
            return NoContent();
        }

        // Exclui as Categorias
        [HttpDelete("{id}")]
        public IActionResult ExcluirSubcategoria(int id)
        {
            Subcategoria subcategoria = _context.Subcategorias.FirstOrDefault(s => s.IdSubcategoria == id);
            if (subcategoria == null)
            {
                return NotFound();
            }
            _context.Remove(subcategoria);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
