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
    public class CategoriaController: ControllerBase
    {
        private  readonly FluxoContext _context;
        private  readonly IMapper _mapper;

        public CategoriaController(FluxoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

      
        // Adiciona uma nova Categoria
        [HttpPost]
        public IActionResult AdicionarCategoria(
            [FromBody] CreateCategoriaDTO categoriaDTO)
        {
            Categoria categoria = _mapper.Map<Categoria>(categoriaDTO);
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperarCategoriasPorId),
                new { id = categoria.IdCategoria },
                categoriaDTO);
        }


        [HttpGet]
        public IActionResult RecuperaCategoria()
        {
            var categorias = _context.Categorias
                .Include(c => c.Subcategorias)
                .Select(c =>
                new
                { Id = c.IdCategoria,
                    Nome = c.DscTipoCategoria,
                    NomeSubcategoria = c.Subcategorias.Select(
                        s => 
                        new { 
                            IdSubcategoria = s.DscTipoSubcategoria })
                    .ToList()
                })
                .ToList();
            if (categorias == null) return NotFound();
            return Ok(categorias); 
        }



        // Recupera todas as Categorias pelo Id
        [HttpGet("{id}")]
        public IActionResult RecuperarCategoriasPorId(int id)
        {
            var categorias = _context.Categorias
                .Include(c => c.Subcategorias)
                .Where(c => c.IdCategoria == id)
                .Select(c =>
                new
                {
                    Id = c.IdCategoria,
                    Nome = c.DscTipoCategoria,
                    Subcategorias = c.Subcategorias.Select(
                        s =>
                        new
                        {
                            Nome = s.DscTipoSubcategoria
                        }).ToList()
                })
                .ToList();
            if (categorias == null) return NotFound();
            return Ok(categorias);
        }

        // Realiza a Alteração das Categorias
        [HttpPut("{id}")]
        public IActionResult AtualizarCategoria(int id, [FromBody] UpdateCategoriaDTO categoriaDto)
        {
            Categoria categoria = _context.Categorias.FirstOrDefault(categoria => categoria.IdCategoria == id);
            if (categoria == null)
            {
                return NotFound();
            }
            _mapper.Map(categoriaDto, categoria);
            _context.SaveChanges();
            return NoContent();
        }

        // Exclui as Categorias
        [HttpDelete("{id}")]
        public IActionResult ExcluirCategoria(int id)
        {
            Categoria categoria = _context.Categorias.FirstOrDefault(c => c.IdCategoria == id);
            if (categoria == null)
            {
                return NotFound();
            }
            _context.Remove(categoria);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
