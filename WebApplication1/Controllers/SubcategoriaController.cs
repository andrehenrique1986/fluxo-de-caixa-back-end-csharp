﻿using AutoMapper;
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
<<<<<<< HEAD
    [Route("[controller]")]
=======
    [Route("api/[controller]")]
>>>>>>> a334876b6fb40ec993e9dd28f4c81cfc1bb2be29
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
<<<<<<< HEAD
        [HttpPost("api/adicionarSubcategoria")]
=======
        [HttpPost("adicionarSubcategoria")]
>>>>>>> a334876b6fb40ec993e9dd28f4c81cfc1bb2be29
        public IActionResult AdicionarSubcategoria(
            [FromBody] CreateSubcategoriaDTO subcategoriaDTO)
        {
            try
            {
                Subcategoria subcategoria = _mapper.Map<Subcategoria>(subcategoriaDTO);
                _context.Subcategorias.Add(subcategoria);
                _context.SaveChanges();
                return CreatedAtAction(nameof(RecuperarSubcategoriasPorId),
                    new { id = subcategoria.IdSubcategoria },
                    subcategoria);
            }
            catch (Exception e)
            {

                return StatusCode(500, $"Erro interno do servidor: {e.Message}");
            }
            
        }

<<<<<<< HEAD
        [HttpGet("api/recuperarSubcategoria")]
        public IActionResult RecuperarSubcategoria()
=======
        [HttpGet("recuperarSubcategoria")]
        public IActionResult RecuperaSubcategoria()
>>>>>>> a334876b6fb40ec993e9dd28f4c81cfc1bb2be29
        {
            try
            {
                var subcategorias = _context.Subcategorias
                .Include(s => s.Categoria)
                .Select(s => new
                {
<<<<<<< HEAD
                    IdDaSubcategoria = s.IdSubcategoria,
                    NomeDaSubcategoria = s.DscTipoSubcategoria,
                    NomeDaCategoria = s.Categoria.DscTipoCategoria
=======
                    Id = s.IdSubcategoria,
                    Nome = s.DscTipoSubcategoria,
                    CategoriaNome = s.Categoria.DscTipoCategoria
>>>>>>> a334876b6fb40ec993e9dd28f4c81cfc1bb2be29
                })
                .ToList();
                if (subcategorias == null) return NotFound();
                return Ok(subcategorias);
            }
            catch (Exception e)
            {

                return StatusCode(500, $"Erro interno do servidor: {e.Message}");
            }
            
        }



        // Recupera todas as Categorias pelo Id
<<<<<<< HEAD
        [HttpGet("api/recuperarSubcategoriaPorId/{id}")]
=======
        [HttpGet("recuperarSubcategoriaPorId/{id}")]
>>>>>>> a334876b6fb40ec993e9dd28f4c81cfc1bb2be29
        public IActionResult RecuperarSubcategoriasPorId(int id)
        {
            try
            {
                var subcategorias = _context.Subcategorias
                .Include(s => s.Categoria)
                .Where(s => s.IdSubcategoria == id)
                .Select(s =>
                new {
<<<<<<< HEAD
                    IdDaSubcategoria = s.IdSubcategoria,
                    NomeDaSubcategoria = s.DscTipoSubcategoria,
                    NomeDaCategoria = s.Categoria.DscTipoCategoria
=======
                    s.IdSubcategoria,
                    s.DscTipoSubcategoria,
                    CategoriaNome = s.Categoria.DscTipoCategoria
>>>>>>> a334876b6fb40ec993e9dd28f4c81cfc1bb2be29
                }).ToList();
                if (subcategorias == null) return NotFound();
                return Ok(subcategorias);
            }
            catch (Exception e)
            {

                return StatusCode(500, $"Erro interno do servidor: {e.Message}");
            }
            
        }

        // Realiza a Alteração das Categorias
<<<<<<< HEAD
        [HttpPut("api/atualizarSubcategoria/{id}")]
=======
        [HttpPut("atualizarSubcategoria/{id}")]
>>>>>>> a334876b6fb40ec993e9dd28f4c81cfc1bb2be29
        public IActionResult AtualizarSubcategoria(int id, [FromBody] UpdateSubcategoriaDTO subcategoriaDto)
        {
            try
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
            catch (Exception e)
            {

                return StatusCode(500, $"Erro interno do servidor: {e.Message}");
            }
            
        }

        // Exclui as Categorias
<<<<<<< HEAD
        [HttpDelete("api/excluirSubcategoria/{id}")]
=======
        [HttpDelete("excluirSubcategoria/{id}")]
>>>>>>> a334876b6fb40ec993e9dd28f4c81cfc1bb2be29
        public IActionResult ExcluirSubcategoria(int id)
        {
            try
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
            catch (Exception e)
            {

                return StatusCode(500, $"Erro interno do servidor: {e.Message}");
            }
            
        }
    }
}
