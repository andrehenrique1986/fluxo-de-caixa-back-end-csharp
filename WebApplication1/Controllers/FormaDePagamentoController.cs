﻿using AutoMapper;
using Enums;
using FluxoCaixa.Context;
using FluxoCaixa.DTO;
using FluxoCaixa.Enums;
using FluxoCaixa.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluxoCaixa.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FormaDePagamentoController : ControllerBase
    {
        private readonly FluxoContext _context;
        private readonly IMapper _mapper;
        public FormaDePagamentoController(FluxoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Adiciona uma nova Forma de Pagamento
        [HttpPost("adicionarFormaDePagamento")]
        public IActionResult AdicionarFormaDePagemanto(
            [FromBody] CreateFormaDePagamentoDTO formaDePagamentoDTO)
        {
            try
            {
                FormaDePagamento formaDePagamento = _mapper.Map<FormaDePagamento>(formaDePagamentoDTO);
                _context.FormasDePagamento.Add(formaDePagamento);
                _context.SaveChanges();
                return CreatedAtAction(nameof(RecuperarFormasDePagamentoPorId),
                    new { id = formaDePagamento.IdFormaDePagamento },
                    formaDePagamento);
            }
            catch (Exception e)
            {

                return StatusCode(500, $"Erro interno do servidor: {e.Message}");
            } 
        }



        // Recupera os Tipos de Forma de pagamento
        [HttpGet("recuperarFormaDePagamento")]
        public IActionResult RecuperaFormaDePagamento()
        {
            try
            {
                var formaDePagamento = _context.FormasDePagamento
                   .Select(f => new
            {
                Id = f.IdFormaDePagamento,
                Nome = f.TipoFormaDePagamento
                  }).ToList();
                return Ok(formaDePagamento);
            }
            catch (Exception e)
            {

                return StatusCode(500, $"Erro interno do servidor: {e.Message}");
            }
        }

        // Recupera as Formas de Pagamento pelo id
        [HttpGet("recuperarFormaDePagamentoPorId/{id}")]
        public IActionResult RecuperarFormasDePagamentoPorId(int id)
        {
            try
            {
                var formaDePagamento = _context.FormasDePagamento
               .Where(f => f.IdFormaDePagamento == id)
               .Select(c => new
                {
                  Id = c.IdFormaDePagamento,
                  Nome = c.TipoFormaDePagamento
                 }).ToList();

                if (formaDePagamento == null || formaDePagamento.Count == 0)
                {
                    return NotFound("Nenhuma forma de pagamento encontrado para o tipo especificado.");
                }
                return Ok(formaDePagamento);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Erro interno do servidor: {e.Message}");
            }
                
        }

        // Realiza a Alteração das Categorias
        [HttpPut("atualizarFormaDePagamento/{id}")]
        public IActionResult AtualizarFormaDePagamento(int id, [FromBody] UpdateFormaDePagamentoDTO formaDePagamentoDTO)
        {
            try
            {
                FormaDePagamento formaDePagamento = _context.FormasDePagamento.FirstOrDefault(f => f.IdFormaDePagamento == id);
                if (formaDePagamento == null)
                {
                    return NotFound();
                }
                _mapper.Map(formaDePagamentoDTO, formaDePagamento);
                _context.SaveChanges();
                return NoContent();
            }
            catch (Exception e)
            {

                return StatusCode(500, $"Erro interno do servidor: {e.Message}");
            }
            
        }

        // Exclui as Categorias
        [HttpDelete("excluirFormaDePagamento/{id}")]
        public IActionResult ExcluirFormaDePagamento(int id)
        {
            try
            {
                FormaDePagamento formaDePagamento = _context.FormasDePagamento.FirstOrDefault(f => f.IdFormaDePagamento == id);
                if (formaDePagamento == null)
                {
                    return NotFound();
                }
                _context.Remove(formaDePagamento);
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
    
