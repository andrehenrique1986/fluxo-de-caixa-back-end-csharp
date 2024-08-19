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
        private readonly FluxoContext _context;
        private readonly IMapper _mapper;

        public CategoriaController(FluxoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

      
        // Adiciona uma nova Categoria
        [HttpPost("api/adicionarCategoria")]
        public IActionResult AdicionarCategoria(
            [FromBody] CreateCategoriaDTO categoriaDTO)
        {
            try
            {
                Categoria categoria = _mapper.Map<Categoria>(categoriaDTO);
                _context.Categorias.Add(categoria);
                _context.SaveChanges();
                return CreatedAtAction(nameof(RecuperarCategoriasPorId),
                    new { id = categoria.IdCategoria },
                    categoriaDTO);
            }
            catch (Exception e)
            {

                return StatusCode(500, $"Erro interno do servidor: {e.Message}");
            } 
        }


        [HttpGet("api/recuperarCategoria")]
        public IActionResult RecuperarCategoria()
        {
            try
            {
                var categorias = _context.Categorias
               .Include(c => c.Subcategorias)
               .Select(c =>
               new
               {
                   Id = c.IdCategoria,
                   NomeDaCategoria = c.DscTipoCategoria,
                   NomeDaSubcategoria = c.Subcategorias.Select(
                       s =>
                       new {
                           NomeDaSubcategoria = s.DscTipoSubcategoria
                       })
                   .ToList()
               })
               .ToList();
                if (categorias == null) return NotFound();
                return Ok(categorias);
            }
            catch (Exception e)
            {

                return StatusCode(500, $"Erro interno do servidor: {e.Message}");
            }
        }



        // Recupera todas as Categorias pelo Id
        [HttpGet("api/recuperarCategoriaPorId/{id}")]
        public IActionResult RecuperarCategoriasPorId(int id)
        {
            try
            {
                var categorias = _context.Categorias
                .Include(c => c.Subcategorias)
                .Where(c => c.IdCategoria == id)
                .Select(c =>
                new
                {
                    Id = c.IdCategoria,
                    NomeDaCategoria = c.DscTipoCategoria,
                    NomeDaSubcategoria = c.Subcategorias.Select(
                        s =>
                        new
                        {
                            NomeDaSubcategoria = s.DscTipoSubcategoria
                        }).ToList()
                })
                .ToList();
                if (categorias == null) return NotFound();
                return Ok(categorias);
            }
            catch (Exception e)
            {

                return StatusCode(500, $"Erro interno do servidor: {e.Message}");
            }  
        }

       

        // Realiza a Alteração das Categorias
        [HttpPut("api/atualizarCategoria/{id}")]
        public IActionResult AtualizarCategoria(int id, [FromBody] UpdateCategoriaDTO categoriaDto)
        {
            try
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
            catch (Exception e)
            {

                return StatusCode(500, $"Erro interno do servidor: {e.Message}");
            } 
        }

        // Exclui as Categorias
        [HttpDelete("api/excluirCategoria/{id}")]
        public IActionResult ExcluirCategoria(int id)
        {
            try
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
            catch (Exception e)
            {

                return StatusCode(500, $"Erro interno do servidor: {e.Message}");
            }
        }
    }
}
