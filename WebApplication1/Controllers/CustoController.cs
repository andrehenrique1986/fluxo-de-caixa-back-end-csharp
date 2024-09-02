using AutoMapper;
using Enums;
using FluxoCaixa.Context;
using FluxoCaixa.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluxoCaixa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustoController: ControllerBase
    {
       
        // Recupera os Tipos de Custo
        [HttpGet("api/recuperarCusto")]
        public IActionResult RecuperarCusto()
        {
            try
            {
                var custo = Enum.GetValues(typeof(EnTipoCusto))
                .Cast<EnTipoCusto>()
                .Select(c => new { Id = (int)c, Nome = c.GetDisplayName() })
                .ToList();
                return Ok(custo);
            }
            catch (Exception e)
            {

                return StatusCode(500, $"Erro interno do servidor: {e.Message}");
            }
        }

        // Recupera os Custos pelo id
        [HttpGet("api/recuperarCustoPorId/{id}")]
        public IActionResult RecuperarCustosPorId(int id)
        {
            try
            {
                var custo = Enum.GetValues(typeof(EnTipoCusto))
                .Cast<EnTipoCusto>()
                .Select(c => new { Id = (int)c, Nome = c.GetDisplayName() })
                .Where(c => c.Id == id)
                .ToList();

                if (custo == null || custo.Count == 0)
                {
                    return NotFound("Nenhum custo encontrado para o tipo especificado.");
                }
                return Ok(custo);
            }
            catch (Exception e)
            {

                return StatusCode(500, $"Erro interno do servidor: {e.Message}");
            }     
        }
    }
}
