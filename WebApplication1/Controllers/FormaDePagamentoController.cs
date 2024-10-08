﻿using AutoMapper;
using Enums;
using FluxoCaixa.Context;
using FluxoCaixa.DTO;
using FluxoCaixa.Enums;
using FluxoCaixa.Interfaces;
using FluxoCaixa.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluxoCaixa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FormaDePagamentoController : ControllerBase
    {
        private readonly FluxoContext _context;
        private readonly IFormaDePagamentoService _service;
        private readonly IMapper _mapper;

        public FormaDePagamentoController(FluxoContext context, IMapper mapper, IFormaDePagamentoService service)
        {
            _context = context;
            _mapper = mapper;
            _service = service;
        }

        // Adiciona uma nova Forma de Pagamento
        [HttpPost("api/adicionarFormaDePagamento")]
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
        [HttpGet("api/recuperarFormaDePagamento")]
        public IActionResult RecuperarFormaDePagamento()
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
        [HttpGet("api/recuperarFormaDePagamentoporId/{id}")]
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

        // Método para atualizar uma forma de pagamento
        [HttpPut("api/atualizarFormaDePagamento/{id}")]
        public async Task<IActionResult> AtualizarFormaDePagamento(int id, [FromBody] UpdateFormaDePagamentoDTO formaDePagamentoDTO)
        {
            if (id <= 0)
            {
                return BadRequest("ID inválido.");
            }

            try
            {
                // Chama o método de serviço para atualizar a forma de pagamento
                var sucesso = await _service.AlterarFormaDePagamento(id, formaDePagamentoDTO);

                if (!sucesso)
                {
                    return NotFound("Forma de pagamento não encontrada.");
                }

                return NoContent(); 
            }
            catch (Exception e)
            {

                return StatusCode(500, $"Erro interno do servidor: {e.Message}");
            }
        }

        // Exclui as Formas de Pagamento
        [HttpDelete("api/excluirFormaDePagamento/{id}")]
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

    
